using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Attendance_System_Basic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            attendnaceMarking1.BringToFront();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            attendanceRegistration1.BringToFront();
        }

        private void btnAttendanceMarking_Click(object sender, EventArgs e)
        {
            attendnaceMarking1.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            report1.BringToFront();
        }

        private void btnViewProfiles_Click(object sender, EventArgs e)
        {
            viewProfiles1.BringToFront();
        }

    }
}
