using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WMPLib;

namespace WorkAlarm
{
    public partial class MainForm : Form
    {
        // Waktu Alarm Default
        private DateTime timeMasuk = DateTime.Today.AddHours(7);
        private DateTime timeIstirahat = DateTime.Today.AddHours(12);
        private DateTime timePulang = DateTime.Today.AddHours(17);

        // Path Audio
        private string audioPathMasuk = "";
        private string audioPathIstirahat = "";
        private string audioPathPulang = "";

        // Catatan Alarm
        private string noteMasuk = "Saatnya mulai bekerja! Selamat beraktivitas.";
        private string noteIstirahat = "Saatnya istirahat dan makan siang!";
        private string notePulang = "Waktu kerja selesai. Selamat beristirahat!";

        // Flag Pencegah Alarm Berulang
        private string lastTriggeredMasuk = "";
        private string lastTriggeredIstirahat = "";
        private string lastTriggeredPulang = "";

        // Control UI Tambahan (Tampilan Jam & Sakelar ON/OFF)
        private Label lblJamMasuk;
        private Label lblJamIstirahat;
        private Label lblJamPulang;

        private CheckBox chkMasuk;
        private CheckBox chkIstirahat;
        private CheckBox chkPulang;

        private WindowsMediaPlayer wmpPlayer = new WindowsMediaPlayer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Buat komponen tampilan Jam & ON/OFF secara otomatis
            SetupTampilanJamDanOnOff();

            timerAlarm.Interval = 1000;
            timerAlarm.Start();

            UpdateCurrentTime();
            UpdateDisplayJam();
        }

        private void SetupTampilanJamDanOnOff()
        {
            // Label Jam & Checkbox Waktu Masuk
            lblJamMasuk = CreateLabelJam();
            chkMasuk = CreateCheckBoxOnOff();
            PositionControls(btnBrowseMasuk, lblJamMasuk, chkMasuk);

            // Label Jam & Checkbox Waktu Istirahat
            lblJamIstirahat = CreateLabelJam();
            chkIstirahat = CreateCheckBoxOnOff();
            PositionControls(btnBrowseIstirahat, lblJamIstirahat, chkIstirahat);

            // Label Jam & Checkbox Waktu Pulang
            lblJamPulang = CreateLabelJam();
            chkPulang = CreateCheckBoxOnOff();
            PositionControls(btnBrowsePulang, lblJamPulang, chkPulang);
        }

