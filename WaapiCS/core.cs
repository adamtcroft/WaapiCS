using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaapiCS.Communication;
using WaapiCS.CustomValues;

namespace ak
{
    public static partial class wwise
    {
        public static partial class core
        {
            /// <summary>
            /// Returns information about the currently running instance of Wwise.
            /// </summary>
            /// <returns></returns>
            public static Dictionary<string, object> GetInfo()
            {
                if (packet.results != null)
                    packet.results.Clear();
                packet.procedure = "ak.wwise.core.getInfo";
                packet.callback = new Callback(packet);
                results = connection.Execute(packet);
                packet.Clear();

                //return (Dictionary<string, object>)results;
                return (Dictionary<string, object>)results;
            }

            public static class undo
            {
                /// <summary>
                /// Begins an undo group.
                /// </summary>
                public static void BeginGroup()
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.undo.beginGroup";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Cancels an undo group.
                /// </summary>
                public static void CancelGroup()
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.undo.cancelGroup";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Ends an undo group.
                /// </summary>
                public static void EndGroup()
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.undo.cancelGroup";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }
            }

            public static class project
            {
                /// <summary>
                /// Saves the current project.
                /// </summary>
                public static void Save()
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.project.save";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }
            }

            public static class remote
            {
                /// <summary>
                /// Connects the Wwise Authoring application to a Wwise Sound Engine running executable.
                /// The host must be running code with communication enabled.
                /// </summary>
                /// <param name="host">The host IP address.
                /// The host can be an IPv4 address or a computer name
                /// Use 127.0.0.1 to connect to localhost.</param>
                public static void Connect(string host)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.remote.connect";
                    packet.keywordArguments.Add("host", host);
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Disconnects the Wwise Authoring application from a connected Wwise Sound Engine running executable.
                /// </summary>
                public static void Disconnect()
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.remote.disconnect";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Retrieves all consoles available for connecting Wwise Authoring to a Sound Engine instance.
                /// </summary>
                /// <returns>A list of IPs available for connecting.</returns>
                public static List<Dictionary<string, object>> GetAvailableConsoles()
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.remote.getAvailableConsoles";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                    return (List<Dictionary<string, object>>)results;
                }

                /// <summary>
                /// Gets the connection status.
                /// </summary>
                /// <returns>The connection status</returns>
                public static Dictionary<string, object> GetConnectionStatus()
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.remote.getConnectionStatus";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                    return (Dictionary<string, object>)results;
                }
            }

            public static class soundbank
            {
                /// <summary>
                /// Retrieves a SoundBank's inclusion list.
                /// </summary>
                /// <param name="soundbankGUID">The soundbank's unique identifier.</param>
                /// <returns></returns>
                public static List<Dictionary<string, object>> GetInclusions(string soundbankGUID)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("soundbank", soundbankGUID);
                    packet.procedure = "ak.wwise.core.soundbank.getInclusions";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();

                    return (List<Dictionary<string, object>>)results;
                }

