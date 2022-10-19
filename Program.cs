namespace ThiefAndPoliceTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City city = new City();
            while (true)
            {
                city.Move();
                city.ShowCity();
                city.CheckForCoisions();
                
            }
        }
    }
}