using System.Collections.Generic; 

namespace Visualiser.Moveable
{
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;

    public class Moveable : Thumb
    {
        public List<LineGeometry> EndLines { get; private set; }
        public List<LineGeometry> StartLines { get; private set; }

        public Moveable()
        {
            StartLines = new List<LineGeometry>();
            EndLines = new List<LineGeometry>();
        }
    }
}
