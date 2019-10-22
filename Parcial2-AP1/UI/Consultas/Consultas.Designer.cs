namespace Parcial2_AP1.UI.Consultas
{
    partial class Consultas
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DesdedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.HastadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FiltrocomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            this.Consultarbutton = new System.Windows.Forms.Button();
            this.ConsultadataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filtro";
            // 
            // DesdedateTimePicker
            // 
            this.DesdedateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.DesdedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DesdedateTimePicker.Location = new System.Drawing.Point(74, 9);
            this.DesdedateTimePicker.Name = "DesdedateTimePicker";
            this.DesdedateTimePicker.Size = new System.Drawing.Size(138, 26);
            this.DesdedateTimePicker.TabIndex = 3;
            // 
            // HastadateTimePicker
            // 
            this.HastadateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.HastadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HastadateTimePicker.Location = new System.Drawing.Point(276, 9);
            this.HastadateTimePicker.Name = "HastadateTimePicker";
            this.HastadateTimePicker.Size = new System.Drawing.Size(140, 26);
            this.HastadateTimePicker.TabIndex = 4;
            // 
            // FiltrocomboBox
            // 
            this.FiltrocomboBox.FormattingEnabled = true;
            this.FiltrocomboBox.Items.AddRange(new object[] {
            "Todos",
            "Id",
            "Estudiante"});
            this.FiltrocomboBox.Location = new System.Drawing.Point(472, 7);
            this.FiltrocomboBox.Name = "FiltrocomboBox";
            this.FiltrocomboBox.Size = new System.Drawing.Size(169, 28);
            this.FiltrocomboBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(647, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Criterio";
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Location = new System.Drawing.Point(712, 9);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(149, 26);
            this.CriteriotextBox.TabIndex = 7;
            // 
            // Consultarbutton
            // 
            this.Consultarbutton.Location = new System.Drawing.Point(870, 2);
            this.Consultarbutton.Name = "Consultarbutton";
            this.Consultarbutton.Size = new System.Drawing.Size(172, 37);
            this.Consultarbutton.TabIndex = 8;
            this.Consultarbutton.Text = "Consultar";
            this.Consultarbutton.UseVisualStyleBackColor = true;
            this.Consultarbutton.Click += new System.EventHandler(this.Consultarbutton_Click);
            // 
            // ConsultadataGridView
            // 
            this.ConsultadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultadataGridView.Location = new System.Drawing.Point(16, 55);
            this.ConsultadataGridView.Name = "ConsultadataGridView";
            this.ConsultadataGridView.RowHeadersWidth = 62;
            this.ConsultadataGridView.RowTemplate.Height = 28;
            this.ConsultadataGridView.Size = new System.Drawing.Size(1026, 499);
            this.ConsultadataGridView.TabIndex = 9;
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 566);
            this.Controls.Add(this.ConsultadataGridView);
            this.Controls.Add(this.Consultarbutton);
            this.Controls.Add(this.CriteriotextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FiltrocomboBox);
            this.Controls.Add(this.HastadateTimePicker);
            this.Controls.Add(this.DesdedateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Consultas";
            this.Text = "Consultas";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DesdedateTimePicker;
        private System.Windows.Forms.DateTimePicker HastadateTimePicker;
        private System.Windows.Forms.ComboBox FiltrocomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CriteriotextBox;
        private System.Windows.Forms.Button Consultarbutton;
        private System.Windows.Forms.DataGridView ConsultadataGridView;
    }
}