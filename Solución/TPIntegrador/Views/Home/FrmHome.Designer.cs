namespace TPIntegrador.Views.Home
{
    partial class FrmHome
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
            this.lstRents = new System.Windows.Forms.ListBox();
            this.txtSearcher = new System.Windows.Forms.TextBox();
            this.gHome = new System.Windows.Forms.GroupBox();
            this.btnEndRent = new System.Windows.Forms.Button();
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnConsoles = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnRents = new System.Windows.Forms.Button();
            this.gHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstRents
            // 
            this.lstRents.FormattingEnabled = true;
            this.lstRents.Location = new System.Drawing.Point(6, 42);
            this.lstRents.Name = "lstRents";
            this.lstRents.Size = new System.Drawing.Size(812, 472);
            this.lstRents.TabIndex = 0;
            this.lstRents.SelectedIndexChanged += new System.EventHandler(this.lstRents_SelectedIndexChanged);
            // 
            // txtSearcher
            // 
            this.txtSearcher.Location = new System.Drawing.Point(442, 19);
            this.txtSearcher.Name = "txtSearcher";
            this.txtSearcher.Size = new System.Drawing.Size(376, 20);
            this.txtSearcher.TabIndex = 1;
            this.txtSearcher.TextChanged += new System.EventHandler(this.txtSearcher_TextChanged);
            // 
            // gHome
            // 
            this.gHome.Controls.Add(this.btnEndRent);
            this.gHome.Controls.Add(this.lblLoggedUser);
            this.gHome.Controls.Add(this.btnUsers);
            this.gHome.Controls.Add(this.btnConsoles);
            this.gHome.Controls.Add(this.btnGames);
            this.gHome.Controls.Add(this.btnClients);
            this.gHome.Controls.Add(this.btnRents);
            this.gHome.Controls.Add(this.txtSearcher);
            this.gHome.Controls.Add(this.lstRents);
            this.gHome.Location = new System.Drawing.Point(13, 13);
            this.gHome.Name = "gHome";
            this.gHome.Size = new System.Drawing.Size(941, 524);
            this.gHome.TabIndex = 2;
            this.gHome.TabStop = false;
            this.gHome.Text = "Videoclub";
            // 
            // btnEndRent
            // 
            this.btnEndRent.Location = new System.Drawing.Point(824, 70);
            this.btnEndRent.Name = "btnEndRent";
            this.btnEndRent.Size = new System.Drawing.Size(111, 45);
            this.btnEndRent.TabIndex = 8;
            this.btnEndRent.Text = "Devolución";
            this.btnEndRent.UseVisualStyleBackColor = true;
            this.btnEndRent.Click += new System.EventHandler(this.btnEndRent_Click);
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.AutoSize = true;
            this.lblLoggedUser.Location = new System.Drawing.Point(7, 19);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(0, 13);
            this.lblLoggedUser.TabIndex = 7;
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(824, 274);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(111, 45);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "Usuarios";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnConsoles
            // 
            this.btnConsoles.Location = new System.Drawing.Point(824, 223);
            this.btnConsoles.Name = "btnConsoles";
            this.btnConsoles.Size = new System.Drawing.Size(111, 45);
            this.btnConsoles.TabIndex = 5;
            this.btnConsoles.Text = "Consolas";
            this.btnConsoles.UseVisualStyleBackColor = true;
            this.btnConsoles.Click += new System.EventHandler(this.btnConsoles_Click);
            // 
            // btnGames
            // 
            this.btnGames.Location = new System.Drawing.Point(824, 172);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(111, 45);
            this.btnGames.TabIndex = 4;
            this.btnGames.Text = "Juegos";
            this.btnGames.UseVisualStyleBackColor = true;
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);
            // 
            // btnClients
            // 
            this.btnClients.Location = new System.Drawing.Point(824, 121);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(111, 45);
            this.btnClients.TabIndex = 3;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnRents
            // 
            this.btnRents.Location = new System.Drawing.Point(824, 19);
            this.btnRents.Name = "btnRents";
            this.btnRents.Size = new System.Drawing.Size(111, 45);
            this.btnRents.TabIndex = 2;
            this.btnRents.Text = "Nuevo alquiler";
            this.btnRents.UseVisualStyleBackColor = true;
            this.btnRents.Click += new System.EventHandler(this.btnRents_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 549);
            this.Controls.Add(this.gHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.gHome.ResumeLayout(false);
            this.gHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstRents;
        private System.Windows.Forms.TextBox txtSearcher;
        private System.Windows.Forms.GroupBox gHome;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnConsoles;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnRents;
        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.Button btnEndRent;
    }
}