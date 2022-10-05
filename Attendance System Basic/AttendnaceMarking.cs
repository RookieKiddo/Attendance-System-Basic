using System;
using System.Windows.Forms;
using System.IO;

namespace Attendance_System_Basic
{
    public partial class AttendnaceMarking : UserControl
    {
        public AttendnaceMarking()
        {
            InitializeComponent();
            GetName();
        }        

        private void btnMark_Click(object sender, EventArgs e)
        {

            try
            {

                StreamReader SR = new StreamReader(@"Employee Info\Applicants\" + txtCardNo.Text + ".txt");
                SR.ReadLine();
                txtUserId.Text = SR.ReadLine();
                txtFirstName.Text = SR.ReadLine();
                txtLastName.Text = SR.ReadLine();
                txtEmail.Text = SR.ReadLine();
                txtPhone.Text = SR.ReadLine();
                txtDesignation.Text = SR.ReadLine();
                txtDateTime.Text = DateTime.Now.ToString();
                SR.Close();

                picBox.Load(@"Employee Info\Applicants\Applicant Photos\" + txtUserId.Text + ".PNG");

                StreamWriter SW = new StreamWriter(@"Attendance/Weekly/" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                SW.WriteLine(txtCardNo.Text + "#" + txtUserId.Text + "#" + txtFirstName.Text + "#" + txtLastName.Text + "#" + txtEmail.Text + "#" + txtPhone.Text + "#" + txtDesignation.Text + "#" + txtDateTime.Text + "#" + " Present");
                SW.Flush();
                SW.Close();

                StreamWriter SM = new StreamWriter(@"Attendance/Monthly/" + DateTime.Now.ToString("MMM-yyyy") + ".txt", true);
                SM.WriteLine(txtCardNo.Text + "#" + txtUserId.Text + "#" + txtFirstName.Text + "#" + txtLastName.Text + "#" + txtEmail.Text + "#" + txtPhone.Text + "#" + txtDesignation.Text + "#" + txtDateTime.Text + "#" + " Present");
                SM.Flush();
                SM.Close();

                StreamWriter SY = new StreamWriter(@"Attendance/Yearly/" + DateTime.Now.ToString("yyyy") + ".txt", true);
                SY.WriteLine(txtCardNo.Text + "#" + txtUserId.Text + "#" + txtFirstName.Text + "#" + txtLastName.Text + "#" + txtEmail.Text + "#" + txtPhone.Text + "#" + txtDesignation.Text + "#" + txtDateTime.Text + "#" + " Present");
                SY.Flush();
                SY.Close();

                MessageBox.Show("Attendance Marked Succesfully", "Marking Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    StreamReader SR = new StreamReader(@"Employee Info\Applicants\" + txtCardNo.Text + ".txt");
                    SR.ReadLine();
                    txtUserId.Text = SR.ReadLine();
                    txtFirstName.Text = SR.ReadLine();
                    txtLastName.Text = SR.ReadLine();
                    txtEmail.Text = SR.ReadLine();
                    txtPhone.Text = SR.ReadLine();
                    txtDesignation.Text = SR.ReadLine();
                    txtDateTime.Text = DateTime.Now.ToString();
                    SR.Close();

                    picBox.Load(@"Employee Info\Applicants\Applicant Photos\" + txtUserId.Text + ".PNG");

                    StreamWriter SW = new StreamWriter(@"Attendance/Weekly/" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    SW.WriteLine(txtCardNo.Text + "#" + txtUserId.Text + "#" + txtFirstName.Text + "#" + txtLastName.Text + "#" + txtEmail.Text + "#" + txtPhone.Text + "#" + txtDesignation.Text + "#" + txtDateTime.Text + "#" + " Present");
                    SW.Flush();
                    SW.Close();

                    StreamWriter SM = new StreamWriter(@"Attendance/Monthly/" + DateTime.Now.ToString("MMM-yyyy") + ".txt", true);
                    SM.WriteLine(txtCardNo.Text + "#" + txtUserId.Text + "#" + txtFirstName.Text + "#" + txtLastName.Text + "#" + txtEmail.Text + "#" + txtPhone.Text + "#" + txtDesignation.Text + "#" + txtDateTime.Text + "#" + " Present");
                    SM.Flush();
                    SM.Close();

                    StreamWriter SY = new StreamWriter(@"Attendance/Yearly/" + DateTime.Now.ToString("yyyy") + ".txt", true);
                    SY.WriteLine(txtCardNo.Text + "#" + txtUserId.Text + "#" + txtFirstName.Text + "#" + txtLastName.Text + "#" + txtEmail.Text + "#" + txtPhone.Text + "#" + txtDesignation.Text + "#" + txtDateTime.Text + "#" + " Present");
                    SY.Flush();
                    SY.Close();

                    MessageBox.Show("Attendance Marked Succesfully", "Marking Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
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

        private void txtSearch_KeyDown_1(object sender, KeyEventArgs e)
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
    }
}
