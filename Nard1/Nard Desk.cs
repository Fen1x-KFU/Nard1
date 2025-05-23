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
            ImagBackGround();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false; // Отключает кнопку развёртывания
            SetupPictureBox();
            CreatePanel();
            CreateBlackChipsInPanel(panel);
            CreateRedChipsInPanel(panel);
        }

        public void ImagBackGround()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Desk.jpg");

           this.BackgroundImage = Image.FromFile(imagePath);  
        }

        private void SetupPictureBox()
        {

            // Устанавливаем размер (например, 200x200)
            pictureBox.Size = new Size(200, 200);

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Board.jpg");

            // Устанавливаем изображение
            pictureBox.Image = Image.FromFile(imagePath);

            // Устанавливаем режим изменения размера (изображение будет отображаться в оригинальном размере)
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

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

        public void CreateBlackChipsInPanel(Panel panel)
        {
            // Очищаем панель перед созданием фишек
            panel.Controls.Clear();

            // Размеры фишки
            int chipSize = 40; // диаметр кружка
            int margin = 5;    // отступ между фишками

            // Количество столбцов для размещения
            int columns = 1;

            // Создаем 15 чёрных фишек
            for (int i = 0; i < 15; i++)
            {
                var chip = new Button()
                {
                    Width = chipSize,
                    Height = chipSize,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Black,
                    Enabled = true, // чтобы не было кликабельного эффекта
                    TabStop = false // убираем из таб-последовательности
                };

                // Делаем фишку круглой
                chip.FlatAppearance.BorderSize = 0;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, chipSize, chipSize);
                chip.Region = new Region(path);

                // Позиционирование (распределяем по сетке)
                int col = i % columns;
                int row = i / columns;
                chip.Left = col * (chipSize + margin);
                chip.Top = row * (chipSize + margin);

                panel.Controls.Add(chip);
            }

            // Включаем скролл при необходимости
            panel.AutoScroll = true;
        }

        public void CreateRedChipsInPanel(Panel panel)
        {
            // Очищаем панель перед созданием фишек
            //panel.Controls.Clear();

            // Размеры фишки
            int chipSize = 40; // диаметр кружка
            int margin = 5;    // отступ между фишками

            // Рассчитываем начальную позицию (правая граница панели минус ширина фишек)
            int rightMargin = margin; // Отступ от правого края
            int startX = panel.Width - chipSize - rightMargin;

            // Количество столбцов для размещения
            int columns = 1;

            // Создаем 15 чёрных фишек
            for (int i = 0; i < 15; i++)
            {
                var chip = new Button()
                {
                    Width = chipSize,
                    Height = chipSize,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Red,
                    Enabled = true, // чтобы не было кликабельного эффекта
                    TabStop = false // убираем из таб-последовательности
                };

                // Делаем фишку круглой
                chip.FlatAppearance.BorderSize = 0;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, chipSize, chipSize);
                chip.Region = new Region(path);

                // Позиционируем справа
                int row = i / columns;
                chip.Left = startX;
                chip.Top = row * (chipSize + margin);

                panel.Controls.Add(chip);
            }

            // Включаем скролл при необходимости
            panel.AutoScroll = true;
        }
    }
}
