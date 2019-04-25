using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    public partial class SettingsForm : Form
    {
       
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            DateTime dt = MotivationForm.getAgeDate();
            dateTimePicker1.Value = dt;

        }
        private void saveKey()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\PHMotivationSetting");
            key.SetValue("birthday", dateTimePicker1.Text);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveKey();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.ShowScreenSaver();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
