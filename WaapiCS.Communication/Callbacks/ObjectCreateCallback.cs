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
    /// The callback object for ak.wwise.core.object.create
    /// </summary>
    /// <seealso cref="WaapiCS.Communication.Callback" />
    public class ObjectCreateCallback : Callback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectCreateCallback"/> class.
        /// </summary>
        /// <param name="packet">The JSON packet.</param>
        /// <exception cref="ArgumentNullException">Packet given to Callback cannot be null!</exception>
        public ObjectCreateCallback (Packet packet) : base(packet)
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
            _packet.results["id"] = argumentsKeywords["id"].ToString();
            _packet.results["name"] = argumentsKeywords["name"].ToString();
            _packet.results["children"] = (dynamic)argumentsKeywords["children"];

            // Allow the application to continue
            SetResetEventQueue();
        }
    }
}
