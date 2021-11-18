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
            //test2.Path = @"C:\Users\klobr\Downloads\62_0001.jpeg";
            test2.testbitmap();
            pictureBox1.Image = test2.Bitmaaaaa;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }






        private void button5_Click(object sender, EventArgs e)
        {
            test2.picturemachen(100,100);

            pictureBox1.Image = test2.Bitmaaaaa;


         





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

            test2.getHotspot(1.7E-3, 0.2, 0.00000369, 0.00000369, test2.Bitmaaaaa.Height, test2.Bitmaaaaa.Width, 0.1);
            pictureBox1.Image = test2.Bitmaaaaa;

            /*for (int y = 0; y < 2; y++)
            {
                for (int i = 0; i < 2; i++)
                {
                    listBox1.Items.Add(test2.Maske[i, y]);
                }
            }*/

            /*for (int j = 0; j < test2.Bitmaaaaa.Height; j++)
            {
                for (int i = 0; i < test2.Bitmaaaaa.Width; i++)
                {
                    listBox1.Items.Add(test2.GefiltertesBild[i,j]);
                }
               
            }*/
            listBox1.Items.Add(test2.Hottspot);
            listBox1.Items.Add(test2.ProzentualerAnteil);
        }
    }
}
    