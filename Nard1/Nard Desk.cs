using System.Windows.Forms;

namespace Nard1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ImagBackGround("Desk.jpg");
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false; // ��������� ������ ������������
            PictureBox();
        }

        public void ImagBackGround(string name)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", name);

           this.BackgroundImage = Image.FromFile(imagePath);  
        }

        private void PictureBox()
        {
            PictureBox pictureBox1 = new PictureBox();

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Board.jpg");

            // ������������� �����������
            pictureBox1.Image = Image.FromFile(imagePath);

            // ������������� ����� ��������� ������� (����������� ����� ������������ � ������������ �������)
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            this.Controls.Add(pictureBox1);

            // �������� ������������� � ��������� �� ��������� ���������
            this.Controls.Add(pictureBox1);

            CenterPictureBox(pictureBox1);
        }

        private void CenterPictureBox(PictureBox pb)
        {
            // ������������� ��������� ���������
            pb.Update();

            // ����������
            pb.Location = new Point(
                (this.ClientSize.Width - pb.Width) / 2,
                (this.ClientSize.Height - pb.Height) / 2
            );
        }
    }
}
