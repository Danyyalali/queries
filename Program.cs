using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace LINQMANIPULATION
{
    class Program
    {
        public  List<Player> getPlayers()
        {
            List<Player> pl;
            using (var context = new PlayerContext())
            {
                
                Console.WriteLine("Started getting the data from the database");
                pl = (from ln in context.Players
                            select ln).ToList();
                Console.WriteLine("Got the data from the database");
            }
            Console.WriteLine("Returning data to the call point");
            return pl;
        }
        static void Main(string[] args)
        {
            /*using (var context = new PlayerContext())
            {
                // to introduce the data in the database using the input from the user
                string name, nationality, tier;
                int age, pay;
                var player = new Player();
                for (int i = 0; i < 1; i++)
                {
                    Console.Write("Please enter your Name\nName:::");
                    name = Console.ReadLine().ToLower();
                    Console.Write("Please enter your Nationality\nNationality:::");
                    nationality = Console.ReadLine().ToLower();
                    Console.Write("Please enter your Tier\nTier:::");
                    tier = Console.ReadLine().ToLower();
                    Console.Write("Please enter your Age\nAge:::");
                    age = int.Parse(Console.ReadLine());
                    while (age < 1 || age > 40)
                    {
                        Console.Write("Please enter Valid Value\nAge:::");
                        age = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Please enter your Pay\nPay:::");
                    pay = int.Parse(Console.ReadLine());

                    player = new Player()
                    {
                        name = name,
                        age = age,
                        nationality = nationality,
                        pay = pay,
                        tier = tier
                    };
                    context.Players.Add(player);

                }
                context.SaveChanges();
            }*/
            using (var context = new PlayerContext())
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //For first occurence of the data
                /*var playerFirst = (from pl in context.Players
                              where pl.age > 30
                              select pl).FirstOrDefault<Player>();
                Console.WriteLine(playerFirst.name + " ");
                */


                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //For Last occurence of the data
                /* var playerLast = (from pl in context.Players
                                    orderby pl.age ascending
                                    select pl).LastOrDefault<Player>();
                 Console.WriteLine(playerLast.name + " ");
                */




                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////for multiple records
                /*
                 var player = (from pl in context.Players
                             where pl.age>30
                             select pl);
                 var ple = player.ToList();
                foreach (var item in ple)
                {
                    Console.WriteLine(item.name + " ");

                }*/



                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //For descending order of the records
                /*  var playerAll = (from pl in context.Players
                                   orderby pl.name descending
                                   select pl);
                  foreach (var item in playerAll)
                  {
                      Console.WriteLine(item.name + " "+item.age);

                  }
  */



                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //uisng group clause
                /*var GroupedData = (from pl in context.Players.AsEnumerable()
                                   group pl by pl.nationality);

                foreach (var item in GroupedData)
                {
                    Console.WriteLine(item.Key+" "+ item.Count()+" ");
                    foreach (var it in item)
                    {
                        Console.WriteLine($"The value against the key {item.Key} is " + it.name);

                    }
                }*/



                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Grouping the data based on nationality and pay
                /*var GroupedData = from pl in context.Players.AsEnumerable()
                                  group pl by new { pl.nationality, pl.pay } into MixedGroup
                                  orderby MixedGroup.Key.nationality, MixedGroup.Key.pay
                                  select new
                                  {
                                      MixedGroup.Key.nationality,
                                      MixedGroup.Key.pay,
                                      PL = MixedGroup.OrderBy(x => x.name)
                                  };
                foreach (var item in GroupedData)
                {
                    Console.WriteLine("{0} {1} {2} ", item.nationality, item.pay, item.PL.Count());
                    foreach (var it in item.PL)
                    {
                        Console.WriteLine($"The name is {it.name} and the tier is " + it.tier);

                    }
                }*/

                List<Player> asd = context.Players.FromSqlRaw("SELECT * FROM Players Where age > 30").ToList();
                Console.WriteLine(asd.Count());


                //to delete the specific data from the records

               /* var player1 = (from de in context.Players
                              where de.name == "babar azam"
                              select de).FirstOrDefault<Player>();
                context.Players.Remove(player1);
                context.SaveChanges();*/


            }
            List<Player> p;
            Program pg = new Program();
            p=pg.getPlayers();
            var q = p.FirstOrDefault<Player>();
            Console.WriteLine(q.name);

        }
    }
}
