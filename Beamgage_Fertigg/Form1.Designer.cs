
namespace Beamgage_Fertigg
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.eingabe = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.FrameDatamithundkpixeln = new System.Windows.Forms.Button();
            this.HeißePixel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Beamgageoeffnen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Werteauslesen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 208);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 57);
            this.button3.TabIndex = 2;
            this.button3.Text = "Bildladen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 75);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 55);
            this.button4.TabIndex = 3;
            this.button4.Text = "Beamgageschließen";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(693, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 20);
            this.textBox1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(341, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 446);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(215, 10);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 420);
            this.listBox1.TabIndex = 6;
            // 
            // eingabe
            // 
            this.eingabe.Location = new System.Drawing.Point(8, 272);
            this.eingabe.Name = "eingabe";
            this.eingabe.Size = new System.Drawing.Size(81, 20);
            this.eingabe.TabIndex = 7;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(4, 298);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 60);
            this.button5.TabIndex = 8;
            this.button5.Text = "Bild_direkt_Laden";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FrameDatamithundkpixeln
            // 
            this.FrameDatamithundkpixeln.Location = new System.Drawing.Point(4, 374);
            this.FrameDatamithundkpixeln.Name = "FrameDatamithundkpixeln";
            this.FrameDatamithundkpixeln.Size = new System.Drawing.Size(92, 56);
            this.FrameDatamithundkpixeln.TabIndex = 9;
            this.FrameDatamithundkpixeln.Text = "FrameDatamithundkpixeln";
            this.FrameDatamithundkpixeln.UseVisualStyleBackColor = true;
            this.FrameDatamithundkpixeln.Click += new System.EventHandler(this.KaltePixel_Click);
            // 
            // HeißePixel
            // 
            this.HeißePixel.Location = new System.Drawing.Point(115, 13);
            this.HeißePixel.Name = "HeißePixel";
            this.HeißePixel.Size = new System.Drawing.Size(94, 56);
            this.HeißePixel.TabIndex = 10;
            this.HeißePixel.Text = "HeißePixel";
            this.HeißePixel.UseVisualStyleBackColor = true;
            this.HeißePixel.Click += new System.EventHandler(this.HeißePixel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HeißePixel);
            this.Controls.Add(this.FrameDatamithundkpixeln);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.eingabe);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox eingabe;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button FrameDatamithundkpixeln;
        private System.Windows.Forms.Button HeißePixel;
    }
}

