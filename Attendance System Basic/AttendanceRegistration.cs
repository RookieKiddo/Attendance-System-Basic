using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Attendance_System_Basic
{
    public partial class AttendanceRegistration : UserControl
    {
        private string UserId;
        private int userId;
        private string PictureFileName;

        public AttendanceRegistration()
        {
            InitializeComponent();

            //Filling UserId and Date of registration Automatically//
            try
            {
                UserId = File.ReadAllText(@"Employee Info/UserId/UserId.txt");
                userId = int.Parse(UserId);
                txtUserId.Text = UserId;
                txtDateRegistration.Text = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp)";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                picBox.Image = new Bitmap(OFD.FileName);
                PictureFileName = OFD.FileName.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Checking If All Fields Are Complete or Not//
            if (txtFirstName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtFirstName.Focus();
            }
            else if (txtLastName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtLastName.Focus();
            }
            else if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEmail.Focus();
            }
            else if (txtPhone.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPhone.Focus();
            }
            else if (txtDesignation.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtDesignation.Focus();
            }
            else if (picBox.Image == null)
            {
                MessageBox.Show("Please Upload Image", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnUpload.Focus();
            }
            else if (txtPhone.TextLength > 11)
            {
                MessageBox.Show("Please Fill Valid Phone Number", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPhone.Focus();
            }
            else if (txtCardNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCardNo.Focus();
            }
            else
            {
                try
                {
                    File.Copy(PictureFileName, Path.Combine(@"Employee Info/Applicants/Applicant Photos/", txtUserId.Text+".PNG"), true);
                    StreamWriter SW = new StreamWriter(@"Employee Info/Applicants/" + txtCardNo.Text + ".txt");
                    SW.WriteLine(txtCardNo.Text);
                    SW.WriteLine(UserId);
                    SW.WriteLine(txtFirstName.Text);
                    SW.WriteLine(txtLastName.Text);
                    SW.WriteLine(txtEmail.Text);
                    SW.WriteLine(txtPhone.Text);
                    SW.WriteLine(txtDesignation.Text);
                    SW.Flush();
                    SW.Close();
                    StreamWriter SR = new StreamWriter(@"Employee Info/Applicants/AllData.txt",true);
                    SR.WriteLine(txtFirstName.Text + "#" + txtLastName.Text + "#" + txtCardNo.Text + "#" + UserId + "#" + txtEmail.Text + "#" + txtPhone.Text + "#" + txtDesignation.Text + "#" + txtDateRegistration.Text);
                    SR.Flush();
                    SR.Close();
                    userId++;
                    File.WriteAllText(@"Employee Info/UserId/UserId.txt", userId.ToString());
                    MessageBox.Show("Data Saved Succesfully", "Save Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFirstName.Text = txtLastName.Text = txtCardNo.Text = txtDesignation.Text = txtEmail.Text = txtPhone.Text = null;
                    UserId = File.ReadAllText(@"Employee Info/UserId/UserId.txt");
                    userId = int.Parse(UserId);
                    txtUserId.Text = UserId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

    }
}
