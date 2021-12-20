using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program 
    {
        static void Main(string[] args) 
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //           Color color = new Color { Id = 1, Name = "Blue" };
            //           color.Name = "Dark Blue";
            //           colorManager.UpdateColor(color);
            //           colorManager.AddColor(color); 
            //           colorManager.DeleteColor(color); 
            /*foreach (var color in colorManager.GetAllColors())
            {
                Console.WriteLine(color.Name);
            }
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.AddBrand(new Brand { Id = 1, Name = "Audi" });
            
            
            carManager.AddCar(new Car
            {
                Id = 1,
                BrandId = 1,
                ColorId = 1,
                CarName = "A7 Sportback",
                ModelYear = 2020,
                DailyPrice = 1000,
                Description = "full packet"  
            });
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails()) 
            {
                Console.WriteLine(car.CarName + '/' + car.BrandName
                    + '/' + car.ColorName + '/' + car.DailyPrice);
            }
            Console.ReadLine();    */

        }
        private static void CarTest()  
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data) 
                {
                    Console.WriteLine(car.CarName + '/' + car.BrandName
                    + '/' + car.ColorName + '/' + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message); 
            }
        }
    }
}
