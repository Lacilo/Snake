using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    internal class SnakePos
    {
        public List<Pos> Positions { get; set; }
        public int MaxSnakeLength { get; set; }
    }
}
