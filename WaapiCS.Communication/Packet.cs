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

namespace WaapiCS.Communication
{
    /// <summary>
    /// A data object which abstracts the JSON packet sent to Wwise.
    /// </summary>
    public class Packet
    {
        /// <summary>
        /// The procedure to be run by WAAPI.
        /// </summary>
        public string procedure = "";

        /// <summary>
        /// The callback function to use.
        /// </summary>
        public Callback callback;

        /// <summary>
        /// The options to be sent to WAAPI (such as what to return).
        /// </summary>
        public WAAPICallOptions options = new WAAPICallOptions();

        /// <summary>
        /// The keyword arguments sent to WAAPI - such as commands.
        /// </summary>
        public IDictionary<string, object> keywordArguments = new Dictionary<string, object>();

        /// <summary>
        /// The JSON returned from Wwise.
        /// </summary>
        public dynamic results; 

        public void Clear()
        {
            procedure = "";
            keywordArguments.Clear();
        }

    }

    public class WAAPICallOptions : CallOptions
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
