using DataLayer;

namespace BusinessLogicLayer
{
    public class BusinessLogic
    {
        public static BattleshipsDBEntities db = new BattleshipsDBEntities();

        public void AddPlayer(string username, string password) // add player to database
        {
            Players player = new Players(username, password); // create new player object and add to database
            db.Players.Add(player);
            db.SaveChanges();
        }

        public int GetPlayerUsernameCount(string username) // get count of players with username
        {
            var playerCount = (from player in db.Players
                               where player.username == username
                               select player).Count();

            return playerCount;
        }

        public string GetPlayerPassword(string username) // get password of player
        {
            var playerPassword = (from player in db.Players
                                  where player.username == username
                                  select player.password).First();

            return playerPassword;
        }

        public void AddGame(string title, bool complete, string creatorFK, string opponentFK) // add game to database
        {
            Games game = new Games(title, complete, creatorFK, opponentFK); // create new game object and add to database
            db.Games.Add(game);
            db.SaveChanges();
        }

        public void UpdateGameComplete(int gameFK) // update game complete
        {
            var game = (from g in db.Games
                        where g.id == gameFK
                        select g).First();

            game.complete = true;
            db.SaveChanges();
        }

        public int GetLatestGameId() // get id of game
        {
            var gameID = (from game in db.Games
                          select game.id).Max();

            return gameID;
        }

        public int GetShipSize(int id) // get size of ship
        {
            var shipSize = (from ship in db.Ships
                            where ship.id == id
                            select ship.size).First();

            return (int)shipSize;
        }

        public void AddGameShipConfiguration(string coordinate, string playerFK, int gameFK) // add game ship configuration to database
        {
            GameShipConfigurations gameShipConfiguration = new GameShipConfigurations(gameFK, playerFK, coordinate); // create new game ship configuration object and add to database
            db.GameShipConfigurations.Add(gameShipConfiguration);
            db.SaveChanges();
        }

        public List<string> GetGameShipConfigurationCoordinates(int gameFK, string playerFK) // get coordinates of game ship configuration
        {
            var gameShipConfigurationCoordinates = (from gameShipConfiguration in db.GameShipConfigurations
                                                    where gameShipConfiguration.gameFK == gameFK && gameShipConfiguration.playerFK == playerFK
                                                    select gameShipConfiguration.coordinate).ToList();

            return gameShipConfigurationCoordinates;
        }

        public void AddAttack(string coordinate, bool hit, int gameFK) // add attack to database
        {
            Attacks attack = new Attacks(coordinate, hit, gameFK); // create new attack object and add to database
            db.Attacks.Add(attack);
            db.SaveChanges();
        }
    }
}