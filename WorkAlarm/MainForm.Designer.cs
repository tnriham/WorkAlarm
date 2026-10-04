namespace WorkAlarm
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubTitle = new Label();
            lblWaktuSekarang = new Label();
            gbJadwal = new GroupBox();
            lblMasuk = new Label();
            btnBrowseMasuk = new Button();
            lblIstirahat = new Label();
            btnBrowseIstirahat = new Button();
            lblPulang = new Label();
            btnBrowsePulang = new Button();
            lblStatus = new Label();
            btnAturJadwal = new Button();
            btnTestAlarm = new Button();
            timerAlarm = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            gbJadwal.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(41, 128, 185);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(760, 60);
            pnlHeader.TabIndex = 6;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(760, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WORK ALARM - Pengingat Waktu Kerja";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubTitle
            // 
            lblSubTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubTitle.ForeColor = Color.DimGray;
            lblSubTitle.Location = new Point(0, 72);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(760, 25);
            lblSubTitle.TabIndex = 5;
            lblSubTitle.Text = "WAKTU SEKARANG";
            lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWaktuSekarang
            // 
            lblWaktuSekarang.Font = new Font("Consolas", 36F, FontStyle.Bold);
            lblWaktuSekarang.ForeColor = Color.FromArgb(44, 62, 80);
            lblWaktuSekarang.Location = new Point(0, 98);
            lblWaktuSekarang.Name = "lblWaktuSekarang";
            lblWaktuSekarang.Size = new Size(760, 65);
            lblWaktuSekarang.TabIndex = 4;
            lblWaktuSekarang.Text = "00:00:00";
            lblWaktuSekarang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbJadwal
            // 
            gbJadwal.Controls.Add(lblMasuk);
            gbJadwal.Controls.Add(btnBrowseMasuk);
            gbJadwal.Controls.Add(lblIstirahat);
            gbJadwal.Controls.Add(btnBrowseIstirahat);
            gbJadwal.Controls.Add(lblPulang);
            gbJadwal.Controls.Add(btnBrowsePulang);
            gbJadwal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbJadwal.Location = new Point(25, 175);
            gbJadwal.Name = "gbJadwal";
            gbJadwal.Size = new Size(710, 185);
            gbJadwal.TabIndex = 3;
            gbJadwal.TabStop = false;
            gbJadwal.Text = "Jadwal Alarm";
            // 
            // lblMasuk
            // 
            lblMasuk.AutoSize = true;
            lblMasuk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMasuk.ForeColor = Color.FromArgb(44, 62, 80);
            lblMasuk.Location = new Point(15, 32);
            lblMasuk.Name = "lblMasuk";
            lblMasuk.Size = new Size(181, 28);
            lblMasuk.TabIndex = 0;
            lblMasuk.Text = "🔔 Waktu Masuk:";
            lblMasuk.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBrowseMasuk
            // 
            btnBrowseMasuk.Font = new Font("Segoe UI", 9F);
            btnBrowseMasuk.Location = new Point(270, 30);
            btnBrowseMasuk.Name = "btnBrowseMasuk";
            btnBrowseMasuk.Size = new Size(130, 30);
            btnBrowseMasuk.TabIndex = 2;
            btnBrowseMasuk.Text = "⚙️ Atur";
            btnBrowseMasuk.Click += btnBrowseMasuk_Click;
            // 
            // lblIstirahat
            // 
            lblIstirahat.AutoSize = true;
            lblIstirahat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIstirahat.ForeColor = Color.FromArgb(44, 62, 80);
            lblIstirahat.Location = new Point(15, 78);
            lblIstirahat.Name = "lblIstirahat";
            lblIstirahat.Size = new Size(197, 28);
            lblIstirahat.TabIndex = 4;
            lblIstirahat.Text = "☕ Waktu Istirahat:";
            lblIstirahat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBrowseIstirahat
            // 
            btnBrowseIstirahat.Font = new Font("Segoe UI", 9F);
            btnBrowseIstirahat.Location = new Point(270, 76);
            btnBrowseIstirahat.Name = "btnBrowseIstirahat";
            btnBrowseIstirahat.Size = new Size(130, 30);
            btnBrowseIstirahat.TabIndex = 6;
            btnBrowseIstirahat.Text = "⚙️ Atur";
            btnBrowseIstirahat.Click += btnBrowseIstirahat_Click;
            // 
            // lblPulang
            // 
            lblPulang.AutoSize = true;
            lblPulang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPulang.ForeColor = Color.FromArgb(44, 62, 80);
            lblPulang.Location = new Point(15, 124);
            lblPulang.Name = "lblPulang";
            lblPulang.Size = new Size(183, 28);
            lblPulang.TabIndex = 8;
            lblPulang.Text = "🏠 Waktu Pulang:";
            lblPulang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBrowsePulang
            // 
            btnBrowsePulang.Font = new Font("Segoe UI", 9F);
            btnBrowsePulang.Location = new Point(270, 122);
            btnBrowsePulang.Name = "btnBrowsePulang";
            btnBrowsePulang.Size = new Size(130, 30);
            btnBrowsePulang.TabIndex = 10;
            btnBrowsePulang.Text = "⚙️ Atur";
            btnBrowsePulang.Click += btnBrowsePulang_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.ForestGreen;
            lblStatus.Location = new Point(0, 370);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(760, 25);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status: Alarm Aktif";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAturJadwal
            // 
            btnAturJadwal.BackColor = Color.FromArgb(46, 204, 113);
            btnAturJadwal.FlatStyle = FlatStyle.Flat;
            btnAturJadwal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAturJadwal.ForeColor = Color.White;
            btnAturJadwal.Location = new Point(230, 405);
            btnAturJadwal.Name = "btnAturJadwal";
            btnAturJadwal.Size = new Size(140, 40);
            btnAturJadwal.TabIndex = 1;
            btnAturJadwal.Text = "SIMPAN JADWAL";
            btnAturJadwal.UseVisualStyleBackColor = false;
            btnAturJadwal.Click += btnAturJadwal_Click;
            // 
            // btnTestAlarm
            // 
            btnTestAlarm.BackColor = Color.FromArgb(230, 126, 34);
            btnTestAlarm.FlatStyle = FlatStyle.Flat;
            btnTestAlarm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTestAlarm.ForeColor = Color.White;
            btnTestAlarm.Location = new Point(390, 405);
            btnTestAlarm.Name = "btnTestAlarm";
            btnTestAlarm.Size = new Size(140, 40);
            btnTestAlarm.TabIndex = 0;
            btnTestAlarm.Text = "TEST ALARM";
            btnTestAlarm.UseVisualStyleBackColor = false;
            btnTestAlarm.Click += btnTestAlarm_Click;
            // 
            // timerAlarm
            // 
            timerAlarm.Interval = 1000;
            timerAlarm.Tick += timerAlarm_Tick;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(760, 470);
            Controls.Add(btnTestAlarm);
            Controls.Add(btnAturJadwal);
            Controls.Add(lblStatus);
            Controls.Add(gbJadwal);
            Controls.Add(lblWaktuSekarang);
            Controls.Add(lblSubTitle);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkAlarm App";
            Load += MainForm_Load;
            pnlHeader.ResumeLayout(false);
            gbJadwal.ResumeLayout(false);
            gbJadwal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblWaktuSekarang;
        private System.Windows.Forms.GroupBox gbJadwal;

        private System.Windows.Forms.Label lblMasuk;
        private System.Windows.Forms.Button btnBrowseMasuk;

        private System.Windows.Forms.Label lblIstirahat;
        private System.Windows.Forms.Button btnBrowseIstirahat;

        private System.Windows.Forms.Label lblPulang;
        private System.Windows.Forms.Button btnBrowsePulang;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAturJadwal;
        private System.Windows.Forms.Button btnTestAlarm;
        private System.Windows.Forms.Timer timerAlarm;
    }
}