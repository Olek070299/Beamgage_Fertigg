using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;
namespace Beamgage_Fertigg
{


   public class Hotspot : Runner
    {
        private double prozentualerAnteil;

        public double ProzentualerAnteil { get { return prozentualerAnteil; } set { prozentualerAnteil = value; } }

        private double hottspot;

        public double Hottspot { get { return hottspot; } set { hottspot = value; } }



        private List<double> maskee;
        public List<double> Maskee
        {
            get { return maskee; }
            set { maskee = value; }
        }
        private List<double> pixelgenauigkeit;
        public List<double> Pixelgenauigkeit
        {
            get { return pixelgenauigkeit; }
            set { pixelgenauigkeit = value; }
        }
        private double[,] maske;
        public double[,] Maske
        {
            get { return maske; }
            set { maske = value; }
        }

        private double[,] xk;
        public double[,] Xk
        {
            get { return xk; }
            set { xk = value; }
        }
        private double[,] xks;
        public double[,] Xks
        {
            get { return xks; }
            set { xks = value; }
        }
        private double[,] yks;
        public double[,] Yks
        {
            get { return yks; }
            set { yks = value; }
        }

        private double[,] yk;
        public double[,] Yk
        {
            get { return yk; }
            set { yk = value; }
        }
        private double[,] ykentfernung;
        public double[,] Ykentfernung
        {
            get { return ykentfernung; }
            set { ykentfernung = value; }
        }
        private double[,] xkentfernung;
        public double[,] Xkentfernung
        {
            get { return xkentfernung; }
            set { xkentfernung = value; }
        }

        private double[,] vektorlaengen;
        public double[,] Vektorlaengen
        {
            get { return vektorlaengen; }
            set { vektorlaengen = value; }
        }

        private Bitmap bitmaa;

        public Bitmap Bitmaa
        {
            get { return bitmaa; }
            set { bitmaa = value; }
        }
        private double[,] xksentfernung;
        public double[,] Xksentfernung
        {
            get { return xksentfernung; }
            set { xksentfernung = value; }
        }
        private double[,] yksentfernung;
        public double[,] Yksentfernung
        {
            get { return yksentfernung; }
            set { yksentfernung = value; }
        }

        private double[,] vektorlaengensubpixel;
        public double[,] Vektorlaengensubpixel
        {
            get { return vektorlaengensubpixel; }
            set { vektorlaengensubpixel = value; }
        }

        private List<double> hotspots;
        public List<double> Hotspots
        {
            get { return hotspots; }
            set { hotspots = value; }
        }

        private double[,] gefiltertesbild;
        public double[,] GefiltertesBild
        {
            get { return gefiltertesbild; }
            set { gefiltertesbild = value; }
        }
        private double[,] framedatain2d;
        public double[,] Framedatain2d
        {
            get { return framedatain2d; }
            set { framedatain2d = value; }
        }
        private Bitmap bitmaaa;

        public Bitmap Bitmaaa
        {
            get { return bitmaaa; }
            set { bitmaaa = value; }
        }



