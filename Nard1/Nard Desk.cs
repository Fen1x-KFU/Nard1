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
            this.MaximizeBox = false; // Отключает кнопку развёртывания
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
            // Создаём PictureBox
            PictureBox pictureBox = new PictureBox();

            // Устанавливаем размер (например, 200x200)
            pictureBox.Size = new Size(200, 200);

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Board.jpg");

            // Устанавливаем изображение
            pictureBox.Image = Image.FromFile(imagePath);

            // Устанавливаем режим изменения размера (изображение будет отображаться в оригинальном размере)
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            // Заливаем красным цветом
            //pictureBox.BackColor = Color.Red;

            // Размещаем по центру формы
            pictureBox.Location = new Point(
                (this.ClientSize.Width - pictureBox.Width) / 2,
                (this.ClientSize.Height - pictureBox.Height) / 2
            );

            // При изменении размера формы PictureBox остаётся по центру
            this.Resize += (sender, e) =>
            {
                pictureBox.Location = new Point(
                    (this.ClientSize.Width - pictureBox.Width) / 2,
                    (this.ClientSize.Height - pictureBox.Height) / 2
                );
            };

            // Добавляем PictureBox на форму
            this.Controls.Add(pictureBox);
        }
    }
}
