using System.Windows.Forms;

namespace Nard1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ImagBackGround();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false; // ��������� ������ ������������
            SetupPictureBox();
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
            PictureBox pictureBox = new PictureBox();

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
    }
}
