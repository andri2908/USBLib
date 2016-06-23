using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace USBLib
{
    public partial class Main : Form
    {
        public Main(string param)
        {
            InitializeComponent();

            if (param != "runAdmin")
            {
                MessageBox.Show("UNABLE TO RUN APPLICATION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void lockbtn_Click(object sender, EventArgs e)
        {
            // Create and name your button on form as lockbtn
            try
            {

                string path = "SYSTEM\\CurrentControlSet\\services\\USBSTOR\\";
                RegistryKey RK = Registry.LocalMachine.OpenSubKey(path, true);

                RK.SetValue("Start", "4", RegistryValueKind.DWord);
                status.Text = "Status : All Usb Ports Locked !";
            }
            catch (Exception ex)
            {

                MessageBox.Show(" Should be Run as Adminstrator", "Stop");

            }
        }

        private void unlockbtn_Click(object sender, EventArgs e)
        {
            //Name your unlock button as unlockbtn

            status.Text = "Status : All Usb Ports Unlocked !";
            string path = "SYSTEM\\CurrentControlSet\\services\\USBSTOR\\";
            RegistryKey RK = Registry.LocalMachine.OpenSubKey(path, true);

            RK.SetValue("Start", "3", RegistryValueKind.DWord);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            status.Text = "";
        }
    }
}