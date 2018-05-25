using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaapiCS.Communication;
using WaapiCS.CustomValues;

namespace ak
{
    public static class soundengine
    {
        //!: Test this
        /// <summary>
        /// Asynchronously post an Event to the sound engine (by event ID).
        /// </summary>
        /// <param name="eventGUID">Either the ID (GUID), name, or short ID of the Event.</param>
        /// <param name="gameObject">The unique ID of the game object.</param>
        /// <returns></returns>
        public static int PostEvent(string eventGUID, int gameObject)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("event", eventGUID);
            wwise.packet.keywordArguments.Add("gameObject", gameObject);
            wwise.packet.procedure = "ak.soundengine.postEvent";
            //TODO: Create a proper callback for PostEvent
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.results = wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
            return (int)wwise.results;
        }

        //!: Test This
        /// <summary>
        /// Execute an action on all nodes that are referenced in the specified event in an action of type play.
        /// </summary>
        /// <param name="eventGUID">Either the ID (GUID), name or short ID of the event.</param>
        /// <param name="actionType">Action to execute on all the elements that were played using the specified event.</param>
        /// <param name="gameObject">Associated game object ID.</param>
        /// <param name="transitionDurationInMs">Fade duration (ms).</param>
        /// <param name="fadeCurve">The fade curve type.</param>
        public static void ExecuteActionOnEvent(string eventGUID,
            WwiseValues.ActionType actionType, int gameObject, int transitionDurationInMs,
            WwiseValues.CurveInterpolation fadeCurve)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("event", eventGUID);
            wwise.packet.keywordArguments.Add("actionType", actionType);
            wwise.packet.keywordArguments.Add("gameObject", gameObject);
            wwise.packet.keywordArguments.Add("transitionDuration", transitionDurationInMs);
            wwise.packet.keywordArguments.Add("fadeCurve", fadeCurve);
            wwise.packet.procedure = "ak.soundengine.executeActionOnEvent";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Display a message in the profiler.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public static void PostMsgMonitor(string message)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("message", message);
            wwise.packet.procedure = "ak.soundengine.postMsgMonitor";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Post the specified Trigger.
        /// </summary>
        /// <param name="triggerGUID">Either the ID (GUID), name, or short ID of the Trigger.</param>
        /// <param name="gameObject">Associated game object ID.</param>
        public static void PostTrigger(string triggerGUID, int gameObject)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("trigger", triggerGUID);
            wwise.packet.keywordArguments.Add("gameObject", gameObject);
            wwise.packet.procedure = "ak.soundengine.postTrigger";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Register a game object. Registering a game object twice does nothing.
        /// Unregistering it once unregisters it no matter how many times it has been registered.
        /// </summary>
        /// <param name="gameObject">ID of the game object to be registered.</param>
        /// <param name="name"> Name of the game object (for monitoring purpose).</param>
        public static void RegisterGameObj(int gameObject, string name)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("gameObject", gameObject);
            wwise.packet.keywordArguments.Add("name", name);
            wwise.packet.procedure = "ak.soundengine.registerGameObj";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Reset the value of a real-time parameter control to its default value, as specified in the Wwise project.
        /// </summary>
        /// <param name="rtpcGUID">Either the ID (GUID), name, or short ID of the real-time parameter control.</param>
        /// <param name="gameObject">Associated game object ID.</param>
        public static void ResetRTPCValue(dynamic rtpcGUID, int gameObject)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("rtpc", rtpcGUID);
            wwise.packet.keywordArguments.Add("gameObject", gameObject);
            wwise.packet.procedure = "ak.soundengine.resetRTPCValue";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Seek inside all playing objects that are referenced in Play Actions of the specified Event.
        /// </summary>
        /// <param name="eventGUID">Either the ID (GUID), name, or short ID of the Event.</param>
        /// <param name="gameObject">Associated game object ID.</param>
        /// <param name="startPositionInMs">Desired position where playback should restart, in milliseconds.</param>
        /// <param name="startPercentage">Desired position where playback should restart, expressed in a percentage of the file's total duration, between 0 and 1.f.</param>
        /// <param name="seekToNearestMarker">If <c>true</c>, the [final seeking position will be made equal to the nearest marker]. </param>
        /// <param name="playingID">Specify the playing ID for the seek to be applied to. Will result in the seek happening only on active actions of the playing ID.</param>
        public static void SeekOnEvent(dynamic eventGUID, int gameObject,
            int startPositionInMs, float startPercentage, bool seekToNearestMarker,
            int playingID)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("event", eventGUID);
            wwise.packet.keywordArguments.Add("gameObject", gameObject);
            wwise.packet.keywordArguments.Add("position", startPositionInMs);
            //TODO: Lock math between 0 and 1.f
            //wwise.packet.keywordArguments.Add("percent", startPercentage);
            wwise.packet.keywordArguments.Add("seekToNearestMarker", seekToNearestMarker);
            wwise.packet.keywordArguments.Add("playingId", playingID);
            wwise.packet.procedure = "ak.soundengine.seekOnEvent";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set a the default active listeners for all subsequent game objects that are registered.
        /// </summary>
        /// <param name="listenerIDs">Array of listener game object IDs. Game objects must have been previously registered.</param>
        public static void SetDefaultListeners(int[] listenerIDs)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("listeners", listenerIDs);
            wwise.packet.procedure = "ak.soundengine.setDefaultListeners";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set the Auxiliary Busses to route the specified game object.
        /// </summary>
        /// <param name="gameObjectID">Associated game object ID.</param>
        /// <param name="auxSendValues">An array of aux send values.</param>
        public static void SetGameObjectAuxSendValues(int gameObjectID, WwiseValues.AuxSendValues[] auxSendValues)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("gameObject", gameObjectID);
            wwise.packet.keywordArguments.Add("auxSendValues", auxSendValues);
            wwise.packet.procedure = "ak.soundengine.setGameObjectAuxSendValues";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set the output bus volume (direct) to be used for the specified game object.
        /// </summary>
        /// <param name="emitterID">Associated emitter game object ID.</param>
        /// <param name="listenerID">Associated listener game object ID.</param>
        /// <param name="controlValue">A multiplier where 0 means silence and 1 means no change.
        /// Therefore, values between 0 and 1 will attenuate the sound, and values greater than 1 will amplify it.</param>
        public static void SetGameObjectOutputBusVolume(int emitterID, int listenerID, float controlValue)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("emitter", emitterID);
            wwise.packet.keywordArguments.Add("listener", listenerID);
            wwise.packet.keywordArguments.Add("controlValue", controlValue);
            wwise.packet.procedure = "ak.soundengine.setGameObjectOutputBusVolume";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set a single game object's active listeners.
        /// By default, all new game objects have no listeners active, but this behavior can be overridden with SetDefaultListeners().
        /// Inactive listeners are not computed.
        /// </summary>
        /// <param name="emitterID">The emitter game object ID.</param>
        /// <param name="listenerIDs">Array of listener game object IDs. Game objects must have been previously registered.</param>
        public static void SetListeners(int emitterID, int[] listenerIDs)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("emitter", emitterID);
            wwise.packet.keywordArguments.Add("listener", listenerIDs);
            wwise.packet.procedure = "ak.soundengine.setListeners";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set a listener's spatialization parameters. This lets you define listener-specific volume offsets for each audio channel. 
        /// </summary>
        /// <param name="listenerID">Listener game object ID.</param>
        /// <param name="spatialized">Spatialization toggle (true: enable spatialization, false: disable spatialization).</param>
        /// <param name="channelConfig">Channel configuration associated with volumeOffsets</param>
        /// <param name="volumeOffsets">Per-speaker volume offset, in dB.</param>
        public static void SetListenerSpatialization(int listenerID, bool spatialized, int channelConfig,
            float[] volumeOffsets)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("listener", listenerID);
            wwise.packet.keywordArguments.Add("spatialized", spatialized);
            wwise.packet.keywordArguments.Add("channelConfig", channelConfig);
            wwise.packet.keywordArguments.Add("volumeOffsets", volumeOffsets);
            wwise.packet.procedure = "ak.soundengine.setListenerSpatialization";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set multiple positions for a single game object.
        /// Setting multiple positions for a single game object is a way to simulate multiple emission sources while using the resources of only one voice.
        /// </summary>
        /// <param name="gameObjectID">The game object identifier.</param>
        /// <param name="positions">Array of positions to apply.</param>
        /// <param name="multiPositionType">Type of the multi position.</param>
        public static void SetMultiplePositions(int gameObjectID, WwiseValues.Position3D[] positions,
            WwiseValues.MultiPositionType multiPositionType)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("gameObject", gameObjectID);
            wwise.packet.keywordArguments.Add("positions", positions);
            wwise.packet.keywordArguments.Add("multiPositionType", multiPositionType);
            wwise.packet.procedure = "ak.soundengine.setMultiplePositions";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set a game object's obstruction and occlusion levels.
        /// This function is used to affect how an object should be heard by a specific listener.
        /// </summary>
        /// <param name="emitterID">The emitter game object ID.</param>
        /// <param name="listenerID">The listener game object ID.</param>
        /// <param name="obstructionLevel">The obstruction level. [0.0f..1.0f]</param>
        /// <param name="occlusionLevel">The occlusion level. [0.0f..1.0f]</param>
        public static void SetObjectObstructionAndOcclusion(int emitterID, int listenerID,
            float obstructionLevel, float occlusionLevel)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("emitter", emitterID);
            wwise.packet.keywordArguments.Add("listener", listenerID);
            wwise.packet.keywordArguments.Add("obstructionLevel", obstructionLevel);
            wwise.packet.keywordArguments.Add("occlusionLevel", occlusionLevel);
            wwise.packet.procedure = "ak.soundengine.setObjectObstructionAndOcclusion";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set the position of a game object.
        /// </summary>
        /// <param name="gameObjectID">The game object identifier.</param>
        /// <param name="position">The 3D position to set for the game object.</param>
        public static void SetPosition(int gameObjectID, WwiseValues.Position3D position)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("gameObject", gameObjectID);
            wwise.packet.keywordArguments.Add("position", position);
            wwise.packet.procedure = "ak.soundengine.setPosition";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set the value of a real-time parameter control. 
        /// </summary>
        /// <param name="rtpcID">Either the ID (GUID), name, or short ID of the real-time parameter control.</param>
        /// <param name="value">The new value.</param>
        /// <param name="gameObjectID">The associated game object ID.</param>
        public static void SetRTPCValue(dynamic rtpcID, float value, int gameObjectID)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("rtpc", rtpcID);
            wwise.packet.keywordArguments.Add("value", value);
            wwise.packet.keywordArguments.Add("gameObject", gameObjectID);
            wwise.packet.procedure = "ak.soundengine.setRTPCValue";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// et the scaling factor of a game object.
        /// Modify the attenuation computations on this game object to simulate sounds with a larger or smaller area of effect.
        /// </summary>
        /// <param name="gameObjectID">The game object identifier.</param>
        /// <param name="attenuationScalingFactor">The scaling factor, where 1 means 100%, 0.5 means 50%, 2 means 200%, and so on.</param>
        public static void SetScalingFactor(int gameObjectID, float attenuationScalingFactor)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("gameObject", gameObjectID);
            wwise.packet.keywordArguments.Add("attenuationScalingFactor", attenuationScalingFactor);
            wwise.packet.procedure = "ak.soundengine.setScalingFactor";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Set the State of a Switch Group.
        /// </summary>
        /// <param name="switchGroupID">Either the ID (GUID), name, or short ID of the Switch Group.</param>
        /// <param name="switchStateID">Either the ID (GUID), name, or short ID of the Switch State.</param>
        /// <param name="gameObjectID">The associated game object identifier.</param>
        public static void SetSwitch(dynamic switchGroupID, dynamic switchStateID, int gameObjectID)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("switchGroup", switchGroupID);
            wwise.packet.keywordArguments.Add("switchState", switchStateID);
            wwise.packet.keywordArguments.Add("gameObject", gameObjectID);
            wwise.packet.procedure = "ak.soundengine.setSwitch";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Stop playing the current content associated to the specified game object ID.
        /// If no game object is specified, all sounds will be stopped.
        /// </summary>
        /// <param name="gameObjectID">The associated game object identifier.</param>
        public static void StopAll(int gameObjectID)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("gameObject", gameObjectID);
            wwise.packet.procedure = "ak.soundengine.stopAll";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Stop the current content, associated to the specified playing ID, from playing.
        /// </summary>
        /// <param name="playingID">The playing ID to be stopped.</param>
        /// <param name="transitionDurationInMs">The fade duration in ms.</param>
        /// <param name="fadeCurve">The fade curve type to be used for the transition.</param>
        public static void StopPlayingID(int playingID, int transitionDurationInMs,
            WwiseValues.CurveInterpolation fadeCurve)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("playingId", playingID);
            wwise.packet.keywordArguments.Add("transitionDuration", transitionDurationInMs);
            wwise.packet.keywordArguments.Add("fadeCurve", fadeCurve);
            wwise.packet.procedure = "ak.soundengine.stopPlayingId";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }

        //!: Test This
        /// <summary>
        /// Unregister a game object. Registering a game object twice does nothing.
        /// Unregistering it once unregisters it no matter how many times it has been registered.
        /// Unregistering a game object while it is in use is allowed, but the control over the parameters of this game object is lost.
        /// </summary>
        /// <param name="gameObjectID">The associated game object identifier.</param>
        public static void UnregisterGameObj(int gameObjectID)
        {
            if (wwise.packet.results != null)
                wwise.packet.results.Clear();
            wwise.packet.keywordArguments.Add("gameObject", gameObjectID);
            wwise.packet.procedure = "ak.soundengine.unregisterGameObj";
            wwise.packet.callback = new Callback(wwise.packet);
            wwise.connection.Execute(wwise.packet);
            wwise.packet.Clear();
        }
    }
}
