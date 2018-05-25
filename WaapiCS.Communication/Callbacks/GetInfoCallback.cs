﻿using Newtonsoft.Json;
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
    /// The callback object for ak.wwise.core.getInfo
    /// </summary>
    /// <seealso cref="WaapiCS.Communication.Callback" />
    public class GetInfoCallback : Callback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInfoCallback"/> class.
        /// </summary>
        /// <param name="packet">The JSON packet.</param>
        /// <exception cref="ArgumentNullException">Packet given to Callback cannot be null!</exception>
        public GetInfoCallback(Packet packet) : base(packet)
        {
            _packet = packet ?? throw new ArgumentNullException("Packet given to Callback cannot be null!");
        }

        /// <summary>
        /// The results returned from Wwise.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="formatter">The formatter.</param>
        /// <param name="details">The details - not used.</param>
        /// <param name="arguments">The arguments - not used.</param>
        /// <param name="argumentsKeywords">The data returned from Wwise.</param>
        public override void Result<TMessage>(IWampFormatter<TMessage> formatter, ResultDetails details, TMessage[] arguments, IDictionary<string, TMessage> argumentsKeywords)
        {
            // For each entry in the returned data
            foreach (KeyValuePair<string, TMessage> entry in argumentsKeywords)
            {
                // Deserialize the Value into its original type
                dynamic token = formatter.Deserialize<dynamic>(entry.Value);

                // If it Deserializes into a JObject...
                if (token.GetType() == typeof(JObject))
                {
                    // Turn it into a Dictionary<string, dynamic>
                    Dictionary<string, dynamic> wwiseValues = formatter.Deserialize<Dictionary<string, dynamic>>(token);

                    // and add it to our results object
                    _packet.results[entry.Key] = wwiseValues;
                }
                else
                {
                    // Otherwise add it to our results object straight away
                    _packet.results[entry.Key] = token;
                }
            }
            // Allow the application to continue
            SetResetEventQueue();
        }
    }
}
