using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiefAndPoliceTest
{
    internal class City
    {
        
       List< Person> [,] cityMap= new List<Person>[25, 100];
        List< Person> [,] prison = new List<Person>[10, 10];
        int numberOfPeopleRobbed = 0;
        int numberOfThiefsCatched = 0;


        public City()
        {

            for (int row = 0; row < cityMap.GetLength(0); row++)
            {

                for (int col = 0; col < cityMap.GetLength(1); col++)
                {
                    cityMap[row, col] = new List<Person>();
                }
            }

            for(int row = 0; row < prison .GetLength(0); row++)
            {

                for (int col = 0; col < prison.GetLength(1); col++)
                {
                    prison[row, col] = new List<Person>();
                }
            }
        


            for (int i = 0; i < 10; i++) 
            {
                Police p = new Police(cityMap.GetLength(0),cityMap.GetLength(1));
                cityMap[p.LocationRow, p.LocationCol].Add(p);
            }

            for (int i = 0; i < 20; i++)
            {
                Thief  t = new Thief(cityMap.GetLength(0), cityMap.GetLength(1));
                cityMap[t.LocationRow, t.LocationCol].Add(t);
            }

            for (int i = 0; i < 30; i++)
            {
                Citizen c = new Citizen(cityMap.GetLength(0), cityMap.GetLength(1));
                cityMap[c.LocationRow, c.LocationCol].Add(c);
            }
            ShowCity();
            CalculateNumberOfColisions();
        }

        private void ShowPrison()
        {
            for (int row = 0; row < prison.GetLength(0); row++)
            {

                for (int col = 0; col < prison.GetLength(1); col++)
                {
                   if (prison[row, col].Count == 0)
                    {
                        Console.Write(" ");
                    }
                    else if (prison[row, col].Count > 1)
                    {
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.Write(prison[row, col].First().Name);
                    }

                }
                Console.WriteLine();
            }
        }

        public void CheckForCoisions()
        {
            for (int row = 0; row < cityMap.GetLength(0); row++)
            {

                for (int col = 0; col < cityMap.GetLength(1); col++)
                {
                    bool shouldRemoveThief = false;
                    int thiefIndex = 0;
                    if (cityMap[row, col].Count >1)
                    {
                        bool isSuccessful = cityMap[row, col].ElementAt(0).Colision(cityMap[row, col].ElementAt(1));
                        if (cityMap[row, col].ElementAt(0) is Police && cityMap[row, col].ElementAt(1) is Thief && isSuccessful)
                        {
                                shouldRemoveThief = true;
                                thiefIndex = 1;
                                ((Thief)cityMap[row, col].ElementAt(1)).MoveToPrison(prison.GetLength(0), prison.GetLength(1));
                                prison[cityMap[row, col].ElementAt(1).LocationRow, cityMap[row, col].ElementAt(1).LocationCol].Add(cityMap[row, col].ElementAt(1));
                        } 
                        else if (cityMap[row, col].ElementAt(0) is Thief && cityMap[row, col].ElementAt(1) is Police && isSuccessful)
                        {
                            shouldRemoveThief= true;
                            thiefIndex = 0;
                            ((Thief)cityMap[row, col].ElementAt(0)).MoveToPrison(prison.GetLength(0), prison.GetLength(1));
                            prison[cityMap[row, col].ElementAt(0).LocationRow, cityMap[row, col].ElementAt(0).LocationCol].Add(cityMap[row, col].ElementAt(0));
                        }
                            Thread.Sleep (1500);
                    }
                    if (shouldRemoveThief)
                    {
                        cityMap[row, col].RemoveAt(thiefIndex);
                    }
                }
            }
            
        }
       
        public void ShowCity()
        {
            Console.Clear();

            for (int row = 0; row < cityMap.GetLength(0); row++)
            {

                for (int col = 0; col < cityMap.GetLength(1); col++)
                {
                    if (cityMap[row, col].Count == 0)
                    {
                        Console.Write(" ");
                    }
                    else if(cityMap[row, col].Count > 1)
                    {
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.Write(cityMap[row,col].First().Name );
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("***Prison***");
            ShowPrison();
        }

        public void CalculateNumberOfColisions()
        {
            for (int row = 0; row < cityMap.GetLength(0); row++)
            {

                for (int col = 0; col < cityMap.GetLength(1); col++)
                {
                    foreach (Person person in cityMap[row, col])
                    {
                        numberOfPeopleRobbed += person.Robbed;
                        numberOfThiefsCatched += person.Arrested;
                    }
                }
            }


        }
        

        public void Move()
        {

            for (int row = 0; row < cityMap.GetLength(0); row++)
            {

                for (int col = 0; col < cityMap.GetLength(1); col++)
                {
                    foreach(Person person in cityMap[row, col])
                    {
                        person.Move(cityMap.GetLength (0), cityMap.GetLength(1));   
                    }
                }
            }

            for (int row = 0; row < cityMap.GetLength(0); row++)
            {

                for (int col = 0; col < cityMap.GetLength(1); col++)
                {
                    List<Person> list = new List<Person>();
                    foreach (Person person in cityMap[row, col])
                    {
                        list.Add(person);
                    }

                    foreach (Person person in list)
                    {
                        if (person.DirectionRow != 0 && person.DirectionCol != 0)
                        {
                            cityMap[person.LocationRow, person.LocationCol].Add(person);
                            cityMap[row, col].Remove(person);
                        }
                    }

                }
            }
            MovePrison();
        }

        public void MovePrison()
        {

            for (int row = 0; row < prison.GetLength(0); row++)
            {

                for (int col = 0; col < prison.GetLength(1); col++)
                {
                    foreach (Person person in prison[row, col])
                    {
                        person.Move(prison.GetLength(0), prison.GetLength(1));
                    }
                }
            }

            for (int row = 0; row < prison.GetLength(0); row++)
            {

                for (int col = 0; col < prison.GetLength(1); col++)
                {
                    List<Person> list = new List<Person>();
                    foreach (Person person in prison[row, col])
                    {
                        list.Add(person);
                    }

                    foreach (Person person in list)
                    {
                        if (person.DirectionRow != 0 && person.DirectionCol != 0)
                        {
                            prison[person.LocationRow, person.LocationCol].Add(person);
                            prison[row, col].Remove(person);
                        }
                    }

                }
            }
        }
        
        //public void Print()
        //{
        //    CalculateNumberOfColisions();
        //    Console.WriteLine("Antal rånade medborgare: " + numberOfPeopleRobbed);

        //    Console.WriteLine("Antal gripna tjuvar: " + numberOfThiefsCatched);
        //}
    }
}
