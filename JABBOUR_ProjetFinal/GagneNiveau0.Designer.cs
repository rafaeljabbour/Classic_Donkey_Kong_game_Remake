namespace JABBOUR_ProjetFinal
{
    partial class GagneNiveau0
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GagneNiveau0));
            this.lblNiveau = new System.Windows.Forms.Label();
            this.point = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.Label();
            this.prochainNiveau = new System.Windows.Forms.Timer(this.components);
            this.nbVie2 = new System.Windows.Forms.PictureBox();
            this.nbVie3 = new System.Windows.Forms.PictureBox();
            this.nbVie1 = new System.Windows.Forms.PictureBox();
            this.hauteur = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbVie2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbVie3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbVie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNiveau
            // 
            this.lblNiveau.BackColor = System.Drawing.Color.Transparent;
            this.lblNiveau.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNiveau.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblNiveau.Location = new System.Drawing.Point(1097, 9);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(275, 68);
            this.lblNiveau.TabIndex = 344;
            this.lblNiveau.Text = "Niveau : 1";
            this.lblNiveau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // point
            // 
            this.point.BackColor = System.Drawing.Color.Transparent;
            this.point.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.point.ForeColor = System.Drawing.Color.Red;
            this.point.Location = new System.Drawing.Point(1097, 73);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(275, 68);
            this.point.TabIndex = 338;
            this.point.Text = "Point";
            this.point.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPoint
            // 
            this.txtPoint.BackColor = System.Drawing.Color.Transparent;
            this.txtPoint.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint.ForeColor = System.Drawing.Color.White;
            this.txtPoint.Location = new System.Drawing.Point(1097, 141);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(275, 56);
            this.txtPoint.TabIndex = 337;
            this.txtPoint.Text = " 0";
            this.txtPoint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // prochainNiveau
            // 
            this.prochainNiveau.Enabled = true;
            this.prochainNiveau.Interval = 5000;
            this.prochainNiveau.Tick += new System.EventHandler(this.prochainNiveau_Tick);
            // 
            // nbVie2
            // 
            this.nbVie2.Image = ((System.Drawing.Image)(resources.GetObject("nbVie2.Image")));
            this.nbVie2.Location = new System.Drawing.Point(67, 12);
            this.nbVie2.Name = "nbVie2";
            this.nbVie2.Size = new System.Drawing.Size(49, 56);
            this.nbVie2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.nbVie2.TabIndex = 342;
            this.nbVie2.TabStop = false;
            // 
            // nbVie3
            // 
            this.nbVie3.Image = ((System.Drawing.Image)(resources.GetObject("nbVie3.Image")));
            this.nbVie3.Location = new System.Drawing.Point(122, 12);
            this.nbVie3.Name = "nbVie3";
            this.nbVie3.Size = new System.Drawing.Size(49, 56);
            this.nbVie3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.nbVie3.TabIndex = 341;
            this.nbVie3.TabStop = false;
            // 
            // nbVie1
            // 
            this.nbVie1.Image = ((System.Drawing.Image)(resources.GetObject("nbVie1.Image")));
            this.nbVie1.Location = new System.Drawing.Point(12, 12);
            this.nbVie1.Name = "nbVie1";
            this.nbVie1.Size = new System.Drawing.Size(49, 56);
            this.nbVie1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.nbVie1.TabIndex = 340;
            this.nbVie1.TabStop = false;
            // 
            // hauteur
            // 
            this.hauteur.BackColor = System.Drawing.Color.Transparent;
            this.hauteur.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hauteur.ForeColor = System.Drawing.Color.White;
            this.hauteur.Location = new System.Drawing.Point(431, 617);
            this.hauteur.Name = "hauteur";
            this.hauteur.Size = new System.Drawing.Size(53, 37);
            this.hauteur.TabIndex = 346;
            this.hauteur.Text = " 25";
            this.hauteur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(476, 518);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(466, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 345;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(373, 733);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(639, 45);
            this.label3.TabIndex = 348;
            this.label3.Text = "Jusqu\'où pouvez-vous aller ?";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GagneNiveau0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hauteur);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNiveau);
            this.Controls.Add(this.nbVie2);
            this.Controls.Add(this.nbVie3);
            this.Controls.Add(this.nbVie1);
            this.Controls.Add(this.point);
            this.Controls.Add(this.txtPoint);
            this.Name = "GagneNiveau0";
            this.Text = "GagneNiveau0";
            ((System.ComponentModel.ISupportInitialize)(this.nbVie2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbVie3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbVie1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNiveau;
        private System.Windows.Forms.PictureBox nbVie2;
        private System.Windows.Forms.PictureBox nbVie3;
        private System.Windows.Forms.PictureBox nbVie1;
        private System.Windows.Forms.Label point;
        private System.Windows.Forms.Label txtPoint;
        private System.Windows.Forms.Timer prochainNiveau;
        private System.Windows.Forms.Label hauteur;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}