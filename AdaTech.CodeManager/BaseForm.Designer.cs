namespace AdaTech.CodeManager
{
    partial class BaseForm
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
        protected void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.CustomizableEdges = customizableEdges1;
            guna2GradientPanel1.Dock = DockStyle.Fill;
            guna2GradientPanel1.FillColor = Color.FromArgb(27, 32, 46);
            guna2GradientPanel1.FillColor2 = Color.FromArgb(27, 32, 46);
            guna2GradientPanel1.Location = new Point(10, 10);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.Padding = new Padding(20);
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GradientPanel1.Size = new Size(1111, 573);
            guna2GradientPanel1.TabIndex = 0;
            // 
            // BaseForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(16, 20, 28);
            ClientSize = new Size(1131, 593);
            Controls.Add(guna2GradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BaseForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterPage";
            ResumeLayout(false);
        }

        #endregion

        protected Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        protected Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}