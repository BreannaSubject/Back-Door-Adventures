namespace Back_Door_Adventures
{
    partial class EasyLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyLevel));
            this.gameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.healthBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.healthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLoopTimer
            // 
            this.gameLoopTimer.Enabled = true;
            this.gameLoopTimer.Interval = 18;
            this.gameLoopTimer.Tick += new System.EventHandler(this.gameLoopTimer_Tick);
            // 
            // healthBox
            // 
            this.healthBox.BackColor = System.Drawing.Color.Transparent;
            this.healthBox.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Health_Bar_Full;
            this.healthBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.healthBox.Location = new System.Drawing.Point(3, 3);
            this.healthBox.Name = "healthBox";
            this.healthBox.Size = new System.Drawing.Size(80, 20);
            this.healthBox.TabIndex = 0;
            this.healthBox.TabStop = false;
            // 
            // EasyLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.healthBox);
            this.DoubleBuffered = true;
            this.Name = "EasyLevel";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.EasyLevel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EasyLevel_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EasyLevel_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EasyLevel_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.healthBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoopTimer;
        private System.Windows.Forms.PictureBox healthBox;
    }
}
