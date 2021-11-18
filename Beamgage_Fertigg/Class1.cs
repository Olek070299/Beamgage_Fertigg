using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiricon.Automation;
using System.IO;
using System.Drawing;


namespace Beamgage_Fertigg
{
   public class Runner
    {
        private List<double> hpixel;
        public List<double> HPixel {
            get { return hpixel; }
            set { hpixel = value; }
        }
        private List<double> kpixel;
        public List<double> KPixel
        {
            get { return kpixel; }
            set { kpixel = value; }
        }


        private Bitmap bitma;
        public Bitmap Bitma
        {
            get { return bitma; }
            set { bitma = value; }
        }
        

        private string path = " ";
        public string Path
        {
            get { return path; }
            set { path = value; }
        }


        private double[] frameData;
        public double[] FrameData
        {
            get { return frameData; }
            set { frameData = value; }
        }


        private Bitmap bitmaaaaa;
        public Bitmap Bitmaaaaa
        {
            get { return bitmaaaaa; }
            set { bitmaaaaa = value; }
        }

        private double intensity;
        public double Intensity { get { return intensity; } set { intensity = value; } }



        // Declare the BeamGage Automation client
        private AutomatedBeamGage _bg;

        public void Run()
        {
            //Console.WriteLine("Press enter to exit.\n");
            // Start BeamGage Automation client
            _bg = new AutomatedBeamGage("ClientOne", true);

            //Console.Write("Ultracalling.... ");
            // Invoke an ultracal cycle




            _bg.Calibration.Ultracal();
            //Console.WriteLine("finished\n");

            // Create and register for the new frame event
            new AutomationFrameEvents(_bg.ResultsPriorityFrame).OnNewFrame += NewFrameFunction;
            // Console.Read();

            // Shutdown BeamGage
            //_bg.Instance.Shutdown();

        }

        public void schließen()
        {

            _bg.Instance.Shutdown();

        }

        /// <summary>
        /// This method is declared above as the delegate method for the OnNewFrame event
        /// Any actions here occur within the BeamGage data aqcuisition cycle
        /// To avoid blocking BeamGage, minimize actions here, or get data and push work to other threads.
        /// </summary>
        public void NewFrameFunction()
        {
            //Obtain the frame data and use it
            //Speichere Daten in frameData array
            frameData = _bg.ResultsPriorityFrame.DoubleData;
   
        }


            //Bild erstellen aus dem array fameData
           public void picturemachen(int hoehe,int breite)
        { 
            //Bitma= Bitmap 
            bitmaaaaa=new Bitmap(breite,hoehe);
            int i = 0;
            /*y läuft nach unten die höhe des Bildes ab und x die Breite, an die stelle x,y wird dann die Grauwertstufe eingesetzt, die beim Array frameData 
             * an der stelle i ist, i läuft das Array frame date vom ersten bis zum letzten Eintrag durch*/
            for (int y = 0; y < bitmaaaaa.Height; y++)
                {for (int x = 0; x < bitmaaaaa.Width; x++){

                    Color grauwertstufe = new Color();

                    grauwertstufe= Color.FromArgb(255,Convert.ToInt32(frameData[i]), Convert.ToInt32(frameData[i]), Convert.ToInt32(frameData[i]));
                   
                    bitmaaaaa.SetPixel(x, y, grauwertstufe);
                    i++;

                    



                }






            }
            
          

         


                    }

        public void KaltePixelFinden()

         /*Suche nach Kalten Pixel, dafür gesamte Kamera bescheinen lassen*/
        {
            kpixel = new List<double>();
            KPixel = new List<double>();
            for (int i = 0; i < frameData.Length; i++)
            {
                if (frameData[i] == 0)
                {
                    kpixel.Add(1);

                }
                else { kpixel.Add(0); }


           }
        }

        /*Suche heiße Pixel, dafür kamera verdunkeln*/
        public void HeißePixelFinden()
        {
            hpixel = new List<double>();
            HPixel = new List<double>();

            for (int i = 0; i < frameData.Length; i++)
            {
                if (frameData[i] == 255)
                {
                    hpixel.Add(1);
                }
                else { hpixel.Add(0); }

            }
        }
        /*Heiße und kalte Pixel durch den median der umliegenden Pixel ersetzen dafür haben wir die Positionen der heißen und kalten pixel in listen gespeichert
         und jetzt schauen wir wenn ein heißer oder kalter Pixel erkannt wird wird dieser ersetzt*/
        public void RichtigeFrameFunktionMitHundKPixeln()
        {
            for (int i = 0; i <= frameData.Length - 1; i++)
            {
                if (hpixel[i] == 1 || kpixel[i] == 1)
                {
                    if (i > 1 && i < frameData.Length - 2)
                    {
                        frameData[i] = (frameData[i - 2] + frameData[i - 1] + frameData[i + 1] + frameData[i + 2]) / 4;
                    }
                    else if (i <= 1)
                    {
                        frameData[i] = (frameData[i + 1] + frameData[i + 2] + frameData[i + 3] + frameData[i + 4]) / 4;
                    }
                    else if (i >= frameData.Length - 2)
                    {
                        frameData[i] = (frameData[i - 1] + frameData[i - 2] + frameData[i - 3] + frameData[i - 4]) / 4;
                    }



                }
                else { 
                
                
                }




            }



        }

        public void testbitmap()
        {
          
            Color grau = new Color();

            int n = 0;
           bitmaaaaa = new Bitmap(@"C:\Users\klobr\Downloads\62_0001.jpeg",true);
            frameData = new double[bitmaaaaa.Width * bitmaaaaa.Height];
            for(int i = 0; i < bitmaaaaa.Height; i++)
            {
                for(int j = 0; j < bitmaaaaa.Width; j++)
                {
                    grau = bitmaaaaa.GetPixel(j, i);
                    byte rot = grau.R;
                    byte grün = grau.G;
                    byte blau = grau.B;



                    intensity = Convert.ToDouble((0.999*rot+0.587*grün+0.114*blau)/3);
                    frameData[n] = intensity;
                    n++;

                    


                }
            }
            n = 0;
            for(int y = 0; y < bitmaaaaa.Height; y++)
            {
                for(int x = 0; x < bitmaaaaa.Width; x++)
                {
                    grau = Color.FromArgb(255, Convert.ToInt32(frameData[n]), Convert.ToInt32(frameData[n]), Convert.ToInt32(frameData[n]));
                    bitmaaaaa.SetPixel(x, y, grau);
                    n++;

                }
            }


        }

     
            }

            }

           
           

           



