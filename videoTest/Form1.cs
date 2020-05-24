using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoTest
{
    public partial class Form1 : Form
    {
        Capture cap;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cap = new Capture("rtsp://"+txt_usuario.Text+":"+txt_contra.Text+"@"+txt_ip.Text+":"+txt_puerto.Text+"");
                cap.ImageGrabbed += ProcessFrame;
                cap.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            Mat image = new Mat();
            cap.Retrieve(image);
            imageBox1.BackgroundImage = image.Bitmap;
        }
    }
}
