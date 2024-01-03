namespace AdaTech.CodeManager
{
    partial class KanbanBoard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KanbanBoard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnBack = new Guna.UI2.WinForms.Guna2ImageButton();
            conteinerBackLog = new FlowLayoutPanel();
            conteinerToDo = new FlowLayoutPanel();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            conteinerDoing = new FlowLayoutPanel();
            label2 = new Label();
            label5 = new Label();
            conteinerDone = new FlowLayoutPanel();
            label6 = new Label();
            conteinerReview = new FlowLayoutPanel();
            conteinerCancelled = new FlowLayoutPanel();
            label7 = new Label();
            btnCreateTask = new Guna.UI2.WinForms.Guna2Button();
            guna2GradientPanel1.SuspendLayout();
            guna2GradientPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.Controls.Add(btnCreateTask);
            guna2GradientPanel1.Controls.Add(label7);
            guna2GradientPanel1.Controls.Add(conteinerCancelled);
            guna2GradientPanel1.Controls.Add(label5);
            guna2GradientPanel1.Controls.Add(conteinerDone);
            guna2GradientPanel1.Controls.Add(label6);
            guna2GradientPanel1.Controls.Add(conteinerReview);
            guna2GradientPanel1.Controls.Add(label2);
            guna2GradientPanel1.Controls.Add(conteinerDoing);
            guna2GradientPanel1.Controls.Add(label4);
            guna2GradientPanel1.Controls.Add(label3);
            guna2GradientPanel1.Controls.Add(label1);
            guna2GradientPanel1.Controls.Add(conteinerToDo);
            guna2GradientPanel1.Controls.Add(conteinerBackLog);
            guna2GradientPanel1.Controls.Add(guna2GradientPanel3);
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2GradientPanel1.Size = new Size(1133, 629);
            // 
            // guna2AnimateWindow1
            // 
            guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_CENTER;
            // 
            // guna2GradientPanel3
            // 
            guna2GradientPanel3.BackColor = Color.FromArgb(27, 32, 46);
            guna2GradientPanel3.BorderColor = Color.Transparent;
            guna2GradientPanel3.BorderRadius = 30;
            guna2GradientPanel3.Controls.Add(btnBack);
            guna2GradientPanel3.CustomBorderColor = Color.White;
            guna2GradientPanel3.CustomizableEdges = customizableEdges10;
            guna2GradientPanel3.Dock = DockStyle.Left;
            guna2GradientPanel3.FillColor = Color.FromArgb(16, 20, 28);
            guna2GradientPanel3.FillColor2 = Color.FromArgb(16, 20, 28);
            guna2GradientPanel3.Location = new Point(20, 20);
            guna2GradientPanel3.Name = "guna2GradientPanel3";
            guna2GradientPanel3.ShadowDecoration.CustomizableEdges = customizableEdges11;
            guna2GradientPanel3.Size = new Size(68, 589);
            guna2GradientPanel3.TabIndex = 3;
            // 
            // btnBack
            // 
            btnBack.CheckedState.ImageSize = new Size(64, 64);
            btnBack.HoverState.ImageSize = new Size(64, 64);
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.ImageOffset = new Point(0, 0);
            btnBack.ImageRotate = 0F;
            btnBack.Location = new Point(6, 31);
            btnBack.Name = "btnBack";
            btnBack.PressedState.ImageSize = new Size(64, 64);
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges9;
            btnBack.Size = new Size(56, 51);
            btnBack.TabIndex = 3;
            // 
            // conteinerBackLog
            // 
            conteinerBackLog.BackColor = Color.FromArgb(27, 32, 46);
            conteinerBackLog.Location = new Point(107, 143);
            conteinerBackLog.Name = "conteinerBackLog";
            conteinerBackLog.Size = new Size(147, 456);
            conteinerBackLog.TabIndex = 4;
            // 
            // conteinerToDo
            // 
            conteinerToDo.BackColor = Color.FromArgb(27, 32, 46);
            conteinerToDo.Location = new Point(276, 143);
            conteinerToDo.Name = "conteinerToDo";
            conteinerToDo.Size = new Size(147, 456);
            conteinerToDo.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(27, 32, 46);
            label1.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(252, 239, 239);
            label1.Location = new Point(107, 42);
            label1.Name = "label1";
            label1.Size = new Size(287, 34);
            label1.TabIndex = 14;
            label1.Text = "Project Name Board";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(251, 152, 51);
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(252, 239, 239);
            label3.Location = new Point(127, 98);
            label3.Name = "label3";
            label3.Size = new Size(108, 28);
            label3.TabIndex = 15;
            label3.Text = "Backlog";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(83, 95, 253);
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(252, 239, 239);
            label4.Location = new Point(314, 98);
            label4.Name = "label4";
            label4.Size = new Size(76, 28);
            label4.TabIndex = 16;
            label4.Text = "To Do";
            // 
            // conteinerDoing
            // 
            conteinerDoing.BackColor = Color.FromArgb(27, 32, 46);
            conteinerDoing.Location = new Point(446, 143);
            conteinerDoing.Name = "conteinerDoing";
            conteinerDoing.Size = new Size(147, 456);
            conteinerDoing.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(27, 118, 142);
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(252, 239, 239);
            label2.Location = new Point(481, 98);
            label2.Name = "label2";
            label2.Size = new Size(80, 28);
            label2.TabIndex = 17;
            label2.Text = "Doing";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(83, 95, 253);
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(252, 239, 239);
            label5.Location = new Point(819, 98);
            label5.Name = "label5";
            label5.Size = new Size(73, 28);
            label5.TabIndex = 21;
            label5.Text = "Done";
            // 
            // conteinerDone
            // 
            conteinerDone.BackColor = Color.FromArgb(27, 32, 46);
            conteinerDone.Location = new Point(781, 143);
            conteinerDone.Name = "conteinerDone";
            conteinerDone.Size = new Size(147, 456);
            conteinerDone.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(251, 152, 51);
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(252, 239, 239);
            label6.Location = new Point(639, 98);
            label6.Name = "label6";
            label6.Size = new Size(94, 28);
            label6.TabIndex = 20;
            label6.Text = "Review";
            label6.Click += label6_Click;
            // 
            // conteinerReview
            // 
            conteinerReview.BackColor = Color.FromArgb(27, 32, 46);
            conteinerReview.Location = new Point(613, 143);
            conteinerReview.Name = "conteinerReview";
            conteinerReview.Size = new Size(147, 456);
            conteinerReview.TabIndex = 18;
            // 
            // conteinerCancelled
            // 
            conteinerCancelled.BackColor = Color.FromArgb(27, 32, 46);
            conteinerCancelled.Location = new Point(947, 143);
            conteinerCancelled.Name = "conteinerCancelled";
            conteinerCancelled.Size = new Size(147, 456);
            conteinerCancelled.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(27, 118, 142);
            label7.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(252, 239, 239);
            label7.Location = new Point(955, 98);
            label7.Name = "label7";
            label7.Size = new Size(134, 28);
            label7.TabIndex = 22;
            label7.Text = "Cancelled";
            // 
            // btnCreateTask
            // 
            btnCreateTask.BorderRadius = 10;
            btnCreateTask.CustomizableEdges = customizableEdges7;
            btnCreateTask.DisabledState.BorderColor = Color.DarkGray;
            btnCreateTask.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreateTask.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreateTask.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreateTask.FillColor = Color.FromArgb(251, 152, 51);
            btnCreateTask.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateTask.ForeColor = Color.White;
            btnCreateTask.Location = new Point(1059, 42);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCreateTask.Size = new Size(35, 34);
            btnCreateTask.TabIndex = 19;
            btnCreateTask.Text = "+";
            btnCreateTask.Click += OnBtnCreateTaskClick;
            // 
            // KanbanBoard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1153, 649);
            Name = "KanbanBoard";
            Text = "KanbanBoard";
            Load += KanbanBoard_Load;
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            guna2GradientPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2ImageButton btnBack;
        private FlowLayoutPanel conteinerToDo;
        private FlowLayoutPanel conteinerBackLog;
        private Label label1;
        private Label label3;
        private FlowLayoutPanel conteinerDoing;
        private Label label4;
        private Label label5;
        private FlowLayoutPanel conteinerDone;
        private Label label6;
        private FlowLayoutPanel conteinerReview;
        private Label label2;
        private FlowLayoutPanel conteinerCancelled;
        private Label label7;
        private Guna.UI2.WinForms.Guna2Button btnCreateTask;
    }
}