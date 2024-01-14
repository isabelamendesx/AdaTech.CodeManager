namespace AdaTech.CodeManager.Model
{
    partial class TasksByStatistics : BaseForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbTaskType = new Label();
            btnExit = new Guna.UI2.WinForms.Guna2Button();
            conteinerTasks = new FlowLayoutPanel();
            guna2GradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.Controls.Add(conteinerTasks);
            guna2GradientPanel1.Controls.Add(btnExit);
            guna2GradientPanel1.Controls.Add(lbTaskType);
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2GradientPanel1.Size = new Size(441, 501);
            // 
            // guna2AnimateWindow1
            // 
            guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_CENTER;
            // 
            // lbTaskType
            // 
            lbTaskType.AutoSize = true;
            lbTaskType.BackColor = Color.Red;
            lbTaskType.Font = new Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTaskType.ForeColor = Color.FromArgb(252, 239, 239);
            lbTaskType.Location = new Point(94, 68);
            lbTaskType.Name = "lbTaskType";
            lbTaskType.Size = new Size(238, 38);
            lbTaskType.TabIndex = 24;
            lbTaskType.Text = "Delayed Tasks";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.BorderRadius = 10;
            btnExit.CustomizableEdges = customizableEdges1;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.FillColor = Color.FromArgb(251, 152, 51);
            btnExit.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(385, 23);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnExit.Size = new Size(33, 31);
            btnExit.TabIndex = 25;
            btnExit.Text = "x";
            btnExit.Click += OnBtnExitClick;
            // 
            // conteinerTasks
            // 
            conteinerTasks.AutoScroll = true;
            conteinerTasks.BackColor = Color.FromArgb(27, 32, 46);
            conteinerTasks.ForeColor = Color.Coral;
            conteinerTasks.Location = new Point(53, 134);
            conteinerTasks.Name = "conteinerTasks";
            conteinerTasks.Size = new Size(385, 318);
            conteinerTasks.TabIndex = 50;
            // 
            // Tasks
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 521);
            Name = "Tasks";
            Text = "Tasks";
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbTaskType;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private FlowLayoutPanel conteinerTasks;
    }
}