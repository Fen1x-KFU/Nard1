using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Nard1
{
    public partial class Form1 : Form
    {
        PictureBox pictureBox = new PictureBox();
        Panel panel = new Panel();

        public Form1()
        {
            InitializeComponent();
            ImagBackGround();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false; // ��������� ������ ������������
            SetupPictureBox();
            CreatePanel();
        }

        public void ImagBackGround()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Desk.jpg");

           this.BackgroundImage = Image.FromFile(imagePath);  
        }

        private void SetupPictureBox()
        {
            // ������ PictureBox
            //PictureBox pictureBox = new PictureBox();

            // ������������� ������ (��������, 200x200)
            pictureBox.Size = new Size(200, 200);

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Board.jpg");

            // ������������� �����������
            pictureBox.Image = Image.FromFile(imagePath);

            // ������������� ����� ��������� ������� (����������� ����� ������������ � ������������ �������)
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            // �������� ������� ������
            //pictureBox.BackColor = Color.Red;

            // ��������� �� ������ �����
            pictureBox.Location = new Point(
                (this.ClientSize.Width - pictureBox.Width) / 2,
                (this.ClientSize.Height - pictureBox.Height) / 2
            );

            // ��� ��������� ������� ����� PictureBox ������� �� ������
            this.Resize += (sender, e) =>
            {
                pictureBox.Location = new Point(
                    (this.ClientSize.Width - pictureBox.Width) / 2,
                    (this.ClientSize.Height - pictureBox.Height) / 2
                );
            };

            // ��������� PictureBox �� �����
            this.Controls.Add(pictureBox);
        }

        private void CreatePanel()
        {
            // ������������ �������������� ������ (4 �� � ��������)
            float cmToPixels = 37.8f; // ��������� ��������
            int extraWidth = (int)(4 * cmToPixels);

            // ������������� ������ ������ (���� pictureBox �� 4 �� � ������ �������)
            panel.Size = new Size(
                pictureBox.Width + (2 * extraWidth),
                pictureBox.Height
            );

            // ������������� ������ �� ������ �����
            panel.Location = new Point(
                (this.ClientSize.Width - panel.Width) / 2,
                (this.ClientSize.Height - panel.Height) / 2
            );

            // ��������� �������� ����
            panel.BackColor = Color.Green; // ������ ����
            panel.BorderStyle = BorderStyle.FixedSingle; // ����� ��� �����������

            // ���������� ��������� ������� �����
            this.Resize += (sender, e) =>
            {
                panel.Location = new Point(
                    (this.ClientSize.Width - panel.Width) / 2,
                    (this.ClientSize.Height - panel.Height) / 2
                );
            };

            // ��������� ������ �� �����
            this.Controls.Add(panel);
        }
    }
}
