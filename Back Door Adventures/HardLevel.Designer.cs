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
            this.healthBox = new System.Windows.Forms.PictureBox();
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
            // HardLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Back_Door_Screen;
            this.Controls.Add(this.healthBox);
            this.Name = "HardLevel";
            this.Size = new System.Drawing.Size(700, 400);
            ((System.ComponentModel.ISupportInitialize)(this.healthBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox healthBox;
    }
}
