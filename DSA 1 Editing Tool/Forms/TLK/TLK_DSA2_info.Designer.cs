namespace DSA_1_Editing_Tool.Forms.TLK
{
    partial class TLK_DSA2_info
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Allgemein_pB_DialogPartner = new System.Windows.Forms.PictureBox();
            this.tB_Allgemein_NAME = new System.Windows.Forms.TextBox();
            this.tB_Allgemein_TOLERANCE = new System.Windows.Forms.TextBox();
            this.tB_Allgemein_PIC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTOPICs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Allgemein_pB_DialogPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTOPICs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Allgemein_pB_DialogPartner);
            this.groupBox1.Controls.Add(this.tB_Allgemein_NAME);
            this.groupBox1.Controls.Add(this.tB_Allgemein_TOLERANCE);
            this.groupBox1.Controls.Add(this.tB_Allgemein_PIC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allgemeines";
            // 
            // Allgemein_pB_DialogPartner
            // 
            this.Allgemein_pB_DialogPartner.Location = new System.Drawing.Point(183, 19);
            this.Allgemein_pB_DialogPartner.Name = "Allgemein_pB_DialogPartner";
            this.Allgemein_pB_DialogPartner.Size = new System.Drawing.Size(48, 48);
            this.Allgemein_pB_DialogPartner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Allgemein_pB_DialogPartner.TabIndex = 6;
            this.Allgemein_pB_DialogPartner.TabStop = false;
            // 
            // tB_Allgemein_NAME
            // 
            this.tB_Allgemein_NAME.Location = new System.Drawing.Point(95, 75);
            this.tB_Allgemein_NAME.Name = "tB_Allgemein_NAME";
            this.tB_Allgemein_NAME.Size = new System.Drawing.Size(136, 20);
            this.tB_Allgemein_NAME.TabIndex = 5;
            // 
            // tB_Allgemein_TOLERANCE
            // 
            this.tB_Allgemein_TOLERANCE.Location = new System.Drawing.Point(95, 49);
            this.tB_Allgemein_TOLERANCE.Name = "tB_Allgemein_TOLERANCE";
            this.tB_Allgemein_TOLERANCE.Size = new System.Drawing.Size(56, 20);
            this.tB_Allgemein_TOLERANCE.TabIndex = 4;
            // 
            // tB_Allgemein_PIC
            // 
            this.tB_Allgemein_PIC.Location = new System.Drawing.Point(95, 23);
            this.tB_Allgemein_PIC.Name = "tB_Allgemein_PIC";
            this.tB_Allgemein_PIC.Size = new System.Drawing.Size(56, 20);
            this.tB_Allgemein_PIC.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TOLERANCE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PIC";
            // 
            // dgvTOPICs
            // 
            this.dgvTOPICs.AllowUserToAddRows = false;
            this.dgvTOPICs.AllowUserToDeleteRows = false;
            this.dgvTOPICs.AllowUserToResizeColumns = false;
            this.dgvTOPICs.AllowUserToResizeRows = false;
            this.dgvTOPICs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTOPICs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.dgvTOPICs.Location = new System.Drawing.Point(15, 127);
            this.dgvTOPICs.MultiSelect = false;
            this.dgvTOPICs.Name = "dgvTOPICs";
            this.dgvTOPICs.ReadOnly = true;
            this.dgvTOPICs.RowHeadersVisible = false;
            this.dgvTOPICs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTOPICs.Size = new System.Drawing.Size(166, 350);
            this.dgvTOPICs.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn13.HeaderText = "#";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 40;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.HeaderText = "TOPIC";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // TLK_DSA2_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTOPICs);
            this.Controls.Add(this.groupBox1);
            this.Name = "TLK_DSA2_info";
            this.Size = new System.Drawing.Size(769, 528);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Allgemein_pB_DialogPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTOPICs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tB_Allgemein_NAME;
        private System.Windows.Forms.TextBox tB_Allgemein_TOLERANCE;
        private System.Windows.Forms.TextBox tB_Allgemein_PIC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTOPICs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.PictureBox Allgemein_pB_DialogPartner;
    }
}
