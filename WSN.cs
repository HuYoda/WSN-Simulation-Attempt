using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSN_Simulation_attempt_2
{
    public partial class Form1 : Form
    {
        private int range = 150;
        private int nodeSize = 30;
        private Size sizeOfNode = new Size(30, 30);
        private Size spawnRange = new Size(50, 50);
        private List<Node> nodes = new List<Node>(20);
        private Random _random = new Random(Guid.NewGuid().GetHashCode());
        private List<PictureBox> pictureBoxes = new List<PictureBox>(20);
        private int sybilIdCounter = 1;
        private List<Rectangle> rectangles = new List<Rectangle>(30);
        private List<Sybil> sybils = new List<Sybil>(10);

        public Form1()
        {
            InitializeComponent();
            area.Image = new Bitmap(area.Width, area.Height);
            area.Size = ClientSize;
            createNodes();
        }

        private void createNodes()
        {
            int lower = 17;
            int upperX = ClientSize.Width - nodeSize - 5;
            int upperY = ClientSize.Height - nodeSize - 155;
            int idCounter = 1;
            Point location;
            Rectangle newPosition;
            
            for (int i = 0; i < 20; i++)
            {
                while (true)
                {
                    location = new Point(_random.Next(lower, upperX), _random.Next(lower, upperY));
                    newPosition = new Rectangle(location, spawnRange);
                    //validate the newPosition
                    if (!rectangles.Any(x => x.IntersectsWith(newPosition)))
                    {
                        //break the loop when there isn't an overlapping rectangle found
                        break;
                    }
                    
                }
                rectangles.Add(newPosition);
                
                nodes.Add(new Node(idCounter, location));
                idCounter++;
            }
            
            defineNeighbours();
        }

        public void defineNeighbours()
        {
            foreach (Node node in nodes)
            {
                foreach (Node neighbour in nodes)
                {
                    if (node.Id != neighbour.Id)
                    {
                        if (isNeighbour(node, neighbour))
                        {
                            node.Neighbours.Add(neighbour);
                        }
                    }
                }
            }
        }

        public bool isNeighbour(Node node, Node neighbour)
        {
            int x = Math.Abs(node.Center.X - neighbour.Center.X);
            int y = Math.Abs(node.Center.Y - neighbour.Center.Y);

            double distance = Math.Sqrt(x * x + y * y);
            if (distance > range)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        private void spawn_Click(object sender, EventArgs e)
        {
            foreach (var node in nodes)
            {
                PictureBox newPictureBox = new PictureBox();
                //loop till you found a new position

                newPictureBox.Size = sizeOfNode;
                //newPictureBox.BackColor = Color.Teal;
                newPictureBox.Location = node.Location;
                newPictureBox.Image = Properties.Resources.node;
                newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                newPictureBox.Click += (unknownObject, unknownSender) => NodeInfo(sender, e, node);
                newPictureBox.Name = node.Id.ToString();
                
                Controls.Add(newPictureBox);
                newPictureBox.BringToFront();
            }
        }

        private void NodeInfo(object sender, EventArgs e, Node node)
        {
            Label nodeInfo = new Label();
            string neighbours = "";
            string id = node.Id.ToString();
            
            foreach (var neighbour in node.Neighbours)
            {
                neighbours += neighbour.Id.ToString() + " ";
            }
            
            nodeInfo.Text = "Id: " + id + "\nNeighbours: " + neighbours;
            nodeInfo.Size = new Size(150, 40);
            nodeInfo.Location = new Point(node.Location.X + 35, node.Location.Y + 35);
            
            using (var g = Graphics.FromImage(area.Image))
            {
                GraphicsExtensions.DrawCircle(g, Pens.ForestGreen, node.Center.X, node.Center.Y, range);
                area.Refresh();
            }

            Controls.Add(nodeInfo);
            nodeInfo.BringToFront();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            foreach (var node in nodes)
            {
                foreach (var neighbour in node.Neighbours)
                {
                    using (var g = Graphics.FromImage(area.Image))
                    {
                        g.DrawLine(Pens.ForestGreen, node.Center, neighbour.Center);
                        area.Refresh();
                    }
                }
            }
        } 
        
        private void sybilSpawn_Click(object sender, EventArgs e)
        {
            int lower = 17;
            int upperX = ClientSize.Width - nodeSize - 5;
            int upperY = ClientSize.Height - nodeSize - 155;
            Point location;
            
            Rectangle newPosition;
            PictureBox newPictureBox = new PictureBox();
            //loop till you found a new position
            while (true)
            {
                location = new Point(_random.Next(lower, upperX), _random.Next(lower, upperY));
                
                newPosition = new Rectangle(location, spawnRange);
                //validate the newPosition
                if (!rectangles.Any(x => x.IntersectsWith(newPosition)))
                {
                    //break the loop when there isn't an overlapping rectangle found
                    break;
                }
            }
            Sybil sybil = new Sybil(sybilIdCounter, location);
            sybilIdCounter++;
            
            newPictureBox.Size = sizeOfNode;
            //newPictureBox.BackColor = Color.Firebrick;
            newPictureBox.Location = location;
            newPictureBox.Image = Properties.Resources.sybil;
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            

            /*Graphics grf = this.CreateGraphics();
            using (Font myFont = new Font("Arial", 14))
            {
                grf.DrawString(sybil.Id.ToString(), myFont, Brushes.White, sybil.Center);
            }
            grf.Dispose();*/
            
            newPictureBox.Name = sybil.Id.ToString();
            newPictureBox.Click += (unknownObject, unknownSender) => SybilInfo(sender, e, sybil);
            
            defineSybilTargets(sybil);
            sybils.Add(sybil);
            
            rectangles.Add(newPosition);
            Controls.Add(newPictureBox);
            newPictureBox.BringToFront();
        }

        private void defineSybilTargets(Sybil sybil)
        {
            foreach (Node neighbour in nodes)
            {
                if (isNeighbour(sybil, neighbour))
                {
                    sybil.Neighbours.Add(neighbour);
                }
            }
        }

        private void SybilInfo(object sender, EventArgs e, Sybil sybil)
        {
            Label nodeInfo = new Label();
            string neighbours = "";
            string id = sybil.Id.ToString();
            
            foreach (var neighbour in sybil.Neighbours)
            {
                neighbours += neighbour.Id.ToString() + " ";
            }
            
            nodeInfo.Text = "Id: " + id + "\nNeighbours: " + neighbours;
            nodeInfo.Size = new Size(150, 40);
            nodeInfo.Location = new Point(sybil.Location.X + 35, sybil.Location.Y + 35);
            
            using (var g = Graphics.FromImage(area.Image))
            {
                GraphicsExtensions.DrawCircle(g, Pens.Crimson, sybil.Center.X, sybil.Center.Y, range);
                area.Refresh();
            }
            
            Controls.Add(nodeInfo);
            nodeInfo.BringToFront();
        }
        
        private void sybilConnect_Click(object sender, EventArgs e)
        {
            foreach (var sybil in sybils)
            {
                foreach (var neighbour in sybil.Neighbours)
                {
                    using (var g = Graphics.FromImage(area.Image))
                    {
                        g.DrawLine(Pens.Crimson, sybil.Center, neighbour.Center);
                        area.Refresh();
                    }
                }
            }
        }

        /*
         * create nodes+
         * spawn nodes+
         * define neighbours+
         * connect nodes+
         * draw lines+
         *
         * spawn sybil
         * define neighbours
         * connect sybil
         */
        
    }
}