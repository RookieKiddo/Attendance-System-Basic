using System;
using System.Windows.Forms;
using System.IO;

namespace Attendance_System_Basic
{
    public partial class ViewProfiles : UserControl
    {
        public ViewProfiles()
        {
            InitializeComponent();
            GetName();

            xGrid.Columns.Add("A", "User-ID");
            xGrid.Columns.Add("B", "Card-No");
            xGrid.Columns.Add("C", "First-Name");
        }

        private void GetName()
        {
            try
            {
                AutoCompleteStringCollection Arr = new AutoCompleteStringCollection();
                StreamReader SR = new StreamReader(@"E:\DHA SUFFA UNIVERSITY\Semester 2\Codings\Attendance System Basic\Attendance System Basic\bin\Debug\Employee Info\Applicants\AllData.txt");
                while (!SR.EndOfStream)
                {
                    Arr.Add(SR.ReadLine());
                }
                SR.Close();

                txtSearch.AutoCompleteCustomSource = Arr;
                txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string[] A = txtSearch.Text.Split('#');
                txtFirstName.Text = A[0];
                txtLastName.Text = A[1];
                txtCardNo.Text = A[2];
                txtUserId.Text = A[3];
                txtEmail.Text = A[4];
                txtPhone.Text = A[5];
                txtDesignation.Text = A[6];
                txtDateTime.Text = DateTime.Now.ToString();
                picBox.Load(@"Employee Info/Applicants/Applicant Photos/" + txtUserId.Text + ".PNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string[] A = txtSearch.Text.Split('#');
                    txtFirstName.Text = A[0];
                    txtLastName.Text = A[1];
                    txtCardNo.Text = A[2];
                    txtUserId.Text = A[3];
                    txtEmail.Text = A[4];
                    txtPhone.Text = A[5];
                    txtDesignation.Text = A[6];
                    txtDateTime.Text = DateTime.Now.ToString();
                    picBox.Load(@"Employee Info/Applicants/Applicant Photos/" + txtUserId.Text + ".PNG");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            xGrid.Rows.Clear();
            int count = 0;
            string xLine = null;
            string[] Arr;
            StreamReader SR = new StreamReader(@"Employee Info/Applicants/AllData.txt");
            while (SR.EndOfStream != true)
            {
                xLine = SR.ReadLine();
                Arr = xLine.Split('#');
                xGrid.Rows.Add(Arr[3], Arr[2], Arr[0]);
                count++;
            }
            SR.Close();
            lblTotalRecords.Text = "Total Records : " + count;
        }

        private void xGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cardNo = xGrid.CurrentRow.Cells[1].Value.ToString();
                StreamReader SR = new StreamReader(@"Employee Info/Applicants/" + cardNo + ".txt");
                txtCardNo.Text = SR.ReadLine();
                txtUserId.Text = SR.ReadLine();
                txtFirstName.Text = SR.ReadLine();
                txtLastName.Text = SR.ReadLine();
                txtEmail.Text = SR.ReadLine();
                txtPhone.Text = SR.ReadLine();
                txtDesignation.Text = SR.ReadLine();
                txtDateTime.Text = DateTime.Now.ToString();
                SR.Close();
                picBox.Load(@"Employee Info\Applicants\Applicant Photos\" + txtUserId.Text + ".PNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