        private Label CreateLabelJam()
        {
            return new Label()
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private CheckBox CreateCheckBoxOnOff()
        {
            CheckBox chk = new CheckBox()
            {
                Text = "ON",
                Checked = true,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.ForestGreen,
                Cursor = Cursors.Hand
            };

            chk.CheckedChanged += (s, e) =>
            {
                if (chk.Checked)
                {
                    chk.Text = "ON";
                    chk.ForeColor = Color.ForestGreen;
                }
                else
                {
                    chk.Text = "OFF";
                    chk.ForeColor = Color.Gray;
                }
                UpdateStatusWarnaJam();
            };

            return chk;
        }

        private void PositionControls(Button targetButton, Label lblJam, CheckBox chk)
        {
            if (targetButton != null && targetButton.Parent != null)
            {
                Control container = targetButton.Parent;

                // 1. Geser tombol Atur lebih ke kanan
                targetButton.Left = 500;

                // 2. Posisikan jam di sebelah kanan label judul alarm
                lblJam.Left = 230;
                lblJam.Top = targetButton.Top + (targetButton.Height - lblJam.Height) / 2;

                // 3. Posisikan Checkbox ON/OFF di antara Jam dan tombol Atur
                chk.Left = 300;
                chk.Top = targetButton.Top + (targetButton.Height - chk.Height) / 2;

                container.Controls.Add(lblJam);
                container.Controls.Add(chk);
            }
        }

        private void UpdateDisplayJam()
        {
            if (lblJamMasuk != null) lblJamMasuk.Text = timeMasuk.ToString("HH:mm");
            if (lblJamIstirahat != null) lblJamIstirahat.Text = timeIstirahat.ToString("HH:mm");
            if (lblJamPulang != null) lblJamPulang.Text = timePulang.ToString("HH:mm");

            UpdateStatusWarnaJam();
        }

        private void UpdateStatusWarnaJam()
        {
            if (lblJamMasuk != null && chkMasuk != null)
                lblJamMasuk.ForeColor = chkMasuk.Checked ? Color.DarkBlue : Color.Gray;

            if (lblJamIstirahat != null && chkIstirahat != null)
                lblJamIstirahat.ForeColor = chkIstirahat.Checked ? Color.DarkBlue : Color.Gray;

            if (lblJamPulang != null && chkPulang != null)
                lblJamPulang.ForeColor = chkPulang.Checked ? Color.DarkBlue : Color.Gray;
        }

        private void timerAlarm_Tick(object sender, EventArgs e)
        {
            UpdateCurrentTime();
            CheckAlarmSchedule();
        }

        private void UpdateCurrentTime()
        {
            if (lblWaktuSekarang != null)
                lblWaktuSekarang.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void CheckAlarmSchedule()
        {
            DateTime now = DateTime.Now;
            string currentMinuteStr = now.ToString("yyyy-MM-dd HH:mm");
            string currentTimeStr = now.ToString("HH:mm");

            // Alarm Masuk (Hanya bunyi jika ON)
            if (chkMasuk != null && chkMasuk.Checked && currentTimeStr == timeMasuk.ToString("HH:mm") && lastTriggeredMasuk != currentMinuteStr)
            {
                lastTriggeredMasuk = currentMinuteStr;
                TriggerAlarm("🔔 Waktu Masuk Kerja", noteMasuk, audioPathMasuk);
            }

            // Alarm Istirahat (Hanya bunyi jika ON)
            if (chkIstirahat != null && chkIstirahat.Checked && currentTimeStr == timeIstirahat.ToString("HH:mm") && lastTriggeredIstirahat != currentMinuteStr)
            {
                lastTriggeredIstirahat = currentMinuteStr;
                TriggerAlarm("☕ Waktu Istirahat", noteIstirahat, audioPathIstirahat);
            }

            // Alarm Pulang (Hanya bunyi jika ON)
            if (chkPulang != null && chkPulang.Checked && currentTimeStr == timePulang.ToString("HH:mm") && lastTriggeredPulang != currentMinuteStr)
            {
                lastTriggeredPulang = currentMinuteStr;
                TriggerAlarm("🏠 Waktu Pulang Kerja", notePulang, audioPathPulang);
            }
        }

        private void TriggerAlarm(string title, string message, string customAudioPath)
        {
            try { wmpPlayer.controls.stop(); } catch { }

            if (!string.IsNullOrEmpty(customAudioPath) && File.Exists(customAudioPath))
            {
                try
                {
                    wmpPlayer.URL = customAudioPath;
                    wmpPlayer.settings.setMode("loop", true);
                    wmpPlayer.controls.play();
                }
                catch { }
            }

            // Menggunakan MessageBoxIcon.None agar tidak ada suara "ding" bawaan Windows
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.None);

            try
            {
                wmpPlayer.controls.stop();
                wmpPlayer.settings.setMode("loop", false);
            }
            catch { }
        }

        private void btnBrowseMasuk_Click(object sender, EventArgs e)
        {
            if (BukaFormPengaturan("Setting Alarm Waktu Masuk", ref timeMasuk, ref audioPathMasuk, ref noteMasuk))
            {
                ResetTriggerStatus();
                UpdateDisplayJam();
                if (lblStatus != null)
                {
                    lblStatus.Text = "Status: Alarm Masuk Berhasil Diperbarui (" + timeMasuk.ToString("HH:mm") + ")";
                    lblStatus.ForeColor = Color.ForestGreen;
                }
            }
        }

        private void btnBrowseIstirahat_Click(object sender, EventArgs e)
        {
            if (BukaFormPengaturan("Setting Alarm Waktu Istirahat", ref timeIstirahat, ref audioPathIstirahat, ref noteIstirahat))
            {
                ResetTriggerStatus();
                UpdateDisplayJam();
                if (lblStatus != null)
                {
                    lblStatus.Text = "Status: Alarm Istirahat Berhasil Diperbarui (" + timeIstirahat.ToString("HH:mm") + ")";
                    lblStatus.ForeColor = Color.ForestGreen;
                }
            }
        }

        private void btnBrowsePulang_Click(object sender, EventArgs e)
        {
            if (BukaFormPengaturan("Setting Alarm Waktu Pulang", ref timePulang, ref audioPathPulang, ref notePulang))
            {
                ResetTriggerStatus();
                UpdateDisplayJam();
                if (lblStatus != null)
                {
                    lblStatus.Text = "Status: Alarm Pulang Berhasil Diperbarui (" + timePulang.ToString("HH:mm") + ")";
                    lblStatus.ForeColor = Color.ForestGreen;
                }
            }
        }

        private bool BukaFormPengaturan(string judul, ref DateTime waktu, ref string pathAudio, ref string catatan)
        {
            Form pop = new Form()
            {
                Text = judul,
                Width = 440,
                Height = 310,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            Label lblJam = new Label() { Text = "⏰ Jam Alarm:", Left = 20, Top = 15, AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            DateTimePicker dtp = new DateTimePicker()
            {
                Left = 20,
                Top = 38,
                Width = 140,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                ShowUpDown = true,
                Value = waktu,
                Font = new Font("Segoe UI", 11)
            };

            Label lblAudio = new Label() { Text = "🎵 File Suara Alarm:", Left = 20, Top = 80, AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox txtAudio = new TextBox()
            {
                Left = 20,
                Top = 103,
                Width = 270,
                Text = string.IsNullOrEmpty(pathAudio) ? "Suara Default" : Path.GetFileName(pathAudio),
                ReadOnly = true,
                Font = new Font("Segoe UI", 9)
            };
            Button btnBrowse = new Button() { Text = "Pilih File...", Left = 300, Top = 101, Width = 95, Height = 28 };

            string tempAudioPath = pathAudio;
            btnBrowse.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Audio Files (*.mp3;*.wav)|*.mp3;*.wav";
                    ofd.Title = "Pilih File Suara Alarm";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        tempAudioPath = ofd.FileName;
                        txtAudio.Text = Path.GetFileName(tempAudioPath);
                    }
                }
            };

            Label lblNote = new Label() { Text = "📝 Catatan / Pesan Alarm:", Left = 20, Top = 145, AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            TextBox txtNote = new TextBox() { Left = 20, Top = 168, Width = 375, Text = catatan, Font = new Font("Segoe UI", 10) };

            Button btnSimpan = new Button()
            {
                Text = "💾 Simpan",
                Left = 195,
                Top = 215,
                Width = 95,
                Height = 35,
                DialogResult = DialogResult.OK,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            Button btnBatal = new Button()
            {
                Text = "Batal",
                Left = 300,
                Top = 215,
                Width = 95,
                Height = 35,
                DialogResult = DialogResult.Cancel
            };

            pop.Controls.AddRange(new Control[] { lblJam, dtp, lblAudio, txtAudio, btnBrowse, lblNote, txtNote, btnSimpan, btnBatal });
            pop.AcceptButton = btnSimpan;

            if (pop.ShowDialog() == DialogResult.OK)
            {
                waktu = dtp.Value;
                pathAudio = tempAudioPath;
                catatan = txtNote.Text;
                return true;
            }

            return false;
        }

        private void ResetTriggerStatus()
        {
            string currentMinute = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            if (timeMasuk.ToString("HH:mm") != DateTime.Now.ToString("HH:mm")) lastTriggeredMasuk = "";
            else lastTriggeredMasuk = currentMinute;

            if (timeIstirahat.ToString("HH:mm") != DateTime.Now.ToString("HH:mm")) lastTriggeredIstirahat = "";
            else lastTriggeredIstirahat = currentMinute;

            if (timePulang.ToString("HH:mm") != DateTime.Now.ToString("HH:mm")) lastTriggeredPulang = "";
            else lastTriggeredPulang = currentMinute;
        }

        private void btnAturJadwal_Click(object sender, EventArgs e)
        {
            if (lblStatus != null)
            {
                lblStatus.Text = "Status: Semua Jadwal tersimpan!";
                lblStatus.ForeColor = Color.ForestGreen;
            }
            MessageBox.Show("Jadwal alarm tersimpan dan aktif!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btnTestAlarm_Click(object sender, EventArgs e)
        {
            TriggerAlarm("🔔 Pengujian Alarm", noteMasuk, audioPathMasuk);
        }
    }
}