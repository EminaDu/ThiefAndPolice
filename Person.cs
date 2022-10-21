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
        public int Robbed { get; set; }
        public int Arrested { get; set; }



        public Person(int rowSize, int colSize)
        {
            Random rnd = new Random();
            LocationRow = rnd.Next(0,rowSize);
            LocationCol = rnd.Next(0,colSize);

            DirectionRow = rnd.Next(-1, 2);
            DirectionCol = rnd.Next(-1, 2);
            Name = " ";
            Robbed = 0;
            Arrested = 0;
        }

        
  
        public virtual bool Colision(Person person)
        {
            return false;
        }

        public void Move(int cityRows, int cityCols)
        {
            LocationRow = (LocationRow + DirectionRow) % cityRows;
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
