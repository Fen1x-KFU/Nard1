using Nard;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Nard1
{
    public partial class Form1 : Form
    {
        PictureBox pictureBox = new PictureBox();
        Panel panel = new Panel();

        public Form1()
        {
            InitializeComponent();
            ImageBackGround();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = true; // ��������� ������ ������������
            SetupPictureBox();
            CreatePanel();
            CreateBlackChipsInPanel(panel);
            CreateRedChipsInPanel(panel);
        }

        string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        public void ImageBackGround()
        {
            var imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Desk.jpg");

           this.BackgroundImage = Image.FromFile(imagePath);  
        }

        private void SetupPictureBox()
        {
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Board.jpg");

            // ��������� �������� ��� �����
            pictureBox.Image = Image.FromFile(imagePath);

            // ������ ���� ������ �������� � ����� �����
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            // ��� ��������� ������� ����� ��������� �� ������
            this.Resize += (sender, e) =>
            {
                pictureBox.Location = new Point(
                    (this.ClientSize.Width - pictureBox.Width) / 2,
                    (this.ClientSize.Height - pictureBox.Height) / 2
                );
            };

            // ���������
            this.Controls.Add(pictureBox);
        }

        private void CreatePanel()
        {
            // ��� ����� (4 ��)
            float cmToPixels = 37.8f; // ��������� ��������
            int extraWidth = (int)(4 * cmToPixels);

            // ������������� ������
            panel.Size = new Size(
                pictureBox.Width + (2 * extraWidth),
                pictureBox.Height
            );

            // ������ ����
            panel.BackColor = Color.Green; // ������ ����
            panel.BorderStyle = BorderStyle.FixedSingle; // ����� ��� �����������

            // ��� ��������� ������� ����� ��������� �� ������
            this.Resize += (sender, e) =>
            {
                panel.Location = new Point(
                    (this.ClientSize.Width - panel.Width) / 2,
                    (this.ClientSize.Height - panel.Height) / 2
                );
            };

            // ���������
            this.Controls.Add(panel);
        }

        public void CreateBlackChipsInPanel(Panel panel)
        {
            // ������� �����
            int chipSize = 40; // �������
            int margin = 5;    // ������ ����� ����

            // ���-�� ��������
            int columns = 1;

            for (int i = 0; i < 15; i++)
            {
                var chip = new Button()
                {
                    Width = chipSize,
                    Height = chipSize,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Black,
                    Enabled = true, // ����� �������
                };

                // ����� �����
                chip.FlatAppearance.BorderSize = 0;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, chipSize, chipSize);
                chip.Region = new Region(path);

                // ��������� �� ������
                int col = i % columns;
                int row = i / columns;
                chip.Left = col * (chipSize + margin);
                chip.Top = row * (chipSize + margin);

                // ���������
                panel.Controls.Add(chip);
            }
        }

        public void CreateRedChipsInPanel(Panel panel)
        {

            // ������� �����
            int chipSize = 40; // �������
            int margin = 5;    // ������

            // ������� ������
            int rightMargin = margin; // ������ �� ������� ����
            int startX = panel.Width - chipSize - rightMargin;

            int columns = 1;

            for (int i = 0; i < 15; i++)
            {
                var chip = new Button()
                {
                    Width = chipSize,
                    Height = chipSize,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Red,
                    Enabled = true, // ����� �������, ���� �� ��������
                };

                // ����� �����
                chip.FlatAppearance.BorderSize = 0;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, chipSize, chipSize);
                chip.Region = new Region(path);

                // ���������� �� ������
                int row = i / columns;
                chip.Left = startX;
                chip.Top = row * (chipSize + margin);

                panel.Controls.Add(chip);
            }
        }

        //public void StartPlay(Player player1, Player player)
        //{

        //}
    }
}
