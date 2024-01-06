using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BluetoothClient bc;
        BluetoothClient bcAsync;

        public Form1()
        {
            InitializeComponent();
            // Initializes a new BluetoothClient Object
            bc = new BluetoothClient();
            bcAsync = new BluetoothClient();
            // Sets the inquiry interval for paired devices
            bc.InquiryLength = new TimeSpan(0, 0, 5);
            bcAsync.InquiryLength = new TimeSpan(0, 0, 5);

            // BluetoothWin32Authentication authenticator = new BluetoothWin32Authentication(Win32AuthCallbackHandler);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
