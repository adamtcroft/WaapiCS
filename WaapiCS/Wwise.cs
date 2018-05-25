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
        /// <summary>
        /// The connection to Wwise
        /// </summary>
        internal static Connection connection = new Connection();

        /// <summary>
        /// The packet acts as a wrapper to the JSON sent to Wwise
        /// </summary>
        internal static Packet packet = new Packet();

        /// <summary>
        /// The subscription connection to Wwise
        /// </summary>
        internal static Subscriber subscription = new Subscriber();

        /// <summary>
        /// A generic object that contains the results of our calls to Wwise
        /// </summary>
        internal static object results;

        /// <summary>
        /// An array of return values available in Wwise 2017.1.0.6302
        /// </summary>
        internal static string[] returnValues2017_1_0_6302 =
{
            "id",
            "name",
            "notes",
            "type",
            "shortId",
            "category",
            "filePath",
            "workunit",
            "parent",
            "owner",
            "path",
            "isPlayable",
            "childrenCount",
            "sound:convertedWemFilePath",
            "sound:originalWavFilePath",
            "soundbank:bnkFilePath",
            "music:transitionRoot",
            "music:playlistRoot",
            "workunit:isDefault",
            "workunit:type",
            "workunit:isDirty"
        };
    }
}
