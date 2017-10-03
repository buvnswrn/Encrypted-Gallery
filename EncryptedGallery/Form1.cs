using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MaterialSkin.Controls;
using GalleryApplication;
using EncryptedGallery;

namespace ShanuImageFolderView
{

    public partial class Form1 : MaterialForm
    {
        String dpath,ppath,username;
            private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
            int locX = 20;
            int locY = 10;
            int sizeWidth = 30;
            int sizeHeight = 30;
        public Form1()
        {
            InitializeComponent();
            
        }
        public Form1(String uname,String path) {
            InitializeComponent();
            dpath = path;
            username = uname;
            DirectoryInfo Folder;
            FileInfo[] Images;


            if (dpath == null)
            {
                dpath = @"C:\Users\Bhuvanesh\Pictures\ToTest";
            }
                Folder = new DirectoryInfo(dpath);

                Images = Folder.GetFiles();

                pnControls.Controls.Clear();

                int locnewX = locX;
                int locnewY = locY;
                foreach (FileInfo img in Images)
                {

                    if (img.Extension.ToLower() == ".png" || img.Extension.ToLower() == ".jpg" || img.Extension.ToLower() == ".gif" || img.Extension.ToLower() == ".jpeg" || img.Extension.ToLower() == ".bmp" || img.Extension.ToLower() == ".tif")
                    {

                        if (locnewX >= pnControls.Width - sizeWidth - 10)
                        {
                            locnewX = locX;
                            locY = locY + sizeHeight + 30;
                            locnewY = locY;
                        }
                        else
                        {

                            locnewY = locY;
                        }

                        loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY);
                        locnewY = locY + sizeHeight + 10;
                        locnewX = locnewX + sizeWidth + 10;


                    }
                }
            


        }


        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo Folder;
            FileInfo[] Images;
            this.folderBrowserDlg.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDlg.ShowNewFolderButton = false;
            DialogResult result = this.folderBrowserDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                Folder = new DirectoryInfo(folderBrowserDlg.SelectedPath);
                Images = Folder.GetFiles();
                dpath = folderBrowserDlg.SelectedPath;
                pnControls.Controls.Clear();

                int locnewX = locX;
                int locnewY = locY;
                foreach (FileInfo img in Images)
                {

                    if (img.Extension.ToLower() == ".png" || img.Extension.ToLower() == ".jpg" || img.Extension.ToLower() == ".gif" || img.Extension.ToLower() == ".jpeg" || img.Extension.ToLower() == ".bmp" || img.Extension.ToLower() == ".tif")
                    {

                        if (locnewX >= pnControls.Width - sizeWidth - 10)
                        {
                            locnewX = locX;
                            locY = locY + sizeHeight + 30;
                            locnewY = locY;
                        }
                        else
                        {

                            locnewY = locY;
                        }

                        loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY);
                        locnewY = locY + sizeHeight + 10;
                        locnewX = locnewX + sizeWidth + 10;


                    }
                }
            
        }
           
        }

        private void loadImagestoPanel(String imageName,String ImageFullName,int newLocX,int newLocY)
        {
                ppath = ImageFullName;
            EncryptPicture h = new EncryptPicture();
                PictureBox ctrl = new PictureBox();
            //ctrl.Image = Image.FromFile(ImageFullName);
                ctrl.Image = h.byteArrayToImage(File.ReadAllBytes(ImageFullName));
                ctrl.BackColor = Color.Black;
                ctrl.Location = new Point(newLocX, newLocY);
                ctrl.Size = new System.Drawing.Size(sizeWidth, sizeHeight);
                ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
                ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                pnControls.Controls.Add(ctrl);

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            locX = 20;
            locY = 10;
            sizeWidth = 30;
            sizeHeight = 30;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {           
            locX = 20;
            locY = 10;
            sizeWidth = 30;
            sizeHeight = 30;
            if (pnControls.Controls.Count > 0)
            {
                loadControls();                
            }
         
        }

        private void loadControls()
        {
            int locnewX = locX;
            int locnewY = locY;

            foreach (Control p in pnControls.Controls)
            {
                if (locnewX >= pnControls.Width - sizeWidth - 10)
                {
                    locnewX = locX;
                    locY = locY + sizeHeight + 30;
                    locnewY = locY;
                }
                else
                {

                    locnewY = locY;
                }
                p.Location = new Point(locnewX, locnewY);
                p.Size = new System.Drawing.Size(sizeWidth, sizeHeight);

                locnewY = locY + sizeHeight + 10;
                locnewX = locnewX + sizeWidth + 10;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth =50;
            sizeHeight = 50;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 80;
            sizeHeight = 80;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 120;
            sizeHeight = 120;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
           
                Control control = (Control)sender;
                PictureBox pic = (PictureBox)control;
                pictureBox1.Image = pic.Image;
                
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pnControls.Width, pnControls.Height);
            pnControls.DrawToBitmap(bmp, new Rectangle(0, 0, pnControls.Width, pnControls.Height));
            SaveFileDialog dlg = new SaveFileDialog();
            // dlg.Filter = "JPG Files (*.JPG)|*.JPG";
            dlg.FileName = "*";
            dlg.DefaultExt = "bmp";
            dlg.ValidateNames = true;
            dlg.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dlg.FileName);
            }           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Closed += (s, args) => this.Close();
            l.Show();
        }

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            EncryptPicture en = new EncryptPicture(username,ppath,dpath);
            //EncryptPicture en = new EncryptPicture();
            en.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 160;
            sizeHeight = 160;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }
    }
}