                /// <summary>
                /// Modifies a SoundBank's inclusion list.
                /// The 'operation' argument determines how the 'inclusions' argument modifies the SoundBank's inclusion list;
                /// 'inclusions' may be added to / removed from / replace the SoundBank's inclusion list.
                /// </summary>
                /// <param name="soundbankGUID">The soundbank's unique identifier.</param>
                /// <param name="operation">The operation to modify the inclusion list - add, remove, or replace.</param>
                /// <param name="inclusions">The inclusions.</param>
                public static void SetInclusions(string soundbankGUID, WwiseValues.soundbankOperation operation,
                    WwiseValues.InclusionObject[] inclusions)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("soundbank", soundbankGUID);
                    packet.keywordArguments.Add("operation", operation.ToString());
                    Dictionary<string, string>[] allInclusions = new Dictionary<string, string>[inclusions.Length];
                    Dictionary<string, string> inclusionDict = new Dictionary<string, string>();
                    int i = 0;
                    foreach (WwiseValues.InclusionObject inclusion in inclusions)
                    {
                        inclusionDict["object"] = inclusion.objectID;
                        inclusionDict["filter"] = inclusion.filter.ToString();
                        allInclusions[i] = inclusionDict;
                        i++;
                    }
                    packet.keywordArguments.Add("inclusions", allInclusions);
                    packet.procedure = "ak.wwise.core.soundbank.setInclusions";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }
            }

            public static class audio
            {
                //!: Needs Testing!
                /// <summary>
                /// Scripted object creation and audio file import.
                /// </summary>
                /// <param name="importOperation">Determines how import object creation is performed.</param>
                /// <param name="defaultValues">Default values for each item in "imports".</param>
                /// <param name="imports">The objects to import.</param>
                public static void Import(WwiseValues.ImportOperation importOperation,
                    WwiseValues.AudioObject defaultValues, WwiseValues.AudioObject[] imports)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("importOperation", importOperation.ToString());
                    packet.keywordArguments.Add("default", defaultValues);
                    packet.keywordArguments.Add("imports", imports);
                    packet.procedure = "ak.wwise.core.audio.import";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                //!: Needs Testing!
                /// <summary>
                /// Scripted object creation and audio file import from a tab-delimited file.
                /// </summary>
                /// <param name="importLocation">Object ID (GUID) or path used as root relative object paths.</param>
                /// <param name="importLanguage">Import language for audio file import.</param>
                /// <param name="importOperation">Determines how import object creation is performed.</param>
                /// <param name="importFile">Location of tab-delimited import file.</param>
                public static void ImportTabDelimited(string importLocation,
                    string importLanguage,
                    WwiseValues.ImportOperation importOperation,
                    string importFile)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("importLocation", importLocation);
                    packet.keywordArguments.Add("importLanguage", importLanguage);
                    packet.keywordArguments.Add("importOperation", importOperation);
                    packet.keywordArguments.Add("importFile", importFile);
                    packet.procedure = "ak.wwise.core.audio.importTabDelimited";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }
            }

            public static class audioSourcePeaks
            {
                //TODO: Setup Return Callback
                //!: Needs Testing!
                /// <summary>
                /// Get the min/max peak pairs, in a given region of an audio source,
                /// as a collection of binary strings (one per channel).
                /// If getCrossChannelPeaks is true,
                /// there will be only one binary string representing peaks across all channels globally.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of the object.</param>
                /// <param name="timeFrom">The start time, in seconds, of the section of the audio source for which peaks are required </param>
                /// <param name="timeTo">The end time, in seconds, of the section of the audio source for which peaks are required.</param>
                /// <param name="numPeaks">The number of peaks that are required.</param>
                /// <param name="getCrossChannelPeaks">When <c>true</c>, [peaks will be calculated globally across channels], instead of per channel. </param>
                public static void GetMinMaxPeaksInRegion(string objectID,
                    float timeFrom,
                    float timeTo,
                    float numPeaks,
                    bool getCrossChannelPeaks)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    packet.keywordArguments.Add("timeFrom", timeFrom);
                    packet.keywordArguments.Add("timeTo", timeTo);
                    packet.keywordArguments.Add("numPeaks", numPeaks);
                    packet.keywordArguments.Add("getCrossChannelPeaks", getCrossChannelPeaks);
                    packet.procedure = "ak.wwise.core.audioSourcePeaks.getMinMaxPeaksInRegion";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                }

                //TODO: Setup Return Callback
                //!: Needs Testing!
                /// <summary>
                /// Get the min/max peak pairs in the entire trimmed region of an audio source,
                /// for each channel, as an array of binary strings (one per channel).
                /// If getCrossChannelPeaks is true,
                /// there will be only one binary string representing peaks across all channels globally.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of the object.</param>
                /// <param name="numPeaks">The number of peaks that are required.</param>
                /// <param name="getCrossChannelPeaks">When <c>true</c>, [peaks will be calculated globally across channels], instead of per channel. </param>
                public static void GetMinMaxPeaksInTrimmedRegion(string objectID,
                    float numPeaks,
                    bool getCrossChannelPeaks)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    packet.keywordArguments.Add("numPeaks", numPeaks);
                    packet.keywordArguments.Add("getCrossChannelPeaks", getCrossChannelPeaks);
                    packet.procedure = "ak.wwise.core.audioSourcePeaks.getMinMaxPeaksInTrimmedRegion";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                }
            }

            public class switchContainer
            {
                //!: Needs Testing!
                /// <summary>
                /// Assign a Switch Container's child to a Switch.
                /// This is the equivalent of doing a drag&drop of the child to a state in the Assigned Objects view.
                /// The child is always added at the end for each state.
                /// </summary>
                /// <param name="childID">The ID (GUID) or path of the object to assign to a State.
                /// This object must be the child of a Switch Container.</param>
                /// <param name="stateOrSwitchID"> 	The ID (GUID) or path of the State or Switch with which to assign.
                /// Must be the child of the Switch Group or State Group that is currently set for the Switch Container.</param>
                public static void AddAssignment(string childID, string stateOrSwitchID)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("child", childID);
                    packet.keywordArguments.Add("stateOrSwitch", stateOrSwitchID);
                    packet.procedure = "ak.wwise.core.switchContainer.addAssignment";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                //!: Needs Testing!
                /// <summary>
                /// Remove an assignment between a Switch Container's child and a State.
                /// </summary>
                /// <param name="childID">The ID (GUID) or path of the object assigned to a State.
                /// This object must be the child of a Switch Container and must be currently assigned to a State.</param>
                /// <param name="stateOrSwitchID">The ID (GUID) or path of the State or Switch to which the child is assigned.
                /// Must be the child of the Switch Group or State Group that is currently set for the Switch Container.</param>
                public static void RemoveAssignment(string childID, string stateOrSwitchID)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("child", childID);
                    packet.keywordArguments.Add("stateOrSwitch", stateOrSwitchID);
                    packet.procedure = "ak.wwise.core.switchContainer.removeAssignment";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                //TODO: Create callback
                //!: Needs Testing!
                /// <summary>
                /// Returns the list of assignments between a Switch Container's children and states.
                /// </summary>
                /// <param name="containerID">The ID (GUID) or path of the Switch Container.</param>
                public static void GetAssignments(string containerID)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("id", containerID);
                    packet.procedure = "ak.wwise.core.switchContainer.getAssignments";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                }
            }

            public class transport
            {
                /// <summary>
                /// Creates a transport object for the given Wwise object.
                /// The return transport object can be used to play, stop, pause and resume 
                /// the Wwise object via the other transport functions.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of the object to control via the transport object.</param>
                /// <param name="gameObjectID">The game object to use for playback.</param>
                public static List<Dictionary<string, object>> Create(string objectID, int gameObjectID = -1)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    if (gameObjectID >= 0)
                        packet.keywordArguments.Add("gameObject", gameObjectID);
                    packet.procedure = "ak.wwise.core.transport.create";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                    return (List<Dictionary<string, object>>)results;
                }

                //!: Needs Testing!
                /// <summary>
                /// Destroys the given transport object.
                /// </summary>
                /// <param name="transportID">Transport object ID to be used with all other ak.wwise.core.transport functions.</param>
                public static void Destroy(string transportID)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("transport", transportID);
                    packet.procedure = "ak.wwise.core.transport.destroy";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                //!: Needs Testing!
                /// <summary>
                /// Executes an action on the given transport object, or all transports if no transport is specified.
                /// </summary>
                /// <param name="transportID">Transport object ID to be used with all other ak.wwise.core.transport functions.</param>
                /// <param name="transportAction">The action to execute.
                /// Possible values : "play", "stop", "pause", "playStop"</param>
                public static void ExecuteAction(string transportID, WwiseValues.transportAction transportAction)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("transport", transportID);
                    packet.keywordArguments.Add("action", transportAction.ToString());
                    packet.procedure = "ak.wwise.core.transport.ExecuteAction";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                //TODO: Create callback
                //!: Needs Testing!
                /// <summary>
                /// Returns the list of transport objects.
                /// </summary>
                public static void GetList()
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.core.transport.getList";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                }

                //TODO: Create callback
                //!: Needs Testing!
                /// <summary>
                /// Gets the state of the given transport object.
                /// </summary>
                /// <param name="transportID">Transport object ID to be used with all other ak.wwise.core.transport functions.</param>
                public static void GetState(int transportID)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("transport", transportID);
                    packet.procedure = "ak.wwise.core.transport.getList";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                }
            }
        }
    }
}
