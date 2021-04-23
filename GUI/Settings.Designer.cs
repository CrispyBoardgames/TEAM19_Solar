namespace SD_GUI
{
    partial class Settings
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
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton_light = new System.Windows.Forms.RadioButton();
            this.radioButton_dark = new System.Windows.Forms.RadioButton();
            this.HomeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(299, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "Vacation Mode";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // radioButton_light
            // 
            this.radioButton_light.AutoSize = true;
            this.radioButton_light.Location = new System.Drawing.Point(145, 182);
            this.radioButton_light.Name = "radioButton_light";
            this.radioButton_light.Size = new System.Drawing.Size(122, 24);
            this.radioButton_light.TabIndex = 2;
            this.radioButton_light.TabStop = true;
            this.radioButton_light.Text = "Light Theme";
            this.radioButton_light.UseVisualStyleBackColor = true;
            this.radioButton_light.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton_dark
            // 
            this.radioButton_dark.AutoSize = true;
            this.radioButton_dark.Location = new System.Drawing.Point(145, 245);
            this.radioButton_dark.Name = "radioButton_dark";
            this.radioButton_dark.Size = new System.Drawing.Size(121, 24);
            this.radioButton_dark.TabIndex = 3;
            this.radioButton_dark.TabStop = true;
            this.radioButton_dark.Text = "Dark Theme";
            this.radioButton_dark.UseVisualStyleBackColor = true;
            this.radioButton_dark.CheckedChanged += new System.EventHandler(this.radioButton_dark_CheckedChanged);
            // 
            // HomeButton
            // 
            this.HomeButton.BackgroundImage = global::SD_GUI.Properties.Resources.homeicon;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HomeButton.Location = new System.Drawing.Point(12, 12);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(80, 69);
            this.HomeButton.TabIndex = 26;
            this.HomeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.radioButton_dark);
            this.Controls.Add(this.radioButton_light);
            this.Controls.Add(this.button1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton_light;
        private System.Windows.Forms.RadioButton radioButton_dark;
        private System.Windows.Forms.Button HomeButton;
    }
}