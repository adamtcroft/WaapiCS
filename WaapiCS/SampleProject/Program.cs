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
            // Hi, welcome, and thank you for downloading WaapiCS
            // Let me point out a few things...

            // First, to use WaapiCS you must add a reference to it within your project.
            // To do this in Visual Studio 2017, got to "Project > Add Reference..." and browse for WaapiCS.dll

            // You do not need to include "using" statements at the top of your files.
            // Simply begin typing ak.wwise. and if WaapiCS is loaded correctly, Intellisense will show you what
            // commands you can use.

            // The vast majority of WaapiCS's user-facing layer uses "static calls", that means you won't need
            // to create any custom objects.

            // Here's an example:
            Dictionary<string, object> results = ak.wwise.core.GetInfo();
            PrintResults(results);

            // In the example above we call "ak.wwise.core.GetInfo()
            // This returns a Dictionary (where a string is the key and an object is the value) I named "results"
            // Down below you'll find a function called "PrintResults" that prints all of the results returned
            // by Wwise to a console window.

            // Below are some more examples:

            // Use the "GetTypes" call
            List<Dictionary<string, object>> types = ak.wwise.core.Object.GetTypes();
            foreach (var item in types)
            {
                foreach (var key in item.Keys)
                {
                    Console.WriteLine("Key: " + key);
                    Console.WriteLine("Value: " + item[key].ToString());
                }
            }

            // See if Wwise is remotely connected to a running game
            Dictionary<string, object> connectionStatus = ak.wwise.core.remote.GetConnectionStatus();
            PrintResults(connectionStatus);

            // Get the objects currently selected in your Wwise project
            List<Dictionary<string, object>> selectedObjects = ak.wwise.ui.GetSelectedObjects();

            // These nd much more are available to you across the entire framework!

            // Please remember the framework is in ACTIVE development!  Some calls are untested and/or do not
            // work quite yet.  All known issues can be found on the GitHub repo under "issues".
            // I'm working as quick as I can to resolve them all.
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
