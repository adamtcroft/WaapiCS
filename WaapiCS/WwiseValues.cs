using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaapiCS.CustomValues
{
    public static class WwiseValues
    {
        /// <summary>
        /// The action to take on a node naming conflict.
        /// </summary>
        public enum OnNameConflict
        {
            rename,
            replace,
            fail
        }

        /// <summary>
        /// The class ID of available Wwise objects.
        /// </summary>
        public enum ClassID
        {
            AcousticTexture = 4718608,
            Action = 327696,
            ActionException = 4980752,
            ActorMixer = 524304,
            Attenuation = 2686992,
            AudioDevice = 4653072,
            AudioSource = 16,
            AuxBus = 3997712,
            BlendContainer = 1900560,
            BlendTrack = 1966096,
            Bus = 1376272,
            ControlSurfaceBinding = 4390928,
            ControlSurfaceBindingGroup = 4456464,
            ControlSurfaceSession = 4325392,
            Conversion = 3604496,
            Curve = 917520,
            DialogueEvent = 3014672,
            Effect = 1114128,
            Event = 262160,
            ExternalSource = 3735568,
            ExternalSourceFile = 3670032,
            Folder = 131088,
            GameParameter = 1507344,
            Language = 4915216,
            MidiParameter = 4128784,
            MixingSession = 3473424,
            Modifier = 983056,
            ModulatorEnvelope = 4259856,
            ModulatorLfo = 4194320,
            MultiSwitchEntry = 655360016,
            MusicClip = 3932176,
            MusicClipMidi = 4063248,
            MusicCue = 3866640,
            MusicFade = 2555920,
            MusicPlaylistContainer = 2228240,
            MusicPlaylistItem = 2359312,
            MusicSegment = 1769488,
            MusicStinger = 2490384,
            MusicSwitchContainer = 2293776,
            MusicTrack = 1835024,
            MusicTrackSequence = 3801104,
            MusicTransition = 2424848,
            ObjectSettingAssoc = 1572880,
            Panner = 2752528,
            ParamControl = 1441808,
            Path = 720912,
            Platform = 4522000,
            PluginDataSource = 3538960,
            Position = 786448,
            Project = 196624,
            Query = 2097168,
            RandomSequenceContainer = 589840,
            SearchCriteria = 2162704,
            Sound = 65552,
            SoundBank = 1179664,
            State = 393232,
            StateGroup = 458768,
            Switch = 1310736,
            SwitchContainer = 655376,
            SwitchGroup = 1245200,
            Trigger = 2621456,
            UserProjectSettings = 3342352,
            WorkUnit = 1638416
        }

        /// <summary>
        /// Action to take.
        /// </summary>
        public enum ActionType
        {
            Stop = 0,
            Pause = 1,
            Resume = 2,
            Break = 3,
            ReleaseEnvelope = 4
        }

        /// <summary>
        /// The type of curve.
        /// </summary>
        public enum CurveType
        {
            VolumeDryUsage,
            VolumeWetGameUsage,
            VolumeWetUserUsage,
            LowPassFilterUsage,
            HighPassFilterUsage,
            SpreadUsage,
            FocusUsage
        }

        /// <summary>
        /// The type of curve points to use.
        /// </summary>
        public enum CurvePointsType
        {
            None,
            Custom,
            UseVolumeDry
        }

        /// <summary>
        /// A curve point defined by x, y coordinates and shape.
        /// </summary>
        public class CurvePoint
        {
            float x;
            float y;
            WwiseValues.CurveShape shape;
        }

        /// <summary>
        /// The curve shape.
        /// </summary>
        public enum CurveShape
        {
            Constant,
            Linear,
            Log3,
            Log2,
            Log1,
            InvertedSCurve,
            SCurve,
            Exp1,
            Exp2,
            Exp3
        }

        /// <summary>
        /// The curve interpolation type.
        /// </summary>
        public enum CurveInterpolation
        {
            Log3 = 0,
            Sine = 1,
            Log1 = 2,
            InvSCurve = 3,
            Linear = 4,
            SCurve = 5,
            Exp1 = 6,
            SineRecip = 7,
            Exp3 = 8,
            Constant = 9
        }

        /// <summary>
        /// A struct of aux send values.
        /// </summary>
        public struct AuxSendValues
        {
            string gameObjectID, auxBusID;
            float fControlValue;
        }

        /// <summary>
        /// Object position in 3D
        /// </summary>
        public class Position3D
        {
            public class OrientationFront
            {
                float x, y, z;
            }

            public class OrientationTop
            {
                float x, y, z;
            }

            public class Position
            {
                float x, y, z;
            }
        }

        /// <summary>
        /// Multi Position Type.
        /// </summary>
        public enum MultiPositionType
        {
            SingleSource = 0,
            MultiSources = 1,
            MultiDirections = 2
        }

        /// <summary>
        /// The type of import operation.
        /// </summary>
        public enum ImportOperation
        {
            createNew,
            useExisting,
            replaceExisting
        }

        /// <summary>
        /// An audio object.
        /// </summary>
        public class AudioObject
        {
            string importLanguage;
            dynamic objectGUID;
            string audioFilePath;
            string audioFilePathBase64;
            string originalsSubFolder;
            string objectPath;
            string objectType;
            string notes;
            string audioSourceNotes;
            string switchAssignation;
            string eventPathName;
            string dialogueEventPathName;
        }

        /// <summary>
        /// The soundbank operation to take.
        /// </summary>
        public enum soundbankOperation
        {
            add,
            remove,
            replace
        }

        /// <summary>
        /// An inclusion object.
        /// </summary>
        public class InclusionObject
        {
            public string objectID;
            public WwiseValues.inclusionFilter filter;
        }

        /// <summary>
        /// The inclusion filter type.
        /// </summary>
        public enum inclusionFilter
        {
            events,
            structures,
            media
        }

        /// <summary>
        /// The transport action to take.
        /// </summary>
        public enum transportAction
        {
            play,
            stop,
            pause,
            playStop
        }

        /// <summary>
        /// The type of "get" query.
        /// </summary>
        public enum getType
        {
            id,
            search,
            path,
            ofType,
            query
        }

        /// <summary>
        /// The type of "get" transform.
        /// </summary>
        public enum getTransformType
        {
            select,
            range,
            where
        }

        /// <summary>
        /// The type and items to "get".
        /// </summary>
        public class Get
        {
            public getType type;
            public string[] objectArray;
        }

        /// <summary>
        /// The type of transform and items to "get".
        /// </summary>
        public class GetTransform
        {
            public getTransformType type;
            public string[] objectArray;
        }
    }
}
