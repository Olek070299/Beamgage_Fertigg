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
    class Runner
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
            bitma=new Bitmap(breite,hoehe);
            int i = 0;
            /*y läuft nach unten die höhe des Bildes ab und x die Breite, an die stelle x,y wird dann die Grauwertstufe eingesetzt, die beim Array frameData 
             * an der stelle i ist, i läuft das Array frame date vom ersten bis zum letzten Eintrag durch*/
            for (int y = 0; y < bitma.Height; y++)
                {for (int x = 0; x < bitma.Width; x++){

                    Color grauwertstufe = new Color();

                    grauwertstufe= Color.FromArgb(255,Convert.ToInt32(frameData[i]), Convert.ToInt32(frameData[i]), Convert.ToInt32(frameData[i]));
                   
                    bitma.SetPixel(x, y, grauwertstufe);
                    i++;

                    



                }






            }
            
          

         


                    }

        public void KaltePixelFinden()

         
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

     
            }

            }

           
           

           



