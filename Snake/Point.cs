namespace Snake
{
    public class Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public bool CompareTo(Point point)
        {
            if (point.X == X && point.Y == Y)
            {
                return true;
            }
            return false;
        }
    }
}
