namespace Nard1
{
    internal partial class Form1 : Form
    {
        PictureBox pictureBox = new PictureBox();
        Panel panel = new Panel();
        Player p1 = new Player();
        Player p2 = new Player();
        //List<Button> buttons = new List<Button>();
        private Action _buttonAction; // Делегат для хранения действия

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
                _buttonAction -= OldButton1;
                _buttonAction += NewButton1;
                button1.Enabled = true;
                button1.BackColor = Color.Blue;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
            }
            else if (dice2 > dice1)
            {
                MessageBox.Show("Первый начинает игрок2");
                _buttonAction -= OldButton1;
                _buttonAction += NewButton1;
                button1.Enabled = true;
                button1.BackColor = Color.Blue;
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
    }
}
