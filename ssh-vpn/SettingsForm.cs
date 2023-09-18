﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ssh_vpn
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string keyName = "ssh_vpn";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyName))
            {
                key.SetValue("ip", txt_ip.Text);
                key.SetValue("username", txt_username.Text);
                key.SetValue("password", txt_password.Text);
                MessageBox.Show("Successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // To read custom data from registry
            

            // Use the loadedData variable as needed in your program
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string keyName = "ssh_vpn";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName))
            {
                txt_ip.Text = key.GetValue("ip") as string;
                txt_username.Text = key.GetValue("username") as string;
                txt_password.Text = key.GetValue("password") as string;
            }
        }
    }
}