        public void getHotspot(double empfangswinkel, double Bildabstand, double Pixelbreite, double Pixelhöhe, int hoeheBildinPixeln, int breiteBildinPixeln, double genauigkeitderSubpixel)
        {

            Color grauwert = new Color();
            //Berechne Durchmesser der Aperatur in m
            double DurchmesserAperatur = Bildabstand * empfangswinkel;
            //Berechne Durchmesser in Pixeln
            double DurchmesserinPixel = DurchmesserAperatur / (Pixelbreite);
            double zaehler;
            //Radius Kreis berechnen, für spätere Berechnungen
            double RadiusKreis = DurchmesserinPixel / 2;

            maskee = new List<double>();

            int durchmesser = Convert.ToInt32(DurchmesserinPixel);
            bitmaa = new Bitmap(durchmesser + 1, durchmesser + 1);
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            xk = new double[4, durchmesser * durchmesser];
            yk = new double[4, durchmesser * durchmesser];
            xkentfernung = new double[4, durchmesser * durchmesser];
            ykentfernung = new double[4, durchmesser * durchmesser];
            vektorlaengen = new double[4, durchmesser * durchmesser];
            pixelgenauigkeit = new List<double>();
            // xks= new double[durchmesser + 1, genauigkeitderSubpixel*genauigkeitderSubpixel];
            // yks=new double[durchmesser + 1, genauigkeitderSubpixel*genauigkeitderSubpixel];
            //Prüfen ob die Maske gerade oder ungerade ist, dass ist wichtig für die spätere Faltung

            //wenn maske gerade, füge eine spalte und zeile mit nullen an sodass sie ungerade wird.Wichtig für Faltung, da Faltung nur mit ungeraden Matrizen sinnvoll
            if (durchmesser % 2 == 0)
            {
                double[,] BeispielMaske = new double[durchmesser + 1, durchmesser + 1];

               
                for (int y = 0; y <= durchmesser; y++)
                {
                    for (int x = 0; x <= durchmesser; x++)
                    {

                        if (x == durchmesser && y == durchmesser)
                        {
                            BeispielMaske[x, y] = 0;

                        }
                        else if (x == durchmesser)
                        {
                            BeispielMaske[x, y] = 0;
                        }
                        else if (y == durchmesser)
                        {
                            BeispielMaske[x, y] = 0;
                        }

                    }
                }
                maske = BeispielMaske;
            }
            //Wenn Maske ungerade nichts verändern
            else
            {
                maske = new double[durchmesser, durchmesser];
            }


            //speicher die x-Koordinaten von den punkten a,b,c,d (bilden die Eckpunkte des Pixels )in einem 2d array
            int n = 0;
            double radius = (double)durchmesser / 2;
            for (int y = 0; y < durchmesser; y++)
            {
                for (int x = 0; x < durchmesser; x++)
                {
                    int m = 0;
                    a = x;
                    xk[m, n] = a;
                    m++;
                    b = x + 1;
                    xk[m, n] = b;
                    m++;
                    c = x;
                    xk[m, n] = c;
                    m++;
                    d = x + 1;
                    xk[m, n] = d;
                    n++;
                }
            }
            //speicher die y-Koordinaten von den punkten a,b,c,d (bilden die Eckpunkte des Pixels )in einem 2d array
            n = 0;
            for (int y = 0; y < durchmesser; y++)
            {
                for (int x = 0; x < durchmesser; x++)
                {
                    int m = 0;
                    a = y;
                    yk[m, n] = a;
                    m++;
                    b = y;
                    yk[m, n] = b;
                    m++;
                    c = y + 1;
                    yk[m, n] = c;
                    m++;
                    d = y + 1;
                    yk[m, n] = d;
                    n++;
                }
            }

            //Berechne aus den x-koordinaten der Eckpunkte die Entfernungen zur Mitte des Kreises mittels des Radius und speicher dieses Wieder in einem 2d array, wo einmal a,b,c,d und eren Entfernung zum mittelpunkt sind
            for (int y = 0; y < durchmesser * durchmesser; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                    if (xk[x, y] >= radius)
                    {
                        xkentfernung[x, y] = xk[x, y] - radius;
                    }
                    else
                    {
                        xkentfernung[x, y] = radius - xk[x, y];
                    }

                }
            }

