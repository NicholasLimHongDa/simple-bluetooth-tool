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

        private void BluetoothRefresh()
        {
            // Bluetoothデバイスの探索を行う。
            // 引数：
            // int maxDevices    : 探索するデバイスの最大数。指定の数で探索を打ち切る。
            // bool authenticated: trueだと認証済み（ペアリング済み）のデバイス、falseだと認証していないデバイスを結果に含める。
            // bool remembered   : trueだとホストに記録済みのデバイスのみを結果に含める（認証したことのあるデバイス以外無視すると同じ？）
            // bool unknown      : falseだと詳細のわからないデバイスを結果に含めない。

            // 未ペアリングのデバイスを探索し、結果を返す
            BluetoothDeviceInfo[] devices_nonpaired = bc.DiscoverDevices(32, false, false, true);
            // ペアリング済みのデバイスを探索し、結果を返す
            BluetoothDeviceInfo[] devices_paired = bc.DiscoverDevices(32, true, false, false);

            bindingSource_nonPair.DataSource = devices_nonpaired;
            bindingSource_Paired.DataSource = devices_paired;
            // ListBoxの設定
            listBoxNonPair.DisplayMember = "DeviceName";
            listBoxPaired.DisplayMember = "DeviceName";
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

        private void buttonPairing_Click(object sender, EventArgs e)
        {
            BluetoothDeviceInfo deviceInfo = (BluetoothDeviceInfo)listBoxNonPair.SelectedItem;
            if (deviceInfo != null)
            {
                Pairing(deviceInfo);
            }
        }
    }
}
