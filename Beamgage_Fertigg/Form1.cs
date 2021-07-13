using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamgage_Fertigg
{
    public partial class Form1 : Form
    {
        Runner test = new Runner();
        Hotspot test2 = new Hotspot();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            test2.Run();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            test2.schließen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test2.NewFrameFunction();




          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            test2.Path = eingabe.Text;
            pictureBox1.Image = Image.FromFile(test.Path);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }






        private void button5_Click(object sender, EventArgs e)
        {
            test2.picturemachen(100, 100);

            pictureBox1.Image = test2.Bitma;


         





        }

        private void KaltePixel_Click(object sender, EventArgs e)
        {
            test2.KaltePixelFinden();
            test2.HeißePixelFinden();
            test2.RichtigeFrameFunktionMitHundKPixeln();
        }

        private void HeißePixel_Click(object sender, EventArgs e)
        {
            //test2.NewFrameFunction();
          
            test2.getHotspot(7.38E-5, 0.2, 0.00000369, 0.00000369, 100, 100, 0.01);
            pictureBox1.Image = test2.Bitmaa;
           

           for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    listBox1.Items.Add(test2.GefiltertesBild[i,j]);
                }
               
            }
            //listBox1.Items.Add(test2.Hottspot);
            //listBox1.Items.Add(test2.ProzentualerAnteil);
        }
    }
}
    