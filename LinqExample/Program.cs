using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    public class Player
    {
        Guid _id;
        string _name;
        int _xp;

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + Xp.ToString();
           
        }
    }
    class Program
    {
        List<Player> players = new List<Player>()
        {
            new Player { Id = Guid.NewGuid(), Name ="Pete Volga", Xp=100},
            new Player { Id = Guid.NewGuid(), Name ="Joe Bloggs", Xp=50},
            new Player { Id = Guid.NewGuid(), Name ="Pete Townsend", Xp=200},
            new Player { Id = Guid.NewGuid(), Name ="Mary Shelly", Xp=300},
        };


        static void Main(string[] args)
        {
            //return the first occurance of the match or null
            Player found = players.FirstOrDefault(p => p.Name == "Mary Shelly");
            if(found != null)
                Console.WriteLine("{0}", found.ToString());
            else Console.WriteLine("Not Found");

            //return the first occurance of some records
            Player found1 = players.FirstOrDefault(p => p.Name.Contains("Pete"));
            if (found != null)
                Console.WriteLine("First Found {0}", found1.ToString());
            else Console.WriteLine("Not Found");




            //Return all thos with an XP value over 100
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if (topPlayers.Count > 0)
                foreach (var item in topPlayers)
                {
                    Console.WriteLine("{0}", found.ToString());
                }
            else Console.WriteLine("Not Found");

            Console.WriteLine();

            //Produce a scoreboard of Player names and scores
            Console.WriteLine("Top Scores");
            var ScoreBoard = players
                                    .OrderByDescending(o => o.Xp)
                                    .Select(scores => new { scores.Name, scores.Xp });
            foreach (var item in ScoreBoard)
            {
                Console.WriteLine("{0} {1} ",item.Name,item.Xp);
            }

            Console.ReadKey();
        }
    }
}
