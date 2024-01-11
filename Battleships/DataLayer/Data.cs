namespace DataLayer
{
    public partial class Players
    {
        public Players(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }

    public partial class Games
    {
        public Games(string title, bool complete, string creatorFK, string opponentFK)
        {
            this.title = title;
            this.complete = complete;
            this.creatorFK = creatorFK;
            this.opponentFK = opponentFK;
        }
    }

    public partial class Attacks
    {
        public Attacks(string coordinate, bool hit, int gameFK)
        {
            this.coordinate = coordinate;
            this.hit = hit;
            this.gameFK = gameFK;
        }
    }

    public partial class Ships
    {
        public Ships(string title, int size)
        {
            this.title = title;
            this.size = size;
        }
    }

    public partial class GameShipConfigurations
    {
        public GameShipConfigurations(int gameFK, string playerFK, string coordinate)
        {
            this.gameFK = gameFK;
            this.playerFK = playerFK;
            this.coordinate = coordinate;
        }
    }
}

