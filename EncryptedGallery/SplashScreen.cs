using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptedGallery
{
    public partial class SplashScreen : Form
    {
        
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            /*for(int i = 0; i < 100; i++)
            {
                progress.Value = i;
                
            }*/
            tmr.Start();

            
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
           
                if (progress.Value < progress.Maximum)
                    progress.Increment(5);
                if(progress.Value==progress.Maximum)
            {
                tmr.Stop();
                this.Hide();
                Login enc = new Login();
                enc.Closed += (s, args) => this.Close();
                enc.Show();
            }
            
        }
    }
}
