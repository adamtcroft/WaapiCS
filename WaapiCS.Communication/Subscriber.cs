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
    /// <summary>
    /// A data object which abstracts the JSON packet sent to Wwise.
    /// </summary>
    public class Subscriber
    {
        /// <summary>
        /// The procedure to be run by WAAPI
        /// </summary>
        public string procedure = "";

        /// <summary>
        /// The callback function to use.
        /// </summary>
        public SubscriptionCallback callback;

        /// <summary>
        /// The options to be sent to WAAPI (such as what to return).
        /// </summary>
        public WAAPISubscribeOptions options = new WAAPISubscribeOptions();

        /// <summary>
        /// The keyword arguments sent to WAAPI - such as commands.
        /// </summary>
        public IDictionary<string, object> keywordArguments = new Dictionary<string, object>();

        /// <summary>
        /// The JSON returned from Wwise.
        /// </summary>
        public Dictionary<string, object> results = new Dictionary<string, object>();

        /// <summary>
        /// The unsubscribe mechanism of the subscriber.
        /// </summary>
        public IAsyncDisposable unsubscribeDisposable = null;
    }

    /// <summary>
    /// The values we are requesting Wwise return.
    /// </summary>
    /// <seealso cref="WampSharp.V2.Core.Contracts.SubscribeOptions" />
    public class WAAPISubscribeOptions : SubscribeOptions
    {
        /// <summary>
        /// Gets or sets the values we are requesting Wwise return.
        /// </summary>
        /// <value>
        /// The values we are requesting Wwise return.
        /// </value>
        [DataMember(Name = "return")]
        public IEnumerable<string> @return { get; set; }
    }
}
