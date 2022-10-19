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



        public City()
        {

            for (int row = 0; row < cityMap.GetLength(0); row++)
            {

                for (int col = 0; col < cityMap.GetLength(1); col++)
                {
                    cityMap[row, col] = new List<Person> ();
                }
            }


            for (int i = 0; i < 10; i++) 
            {
                Police p = new Police();
                cityMap[p.LocationRow, p.LocationCol].Add(p);
            }

            for (int i = 0; i < 20; i++)
            {
                Thief  t = new Thief ();
                cityMap[t.LocationRow, t.LocationCol].Add(t);
            }

            for (int i = 0; i < 30; i++)
            {
                Citizen c = new Citizen();
                cityMap[c.LocationRow, c.LocationCol].Add(c);
            }
            ShowCity();

            }
        public void CheckForCoisions()
        {
            for (int row = 0; row < cityMap.GetLength(0); row++)
            {

                for (int col = 0; col < cityMap.GetLength(1); col++)
                {
                    if (cityMap[row, col].Count >1)
                    {
                        cityMap[row, col].ElementAt(0).Colision(cityMap[row, col].ElementAt(1));
                        Thread.Sleep (1000);
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
                        list.Add(person); }
                        
                        foreach (Person person in list)
                        {
                        if (person.DirectionRow == 0 && person.DirectionCol == 0)
                        {


                           cityMap[person.LocationRow, person.LocationCol].Add(person);
                            cityMap[row, col].Remove(person); 
                        }
                        }
                    
                }
            }

        }
    } }
