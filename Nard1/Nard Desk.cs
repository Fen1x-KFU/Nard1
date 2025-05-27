using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Nard1
{
    internal partial class Form1 : Form
    {

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

        

        private void button1_Click(object sender, EventArgs e)
        {
            _buttonAction?.Invoke();
        }

        public void StartPlay(Player p1, Player p2)
        {
            _buttonAction = OldButton1;
        }

        private void OldButton1()
        {
            // "Выключаем" кнопку
            button1.BackColor = Color.White;
            button1.Enabled = false;
            StartRolltheDice();
        }

        private void NewButton1()
        {

        }
    }
}
