using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaapiCS.CustomValues;

namespace SampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, object>> results = ak.wwise.core.soundbank.GetInclusions("{00318C83-50A1-4716-B349-1DF45961A040}");
            //Dictionary<string, object> results = ak.wwise.core.remote.GetConnectionStatus();
            //PrintResults(results);

            //List<Dictionary<string, object>> results = ak.wwise.core.remote.GetAvailableConsoles();
            //foreach(Dictionary<string, object> dictionary in results)
            //{
            //    foreach(KeyValuePair<string,object> pair in dictionary)
            //    {
            //        Console.WriteLine(pair.Key + " " + pair.Value);
            //    }
            //}
            //object results = ak.wwise.core.GetInfo();
            //foreach(var item in (Dictionary<string, object>) results)
            //{
            //    Console.WriteLine("Key: " + item.Key + ", Value: " + item.Value);
            //}
            //ak.wwise.core.remote.GetAvailableConsoles();
            //ak.wwise.core.soundbank.GetInclusions("{206D5F70-9369-4BBA-ADA0-7BEA34771247}");
            //Dictionary<string, object> results = ak.wwise.core.Object.Move("{BD5D43D2-B973-4C75-AC4E-A815AD1E7E8A}", "{5EBCEC7F-E042-4C0C-BF1A-3E23BD29D9FD}");

            // foreach(var item in results)
            // {
            //     Console.WriteLine(item.Key + ": " + item.Value);
            // }
            //ak.wwise.ui.BringToForeground();
            //List<Dictionary<string, object>> results = ak.wwise.core.Object.GetTypes();
            //foreach (Dictionary<string, object> entry in results)
            //{
            //    foreach (KeyValuePair<string, object> item in entry)
            //        Console.WriteLine(item.Key + ": " + item.Value);
            //}

            //List<string> results = ak.wwise.core.Object.GetPropertyNames("", 65552);
            //foreach (string item in results)
            //    Console.WriteLine(item);

            //Dictionary<string, object> results = ak.wwise.core.Object.Create("{5EBCEC7F-E042-4C0C-BF1A-3E23BD29D9FD}", "Folder", "Generated", "rename");

            //string[] guids = { "{07976883-BA6E-4048-ADD8-78E8C5B87A0F}", "{6C3B215F-9199-43E4-8D4E-6D6E6369A3E2}", "{02F1C262-E983-49B9-ACBA-B3F2E0BFD360}" };
            //ak.wwise.ui.commands.Execute("FindInProjectExplorerSyncGroup1", guids);

            //List<string> commands = ak.wwise.ui.commands.GetCommands();
            //foreach (string command in commands)
            //    Console.WriteLine(command);
            //ak.wwise.ui.commands.Execute("Help");
            //ak.wwise.ui.project.Close(false);

            //Dictionary<string,object> results = ak.wwise.ui.GetSelectedObjects();

            //foreach(KeyValuePair<string,object> entry in results)
            //{
            //    Console.WriteLine("Key " + entry.Key);
            //    Console.WriteLine("Value " + entry.Value);
            //    Console.WriteLine("Type: " + entry.Value.GetType());
            //}

            //ak.wwise.core.project.Save();
            //ak.wwise.ui.project.Close(false);
            //Dictionary<string, object> subResults = ak.wwise.core.Object.NameChanged();
        }

        static void PrintResults(object results)
        {
            foreach (var pair in (Dictionary<string, object>)results)
            {
                Console.WriteLine("Key: " + pair.Key + ", Value: " + pair.Value);
            }
        }
    }
}
