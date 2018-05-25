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
    public class CreateObjectCallback : Callback
    {
        public CreateObjectCallback(Packet packet) : base(packet)
        {
            _packet = packet ?? throw new ArgumentNullException("Packet given to Callback cannot be null!");
        }

        public override void Result<TMessage>(IWampFormatter<TMessage> formatter, ResultDetails details, TMessage[] arguments, IDictionary<string, TMessage> argumentsKeywords)
        {
            JToken array = formatter.Deserialize<JToken>(argumentsKeywords["objects"]);

            foreach (dynamic entry in array)
            {
                foreach (string item in _packet.options.@return)
                {
                    switch (item)
                    {
                        case "shortId":
                        case "childrenCount":
                            if (entry[item] == null)
                                entry[item] = "";
                            else
                                _packet.results[item] = (int)entry[item];
                            break;

                        case "isPlayable":
                        case "workunit:isDefault":
                        case "workunit:isDirty":
                            if (entry[item] == null)
                                entry[item] = "";
                            else
                                _packet.results[item] = (bool)entry[item];
                            break;

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
                            if (entry[item] == null)
                                entry[item] = "";
                            else
                                _packet.results[item] = entry[item].ToString();
                            break;
                    }
                }
            }
            SetResetEventQueue();
        }
    }
}
