namespace Back_Door_Adventures
{
    partial class PlayScreen
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
            this.easyButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.hardButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.easyLabel = new System.Windows.Forms.Label();
            this.mediumLabel = new System.Windows.Forms.Label();
            this.hardLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // easyButton
            // 
            this.easyButton.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Back_Door;
            this.easyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.easyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyButton.ForeColor = System.Drawing.Color.Transparent;
            this.easyButton.Location = new System.Drawing.Point(45, 96);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(128, 200);
            this.easyButton.TabIndex = 0;
            this.easyButton.UseVisualStyleBackColor = true;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            this.easyButton.Enter += new System.EventHandler(this.easyButton_Enter);
            // 
            // mediumButton
            // 
            this.mediumButton.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Back_Door;
            this.mediumButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mediumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mediumButton.ForeColor = System.Drawing.Color.Transparent;
            this.mediumButton.Location = new System.Drawing.Point(207, 96);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(128, 200);
            this.mediumButton.TabIndex = 1;
            this.mediumButton.UseVisualStyleBackColor = true;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click);
            this.mediumButton.Enter += new System.EventHandler(this.mediumButton_Enter);
            // 
            // hardButton
            // 
            this.hardButton.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Back_Door;
            this.hardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hardButton.ForeColor = System.Drawing.Color.Transparent;
            this.hardButton.Location = new System.Drawing.Point(373, 96);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(128, 200);
            this.hardButton.TabIndex = 2;
            this.hardButton.UseVisualStyleBackColor = true;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            this.hardButton.Enter += new System.EventHandler(this.hardButton_Enter);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = global::Back_Door_Adventures.Properties.Resources.Back_Door;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.Transparent;
            this.exitButton.Location = new System.Drawing.Point(532, 96);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(128, 200);
            this.exitButton.TabIndex = 3;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            // 
            // easyLabel
            // 
            this.easyLabel.AutoSize = true;
            this.easyLabel.Font = new System.Drawing.Font("Vivaldi", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyLabel.Location = new System.Drawing.Point(76, 68);
            this.easyLabel.Name = "easyLabel";
            this.easyLabel.Size = new System.Drawing.Size(61, 25);
            this.easyLabel.TabIndex = 4;
            this.easyLabel.Text = "Easy";
            // 
            // mediumLabel
            // 
            this.mediumLabel.AutoSize = true;
            this.mediumLabel.Font = new System.Drawing.Font("Vivaldi", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumLabel.Location = new System.Drawing.Point(227, 68);
            this.mediumLabel.Name = "mediumLabel";
            this.mediumLabel.Size = new System.Drawing.Size(83, 25);
            this.mediumLabel.TabIndex = 5;
            this.mediumLabel.Text = "Medium";
            // 
            // hardLabel
            // 
            this.hardLabel.AutoSize = true;
            this.hardLabel.Font = new System.Drawing.Font("Vivaldi", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardLabel.Location = new System.Drawing.Point(407, 68);
            this.hardLabel.Name = "hardLabel";
            this.hardLabel.Size = new System.Drawing.Size(67, 25);
            this.hardLabel.TabIndex = 6;
            this.hardLabel.Text = "Hard";
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Vivaldi", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.Location = new System.Drawing.Point(567, 68);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(57, 25);
            this.exitLabel.TabIndex = 7;
            this.exitLabel.Text = "Exit";
            // 
            // PlayScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.hardLabel);
            this.Controls.Add(this.mediumLabel);
            this.Controls.Add(this.easyLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.Name = "PlayScreen";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.PlayScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label easyLabel;
        private System.Windows.Forms.Label mediumLabel;
        private System.Windows.Forms.Label hardLabel;
        private System.Windows.Forms.Label exitLabel;
    }
}
