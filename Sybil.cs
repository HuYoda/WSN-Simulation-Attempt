using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace WSN_Simulation_attempt_2
{
    public class Sybil : Node
    {
        private int id;
        private Point location;
        private List<Node> neighbours = new List<Node>(19);
        private Point center;
        
        public Sybil(int id, Point location)
        {
            this.location = location;
            this.id = id;
            center = new Point(location.X + 15, location.Y + 15);
        }
        
        public override int Id
        {
            get => id;
            set => id = value;
        }

        public override Point Location
        {
            get => location;
            set => location = value;
        }

        public override List<Node> Neighbours
        {
            get => neighbours;
            set => neighbours = value;
        }

        public override Point Center
        {
            get => center;
            set => center = value;
        }
        
    }
}