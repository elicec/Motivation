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
    public partial class MotivationForm : Form
    {
        Rectangle area;
        private string ageText;
        public static DateTime ageDateTime = DateTime.Now;
        public MotivationForm(Rectangle bounds)
        {
            InitializeComponent();
            this.Bounds = bounds;
            this.timer1.Tick += new System.EventHandler(this.tClockTick_Tick);
            area = Screen.FromControl(this).WorkingArea;
        }
        // Terminate app when user interacts
        private void MotivationForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Currently not wanted
        }

        private void MotivationForm_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void MotivationForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void updateLable(string age)
        {

            label1.Text = age;
        }

        private void tClockTick_Tick(object sender, EventArgs e)
        {
            label1.Text = Convert.ToDouble(ageForYears(ageDateTime)).ToString("f9");
        }
        private Double ageForYears(DateTime age)
        {
            DateTime currentTime = DateTime.Now;
            DateTime tmpTime = new DateTime(currentTime.Year, age.Month, age.Day);
            TimeSpan ts = currentTime.Subtract(tmpTime);
            Double years = ts.TotalMilliseconds / 1000 / 3600 / 24 / 365 + currentTime.Year - age.Year;
            return years;
        }
        public static DateTime getAgeDate()
        {
            string age = DateTime.Now.ToString();
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\PHMotivationSetting");
            try
            {
                // Registry-Settings
                age = (string)key.GetValue("birthday");

            }
            catch (Exception ex)
            {
                //MessageBox.Show("data error");
            }
            ageDateTime = Convert.ToDateTime(age);
            //MessageBox.Show(ageDt.ToString());
            return ageDateTime;
        }

        private void MotivationForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
            getAgeDate();
            label1.Location = new Point((this.Bounds.Width - label1.Width) / 2, (this.Bounds.Height-label1.Height) / 2);
        }
    }
}
