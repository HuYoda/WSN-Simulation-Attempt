using System.Drawing;

namespace WSN_Simulation_attempt_2
{
    public class GraphicsExtensions
    {
        public static void DrawCircle(Graphics g, Pen pen,
            float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                radius + radius, radius + radius);
        }

        public static void FillCircle(Graphics g, Brush brush,
            float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                radius + radius, radius + radius);
        }
    }
}