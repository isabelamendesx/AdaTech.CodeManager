namespace AdaTech.CodeManager
{
    partial class SelectTeam
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnCreateTeam = new Guna.UI2.WinForms.Guna2Button();
            conteinerTeams = new FlowLayoutPanel();
            label1 = new Label();
            lbSelectTeam = new Label();
            lbHello = new Label();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            guna2GradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.BackColor = Color.FromArgb(27, 32, 46);
            guna2GradientPanel1.BorderColor = Color.White;
            guna2GradientPanel1.Controls.Add(btnBack);
            guna2GradientPanel1.Controls.Add(btnCreateTeam);
            guna2GradientPanel1.Controls.Add(conteinerTeams);
            guna2GradientPanel1.Controls.Add(label1);
            guna2GradientPanel1.Controls.Add(lbSelectTeam);
            guna2GradientPanel1.Controls.Add(lbHello);
            guna2GradientPanel1.CustomizableEdges = customizableEdges5;
            guna2GradientPanel1.Dock = DockStyle.Fill;
            guna2GradientPanel1.Location = new Point(10, 10);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.Padding = new Padding(20);
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2GradientPanel1.Size = new Size(1133, 629);
            guna2GradientPanel1.TabIndex = 0;
            // 
            // btnCreateTeam
            // 
            btnCreateTeam.BorderRadius = 15;
            btnCreateTeam.CustomizableEdges = customizableEdges3;
            btnCreateTeam.DisabledState.BorderColor = Color.DarkGray;
            btnCreateTeam.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreateTeam.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreateTeam.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreateTeam.FillColor = Color.FromArgb(251, 152, 51);
            btnCreateTeam.Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreateTeam.ForeColor = Color.White;
            btnCreateTeam.Location = new Point(983, 238);
            btnCreateTeam.Name = "btnCreateTeam";
            btnCreateTeam.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCreateTeam.Size = new Size(58, 44);
            btnCreateTeam.TabIndex = 13;
            btnCreateTeam.Text = "+";
            btnCreateTeam.Click += OnBtnCreateTeamClick;
            // 
            // conteinerTeams
            // 
            conteinerTeams.Location = new Point(80, 307);
            conteinerTeams.Name = "conteinerTeams";
            conteinerTeams.Size = new Size(973, 170);
            conteinerTeams.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(80, 214);
            label1.Name = "label1";
            label1.Size = new Size(518, 68);
            label1.TabIndex = 6;
            label1.Text = "Here are your teams. \r\nWhich team would you like to acess?\r\n";
            // 
            // lbSelectTeam
            // 
            lbSelectTeam.AutoSize = true;
            lbSelectTeam.BackColor = Color.FromArgb(251, 152, 51);
            lbSelectTeam.Font = new Font("Century Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSelectTeam.ForeColor = Color.White;
            lbSelectTeam.Location = new Point(89, 166);
            lbSelectTeam.Name = "lbSelectTeam";
            lbSelectTeam.Size = new Size(281, 47);
            lbSelectTeam.TabIndex = 5;
            lbSelectTeam.Text = "Team Choice";
            // 
            // lbHello
            // 
            lbHello.AutoSize = true;
            lbHello.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbHello.ForeColor = Color.White;
            lbHello.Location = new Point(77, 111);
            lbHello.Name = "lbHello";
            lbHello.Size = new Size(0, 43);
            lbHello.TabIndex = 4;
            // 
            // btnBack
            // 
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges1;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.FromArgb(251, 152, 51);
            btnBack.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(80, 41);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBack.Size = new Size(92, 33);
            btnBack.TabIndex = 20;
            btnBack.Text = "back";
            btnBack.Click += OnBtnBackClick;
            // 
            // SelectTeam
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 20, 28);
            ClientSize = new Size(1153, 649);
            Controls.Add(guna2GradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SelectTeam";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectTeam";
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Label lbHello;
        private Label lbSelectTeam;
        private Label label1;
        private FlowLayoutPanel conteinerTeams;
        private Guna.UI2.WinForms.Guna2Button btnCreateTeam;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}