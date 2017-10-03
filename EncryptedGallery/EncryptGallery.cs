using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.IO;
using System.Drawing.Imaging;
using ImageEditor;
using MaterialSkin.Controls;
using ShanuImageFolderView;

namespace GalleryApplication
{
    
    public partial class EncryptPicture : MaterialForm
    {
        private Image Img,Img_Source;
        private String path=null,username=null,dpath;
        public EncryptPicture()
        {
            InitializeComponent();

            username = "img.jpg";
            path = @"C:\Users\Bhuvanesh\Pictures\ToTest\untitled - Copy.png";
            Path_TextBox.Text = path;
            checkimage(path);
        }
        public EncryptPicture(String name,String upath,String directory)
        {
            InitializeComponent();
            path = upath;
            username = "img.jpg";
            dpath = directory;
            Path_TextBox.Text = path;
            checkimage(path);
        }
    

        private void OpenButton_Click(object sender, EventArgs e)
        {
            opendialog();
            checkimage(path);
        }
        private void opendialog()
        {
            
            OpenFileDialog dig = new OpenFileDialog();
            dig.Title = "Select Image";
            dig.Filter = "JPEG files (*.jpeg)|*.jpeg|PNG Images(*.png)|*.png|GIF Images(*.gif)|*.gif|All files (*.*)|*.*";
            dig.ShowDialog();
            
            path = dig.FileName;
            Path_TextBox.Text = path;
            //Img_Source = byteArrayToImage(File.ReadAllBytes(path));
            
            
            

        }
        private void LoadImage()
        {
            int imgwidth = Img.Width;
            int imgheight = Img.Height;
            //View.Width = imgwidth;
            //View.Height = imgheight;
            View.Image = Img;
            imgwidth = Img_Source.Width;
            imgheight = Img_Source.Height;
            //Source_Image.Width = imgwidth;
            //Source_Image.Height = imgheight;
            Source_Image.Image = Img_Source;
        }
        private Image Encrypt(String path,Boolean write)
        {
            Image i;
            byte[] source = File.ReadAllBytes(path);
            byte[] keyimg = File.ReadAllBytes(@"..\..\"+username);
            byte[] desti= Combine(keyimg, source);
            if (write)
            {
                File.WriteAllBytes(path, desti);
            }
            i = byteArrayToImage(desti);
            return i;
        }
        private Image Decrypt(String path,Boolean write)
        {
            Image i;
            byte[] encimg = File.ReadAllBytes(path);
            byte[] keyimg = File.ReadAllBytes(@"..\..\img.jpg");
            byte[] decimg =Split(encimg,keyimg);
            if (write)
            {
                File.WriteAllBytes(path, decimg);
            }
            i = byteArrayToImage(decimg);
            return i;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private byte[] Combine(byte[] a,byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
        private byte[] Split(byte[] c,byte[] a)
        {
            byte[] b = new byte[c.Length-a.Length];
           System.Buffer.BlockCopy(c, a.Length, b, 0, c.Length-a.Length);
            return b;
        }

        private void Lock_Image_Click(object sender, EventArgs e)
        {
            checkimage(path);
        }

       

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkimage(path);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       

        private void encryptDecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkimage(path);
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Editor i = new Editor(path,username,dpath);
            i.Closed += (s, args) => this.Close();
            i.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            opendialog();
            checkimage(path);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Form1 f = new Form1(username,dpath);
            Form1 f = new Form1(username,dpath);
            f.Show();
        }

        private void Path_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public Boolean checkimage(String path)
        {
            try
            {
                Img_Source = byteArrayToImage(File.ReadAllBytes(path));
                status_label.Visible = true;
                if (isEncrypted(path))
                {
                    Lock.Text = "Image Decrypted";
                    Lock.Visible = true;
                    Img = Decrypt(path, true);
                    Lock_Image.Image = Image.FromFile(@"..\..\img\padlock-open.png");
                    Lock_Image.Visible = true;
                    
                }
                else
                {
                    Lock.Text = "Image Now Encrypted";
                    Lock.Visible = true;
                    Img = Encrypt(path, true);
                    Lock_Image.Image = Image.FromFile(@"..\..\img\padlock-close.png");
                    Lock_Image.Visible = true;
                }
                LoadImage();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public Boolean isEncrypted(String path)
        {
            byte[] source=File.ReadAllBytes(path);
            byte[] keyimg = File.ReadAllBytes(@"..\..\img.jpg"); 
            for(int i = 0; i < keyimg.Length; i++)
            {
                if (!(source[i] == keyimg[i]))
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}