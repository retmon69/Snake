namespace Snake
{
    public class SnakeBodyPart
    {
        public Point Location;
        public string Direction;

        public SnakeBodyPart()
        {
            Direction = "Right";
            Location = new Point(1, 0);
        }

        public SnakeBodyPart(Point location, string direction)
        {
            Location = location;
            Direction = direction;
        }


    }
}
