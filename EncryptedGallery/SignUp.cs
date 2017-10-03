using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptedGallery
{
    public partial class SignUp : MaterialForm
    {
        private String path,Pic_path;
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dig = new FolderBrowserDialog();
            dig.Description = "Select Your Default Folder";
            dig.ShowDialog();

            path = dig.SelectedPath;
            Path_TextBox.Text = path;

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bhuvanesh\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserTable (Username,Password,Path) Values ('" + uname.Text + "','" + pwd.Text + "','" + @path + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Hide();
                Login f = new Login();
                f.Closed += (s, args) => this.Close();
                f.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Closed += (s, args) => this.Close();
            l.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Title = "Select Image";
            dig.Filter = "JPEG files (*.jpeg)|*.jpeg|PNG Images(*.png)|*.png|GIF Images(*.gif)|*.gif|All files (*.*)|*.*";
            dig.ShowDialog();

            Pic_path = dig.FileName;
            picpath.Text = Pic_path;
        }
    }
}
