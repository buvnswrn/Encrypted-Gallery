using GalleryApplication;
using MaterialSkin.Controls;
using ShanuImageFolderView;
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
    public partial class Login : MaterialForm
    {
        String path=null, username=null;
        public Login()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bhuvanesh\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd= new SqlCommand("SELECT Path FROM UserTable WHERE Username='" + uname.Text + "' AND Password='" + pwd.Text + "'", conn);
            SqlDataReader dt=cmd.ExecuteReader();
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            while(dt.Read())
            path = dt[0].ToString();
            
            username = uname.Text;
            //username = "img.png";
            path = path;
            if (!(path==null))
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                this.Hide();
                Form f = new Form1(username,path);
                f.Show();
                Console.Out.Write(path);
            }
            else
                MessageBox.Show("Invalid username or password");


        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp enc = new SignUp();
            enc.Closed += (s, args) => this.Close();
            enc.Show();
        }
    }
}
