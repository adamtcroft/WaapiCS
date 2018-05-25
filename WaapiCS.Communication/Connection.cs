using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using WampSharp.Core.Serialization;
using WampSharp.V2;
using WampSharp.V2.Client;
using WampSharp.V2.Core.Contracts;
using WampSharp.V2.Rpc;
using System.Threading;

namespace WaapiCS.Communication
{
    /// <summary>
    /// The object that creates a connection to Wwise via WAAPI.
    /// </summary>
    public partial class Connection
    {
        // WAMP-related variables
        /// <summary>
        /// The IP and port address to connect to WAAPI.
        /// </summary>
        const string localhost = "ws://127.0.0.1:8080/waapi";
        public DefaultWampChannelFactory factory = new DefaultWampChannelFactory();
        public IWampChannel channel;
        public IWampRealmProxy realmProxy;
        public IWampTopicProxy topicProxy;
        private bool wwiseConnected = false;
        public static AutoResetEvent eventQueue = new AutoResetEvent(false);

        /// <summary>
        /// The object that creates a connection to Wwise via WAAPI.
        /// </summary>
        public Connection()
        {
            channel = factory.CreateJsonChannel(localhost, "realm1");
            channel.Open().Wait();
            realmProxy = channel.RealmProxy;

            while (wwiseConnected == false)
                TestPing();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Connection"/> class.
        /// </summary>
        ~Connection()
        {
            channel.Close();
        }

        /// <summary>
        /// Tests the ping to Wwise.
        /// </summary>
        public void TestPing()
        {
            if (realmProxy.Monitor.IsConnected)
                wwiseConnected = true;
        }
    }
}
