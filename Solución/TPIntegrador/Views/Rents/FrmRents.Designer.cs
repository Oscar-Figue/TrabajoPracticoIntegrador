namespace TPIntegrador.Views.Rents
{
    partial class FrmRents
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
            this.gRents = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGames = new System.Windows.Forms.ComboBox();
            this.cboClients = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gRents.SuspendLayout();
            this.SuspendLayout();
            // 
            // gRents
            // 
            this.gRents.Controls.Add(this.btnCancel);
            this.gRents.Controls.Add(this.btnAceptar);
            this.gRents.Controls.Add(this.cboClients);
            this.gRents.Controls.Add(this.cboGames);
            this.gRents.Controls.Add(this.label4);
            this.gRents.Controls.Add(this.label3);
            this.gRents.Location = new System.Drawing.Point(12, 12);
            this.gRents.Name = "gRents";
            this.gRents.Size = new System.Drawing.Size(429, 220);
            this.gRents.TabIndex = 0;
            this.gRents.TabStop = false;
            this.gRents.Text = "Alquileres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Juego:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cliente:";
            // 
            // cboGames
            // 
            this.cboGames.FormattingEnabled = true;
            this.cboGames.Location = new System.Drawing.Point(97, 48);
            this.cboGames.Name = "cboGames";
            this.cboGames.Size = new System.Drawing.Size(326, 21);
            this.cboGames.TabIndex = 4;
            // 
            // cboClients
            // 
            this.cboClients.FormattingEnabled = true;
            this.cboClients.Location = new System.Drawing.Point(97, 94);
            this.cboClients.Name = "cboClients";
            this.cboClients.Size = new System.Drawing.Size(326, 21);
            this.cboClients.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(105, 155);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(108, 47);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 155);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 47);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmRentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 243);
            this.Controls.Add(this.gRents);
            this.Name = "FrmRentsList";
            this.Text = "FrmRents";
            this.gRents.ResumeLayout(false);
            this.gRents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gRents;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboClients;
        private System.Windows.Forms.ComboBox cboGames;
    }
}