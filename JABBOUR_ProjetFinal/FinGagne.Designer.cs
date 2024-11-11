namespace JABBOUR_ProjetFinal
{
    partial class FinGagne
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinGagne));
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Demarrer = new System.Windows.Forms.Button();
            this.txtPoint = new System.Windows.Forms.Label();
            this.lblPointFinale = new System.Windows.Forms.Label();
            this.lblFinjeu = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(547, 693);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(280, 59);
            this.button4.TabIndex = 293;
            this.button4.Text = "Menu Principal";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(547, 769);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 59);
            this.button1.TabIndex = 292;
            this.button1.Text = "Contrôle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Controle_Click);
            // 
            // Demarrer
            // 
            this.Demarrer.BackColor = System.Drawing.Color.Black;
            this.Demarrer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Demarrer.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Demarrer.ForeColor = System.Drawing.Color.White;
            this.Demarrer.Location = new System.Drawing.Point(547, 615);
            this.Demarrer.Name = "Demarrer";
            this.Demarrer.Size = new System.Drawing.Size(280, 59);
            this.Demarrer.TabIndex = 291;
            this.Demarrer.Text = "Réessayer";
            this.Demarrer.UseVisualStyleBackColor = false;
            this.Demarrer.Click += new System.EventHandler(this.Reessayer_Click);
            // 
            // txtPoint
            // 
            this.txtPoint.BackColor = System.Drawing.Color.Transparent;
            this.txtPoint.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint.ForeColor = System.Drawing.Color.White;
            this.txtPoint.Location = new System.Drawing.Point(765, 492);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(275, 56);
            this.txtPoint.TabIndex = 289;
            this.txtPoint.Text = " 000000";
            this.txtPoint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPointFinale
            // 
            this.lblPointFinale.BackColor = System.Drawing.Color.Transparent;
            this.lblPointFinale.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointFinale.ForeColor = System.Drawing.Color.Red;
            this.lblPointFinale.Location = new System.Drawing.Point(251, 480);
            this.lblPointFinale.Name = "lblPointFinale";
            this.lblPointFinale.Size = new System.Drawing.Size(615, 68);
            this.lblPointFinale.TabIndex = 287;
            this.lblPointFinale.Text = "Pointage Final :";
            this.lblPointFinale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFinjeu
            // 
            this.lblFinjeu.BackColor = System.Drawing.Color.Transparent;
            this.lblFinjeu.Font = new System.Drawing.Font("Showcard Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinjeu.ForeColor = System.Drawing.Color.White;
            this.lblFinjeu.Location = new System.Drawing.Point(259, 285);
            this.lblFinjeu.Name = "lblFinjeu";
            this.lblFinjeu.Size = new System.Drawing.Size(874, 138);
            this.lblFinjeu.TabIndex = 286;
            this.lblFinjeu.Text = "Fin  du  Jeu";
            this.lblFinjeu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(547, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 285;
            this.pictureBox1.TabStop = false;
            // 
            // FinGagne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Demarrer);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.lblPointFinale);
            this.Controls.Add(this.lblFinjeu);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FinGagne";
            this.Text = "FinGagne";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Demarrer;
        private System.Windows.Forms.Label txtPoint;
        private System.Windows.Forms.Label lblPointFinale;
        private System.Windows.Forms.Label lblFinjeu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}