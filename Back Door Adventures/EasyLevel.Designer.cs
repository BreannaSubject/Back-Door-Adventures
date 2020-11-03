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
            this.SuspendLayout();
            // 
            // gameLoopTimer
            // 
            this.gameLoopTimer.Enabled = true;
            this.gameLoopTimer.Interval = 18;
            this.gameLoopTimer.Tick += new System.EventHandler(this.gameLoopTimer_Tick);
            // 
            // EasyLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.DoubleBuffered = true;
            this.Name = "EasyLevel";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.EasyLevel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EasyLevel_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EasyLevel_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EasyLevel_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoopTimer;
    }
}
