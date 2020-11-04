namespace Back_Door_Adventures
{
    partial class MediumLevel
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
            this.lightBox = new System.Windows.Forms.PictureBox();
            this.healthBox = new System.Windows.Forms.PictureBox();
            this.gameLoopTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lightBox
            // 
            this.lightBox.BackColor = System.Drawing.Color.Transparent;
            this.lightBox.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Blue_Easy_Light;
            this.lightBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lightBox.Location = new System.Drawing.Point(50, 25);
            this.lightBox.Name = "lightBox";
            this.lightBox.Size = new System.Drawing.Size(600, 20);
            this.lightBox.TabIndex = 0;
            this.lightBox.TabStop = false;
            // 
            // healthBox
            // 
            this.healthBox.BackColor = System.Drawing.Color.Transparent;
            this.healthBox.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Health_Bar_Full;
            this.healthBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.healthBox.Location = new System.Drawing.Point(3, 3);
            this.healthBox.Name = "healthBox";
            this.healthBox.Size = new System.Drawing.Size(80, 20);
            this.healthBox.TabIndex = 1;
            this.healthBox.TabStop = false;
            // 
            // gameLoopTimer
            // 
            this.gameLoopTimer.Enabled = true;
            this.gameLoopTimer.Interval = 18;
            this.gameLoopTimer.Tick += new System.EventHandler(this.gameLoopTimer_Tick);
            // 
            // MediumLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Easy_Background_Screen;
            this.Controls.Add(this.healthBox);
            this.Controls.Add(this.lightBox);
            this.DoubleBuffered = true;
            this.Name = "MediumLevel";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.MediumLevel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MediumLevel_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MediumLevel_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MediumLevel_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox lightBox;
        private System.Windows.Forms.PictureBox healthBox;
        private System.Windows.Forms.Timer gameLoopTimer;
    }
}
