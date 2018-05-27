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
            Dictionary<string,object> results = ak.wwise.core.remote.GetConnectionStatus();
            //ak.wwise.core.Object.SetProperty("{8E598160-6E29-44E0-8145-C31ED577DC45}", "Volume", -1);
            //ak.wwise.core.Object.SetNotes("{8E598160-6E29-44E0-8145-C31ED577DC45}", "Note");
            //ak.wwise.core.Object.SetName("{8E598160-6E29-44E0-8145-C31ED577DC45}", "This is a name");
            //ak.wwise.core.Object.IsPropertyEnabled("{AC5D2B26-8029-42F2-AA5D-EDEF8D9A3036}", "{6E0CB257-C6C8-4c5c-8366-2740DFC441EB}", "Volume");
            //Dictionary<string, object> results = ak.wwise.core.Object.GetPropertyInfo("Volume", "{C114F296-384C-4208-A23F-BE9DA945F0E3}");
            //ak.wwise.core.project.Save();
            //ak.wwise.core.Object.Delete("{82B01565-FB9C-4959-ABC4-1609269755F0}");

            //Dictionary<string, object> results = ak.wwise.core.Object.Create("{F97FA490-EAA3-42E0-8FA3-6D4A26B325F0}", "Sound", "New Sound 8");

            //WwiseValues.getType type = WwiseValues.getType.id;
            //string[] objects = { "{F97FA490-EAA3-42E0-8A3-6D4A26B325F0}", "{E269A71E-5E07-4B6A-AEB8-978C05199CB1}", "{1742FA50-5008-4F5B-A606-F9BEC58A7128}" };
            //WwiseValues.Get newGet = new WwiseValues.Get();
            //newGet.type = type;
            //newGet.objectArray = objects;

            //Dictionary<string, object> results = ak.wwise.core.Object.Get(newGet);
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
