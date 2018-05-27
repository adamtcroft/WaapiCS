using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using WampSharp.Core.Serialization;
using WampSharp.V2;
using WampSharp.V2.Client;
using WampSharp.V2.Core.Contracts;
using WampSharp.V2.PubSub;
using WampSharp.V2.Rpc;

namespace WaapiCS.Communication
{
    /// <summary>
    /// The callback for one-off events.
    /// </summary>
    /// <seealso cref="WampSharp.V2.Rpc.IWampRawRpcOperationClientCallback" />
    public class Callback : IWampRawRpcOperationClientCallback
    {
        /// <summary>
        /// A scoped JSON packet instance
        /// </summary>
        protected Packet _packet;

        /// <summary>
        /// Initializes a new instance of the one-off <see cref="Callback"/> class.
        /// </summary>
        /// <param name="packet">The JSON packet.</param>
        /// <exception cref="ArgumentNullException">Packet given to Callback cannot be null!</exception>
        public Callback(Packet packet)
        {
            _packet = packet ?? throw new ArgumentNullException("Packet given to Callback cannot be null!");
        }

        /// <summary>
        /// The results returned from Wwise.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="formatter">The formatter.</param>
        /// <param name="details">The details.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="argumentsKeywords">The arguments keywords.</param>
        public virtual void Result<TMessage>(IWampFormatter<TMessage> formatter, ResultDetails details, TMessage[] arguments, IDictionary<string, TMessage> argumentsKeywords)
        {
            Console.WriteLine("Procedure " + _packet.procedure + " executed.");

            if (argumentsKeywords.Count == 1)
            {
                _packet.results = new List<Dictionary<string, object>>();
                foreach (var value in argumentsKeywords.Values)
                {
                    foreach (JObject jsonObject in formatter.Deserialize<JToken>(value))
                    {
                        Dictionary<string, object> results = new Dictionary<string, object>();
                        foreach (KeyValuePair<string, JToken> pair in jsonObject)
                        {
                            results[pair.Key] = pair.Value;
                        }
                        _packet.results.Add(results);
                    }
                }
            }
            else
            {
                _packet.results = new Dictionary<string, object>();
                foreach (string key in argumentsKeywords.Keys)
                {
                    dynamic value = argumentsKeywords[key];
                    if (value.Type == JTokenType.Array)
                    {
                        value = formatter.Deserialize<object>(value);
                        _packet.results[key] = value;
                    }
                    else
                    {
                        _packet.results[key] = value.Value;
                    }
                }
            }

            // Allow the application to continue
            SetResetEventQueue();
        }

        // Other method overloads are never used: WAAPI always sends keyword arguments
        public void Error<TMessage>(IWampFormatter<TMessage> formatter, TMessage details, string error, TMessage[] arguments, TMessage argumentsKeywords) { }
        public void Error<TMessage>(IWampFormatter<TMessage> formatter, TMessage details, string error) { }
        public void Error<TMessage>(IWampFormatter<TMessage> formatter, TMessage details, string error, TMessage[] arguments) { }
        public void Result<TMessage>(IWampFormatter<TMessage> formatter, ResultDetails details) { }
        public void Result<TMessage>(IWampFormatter<TMessage> formatter, ResultDetails details, TMessage[] arguments) { }

        /// <summary>
        /// Sets and then Resets the eventQueue
        /// </summary>
        public void SetResetEventQueue()
        {
            Connection.eventQueue.Set();
            Connection.eventQueue.Reset();
        }
    }

    /// <summary>
    /// The callback for subscribed events.
    /// </summary>
    /// <seealso cref="WampSharp.V2.PubSub.IWampRawTopicClientSubscriber" />
    public class SubscriptionCallback : IWampRawTopicClientSubscriber
    {

        /// <summary>
        /// A scoped JSON subscriber instance.
        /// </summary>
        private Subscriber _subscriber;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionCallback"/> class.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        public SubscriptionCallback(Subscriber subscriber)
        {
            _subscriber = subscriber;
        }

        /// <summary>
        /// Occurs when an event previously subscribed to is fired in Wwise. 
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="formatter">A formatter that can be used to deserialize event arguments.</param>
        /// <param name="publicationId">The publication id of the incoming publication.</param>
        /// <param name="details">The details about this publication.</param>
        /// <param name="arguments">The arguments of this publication.</param>
        /// <param name="argumentsKeywords">The arguments keywords of this publication.</param>
        public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments, IDictionary<string, TMessage> argumentsKeywords)
        {
            _subscriber.results = (Dictionary<string, object>)argumentsKeywords;
            Connection.eventQueue.Set();
            Connection.eventQueue.Reset();
        }

        // Other method overloads are never used: WAAPI always sends keyword arguments
        public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details) { }
        public void Event<TMessage>(IWampFormatter<TMessage> formatter, long publicationId, EventDetails details, TMessage[] arguments) { }
    }
}
