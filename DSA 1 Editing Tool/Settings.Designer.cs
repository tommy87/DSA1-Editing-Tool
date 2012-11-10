namespace DSA_1_Editing_Tool
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbImages = new System.Windows.Forms.CheckBox();
            this.cbAnimations = new System.Windows.Forms.CheckBox();
            this.cbData = new System.Windows.Forms.CheckBox();
            this.btSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Was Laden?";
            // 
            // cbImages
            // 
            this.cbImages.AutoSize = true;
            this.cbImages.Location = new System.Drawing.Point(45, 43);
            this.cbImages.Name = "cbImages";
            this.cbImages.Size = new System.Drawing.Size(52, 17);
            this.cbImages.TabIndex = 1;
            this.cbImages.Text = "Bilder";
            this.cbImages.UseVisualStyleBackColor = true;
            // 
            // cbAnimations
            // 
            this.cbAnimations.AutoSize = true;
            this.cbAnimations.Location = new System.Drawing.Point(45, 66);
            this.cbAnimations.Name = "cbAnimations";
            this.cbAnimations.Size = new System.Drawing.Size(84, 17);
            this.cbAnimations.TabIndex = 2;
            this.cbAnimations.Text = "Animationen";
            this.cbAnimations.UseVisualStyleBackColor = true;
            // 
            // cbData
            // 
            this.cbData.AutoSize = true;
            this.cbData.Location = new System.Drawing.Point(45, 89);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(55, 17);
            this.cbData.TabIndex = 3;
            this.cbData.Text = "Daten";
            this.cbData.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(322, 193);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "Speichern";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 228);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.cbData);
            this.Controls.Add(this.cbAnimations);
            this.Controls.Add(this.cbImages);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbImages;
        private System.Windows.Forms.CheckBox cbAnimations;
        private System.Windows.Forms.CheckBox cbData;
        private System.Windows.Forms.Button btSave;
    }
}