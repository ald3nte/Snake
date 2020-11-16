using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sneke2
{
    public partial class Form1 : Form
    {
        Snake snake,lastPartOfSnake;
        Rectangle food;
        Graphics g1;
        Brush b1;
        bool isEat;
        Keys k1;
        Random randX,randY;
        public Form1()
        {
            InitializeComponent();
            g1 = panel1.CreateGraphics();
            randX = new Random();
            randY = new Random();
            food = new Rectangle();
            snake = new Snake(new Rectangle(panel1.Size.Width / 2, panel1.Size.Height / 2, 5, 5));
            isEat = false;
           // snake = new Rectangle(panel1.Width-5, 0 , 5, 5);
            b1 = new SolidBrush(Color.Black);
            food.X = randX.Next(0, (panel1.Width - 5) / 5)*5;
            food.Y = randY.Next(0, (panel1.Height - 5) / 5)*5;
          
            food.Width = 5;food.Height = 5;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Snake tmp = snake;
            while (tmp != null)
            {
                g1.FillRectangle(b1, tmp.body);
                tmp = tmp.next;
            }
            if(isEat == true)
            {
                food.X = randX.Next(0, (panel1.Width - 5) / 5) * 5;
                food.Y = randY.Next(0, (panel1.Height - 5) / 5) * 5;
                isEat = false;
            }

            g1.FillRectangle(b1, food);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right|| e.KeyCode == Keys.Left|| e.KeyCode == Keys.Up || e.KeyCode == Keys.Down )
            {
                timer1.Start();
            }
            k1 = e.KeyCode;
            
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            IsEat();

            snake.moveSnakeBody();

            switch (k1)
            {
                case Keys.Right:
                    snake.body.X += 5;

                    break;
                case Keys.Left:
                    snake.body.X -= 5;

                    break;
                case Keys.Up:
                    snake.body.Y -= 5;

                    break;
                case Keys.Down:
                    snake.body.Y += 5;

                    break;
            }
            if( lastPartOfSnake != null)
            {
                snake.growUp(lastPartOfSnake);
                lastPartOfSnake = null;
            }
            
            panel1.Refresh();
        }

        private void IsEat()
        {
            if(snake.body.X == food.X && snake.body.Y == food.Y)
            {
                // food.newPosition();
                if (snake.last == null)
                {
                    isEat = true;
                    lastPartOfSnake = new Snake(snake.body);
                }
                else
                {
                    isEat = true;
                    lastPartOfSnake = new Snake(snake.last.body);
                }
            }
            
            
        }
    }
}
