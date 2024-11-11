namespace JABBOUR_ProjetFinal
{
    partial class ControleJeu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControleJeu));
            this.timerInstruction = new System.Windows.Forms.Timer(this.components);
            this.lblInstruction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRetourne = new System.Windows.Forms.Button();
            this.lblInstructions2 = new System.Windows.Forms.Label();
            this.lblCache = new System.Windows.Forms.Label();
            this.instruction2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Instruction1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.instruction2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Instruction1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerInstruction
            // 
            this.timerInstruction.Enabled = true;
            this.timerInstruction.Interval = 1000;
            this.timerInstruction.Tick += new System.EventHandler(this.IntervaleInstructions1);
            // 
            // lblInstruction
            // 
            this.lblInstruction.BackColor = System.Drawing.Color.Black;
            this.lblInstruction.Font = new System.Drawing.Font("Adobe Arabic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.White;
            this.lblInstruction.Location = new System.Drawing.Point(250, 310);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(902, 120);
            this.lblInstruction.TabIndex = 2;
            this.lblInstruction.Text = "Appuyez sur les touches fléchées pour vous déplacer vers la gauche et la droite";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("SimSun", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(291, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(780, 67);
            this.label1.TabIndex = 4;
            this.label1.Text = "Astuces";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRetourne
            // 
            this.btnRetourne.BackColor = System.Drawing.Color.Black;
            this.btnRetourne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetourne.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourne.ForeColor = System.Drawing.Color.White;
            this.btnRetourne.Location = new System.Drawing.Point(534, 764);
            this.btnRetourne.Name = "btnRetourne";
            this.btnRetourne.Size = new System.Drawing.Size(359, 59);
            this.btnRetourne.TabIndex = 8;
            this.btnRetourne.Text = "Revenir en arrière";
            this.btnRetourne.UseVisualStyleBackColor = false;
            this.btnRetourne.Click += new System.EventHandler(this.btnRetourne_Click);
            this.btnRetourne.MouseLeave += new System.EventHandler(this.RevenirJeu_Leave);
            this.btnRetourne.MouseHover += new System.EventHandler(this.RevenirJeu_Hover);
            // 
            // lblInstructions2
            // 
            this.lblInstructions2.Font = new System.Drawing.Font("Adobe Arabic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions2.ForeColor = System.Drawing.Color.White;
            this.lblInstructions2.Location = new System.Drawing.Point(643, 421);
            this.lblInstructions2.Name = "lblInstructions2";
            this.lblInstructions2.Size = new System.Drawing.Size(428, 328);
            this.lblInstructions2.TabIndex = 9;
            this.lblInstructions2.Text = resources.GetString("lblInstructions2.Text");
            this.lblInstructions2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInstructions2.Visible = false;
            // 
            // lblCache
            // 
            this.lblCache.Location = new System.Drawing.Point(637, 367);
            this.lblCache.Name = "lblCache";
            this.lblCache.Size = new System.Drawing.Size(373, 41);
            this.lblCache.TabIndex = 10;
            this.lblCache.Visible = false;
            // 
            // instruction2
            // 
            this.instruction2.Image = ((System.Drawing.Image)(resources.GetObject("instruction2.Image")));
            this.instruction2.Location = new System.Drawing.Point(416, 367);
            this.instruction2.Name = "instruction2";
            this.instruction2.Size = new System.Drawing.Size(594, 362);
            this.instruction2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.instruction2.TabIndex = 5;
            this.instruction2.TabStop = false;
            this.instruction2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(302, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(736, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Instruction1
            // 
            this.Instruction1.Image = ((System.Drawing.Image)(resources.GetObject("Instruction1.Image")));
            this.Instruction1.Location = new System.Drawing.Point(416, 367);
            this.Instruction1.Name = "Instruction1";
            this.Instruction1.Size = new System.Drawing.Size(594, 362);
            this.Instruction1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Instruction1.TabIndex = 0;
            this.Instruction1.TabStop = false;
            // 
            // ControleJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.lblInstructions2);
            this.Controls.Add(this.lblCache);
            this.Controls.Add(this.btnRetourne);
            this.Controls.Add(this.instruction2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.Instruction1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ControleJeu";
            this.Text = "ControleJeu";
            ((System.ComponentModel.ISupportInitialize)(this.instruction2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Instruction1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Instruction1;
        private System.Windows.Forms.Timer timerInstruction;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox instruction2;
        private System.Windows.Forms.Button btnRetourne;
        private System.Windows.Forms.Label lblInstructions2;
        private System.Windows.Forms.Label lblCache;
    }
}