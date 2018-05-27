using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaapiCS.Communication;

namespace ak
{
    public static partial class wwise
    {
        public static class ui
        {
            /// <summary>
            /// Gets the currently selected Wwise objects.
            /// </summary>
            /// <returns>Details about the selected objects.</returns>
            public static Dictionary<string, object> GetSelectedObjects()
            {
                if (packet.results != null)
                    packet.results.Clear();
                packet.results = new Dictionary<string, object>();
                packet.procedure = "ak.wwise.ui.getSelectedObjects";
                packet.callback = new Callback(packet);
                packet.options.@return = returnValues2017_1_0_6302;
                results = connection.Execute(packet);
                packet.Clear();
                return (Dictionary<string, object>)results;
            }

            public static void BringToForeground()
            {
                if (packet.results != null)
                    packet.results.Clear();
                packet.procedure = "ak.wwise.ui.bringToForeground";
                packet.callback = new Callback(packet);
                results = connection.Execute(packet);
                packet.Clear();
            }

            public static class project
            {
                /// <summary>
                /// Closes  the current Wwise project.
                /// </summary>
                /// <param name="bypassSave">if set to <c>true</c> [bypass save].</param>
                public static void Close(bool bypassSave)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.ui.project.close";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Opens the "open project" dialogue in Wwise.
                /// </summary>
                /// <param name="bypassSave">if set to <c>true</c> [bypass save].</param>
                public static void Open(bool bypassSave)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.procedure = "ak.wwise.ui.project.open";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                }
            }

            public static class commands
            {
                /// <summary>
                /// Executes the specified command.  Command list can be retrieved via "GetCommands".
                /// </summary>
                /// <param name="command">The command to run.</param>
                public static void Execute(string command, string[] objects = null)
                {
                    if (packet.results != null)
                        packet.results.Clear();

                    if (objects != null)
                        packet.keywordArguments.Add("objects", objects);
                    packet.keywordArguments.Add("command", command);
                    packet.callback = new Callback(packet);
                    packet.procedure = "ak.wwise.ui.commands.execute";
                    results = connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Gets the available list of commands for Wwise to execute.
                /// </summary>
                /// <returns>The List<string> of commands.</returns>
                public static List<string> GetCommands()
                {
                    packet.results = new List<string>();
                    packet.results.Clear();
                    packet.callback = new Callback(packet);
                    packet.procedure = "ak.wwise.ui.commands.getCommands";
                    results = connection.Execute(packet);
                    packet.Clear();
                    return (List<string>)results;
                }
            }
        }
    }
}
