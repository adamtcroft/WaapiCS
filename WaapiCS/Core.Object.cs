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
            public static class Object
            {
                /// <summary>
                /// A subscriber that listens for the renaming of any node.
                /// </summary>
                /// <returns>Returns details about the node that was renamed.</returns>
                public static Dictionary<string, object> NameChanged()
                {
                    subscription.procedure = "ak.wwise.core.object.nameChanged";
                    subscription.options.@return = returnValues2017_1_0_6302;
                    connection.Execute(subscription);
                    return subscription.results;
                }

                //TODO: Check Callback results come in correctly
                /// <summary>
                /// Creates the specified node in Wwsise
                /// </summary>
                /// <param name="parent">The GUID or path of the parent to the new object.</param>
                /// <param name="type">The type of the new object. See Wwise Objects Reference at audiokinetic.com</param>
                /// <param name="name">The name of the new object.</param>
                /// <param name="onNameConflict">The action to take on a name conflict.</param>
                /// <param name="platform">The GUID or path of the platform to use.  Default uses all linked platforms.</param>
                /// <param name="notes">Notes to add to the object.</param>
                /// <param name="children">A list of child objects to be created below the new object.</param>
                /// <returns></returns>
                public static Dictionary<string, object> Create(string parent, string type, string name,
                    WwiseValues.OnNameConflict onNameConflict = WwiseValues.OnNameConflict.fail, string platform = null, string notes = null,
                    string[] children = null)
                {

                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("parent", parent);
                    packet.keywordArguments.Add("type", type);
                    packet.keywordArguments.Add("name", name);
                    packet.keywordArguments.Add("onNameConflict", onNameConflict.ToString());
                    if (platform != null)
                        packet.keywordArguments.Add("platform", platform);
                    if (notes != null)
                        packet.keywordArguments.Add("notes", notes);
                    if (children != null)
                        packet.keywordArguments.Add("children", children);
                    packet.procedure = "ak.wwise.core.object.create";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                    return (Dictionary<string, object>)results;
                }

                /// <summary>
                /// Copies the specified node beneath the specified parent node.
                /// </summary>
                /// <param name="node">The node GUID.</param>
                /// <param name="parent">The parent GUID.</param>
                /// <param name="onNameConflict">What action to take on naming conflict.</param>
                /// <returns>Returns information on the moved node.</returns>
                public static Dictionary<string, object> Copy(string node, string parent,
                    WwiseValues.OnNameConflict onNameConflict = WwiseValues.OnNameConflict.fail)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", node);
                    packet.keywordArguments.Add("parent", parent);
                    if (onNameConflict != WwiseValues.OnNameConflict.fail)
                        packet.keywordArguments.Add("onNameConflict", onNameConflict.ToString());
                    packet.procedure = "ak.wwise.core.object.copy";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                    return (Dictionary<string, object>)results;
                }

                /// <summary>
                /// Moves the specified node to beneath the specified parent node.
                /// </summary>
                /// <param name="node">The node GUID.</param>
                /// <param name="parent">The parent GUID.</param>
                /// <param name="onNameConflict">What action to take on naming conflict.</param>
                /// <returns><Returns information on the moved node.</returns>
                public static Dictionary<string, object> Move(string node, string parent,
                    WwiseValues.OnNameConflict onNameConflict = WwiseValues.OnNameConflict.fail)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", node);
                    packet.keywordArguments.Add("parent", parent);
                    if (onNameConflict != WwiseValues.OnNameConflict.fail)
                        packet.keywordArguments.Add("onNameConflict", onNameConflict.ToString());
                    packet.procedure = "ak.wwise.core.object.move";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();

                    return (Dictionary<string, object>)results;
                }

                /// <summary>
                /// Deletes the specified node.
                /// </summary>
                /// <param name="node">The node GUID.</param>
                public static void Delete(string nodeID)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", nodeID);
                    packet.procedure = "ak.wwise.core.object.delete";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();

                }

                //!: Needs Testing
                /// <summary>
                /// Performs a query, returns specified data for each object in query result.
                /// </summary>
                /// <param name="get">The query starting point.</param>
                /// <param name="transform">Sequential transformations on object list returned by "get".</param>
                /// <returns></returns>
                //public static Dictionary<string, object> Get(WwiseValues.Get get, WwiseValues.GetTransform transform = null)
                //{
                //    if (packet.results != null)
                //        packet.results.Clear();
                //    Dictionary<string, object> getNodes = new Dictionary<string, object>();
                //    getNodes[get.type.ToString()] = get.objectArray;
                //    packet.keywordArguments.Add("from", getNodes);
                //    if (transform != null)
                //        packet.keywordArguments.Add(transform.type.ToString(), transform.objectArray);
                //    packet.procedure = "ak.wwise.core.object.get";
                //    packet.options.@return = returnValues2017_1_0_6302;
                //    results = connection.Execute(packet);
                //    packet.Clear();
                //    return (Dictionary<string, object>)results;
                //}

                /// <summary>
                /// Retrieves information about an object property.
                /// </summary>
                /// <param name="property">The name of the property to retrieve.</param>
                /// <param name="objectID">The ID (GUID) or path of the object.</param>
                /// <param name="classID">The ID (class ID) of the object to retrieve the property from.</param>
                public static Dictionary<string, object> GetPropertyInfo(string property, string objectID = "", int classID = 0)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    if (objectID != "")
                        packet.keywordArguments.Add("object", objectID);
                    if (classID != 0)
                        packet.keywordArguments.Add("classId", classID);
                    packet.keywordArguments.Add("property", property);
                    packet.procedure = "ak.wwise.core.object.getPropertyInfo";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                    return (Dictionary<string, object>)results;
                }

                //!: Needs Testing
                /// <summary>
                /// Gets the specified attenuation curve for a given attenuation object.
                /// </summary>
                /// <param name="objectID">	The ID (GUID) or path of attenuation object.</param>
                /// <param name="platformID">The ID (GUID) or path of the platform to get curves. Set to null-guid for unlinked reference.</param>
                /// <param name="curveType">The type of attenuation curve.</param>
                public static void GetAttenuationCurve(string objectID, string platformID, WwiseValues.CurveType curveType)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    packet.keywordArguments.Add("platform", platformID);
                    packet.keywordArguments.Add("curveType", curveType.ToString());
                    packet.procedure = "ak.wwise.core.object.getAttenuationCurve";
                    packet.callback = new Callback(packet);
                    results = connection.Execute(packet);
                    packet.Clear();
                }

                //!: Currently non-functioning
                //!: Needs Testing
                /// <summary>
                /// Retrieves the status of a property.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of the object to check.</param>
                /// <param name="platformID">The ID (GUID) or path of the platform to link the reference. Set to null-guid for unlinked reference.</param>
                /// <param name="property">The name of the property.</param>
                //public static Dictionary<string, object> IsPropertyEnabled(string objectID, string platformID, string property)
                //{
                //    if (packet.results != null)
                //        packet.results.Clear();
                //    packet.keywordArguments.Add("object", objectID);
                //    packet.keywordArguments.Add("platform", platformID);
                //    packet.keywordArguments.Add("property", property);
                //    packet.procedure = "ak.wwise.core.object.isPropertyEnabled";
                //    packet.callback = new Callback(packet);
                //    results = connection.Execute(packet);
                //    packet.Clear();
                //    return (Dictionary<string, object>)results;
                //}

                /// <summary>
                /// Gets the property names of the chosen node or node-type.
                /// </summary>
                /// <param name="node">The GUID of a project node.</param>
                /// <param name="classID">The class identifier of a node type.</param>
                /// <returns></returns>
                public static List<Dictionary<string, object>> GetPropertyNames(string node = null, int classID = 0)
                {
                    if (packet.results != null)
                        packet.results.Clear();

                    packet.procedure = "ak.wwise.core.object.getPropertyNames";
                    if (node != null)
                        packet.keywordArguments.Add("object", node);
                    if (classID != 0)
                        packet.keywordArguments.Add("classId", classID);
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();

                    return (List<Dictionary<string, object>>)packet.results;
                }

                internal static string[] typeReturnValues =
                {
                    "classId",
                    "name",
                    "type",
                };

                /// <summary>
                /// Gets a list of all object types.
                /// </summary>
                /// <returns></returns>
                public static List<Dictionary<string, object>> GetTypes()
                {
                    if (packet.results != null)
                        packet.results.Clear();

                    packet.procedure = "ak.wwise.core.object.getTypes";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                    return (List<Dictionary<string, object>>)packet.results;
                }

                //!: Needs testing
                /// <summary>
                /// Sets the specified attenuation curve for a given attenuation object.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of attenuation object.</param>
                /// <param name="platformID">The ID (GUID) or path of the platform to set curves. Set to null-guid for unlinked curve.</param>
                /// <param name="curveType">Type of attenuation curve.</param>
                /// <param name="pointsType">Defines if the curve has no points, has its own set of points, or uses those of the VolumeDryUsage curve.</param>
                /// <param name="curvePoints">An array of cure points.</param>
                public static void SetAttenuationCurve(string objectID, string platformID,
                    WwiseValues.CurveType curveType, WwiseValues.CurvePointsType pointsType,
                    WwiseValues.CurvePoint[] curvePoints)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    packet.keywordArguments.Add("platform", platformID);
                    packet.keywordArguments.Add("curveType", curveType.ToString());
                    packet.keywordArguments.Add("use", pointsType.ToString());
                    packet.keywordArguments.Add("points", curvePoints);
                    packet.procedure = "ak.wwise.core.object.setAttenuationCurve";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Renames an object.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of the object to rename.</param>
                /// <param name="name">The new name of the object.</param>
                public static void SetName(string objectID, string name)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    packet.keywordArguments.Add("value", name);
                    packet.procedure = "ak.wwise.core.object.setName";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Sets the object's notes.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of the object to set value.</param>
                /// <param name="notes">The new notes of the object.</param>
                public static void SetNotes(string objectID, string notes)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    packet.keywordArguments.Add("value", notes);
                    packet.procedure = "ak.wwise.core.object.setNotes";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                /// <summary>
                /// Sets a property value of an object for a specific platform.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of the object to set value.</param>
                /// <param name="property">The name of the property.</param>
                /// <param name="platformID">The ID (GUID) or path of the platform.</param>
                /// <param name="value">The value of the object.</param>
                public static void SetProperty(string objectID, string property, dynamic value,
                    string platformID = null)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    packet.keywordArguments.Add("property", property);
                    if (platformID != null)
                        packet.keywordArguments.Add("platform", platformID);
                    packet.keywordArguments.Add("value", value);
                    packet.procedure = "ak.wwise.core.object.setProperty";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }

                //!: Needs testing
                /// <summary>
                /// Sets an object's reference value.
                /// </summary>
                /// <param name="objectID">The ID (GUID) or path of the object which has the reference.</param>
                /// <param name="platformID">The ID (GUID) or path of the platform to link the reference. Set to null-guid for unlinked reference.</param>
                /// <param name="referenceName">The name of the reference to set.</param>
                /// <param name="referenceID">The ID (GUID) or path of the object to be referred to.</param>
                public static void SetReference(string objectID, string referenceID, string referenceName,
                    string platformID = null)
                {
                    if (packet.results != null)
                        packet.results.Clear();
                    packet.keywordArguments.Add("object", objectID);
                    if (platformID != null)
                        packet.keywordArguments.Add("platform", platformID);
                    packet.keywordArguments.Add("reference", referenceName);
                    packet.keywordArguments.Add("value", referenceID);
                    packet.procedure = "ak.wwise.core.object.setProperty";
                    packet.callback = new Callback(packet);
                    connection.Execute(packet);
                    packet.Clear();
                }
            }
        }
    }
}
