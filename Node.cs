using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace WSN_Simulation_attempt_2
{
    public class Node
    {
        private int id;
        private Point location;
        private List<Node> neighbours = new List<Node>(19);
        private Point center;
        
        public Node(int id, Point location)
        {
            this.location = location;
            this.id = id;
            center = new Point(location.X + 15, location.Y + 15);
        }

        protected Node()
        {
        }

        public virtual int Id
        {
            get => id;
            set => id = value;
        }

        public virtual Point Location
        {
            get => location;
            set => location = value;
        }

        public virtual List<Node> Neighbours
        {
            get => neighbours;
            set => neighbours = value;
        }

        public virtual Point Center
        {
            get => center;
            set => center = value;
        }

        /*
         * location
         * range
         * neighbours array
         * id
         * 
         */
    }
}