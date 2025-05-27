using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nard1
{
    internal partial class Form1 : Form
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        public void ImageBackGround()
        {
            var imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Desk.jpg");

            this.BackgroundImage = Image.FromFile(imagePath);
        }

        private void SetupPictureBox()
        {
            string imagePath = Path.Combine(baseDir, "..", "..", "..", "Ico", "Board.jpg");

            // установка картинки для доски
            pictureBox.Image = Image.FromFile(imagePath);

            // Делаем ориг размер картинки в текст боксе
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            // при изменении размера формы находится по центру
            this.Resize += (sender, e) =>
            {
                pictureBox.Location = new Point(
                    (this.ClientSize.Width - pictureBox.Width) / 2,
                    (this.ClientSize.Height - pictureBox.Height) / 2
                );
            };

            // добавляем
            this.Controls.Add(pictureBox);
        }

        private void CreatePanel()
        {
            // доп длина (4 см)
            float cmToPixels = 37.8f; // примерное значение
            int extraWidth = (int)(4 * cmToPixels);

            // устанавливаем размер
            panel.Size = new Size(
                pictureBox.Width + (2 * extraWidth),
                pictureBox.Height
            );

            // зелёный цвет
            panel.BackColor = Color.Green; // Зелёный цвет
            panel.BorderStyle = BorderStyle.FixedSingle; // Рамка для наглядности

            // при изменении размера формы находится по центру
            this.Resize += (sender, e) =>
            {
                panel.Location = new Point(
                    (this.ClientSize.Width - panel.Width) / 2,
                    (this.ClientSize.Height - panel.Height) / 2
                );
            };

            // добавляем
            this.Controls.Add(panel);
        }

        public void CreateBlackChipsInPanel(Panel panel)
        {
            // размеры фишки
            int chipSize = 40; // диаметр
            int margin = 5;    // отступ между ними

            // кол-во столбцов
            int columns = 1;

            for (int i = 0; i < 15; i++)
            {
                var chip = new Button()
                {
                    Width = chipSize,
                    Height = chipSize,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Black,
                    Enabled = true, // можно кликать
                };

                // форма круга
                chip.FlatAppearance.BorderSize = 0;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, chipSize, chipSize);
                chip.Region = new Region(path);

                // размещаем по панели
                int col = i % columns;
                int row = i / columns;
                chip.Left = col * (chipSize + margin);
                chip.Top = row * (chipSize + margin);

                // добавляем
                panel.Controls.Add(chip);

                //chip.Name = $"chipBlack{i}";
                //buttons.Add(chip);
            }
        }

        public void CreateRedChipsInPanel(Panel panel)
        {

            // размеры фишки
            int chipSize = 40; // диаметр
            int margin = 5;    // отступ

            // позиция справа
            int rightMargin = margin; // отступ от правого края
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
                    Enabled = true, // можно кликать, пока не придумал
                };

                // форма круга
                chip.FlatAppearance.BorderSize = 0;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, chipSize, chipSize);
                chip.Region = new Region(path);

                // размещение по панели
                int row = i / columns;
                chip.Left = startX;
                chip.Top = row * (chipSize + margin);

                panel.Controls.Add(chip);
            }
        }

        public void Center()
        {
            this.Resize += (sender, e) =>
            {
                button1.Location = new Point(
                (this.ClientSize.Width - button1.Width) / 2,
                (this.ClientSize.Height - button1.Height) / 2
                );

                pictureBox1.Location = new Point(
                    (button1.Location.X - 110),
                    (button1.Location.Y + 105)
                    );

                pictureBox2.Location = new Point(
                    (button1.Location.X + 110),
                    (button1.Location.Y + 105)
                    );
            };
        }
    }
}
