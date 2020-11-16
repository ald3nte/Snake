using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sneke2
{
    public class Snake
    {
        public Snake next;
        public Rectangle body;
        public Snake last;
        public Snake prevoius;
        public Snake(Rectangle body)
        {
            this.body = body;
            this.last = null;
        }
        public void moveSnakeBody()
            {
                if (this.last != null)
                {
                    Snake tmp = this.last;
                    while (tmp.prevoius != null)
                    {

                        tmp.body = tmp.prevoius.body;
                        tmp = tmp.prevoius;
                    }
                }
            }

        public void growUp(Snake lastPartOfSnake)
        {
            if(this.last != null)
            {
                lastPartOfSnake.prevoius = this.last;
                this.last.next = lastPartOfSnake;
                
            }
            else
            {
                lastPartOfSnake.prevoius = this;
                this.next = lastPartOfSnake;
            }
           
            this.last = lastPartOfSnake;
        }
    }
}
