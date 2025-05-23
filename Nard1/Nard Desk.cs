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
            this.MaximizeBox = false; // Отключает кнопку развёртывания
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
            // Создаём PictureBox
            //PictureBox pictureBox = new PictureBox();

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

        private void CreatePanel()
        {
            // Рассчитываем дополнительную ширину (4 см в пикселях)
            float cmToPixels = 37.8f; // Примерное значение
            int extraWidth = (int)(4 * cmToPixels);

            // Устанавливаем размер панели (шире pictureBox на 4 см с каждой стороны)
            panel.Size = new Size(
                pictureBox.Width + (2 * extraWidth),
                pictureBox.Height
            );

            // Позиционируем панель по центру формы
            panel.Location = new Point(
                (this.ClientSize.Width - panel.Width) / 2,
                (this.ClientSize.Height - panel.Height) / 2
            );

            // Настройка внешнего вида
            panel.BackColor = Color.Green; // Зелёный цвет
            panel.BorderStyle = BorderStyle.FixedSingle; // Рамка для наглядности

            // Обработчик изменения размера формы
            this.Resize += (sender, e) =>
            {
                panel.Location = new Point(
                    (this.ClientSize.Width - panel.Width) / 2,
                    (this.ClientSize.Height - panel.Height) / 2
                );
            };

            // Добавляем панель на форму
            this.Controls.Add(panel);
        }
    }
}
