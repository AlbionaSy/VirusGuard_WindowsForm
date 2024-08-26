namespace VirusGUARD_Final
{
    partial class Security
    {    /// <summary> 
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Security));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            progresbarFullCheck = new ProgressBar();
            listView1 = new ListView();
            folderBrowserDialog1 = new FolderBrowserDialog();
            lblLoading = new Label();
            panel1 = new Panel();
            FullScan = new Guna.UI2.WinForms.Guna2GradientButton();
            FolderScan = new Guna.UI2.WinForms.Guna2GradientButton();
            QuickScan = new Guna.UI2.WinForms.Guna2GradientButton();
            ThreatFoundForm = new VirusGuard_Antivirus.ThreatsFound();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            panel1.SuspendLayout();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // progresbarFullCheck
            // 
            progresbarFullCheck.Location = new Point(63, 397);
            progresbarFullCheck.Name = "progresbarFullCheck";
            progresbarFullCheck.Size = new Size(577, 21);
            progresbarFullCheck.TabIndex = 14;
            progresbarFullCheck.Visible = false;
            // 
            // listView1
            // 
            listView1.Alignment = ListViewAlignment.Default;
            listView1.Anchor = AnchorStyles.None;
            listView1.BackColor = SystemColors.InactiveBorder;
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.ImeMode = ImeMode.NoControl;
            listView1.Location = new Point(64, 56);
            listView1.Name = "listView1";
            listView1.Size = new Size(577, 338);
            listView1.TabIndex = 16;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.Visible = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.BackColor = Color.Transparent;
            lblLoading.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoading.ForeColor = Color.Transparent;
            lblLoading.Location = new Point(161, 35);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(402, 76);
            lblLoading.TabIndex = 17;
            lblLoading.Text = "Virus Guard is scanning files, \r\n             please wait...";
            lblLoading.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 0, 61);
            panel1.Controls.Add(FullScan);
            panel1.Controls.Add(FolderScan);
            panel1.Controls.Add(QuickScan);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 466);
            panel1.TabIndex = 19;
            // 
            // FullScan
            // 
            FullScan.CustomizableEdges = customizableEdges1;
            FullScan.DisabledState.BorderColor = Color.DarkGray;
            FullScan.DisabledState.CustomBorderColor = Color.DarkGray;
            FullScan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            FullScan.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            FullScan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            FullScan.Dock = DockStyle.Top;
            FullScan.FillColor = Color.FromArgb(37, 40, 43);
            FullScan.FillColor2 = Color.FromArgb(102, 39, 0);
            FullScan.FocusedColor = Color.FromArgb(37, 40, 43);
            FullScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FullScan.ForeColor = Color.White;
            FullScan.Image = (Image)resources.GetObject("FullScan.Image");
            FullScan.ImageOffset = new Point(18, -5);
            FullScan.ImageSize = new Size(75, 75);
            FullScan.Location = new Point(0, 312);
            FullScan.Name = "FullScan";
            FullScan.ShadowDecoration.CustomizableEdges = customizableEdges2;
            FullScan.Size = new Size(246, 156);
            FullScan.TabIndex = 23;
            FullScan.Text = "Full Scan";
            FullScan.TextOffset = new Point(-20, 40);
            FullScan.Click += FullScan_Click;
            // 
            // FolderScan
            // 
            FolderScan.CustomizableEdges = customizableEdges3;
            FolderScan.DisabledState.BorderColor = Color.DarkGray;
            FolderScan.DisabledState.CustomBorderColor = Color.DarkGray;
            FolderScan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            FolderScan.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            FolderScan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            FolderScan.Dock = DockStyle.Top;
            FolderScan.FillColor = Color.FromArgb(37, 40, 43);
            FolderScan.FillColor2 = Color.FromArgb(102, 39, 0);
            FolderScan.FocusedColor = Color.FromArgb(37, 40, 43);
            FolderScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FolderScan.ForeColor = Color.White;
            FolderScan.Image = (Image)resources.GetObject("FolderScan.Image");
            FolderScan.ImageOffset = new Point(30, -10);
            FolderScan.ImageSize = new Size(75, 75);
            FolderScan.Location = new Point(0, 156);
            FolderScan.Name = "FolderScan";
            FolderScan.ShadowDecoration.CustomizableEdges = customizableEdges4;
            FolderScan.Size = new Size(246, 156);
            FolderScan.TabIndex = 22;
            FolderScan.Text = "Folder Scan";
            FolderScan.TextOffset = new Point(-15, 40);
            FolderScan.Click += FolderScan_Click;
            // 
            // QuickScan
            // 
            QuickScan.CustomizableEdges = customizableEdges5;
            QuickScan.DisabledState.BorderColor = Color.DarkGray;
            QuickScan.DisabledState.CustomBorderColor = Color.DarkGray;
            QuickScan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            QuickScan.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            QuickScan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            QuickScan.Dock = DockStyle.Top;
            QuickScan.FillColor = Color.FromArgb(37, 40, 43);
            QuickScan.FillColor2 = Color.FromArgb(102, 39, 0);
            QuickScan.FocusedColor = Color.FromArgb(255, 224, 192);
            QuickScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            QuickScan.ForeColor = Color.White;
            QuickScan.Image = (Image)resources.GetObject("QuickScan.Image");
            QuickScan.ImageOffset = new Point(25, -10);
            QuickScan.ImageSize = new Size(75, 75);
            QuickScan.Location = new Point(0, 0);
            QuickScan.Name = "QuickScan";
            QuickScan.ShadowDecoration.CustomizableEdges = customizableEdges6;
            QuickScan.Size = new Size(246, 156);
            QuickScan.TabIndex = 21;
            QuickScan.Text = "Quick Scan";
            QuickScan.TextOffset = new Point(-20, 40);
            QuickScan.Click += QuickScan_Click;
            // 
            // ThreatFoundForm
            // 
            ThreatFoundForm.BackColor = Color.FromArgb(64, 64, 64);
            ThreatFoundForm.Location = new Point(28, 128);
            ThreatFoundForm.Name = "ThreatFoundForm";
            ThreatFoundForm.Size = new Size(365, 228);
            ThreatFoundForm.TabIndex = 20;
            ThreatFoundForm.Visible = false;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.BackColor = Color.FromArgb(64, 64, 64);
            guna2CustomGradientPanel1.Controls.Add(lblLoading);
            guna2CustomGradientPanel1.Controls.Add(ThreatFoundForm);
            guna2CustomGradientPanel1.Controls.Add(listView1);
            guna2CustomGradientPanel1.Controls.Add(progresbarFullCheck);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges7;
            guna2CustomGradientPanel1.FillColor = Color.Transparent;
            guna2CustomGradientPanel1.FillColor2 = Color.Transparent;
            guna2CustomGradientPanel1.FillColor3 = Color.Transparent;
            guna2CustomGradientPanel1.FillColor4 = Color.Transparent;
            guna2CustomGradientPanel1.Location = new Point(244, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.Quality = 12;
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2CustomGradientPanel1.Size = new Size(703, 466);
            guna2CustomGradientPanel1.TabIndex = 21;
            // 
            // Security
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 55, 63);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Security";
            Size = new Size(947, 466);
            Load += Security_Load;
            panel1.ResumeLayout(false);
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ProgressBar progresbarFullCheck;
        private ListView listView1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label lblLoading;
        private VirusGuard_Antivirus.ThreatsFound threatsFound1;
        private Panel panel1;
        private VirusGuard_Antivirus.ThreatsFound ThreatFoundForm;
        private Guna.UI2.WinForms.Guna2GradientButton QuickScan;
        private Guna.UI2.WinForms.Guna2GradientButton FullScan;
        private Guna.UI2.WinForms.Guna2GradientButton FolderScan;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}
