using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiefAndPoliceTest
{
    internal class Person
    {
        public string Name { get; set; } 
        public int LocationRow { get; set; } //nuvarande position, ges av direction
        public int LocationCol { get; set; } //nuvarande position, ges av direction
        public int DirectionRow { get; set; }
        public int DirectionCol { get; set; }
        
         

        public Person()
        {
            Random rnd = new Random();
            LocationRow = rnd.Next(0,25);
            LocationCol = rnd.Next(0,100);

            DirectionRow = rnd.Next(-1,2);
            DirectionCol = rnd.Next(-1,2);
            Name = " ";

            
        }

        
  
        public virtual void Colision(Person person)
        {

        }

        public void Move(int cityRows, int cityCols)
        {
            Random rnd = new Random();
            
            DirectionRow = rnd.Next(-1, 2);
            DirectionCol = rnd.Next(-1, 2);

            LocationRow = (LocationRow + DirectionRow) % cityRows ;
            LocationCol = (LocationCol + DirectionCol) % cityCols;
            if (LocationCol < 0)
            {
                LocationCol = cityCols-1;

            }
            if (LocationRow < 0)
            {
                LocationRow =cityRows -1;

            }

        }




    }
}
