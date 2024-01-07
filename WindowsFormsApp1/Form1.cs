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

        private bool Pairing(BluetoothDeviceInfo deviceInfo)
        {
            // Creates a paring request, and waits until a value is returned (signifying that the Task is complete)
            bool paired = BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, null);

            if (!paired)
            {
                return false;
            }

            deviceInfo = new BluetoothDeviceInfo(deviceInfo.DeviceAddress);

            // List object to store the services offered by the paired device
            List<Guid> serviceGuidList = new List<Guid>();
            // Gets the services info of the pairing device using L2Cap
            ServiceRecord[] serviceinfo = deviceInfo.GetServiceRecords(BluetoothService.L2CapProtocol);
            foreach (var record in serviceinfo)
            {
                // ServiceRecordUtilities.Dump(Console.Error, record);
                // Gets the ServiceDescription record from the detected services
                ServiceAttribute sdpRecord = record.GetAttributeById(InTheHand.Net.Bluetooth.AttributeIds.UniversalAttributeId.ServiceDescription);
                if (sdpRecord != null)
                {
                    serviceGuidList.Add(sdpRecord.Value.GetValueAsElementArray()[0].GetValueAsUuid());
                }
            }

            return true;
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
