namespace Back_Door_Adventures
{
    partial class HardLevel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.healthBox = new System.Windows.Forms.PictureBox();
            this.gameTimerLoop = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.healthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // healthBox
            // 
            this.healthBox.BackColor = System.Drawing.Color.Transparent;
            this.healthBox.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Health_Bar_Full_Green;
            this.healthBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.healthBox.Location = new System.Drawing.Point(6, 6);
            this.healthBox.Name = "healthBox";
            this.healthBox.Size = new System.Drawing.Size(80, 20);
            this.healthBox.TabIndex = 2;
            this.healthBox.TabStop = false;
            // 
            // gameTimerLoop
            // 
            this.gameTimerLoop.Enabled = true;
            this.gameTimerLoop.Interval = 18;
            this.gameTimerLoop.Tick += new System.EventHandler(this.gameTimerLoop_Tick);
            // 
            // HardLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Back_Door_Screen;
            this.Controls.Add(this.healthBox);
            this.DoubleBuffered = true;
            this.Name = "HardLevel";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.HardLevel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HardLevel_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HardLevel_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HardLevel_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.healthBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox healthBox;
        private System.Windows.Forms.Timer gameTimerLoop;
    }
}
