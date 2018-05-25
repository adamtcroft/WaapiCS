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
    /// The callback object for ak.wwise.ui.getSelectedObjects
    /// </summary>
    /// <seealso cref="WaapiCS.Communication.Callback" />
    public class GetSelectedObjectsCallback : Callback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSelectedObjectsCallback"/> class.
        /// </summary>
        /// <param name="packet">The JSON packet.</param>
        /// <exception cref="ArgumentNullException">Packet given to Callback cannot be null!</exception>
        public GetSelectedObjectsCallback(Packet packet) : base(packet)
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
            // Deserialize the JSON dictionary into a JTOKEN
            JToken array = formatter.Deserialize<JToken>(argumentsKeywords["objects"]);

            // For each entry in the token
            foreach (dynamic entry in array)
            {
                // Go through each availble return option we can get from Wwise
                foreach (string item in _packet.options.@return)
                {
                    switch (item)
                    {
                        // Each item below is added to the dictionary
                        // by type.

                        // If it's a number, add to the dictionary
                        case "shortId":
                        case "childrenCount":
                            if (entry[item] == null)
                                entry[item] = "";
                            else
                                _packet.results[item] = (int)entry[item];
                            break;

                        // If it's a boolean, add to the dictionary
                        case "isPlayable":
                        case "workunit:isDefault":
                        case "workunit:isDirty":
                            if (entry[item] == null)
                                entry[item] = "";
                            else
                                _packet.results[item] = (bool)entry[item];
                            break;

                        // If it's an object, add to the dictionary
                        // These will be of type Dictionary<string, object>
                        case "parent":
                        case "owner":
                        case "workunit":
                        case "music:transitionRoot":
                        case "music:playlistRoot":
                            if (entry[item] == null)
                                entry[item] = "";
                            else
                            {
                                Dictionary<string, dynamic> wwiseValues = formatter.Deserialize<Dictionary<string, dynamic>>(entry[item]);
                                _packet.results[item] = wwiseValues;
                            }
                            break;
                        default:
                            // If the item is null, replace it with a blank string
                            if (entry[item] == null)
                                entry[item] = "";
                            else
                                // Add the strings to the dictionary
                                _packet.results[item] = entry[item].ToString();
                            break;
                    }
                }
            }
            // Allow the application to continue
            SetResetEventQueue();
        }
    }
}
