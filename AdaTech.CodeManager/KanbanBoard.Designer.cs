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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnMenu = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            conteinerBackLog = new FlowLayoutPanel();
            conteinerToDo = new FlowLayoutPanel();
            label1 = new Label();
            lbBacklog = new Label();
            lbToDo = new Label();
            conteinerDoing = new FlowLayoutPanel();
            lbDoing = new Label();
            lbDone = new Label();
            conteinerDone = new FlowLayoutPanel();
            lbReview = new Label();
            conteinerReview = new FlowLayoutPanel();
            conteinerCancelled = new FlowLayoutPanel();
            lbCancelled = new Label();
            btnCreateTask = new Guna.UI2.WinForms.Guna2Button();
            btnEdit = new Guna.UI2.WinForms.Guna2Button();
            lbResult = new Label();
            guna2GradientPanel1.SuspendLayout();
            pnMenu.SuspendLayout();
            SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.Controls.Add(lbResult);
            guna2GradientPanel1.Controls.Add(btnEdit);
            guna2GradientPanel1.Controls.Add(btnCreateTask);
            guna2GradientPanel1.Controls.Add(lbCancelled);
            guna2GradientPanel1.Controls.Add(conteinerCancelled);
            guna2GradientPanel1.Controls.Add(lbDone);
            guna2GradientPanel1.Controls.Add(conteinerDone);
            guna2GradientPanel1.Controls.Add(lbReview);
            guna2GradientPanel1.Controls.Add(conteinerReview);
            guna2GradientPanel1.Controls.Add(lbDoing);
            guna2GradientPanel1.Controls.Add(conteinerDoing);
            guna2GradientPanel1.Controls.Add(lbToDo);
            guna2GradientPanel1.Controls.Add(lbBacklog);
            guna2GradientPanel1.Controls.Add(label1);
            guna2GradientPanel1.Controls.Add(conteinerToDo);
            guna2GradientPanel1.Controls.Add(conteinerBackLog);
            guna2GradientPanel1.Controls.Add(pnMenu);
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges9;
            guna2GradientPanel1.Size = new Size(1133, 629);
            // 
            // guna2AnimateWindow1
            // 
            guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_CENTER;
            // 
            // pnMenu
            // 
            pnMenu.BackColor = Color.Transparent;
            pnMenu.BorderColor = Color.Transparent;
            pnMenu.BorderRadius = 30;
            pnMenu.Controls.Add(btnBack);
            pnMenu.CustomBorderColor = Color.White;
            pnMenu.CustomizableEdges = customizableEdges7;
            pnMenu.Dock = DockStyle.Left;
            pnMenu.FillColor = Color.FromArgb(16, 20, 28);
            pnMenu.FillColor2 = Color.FromArgb(16, 20, 28);
            pnMenu.Location = new Point(20, 20);
            pnMenu.Name = "pnMenu";
            pnMenu.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnMenu.Size = new Size(68, 589);
            pnMenu.TabIndex = 3;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges5;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.FromArgb(251, 152, 51);
            btnBack.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(17, 40);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnBack.Size = new Size(35, 34);
            btnBack.TabIndex = 23;
            btnBack.Text = "<";
            btnBack.Click += OnBtnBackClick;
            // 
            // conteinerBackLog
            // 
            conteinerBackLog.BackColor = Color.Transparent;
            conteinerBackLog.Location = new Point(107, 143);
            conteinerBackLog.Name = "conteinerBackLog";
            conteinerBackLog.Size = new Size(147, 456);
            conteinerBackLog.TabIndex = 4;
            // 
            // conteinerToDo
            // 
            conteinerToDo.BackColor = Color.Transparent;
            conteinerToDo.Location = new Point(276, 143);
            conteinerToDo.Name = "conteinerToDo";
            conteinerToDo.Size = new Size(147, 456);
            conteinerToDo.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(252, 239, 239);
            label1.Location = new Point(107, 42);
            label1.Name = "label1";
            label1.Size = new Size(287, 34);
            label1.TabIndex = 14;
            label1.Text = "Project Name Board";
            // 
            // lbBacklog
            // 
            lbBacklog.AutoSize = true;
            lbBacklog.BackColor = Color.FromArgb(251, 152, 51);
            lbBacklog.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbBacklog.ForeColor = Color.FromArgb(252, 239, 239);
            lbBacklog.Location = new Point(127, 98);
            lbBacklog.Name = "lbBacklog";
            lbBacklog.Size = new Size(108, 28);
            lbBacklog.TabIndex = 15;
            lbBacklog.Text = "Backlog";
            // 
            // lbToDo
            // 
            lbToDo.AutoSize = true;
            lbToDo.BackColor = Color.FromArgb(83, 95, 253);
            lbToDo.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbToDo.ForeColor = Color.FromArgb(252, 239, 239);
            lbToDo.Location = new Point(314, 98);
            lbToDo.Name = "lbToDo";
            lbToDo.Size = new Size(76, 28);
            lbToDo.TabIndex = 16;
            lbToDo.Text = "To Do";
            // 
            // conteinerDoing
            // 
            conteinerDoing.BackColor = Color.Transparent;
            conteinerDoing.Location = new Point(446, 143);
            conteinerDoing.Name = "conteinerDoing";
            conteinerDoing.Size = new Size(147, 456);
            conteinerDoing.TabIndex = 6;
            // 
            // lbDoing
            // 
            lbDoing.AutoSize = true;
            lbDoing.BackColor = Color.FromArgb(27, 118, 142);
            lbDoing.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDoing.ForeColor = Color.FromArgb(252, 239, 239);
            lbDoing.Location = new Point(481, 98);
            lbDoing.Name = "lbDoing";
            lbDoing.Size = new Size(80, 28);
            lbDoing.TabIndex = 17;
            lbDoing.Text = "Doing";
            // 
            // lbDone
            // 
            lbDone.AutoSize = true;
            lbDone.BackColor = Color.FromArgb(83, 95, 253);
            lbDone.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDone.ForeColor = Color.FromArgb(252, 239, 239);
            lbDone.Location = new Point(819, 98);
            lbDone.Name = "lbDone";
            lbDone.Size = new Size(73, 28);
            lbDone.TabIndex = 21;
            lbDone.Text = "Done";
            // 
            // conteinerDone
            // 
            conteinerDone.BackColor = Color.Transparent;
            conteinerDone.Location = new Point(781, 143);
            conteinerDone.Name = "conteinerDone";
            conteinerDone.Size = new Size(147, 456);
            conteinerDone.TabIndex = 19;
            // 
            // lbReview
            // 
            lbReview.AutoSize = true;
            lbReview.BackColor = Color.FromArgb(251, 152, 51);
            lbReview.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbReview.ForeColor = Color.FromArgb(252, 239, 239);
            lbReview.Location = new Point(639, 98);
            lbReview.Name = "lbReview";
            lbReview.Size = new Size(94, 28);
            lbReview.TabIndex = 20;
            lbReview.Text = "Review";
            // 
            // conteinerReview
            // 
            conteinerReview.BackColor = Color.Transparent;
            conteinerReview.Location = new Point(613, 143);
            conteinerReview.Name = "conteinerReview";
            conteinerReview.Size = new Size(147, 456);
            conteinerReview.TabIndex = 18;
            // 
            // conteinerCancelled
            // 
            conteinerCancelled.BackColor = Color.Transparent;
            conteinerCancelled.Location = new Point(947, 143);
            conteinerCancelled.Name = "conteinerCancelled";
            conteinerCancelled.Size = new Size(147, 456);
            conteinerCancelled.TabIndex = 20;
            // 
            // lbCancelled
            // 
            lbCancelled.AutoSize = true;
            lbCancelled.BackColor = Color.FromArgb(27, 118, 142);
            lbCancelled.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCancelled.ForeColor = Color.FromArgb(252, 239, 239);
            lbCancelled.Location = new Point(955, 98);
            lbCancelled.Name = "lbCancelled";
            lbCancelled.Size = new Size(134, 28);
            lbCancelled.TabIndex = 22;
            lbCancelled.Text = "Cancelled";
            // 
            // btnCreateTask
            // 
            btnCreateTask.BackColor = Color.Transparent;
            btnCreateTask.BorderRadius = 10;
            btnCreateTask.CustomizableEdges = customizableEdges3;
            btnCreateTask.DisabledState.BorderColor = Color.DarkGray;
            btnCreateTask.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreateTask.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreateTask.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreateTask.FillColor = Color.FromArgb(251, 152, 51);
            btnCreateTask.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateTask.ForeColor = Color.White;
            btnCreateTask.Location = new Point(1059, 42);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCreateTask.Size = new Size(35, 34);
            btnCreateTask.TabIndex = 19;
            btnCreateTask.Text = "+";
            btnCreateTask.Click += OnBtnCreateTaskClick;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Transparent;
            btnEdit.BorderRadius = 10;
            btnEdit.CustomizableEdges = customizableEdges1;
            btnEdit.DisabledState.BorderColor = Color.DarkGray;
            btnEdit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEdit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEdit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEdit.FillColor = Color.FromArgb(251, 152, 51);
            btnEdit.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(976, 42);
            btnEdit.Name = "btnEdit";
            btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEdit.Size = new Size(77, 34);
            btnEdit.TabIndex = 23;
            btnEdit.Text = "edit";
            btnEdit.Click += OnBtnEditClick;
            // 
            // lbResult
            // 
            lbResult.AutoSize = true;
            lbResult.BackColor = Color.FromArgb(0, 192, 0);
            lbResult.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbResult.ForeColor = Color.FromArgb(252, 239, 239);
            lbResult.Location = new Point(464, 42);
            lbResult.Name = "lbResult";
            lbResult.Size = new Size(239, 28);
            lbResult.TabIndex = 24;
            lbResult.Text = "select a task to edit";
            // 
            // KanbanBoard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1153, 649);
            Name = "KanbanBoard";
            Text = "KanbanBoard";
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            pnMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnMenu;
        private FlowLayoutPanel conteinerToDo;
        private FlowLayoutPanel conteinerBackLog;
        private Label label1;
        private Label lbBacklog;
        private FlowLayoutPanel conteinerDoing;
        private Label lbToDo;
        private Label lbDone;
        private FlowLayoutPanel conteinerDone;
        private Label lbReview;
        private FlowLayoutPanel conteinerReview;
        private Label lbDoing;
        private FlowLayoutPanel conteinerCancelled;
        private Label lbCancelled;
        private Guna.UI2.WinForms.Guna2Button btnCreateTask;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Label lbResult;
    }
}