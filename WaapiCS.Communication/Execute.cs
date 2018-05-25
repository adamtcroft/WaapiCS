using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using WampSharp.Core.Serialization;
using WampSharp.V2;
using WampSharp.V2.Client;
using WampSharp.V2.Core.Contracts;
using WampSharp.V2.Rpc;
using System.Threading;
using SystemEx;

namespace WaapiCS.Communication
{
    public partial class Connection
    {
        /// <summary>
        /// Sends the specified JSON packet to Wwise, executing the corresponding one-off command.
        /// </summary>
        /// <param name="packet">The JSON packet.</param>
        /// <returns></returns>
        public dynamic Execute(Packet packet)
        {
            CallWwise(packet.callback, packet.options, packet.procedure, packet.keywordArguments);
            return packet.results;
        }

        /// <summary>
        /// Makes the call to Wwise.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="options">The return options.</param>
        /// <param name="procedure">The specified Wwise procedure.</param>
        /// <param name="keywordArguments">The arguments to send Wwise.</param>
        private void CallWwise(Callback callback, WAAPICallOptions options, string procedure, IDictionary<string, object> keywordArguments)
        {
            realmProxy.RpcCatalog.Invoke
                    (
                    callback,
                    options,
                    procedure,
                    new object[] { },
                    keywordArguments
                    );
            eventQueue.WaitOne();
        }


        /// <summary>
        /// Connects the specified JSON subscription with Wwise.
        /// </summary>
        /// <param name="subscription">The JSON subscription.</param>
        /// <returns></returns>
        public dynamic Execute(Subscriber subscription)
        {
            subscription.callback = new SubscriptionCallback(subscription);
            topicProxy = channel.RealmProxy.TopicContainer.GetTopicByUri(subscription.procedure);
            SubscribeToWwise(subscription.callback, subscription.options, subscription.unsubscribeDisposable);

            return subscription.results;
        }

        /// <summary>
        /// Subscribes to a topic in Wwise.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="options">The return options.</param>
        /// <param name="unsubscribeDisposable">The unsubscribe mechanism of the subscriber.</param>
        private void SubscribeToWwise(SubscriptionCallback callback, SubscribeOptions options, IAsyncDisposable unsubscribeDisposable)
        {
            topicProxy.Subscribe(
                callback,
                options)
                .ContinueWith(t => unsubscribeDisposable = t.Result)
                .Wait();
            eventQueue.WaitOne();
        }
    }
}
