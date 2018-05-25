using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMixer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Get connection status
            // if not connected, connect
            // TODO: Check if output emitter means individual object
            // TODO: Get listener ID
            ak.wwise.core.Object.SetProperty("{1514A4D8-1DA6-412A-A17E-75CA0C2149F3}", "BusVolume", "", trackBar1.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
