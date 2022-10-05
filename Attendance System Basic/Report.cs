using System;
using System.Windows.Forms;
using System.IO;

namespace Attendance_System_Basic
{
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
            xGrid.Columns.Add("A", "Card-No");
            xGrid.Columns.Add("B", "User-ID");
            xGrid.Columns.Add("C", "First-Name");
            xGrid.Columns.Add("D", "Last-Name");
            xGrid.Columns.Add("E", "Email");
            xGrid.Columns.Add("F", "Phone-No");
            xGrid.Columns.Add("G", "Designation");
            xGrid.Columns.Add("H", "Time-In");
            xGrid.Columns.Add("I", "Status");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            xGrid.Rows.Clear();
            string check = cmbFilter.Text;

            if (cmbFilter == null)
            {
                MessageBox.Show("Please Filter Out According", "Filter Selection", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (check.Equals("Monthly"))
            {
                StreamReader SR = new StreamReader(@"Attendance/Monthly/" + DateTime.Now.ToString("MMM-yyyy") + ".txt");
                string xLine;
                string[] Arr;
                while (SR.EndOfStream != true)
                {
                    xLine = SR.ReadLine();
                    Arr = xLine.Split('#');
                    xGrid.Rows.Add(Arr[0], Arr[1], Arr[2], Arr[3], Arr[4], Arr[5], Arr[6], Arr[7], Arr[8]);
                }
            }
            else if (check.Equals("Yearly"))
            {
                StreamReader SR = new StreamReader(@"Attendance/Yearly/" + DateTime.Now.ToString("yyyy") + ".txt");
                string xLine;
                string[] Arr;
                while (SR.EndOfStream != true)
                {
                    xLine = SR.ReadLine();
                    Arr = xLine.Split('#');
                    xGrid.Rows.Add(Arr[0], Arr[1], Arr[2], Arr[3], Arr[4], Arr[5], Arr[6], Arr[7], Arr[8]);
                }
            }
            else if (check.Equals("None"))
            {
                MessageBox.Show("Please Filter Out According", "Filter Selection", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
