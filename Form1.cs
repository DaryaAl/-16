using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_работа__16
{
    public partial class Form1 : Form
    {
        int veter, vector, counter;
        Rectangle r1, r2;


        private void menuStrip1_KeyUp(object sender, KeyEventArgs e)
        {
            vector = 0;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)//если нажата кнопка влево
                vector = -10;//вектор смещения влево
            if (e.KeyData == Keys.Right)//если нажата кнопка вправо
                vector = 10;//вектор смещения вправо 
        }

        private void оПргограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик Алешина Дарья ИСП-31" +
                "Игра Снегопад");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Width = 639;
            this.Height = 479;
            this.MaximizeBox = false;// кнопка развёртывая
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            pictureBox2.Height = 60;//высота
            pictureBox2.Width = 80;//ширина         
            pictureBox5.Parent = pictureBox1;
            pictureBox2.Parent = pictureBox1;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            Random r = new Random();//рандом
            //задаем расположение объекта по координате Х от 100 д 200
            pictureBox2.Left = r.Next(50, 400);
            //задаем расположения объекта  по координате y
            pictureBox2.Top = -120;
            veter = r.Next(5);//задаем силу ветра
            vector = 0;//обнуляем скорость смещения
            counter = 1;//счетчик для отображения картинок
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            //задаем расположение объекта 
            pictureBox5.Left = r.Next(50, 400);

            //задаем расположения объекта 
            pictureBox5.Top = -120;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int skorost_padenia = 5;//скорость падения

            //перемещение по X с учетом ветра и вектора управления
            pictureBox2.Left = pictureBox2.Left + veter + vector;

            //Перемещение по Y
            pictureBox2.Top = pictureBox2.Top + skorost_padenia;

            counter++;//Увеличиваем значение
            if (counter > 10)
                counter = 0;

            //Картинка вышла за форму
            if (pictureBox2.Top >= pictureBox1.Height)
            {
                timer1.Enabled = false;
                MessageBox.Show("Проигрыш");
            }
            r1 = pictureBox2.DisplayRectangle; r2 = pictureBox5.DisplayRectangle;
            r1.Location = pictureBox2.Location; r2.Location = pictureBox5.Location;

            //Картинка пересеклась с другой картинкой
            if (r1.IntersectsWith(r2) == true)
            {
                timer1.Enabled = false;
                MessageBox.Show("Вас засыпало снегом. Поздравляю!");
            }
        }
    }
}
