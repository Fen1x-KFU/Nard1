using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Nard1
{
    internal partial class Form1 : Form
    {
        PictureBox pictureBox = new PictureBox();
        Panel panel = new Panel();
        Player p1 = new Player();
        Player p2 = new Player();
        //List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            ImageBackGround();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = true; // Отключает кнопку развёртывания
            SetupPictureBox();
            CreatePanel();
            CreateBlackChipsInPanel(panel);
            CreateRedChipsInPanel(panel);
            Center();
            StartPlay(p1, p2);
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

        //button1.Click += (s, e) => OldButton1();


        public void StartRolltheDice()
        {

            var dice1 = p1.RollTheDice();
            var dice2 = p2.RollTheDice();
            var imagePath1 = Path.Combine(baseDir, "..", "..", "..", "Ico", $"Cube{dice1}.jpg");
            var imagePath2 = Path.Combine(baseDir, "..", "..", "..", "Ico", $"Cube{dice2}.jpg");

            pictureBox1.Image = Image.FromFile(imagePath1);
            pictureBox2.Image = Image.FromFile(imagePath2);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            if (dice1 > dice2)
            {
                MessageBox.Show("Первый начинает игрок1");
                button1.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
            }
            else if (dice2  >  dice1)
            {
                MessageBox.Show("Первый начинает игрок2");
                button1.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
            }
            else
            {
                MessageBox.Show("НАДО ПОДБРОСИТЬ ЗАНОВО!!!");
                button1.BackColor = Color.GreenYellow;
                button1.Enabled = true;
            }
        }

        public void StartPlay(Player p1, Player p2)
        {
            var flag = true;
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

        private void OldButton1()
        {
            // "Выключаем" кнопку
            button1.BackColor = Color.White;
            button1.Enabled = false;
            StartRolltheDice();
        }

        //private void NewButton1
    }
}