            //Berechne aus den y-koordinaten der Eckpunkte die Entfernungen zur Mitte des Kreises mittels des Radius und speicher dieses Wieder in einem 2d array, wo einmal a,b,c,d und eren Entfernung zum mittelpunkt sind
            for (int y = 0; y < durchmesser * durchmesser; y++)
            {
                for (int x = 0; x <= 3; x++)
                {
                    if (yk[x, y] >= radius)
                    {
                        ykentfernung[x, y] = yk[x, y] - radius;
                    }
                    else
                    {
                        ykentfernung[x, y] = radius - yk[x, y];
                    }

                }
            }
            //Berechne die Länge des Vektores vom Mittelpunkt zu dem Punkt [x,y] 
            double laenge = 0;
            for (int y = 0; y < durchmesser * durchmesser; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    laenge = Math.Sqrt((xkentfernung[x, y] * xkentfernung[x, y]) + (ykentfernung[x, y] * ykentfernung[x, y]));
                    vektorlaengen[x, y] = laenge;
                }

            }
            /*Die vektorlängen der einzelnen Eckpunkte des Pixels werden in einer Tabelle gespeichert. Nun wird geschaut von dem 0 Pixel bis zu dem Letzten Pixel 
             ob alle 4 Eckpunkte eine länge haben, die kürzer ist als der Radius des Kreises,wenn alle 4 Eckpunkte eine Länge haben die länger ist als
            der Radius, wird der Pixel auf 0 gesetzt, wenn einer oder mehr, aber nicht alle, Eckpunkte innerhalb des Radius liegen, dann wird der 
            Pixel nochmal aufgeteilt in mehrere kleinere Pixel und der gesamte Vorgang wird wiederholt. Wenn alle Punkte im radius liegen
            WIrd der Pixel auf 1 gesettzt.*/
            for (int y = 0; y < durchmesser * durchmesser; y++)
            {
                int x = 0;
                a = vektorlaengen[x, y];
                x++;
                b = vektorlaengen[x, y];
                x++;
                c = vektorlaengen[x, y];
                x++;
                d = vektorlaengen[x, y];

                if (a <= radius && b <= radius && c <= radius && d <= radius)
                {
                    maskee.Add(1);
                }
                else if (a > radius && b > radius && c > radius && d > radius)
                {
                    maskee.Add(0);

                }
                else
                {
                    /*Erstellung von Subpixeln, die Anzahl der Subpixel kann mittels der Varible genauigkeitderSubpixel angepasst werden.
                     Setzt man z.b Genauigkeit der Subpixel auf 0,1 hätte man 11 Subpixel, da das Programm dann von zb 0 bis 1 läuft in 0,1 schritten*/ 
                    zaehler = 0;
                    x = 0;
                    double ax = xk[x, y];
                    double ay = yk[x, y];
                    double bx = xk[x + 1, y];
                    double cy = yk[x + 2, y];
                    /*zaehler initilisieren um die ANzahl an Subpixeln in x und y richtung zu bekommen*/
                    for (double s = ay; s <= cy; s += genauigkeitderSubpixel)
                    {
                        for (double w = ax; w <= bx; w += genauigkeitderSubpixel)
                        {
                            zaehler = zaehler + 1;
                        }

                    }
                    //defeinition der Tabellen, wo die x und y koordinaten der Subpixel gespeichert werden( 4 wegen den 4 Eckpunkten a,b,c,d und zaehler= Anzahl Subpixel)
                    xks = new double[4, Convert.ToInt32(zaehler)];
                    yks = new double[4, Convert.ToInt32(zaehler)];
                    xksentfernung = new double[4, Convert.ToInt32(zaehler)];
                    yksentfernung = new double[4, Convert.ToInt32(zaehler)];
                    vektorlaengensubpixel = new double[4, Convert.ToInt32(zaehler)];
                    /*Speichere die x koordinaten der einzelenen Pixel eckpunkte (a,b,c,d) in einer Tabelle für jeden Pixel*/
                    n = 0;
                    for (double s = ay; s <= cy; s += genauigkeitderSubpixel)
                    {
                        for (double w = ax; w <= bx; w += genauigkeitderSubpixel)
                        {

                            int m = 0;
                            a = w;
                            xks[m, n] = a;
                            m++;
                            b = w + genauigkeitderSubpixel;
                            xks[m, n] = b;
                            m++;
                            c = w;
                            xks[m, n] = c;
                            m++;
                            d = w + genauigkeitderSubpixel;
                            xks[m, n] = d;
                            n++;
                        }
                    }
                    /*Speichere die y koordinaten der einzelenen Pixel eckpunkte (a,b,c,d) in einer Tabelle für jeden Pixel*/
                    n = 0;
                    for (double s = ay; s <= cy; s += genauigkeitderSubpixel)
                    {
                        for (double w = ax; w <= bx; w += genauigkeitderSubpixel)
                        {
                            int m = 0;
                            a = s;
                            yks[m, n] = a;
                            m++;
                            b = s;
                            yks[m, n] = b;
                            m++;
                            c = s + genauigkeitderSubpixel;
                            yks[m, n] = c;
                            m++;
                            d = s + genauigkeitderSubpixel;
                            yks[m, n] = d;
                            n++;

                        }
                    }
                    /*Berechne für die Einzelenen Pixel, für die einzelen Eckpunkte, jeweils die Entfernung zur Mitte*/
                    for (int j = 0; j < zaehler; j++)
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            if (xks[i, j] >= radius)
                            {
                                xksentfernung[i, j] = xks[i, j] - radius;
                            }
                            else
                            {
                                xksentfernung[i, j] = radius - xks[i, j];
                            }

                        }
                    }
                    /*Berechne für die Einzelenen Pixel, für die einzelen Eckpunkte, jeweils die Entfernung zur Mitte*/
                    for (int j = 0; j < zaehler; j++)
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            if (yks[i, j] >= radius)
                            {
                                yksentfernung[i, j] = yks[i, j] - radius;
                            }
                            else
                            {
                                yksentfernung[i, j] = radius - yks[i, j];
                            }

                        }
                    }
                    /*Berechnen die Vektorlängen aus den x und y koordinaten abständen zur Mitte, wenn einer der Eckpunkte des Subpixels im Bereich des radius
                     ist, dann speichern eine 1 sonst eine 0, um den Wert des Gesamten Pixels zu bekommen wird das mit allen subpixeln gemacht und am ende 
                    den Prozentualen ANteil des Pixels zu berechnen*/
                    laenge = 0;
                    for (int j = 0; j < zaehler; j++)
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            laenge = Math.Sqrt((xksentfernung[i, j] * xksentfernung[i, j]) + (yksentfernung[i, j] * yksentfernung[i, j]));
                            vektorlaengensubpixel[i, j] = laenge;
                        }

                    }
                    for (int j = 0; j < zaehler; j++)
                    {
                        int i = 0;
                        a = vektorlaengensubpixel[i, j];
                        i++;
                        b = vektorlaengensubpixel[i, j];
                        i++;
                        c = vektorlaengensubpixel[i, j];
                        i++;
                        d = vektorlaengensubpixel[i, j];

                        if (a <= radius && b <= radius && c <= radius && d <= radius)
                        {
                            pixelgenauigkeit.Add(1);
                        }
                        else
                        {
                            pixelgenauigkeit.Add(0);

                        }
                    }
                    zaehler = 0;
                    for (int o = 0; o <= pixelgenauigkeit.Count - 1; o++)
                    {
                        if (pixelgenauigkeit[o] == 1) { zaehler = zaehler + 1; }
                        else { }
                    }
                    double ergebnis = (double)zaehler / (double)pixelgenauigkeit.Count;
                    maskee.Add(ergebnis);



                    pixelgenauigkeit.Clear();




                }

            }
            int f = 0;
            for (int y = 0; y < durchmesser; y++)
            {
                for (int x = 0; x < durchmesser; x++)
                {
                    maske[x, y] = maskee[f];
                    f++;
                }
            }


            bitmaaa = new Bitmap(Convert.ToInt32(DurchmesserinPixel), Convert.ToInt32(DurchmesserinPixel));

            for (int j = 0; j < durchmesser; j++)
            {
                for (int i = 0; i < durchmesser; i++)
                {
                    // grauwert=Color.FromArgb(255,Convert.ToInt32(maske[i, j]), Convert.ToInt32(maske[i, j]),  Convert.ToInt32(maske[i, j]));
                    // bitmaa.SetPixel(i, j, grauwert);

                    if (maske[i, j] == 1)
                    {
                        grauwert = Color.FromArgb(255,255, 255,255);
                        bitmaaa.SetPixel(i, j, grauwert);
                    }
                    else if (maske[i, j] == 0)
                    {
                        grauwert = Color.FromArgb(255, 0, 0, 0);
                        bitmaaa.SetPixel(i, j, grauwert);

                    }
                    else
                    {
                        grauwert = Color.FromArgb(255, 255, 0, 0);
                        bitmaaa.SetPixel(i, j, grauwert);
                    }


                }
            }






        


        //FrameDate in 2d array umwandeln für Faltung
        int h = 0;
            double[,] framedatain2d = new double[breiteBildinPixeln, hoeheBildinPixeln];
            
           // gefiltertesbild = new double[breiteBildinPixeln, hoeheBildinPixeln];
           /* double[] beispiel = new double[1000000];
            for(int i = 0; i < beispiel.Length; i++)
            {
                if (i == 5500) { beispiel[i] = 1; }
                else { beispiel[i] = 0; }
            }*/

           
           

            //Faltung
            //i und j sind die höhe und breite des Bildes(der Matrix)

            gefiltertesbild = new double[breiteBildinPixeln, hoeheBildinPixeln];
            int durchmesserinint = Convert.ToInt32(Math.Round(DurchmesserinPixel));
           double ö= (Math.Sqrt(maske.Length)) / 2;
            double elpunkt =  Math.Floor(ö);
            int mittelpunkt = Convert.ToInt32(elpunkt);

           
            int xmaske = Convert.ToInt32(Math.Sqrt(maske.Length));
            int ymaske = Convert.ToInt32(Math.Sqrt(maske.Length));

            double summe;
            int ix;
            int jy;
            framedatain2d = new double[breiteBildinPixeln, hoeheBildinPixeln];
            for(int y=0;y< hoeheBildinPixeln; y++)
            {
                for(int x=0;x< breiteBildinPixeln; x++)
                {

                    framedatain2d[x, y] = FrameData[h];
                    h++;


                }
            }


            /*if(FrameData.Length<maske.Length)
            {
                h = 0;
                framedatain2d = new double[xmaske, ymaske];
               
                for (int y = 0; y < ymaske; y++)
                {
                    for (int x = 0; x < xmaske; x++)
                    {
                        if (x < hoeheBildinPixeln && y < breiteBildinPixeln)
                        {
                            framedatain2d[x, y] = FrameData[h];
                            h++;
                        }
                        else
                        {
                            framedatain2d[x, y] = 0;
                        }

                    }
                }
            }
            else
            {
                h = 0;
                framedatain2d = new double[breiteBildinPixeln, hoeheBildinPixeln];
                for (int y = 0; y < hoeheBildinPixeln; y++)
                {
                    for (int x = 0; x < breiteBildinPixeln; x++)
                    {
                        framedatain2d[x, y] = FrameData[h];
                        h++;
                    }

                }

            }

            */


            int groesseMaske = Convert.ToInt32(Math.Sqrt(maske.Length));

            for (int j = 0; j < hoeheBildinPixeln; j++)
            {
                for (int i = 0; i < breiteBildinPixeln; i++)
                {
                    summe = 0;
                    //x und y laufen die Filtermaske ab, diese ist so groß, wie der Durchmesser des Kreises, den der empfangswinkel bildet
                    for (int y = 0; y < groesseMaske; y++)
                    {
                        for (int x = 0; x < groesseMaske; x++)
                        {

                            ix = i + x - mittelpunkt;
                            jy = j + y - mittelpunkt;
                            //Wenn ix und jy im bereich des Durchmessers liegen, summiere auf
                            /*ix und jy laufen um den wert von framedata der in der mitte liegt und multiplizieren diesen Wert mit den
                             Wert der an der Stelle x,y der maske liegt*/
                            if (ix < breiteBildinPixeln && ix >= 0 && jy >= 0 && jy < hoeheBildinPixeln)
                            {
                                summe = summe + framedatain2d[ix, jy] * maske[x, y];
                            }
                            else
                            {
                                summe = summe + 0;
                            }


                        }
                    }
                    //Der Wert an der stelle i,j ist gleich der Summe der Werte
                    gefiltertesbild[i, j] = summe;

                }
            }
            hotspots = new List<double>();
            //Durchlaufe das komplette array gefiltertes bild und speichere den größten wert=Hotspot
            hottspot = 0;
            for (int y = 0; y < hoeheBildinPixeln; y++)
            {
                for (int x = 0; x < breiteBildinPixeln; x++)
                {
                    hottspot = Math.Max(hottspot, gefiltertesbild[x, y]);

                }
            }
            //Prozentualen Anteil des Hotspots an gesamten Werten berechenn: Summiere alle werte von gefiltertes bild und dividiere hotspot dadurch
            ProzentualerAnteil = 0;
            double summegesamt = 0;
            for (int j = 0; j < hoeheBildinPixeln; j++)
            {
                for (int i = 0; i < breiteBildinPixeln; i++)
                {
                    summegesamt = summegesamt + gefiltertesbild[i, j];

                }
            }
            ProzentualerAnteil = hottspot / summegesamt;

            int z1 = 0;
            int z2 = 0;

            /*Um den Hotspot einzukreisen speichere die x und y koordinate in den Variablen z1 und z2, dann damit der Hotspot in der mitte liegt 
             Subtrahiere von der Koordinate den radius des kreises. der kreisdurchmesser ist der gleiche durchmesser wie die Maske*/
            for(int y = 0; y < hoeheBildinPixeln; y++)
            {
                for(int x = 0; x < breiteBildinPixeln; x++)
                {

                    if (gefiltertesbild[x, y] == hottspot) { z1 = x; z2 = y; }

                    else { }
                }
            }
            bitmaa = new Bitmap(breiteBildinPixeln, hoeheBildinPixeln);
            for (int y = 0; y < hoeheBildinPixeln; y++)
            {
                for (int x = 0; x < breiteBildinPixeln; x++)
                {
                    if (framedatain2d[x, y] !=0) {
                        grauwert = Color.FromArgb(255, Convert.ToInt32(framedatain2d[x,y]), Convert.ToInt32(framedatain2d[x, y]), Convert.ToInt32(framedatain2d[x, y]));
                            }
                    else { grauwert = Color.FromArgb(255,0, 0, 0); }

                    bitmaa.SetPixel(x, y, grauwert);
                }
            }
            
            
            Graphics g = Graphics.FromImage(bitmaa);
            Pen p = new Pen(Color.GreenYellow, 1);
            g.DrawEllipse(p, Convert.ToInt32(z1-RadiusKreis), Convert.ToInt32(z2-RadiusKreis), Convert.ToInt32(DurchmesserinPixel), Convert.ToInt32(DurchmesserinPixel));



                }


        














    }
}
          



    







