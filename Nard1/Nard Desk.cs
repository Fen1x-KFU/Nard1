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
            this.MaximizeBox = false; // Отключает кнопку развёртывания
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

            // Устанавливаем изображение
            pictureBox1.Image = Image.FromFile(imagePath);

            // Устанавливаем режим изменения размера (изображение будет отображаться в оригинальном размере)
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            this.Controls.Add(pictureBox1);

            // Вызываем центрирование с задержкой до следующей отрисовки
            this.Controls.Add(pictureBox1);

            CenterPictureBox(pictureBox1);
        }

        private void CenterPictureBox(PictureBox pb)
        {
            // Принудительно обновляем отрисовку
            pb.Update();

            // Центрируем
            pb.Location = new Point(
                (this.ClientSize.Width - pb.Width) / 2,
                (this.ClientSize.Height - pb.Height) / 2
            );
        }
    }
}
