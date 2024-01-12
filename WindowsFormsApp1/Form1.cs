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

            // Services handler
            foreach (Guid serviceGuid in serviceGuidList)
            {
                try
                {
                    // Initializes the services broadcasted by the Bluetooth device
                    deviceInfo.SetServiceState(serviceGuid, true, true);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.Error.WriteLine(ex.StackTrace);
                }
            }

            return true;
        }

        private void BluetoothRefresh()
        {
            // Searches for nearby Bluetooth devices
            // Arguments：
            // int maxDevices    : Maximum number of discoverable devices
            // bool authenticated: True if you want to limit the search for devices that were paired before、otherwise false for unpaired devices
            // bool remembered   : True if you want to limit the search to devices that the host has recognized previously (unsure if it overrides 'authenticated')
            // bool unknown      : If this is false, ignores devices that do not broadcast details

            // Returns unpaired devices
            BluetoothDeviceInfo[] devices_nonpaired = bc.DiscoverDevices(32, false, false, true);
            // Returns paired devices
            BluetoothDeviceInfo[] devices_paired = bc.DiscoverDevices(32, true, false, false);

            notPairedBindingSource.DataSource = devices_nonpaired;
            pairedBindingSource.DataSource = devices_paired;

            // ListBox
            listBoxNonPair.DisplayMember = "DeviceName";
            listBoxPaired.DisplayMember = "DeviceName";
        }

        private void listBox_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonPairing_Click(object sender, EventArgs e)
        {
            BluetoothDeviceInfo deviceInfo = (BluetoothDeviceInfo)listBoxNonPair.SelectedItem;
            if (deviceInfo != null)
            {
                Pairing(deviceInfo);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            BluetoothRefresh();
        }
    }
}
