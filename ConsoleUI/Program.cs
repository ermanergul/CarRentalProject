using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewColorAdded();
            //NewBrandAdded();
            //NewCarAdded();

            //DeleteCar();
            //DeleteColor();
            //DeleteBrand();

            //GetAllColors();
            //GetAllCars();
            //GetAllBrands();

            //UpdateBrand();
            //UpdateColor();
            //UpdateCar();

            //GetByIdCar();
            //GetByIdColor();
            //GetByIdBrand();

            //GetDetails();
            //GetAll();

            //AddUser();
            //AddCustomer();
            //RentACarUsageSimulation();

            //RentalDetailsDto();
            //AllRentals();
          


            Console.ReadLine();
        }

        private static void AllRentals()
        {
            RentalMenager rentalMenager = new RentalMenager(new EfRentalDal());
            var result = rentalMenager.GetAll();
            Console.WriteLine("**************{0}******************************************", result.Message);
            foreach (var re in result.Data)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(" ID : {0} \n ŞİRKET ID : {1} \n ARAÇ ID : {2} \n KİRALANAN TARİH : {3} \n KİRADAN DÖNME TARİHİ : {4}", re.Id, re.CustomerId, re.CarId, re.RentDate, re.ReturnDate);
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            }
        }

        private static void RentalDetailsDto()
        {
            RentalMenager rentalMenager = new RentalMenager(new EfRentalDal());
            var result = rentalMenager.GetRentalDetails();

            Console.WriteLine(result.Message);
            foreach (var rental in result.Data)
            {
               
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(" ID : {0} \n ŞİRKET ADI : {1} \n ARAÇ ADI : {2} \n KİRALANAN TARİH : {3} \n KİRADAN DÖNME TARİHİ : {4}", rental.Id, rental.CustomerName, rental.CarName, rental.RentDate, rental.ReturnDate);
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            }
        }

        private static void RentACarUsageSimulation()
        {
            RentalMenager rentalMenager = new RentalMenager(new EfRentalDal());
            string value1 = "15/02/2021";
            Rental rental = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Parse(value1) };
        
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer { UserId = 1003, CompanyName = "ergul33limited" };
            customerManager.Add(customer);
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = "erman", LastName = "ergyeal", Email = "erman2@gmail.com", Password = "2222" };
            userManager.Add(user);
        }

        private static void GetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("|" + "ID " + "=>" + car.CarID + "|" +
                    "BrandID " + "=>" + car.BrandID + "|" +
                    "ColorID " + "=>" + car.ColorID + "|" +
                    "ModelYear" + "=>" + car.ModelYear + "|" +
                    "DailyPrice" + "=>" + car.DailyPrice + "|" +
                    "Description " + car.Descriptions + "\n" + "|"
                    );
            }
        }

        private static void GetDetails()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            var result1 = carManager1.GetDetails();
            foreach (var car in result1.Data)
            {
                Console.WriteLine
                    (
                    "----------------------------------------------" + "\n" +
                    "Araba İsmi : " + car.CarName + "\n" +
                    "Araba Markası : " + car.BrandName + "\n" +
                    "Arabanın Rengi : " + car.ColorName + "\n" +
                    "Arabanın Kira Fiyatı : " + car.DailyPrice + "\n"

                    );
            }
        }

        private static void GetByIdBrand(int id)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(id);
            if (result.Success)
            {
                Console.WriteLine("Marka ID : " + result.Data.BrandId + "\n" + "Marka İsmi : " + result.Data.BrandName);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void GetByIdColor(int id)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetById(id);
            if (result.Success)
            {
                Console.WriteLine("Renk ID'si : " + result.Data.ColorId + "\n" + "Renk İsmi : " + result.Data.ColorName);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void GetByIdCar(int id)
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            var result = carManager1.GetById(id);
            if (result.Success)
            {
                Console.WriteLine(result.Data.CarID + result.Data.BrandID + result.Data.DailyPrice + result.Data.Descriptions);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }

        private static void UpdateCar()
        {
            Car car1 = new Car { CarID = 1, BrandID = 2, ColorID = 3, DailyPrice = 200, ModelYear = "2021", Descriptions = "Cabrio" };
            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Update(car1);
        }

        private static void UpdateColor()
        {
            Color color = new Color { ColorId = 1002, ColorName = "Kahverengi" };
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(color);
            Console.WriteLine();
        }

        private static void GetAllColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void UpdateBrand()
        {
            Brand brand = new Brand { BrandId = 1002, BrandName = "Hyundai" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(brand);
        }

        private static void DeleteBrand()
        {
            Brand brand = new Brand { BrandId = 1002, BrandName = "VOLVO" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(brand);
        }

        private static void DeleteColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color { ColorId = 1002, ColorName = "Pembe" };
            colorManager.Delete(color);
        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car1 = new Car { CarID = 2002, BrandID = 1, ColorID = 2, ModelYear = "2021", DailyPrice = -300, Descriptions = "Otomatik Dizel" };

            carManager.Delete(car1);
        }

        private static void GetAllBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(result.Message);
           
        }

        private static void GetAllCars()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void NewCarAdded()
        {
            Car car = new Car { BrandID = 3, ColorID = 4, Descriptions = "Hatcback", CarName="Clio" , DailyPrice = 70, ModelYear = "2015" };
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car);
            
        }

        private static void NewBrandAdded()
        {
            Brand brand = new Brand { BrandName = "VOLVO" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(brand);
        }

        private static void NewColorAdded()
        {
            Color color = new Color { ColorName = "Pembe" };
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(color);
        }


        //  O   L   D       V   E   R   S   İ   O   N       S  İ   M   U   L   A   T   İ   O   N       C   O   N   S   O   L   E
        //var car1 = new Car { Id = 11, BrandId = 10, ColorId = 5, ModelYear = 2011, DailyPrice = 100, Description = "Cabrio" };

        //var cars = carManager.GetAll();
        //var cars1 = carManager.GetCoupeCars();
        //var cars2 = carManager.GetCheaps();
        //var cars3 = carmanager.GetExpensives();
        //var car4 = carManager.GetSedans();

        //Console.WriteLine("                     **********W E L C O M E   T O   R E N T   A   C A R   S Y S T E M *****************");
        //Console.WriteLine("\n");
        //Console.WriteLine("_______________________________________________________________________________________");
        //Console.WriteLine("                     **********    A  L  L     C A R S    A  T   S Y S T E M           *****************");
        //foreach (var car in cars)
        //{
        //    Console.WriteLine("|" + "ID " + "=>" + car.Id + "|" +
        //        "BrandID " + "=>" + car.BrandId + "|" +
        //        "ColorID " + "=>" + car.ColorId + "|" +
        //        "ModelYear" + "=>" + car.ModelYear + "|" +
        //        "DailyPrice" + "=>" + car.DailyPrice + "|" +
        //        "Description " + car.Description + "\n" + "|"
        //        );
        //}
        //Console.WriteLine("_______________________________________________________________________________________");
        //Console.WriteLine("                     ********** E X P E N S İ V E     C A R S    A  T   S Y S T E M     *****************");
        //foreach (var car in cars3)
        //{
        //    Console.WriteLine("|" + "ID " + "=>" + car.Id + "|" +
        //        "BrandID " + "=>" + car.BrandId + "|" +
        //        "ColorID " + "=>" + car.ColorId + "|" +
        //        "ModelYear" + "=>" + car.ModelYear + "|" +
        //        "DailyPrice" + "=>" + car.DailyPrice + "|" +
        //        "Description " + car.Description + "\n" + "|"
        //        );
        //}
        //Console.WriteLine("_______________________________________________________________________________________");
        //Console.WriteLine("                     **********   C H E A P       C A R S       A  T   S Y S T E M      *****************");
        //foreach (var car in cars2)
        //{
        //    Console.WriteLine("|" + "ID " + "=>" + car.Id + "|" +
        //        "BrandID " + "=>" + car.BrandId + "|" +
        //        "ColorID " + "=>" + car.ColorId + "|" +
        //        "ModelYear" + "=>" + car.ModelYear + "|" +
        //        "DailyPrice" + "=>" + car.DailyPrice + "|" +
        //        "Description " + car.Description + "\n" + "|"
        //        );
        //}
        //Console.WriteLine("_______________________________________________________________________________________");
        //Console.WriteLine("                     **********    C O U P E     C A R S    A  T   S Y S T E M           *****************");
        //foreach (var car in cars1)
        //{
        //    Console.WriteLine("|" + "ID " + "=>" + car.Id + "|" +
        //        "BrandID " + "=>" + car.BrandId + "|" +
        //        "ColorID " + "=>" + car.ColorId + "|" +
        //        "ModelYear" + "=>" + car.ModelYear + "|" +
        //        "DailyPrice" + "=>" + car.DailyPrice + "|" +
        //        "Description " + car.Description + "\n" + "|"
        //        );
        //}
        //Console.WriteLine("_______________________________________________________________________________________");
        //Console.WriteLine("                     **********    S E D A N     C A R S    A  T   S Y S T E M           *****************");
        //foreach (var car in car4)
        //{
        //    Console.WriteLine("|" + "ID " + "=>" + car.Id + "|" +
        //        "BrandID " + "=>" + car.BrandId + "|" +
        //        "ColorID " + "=>" + car.ColorId + "|" +
        //        "ModelYear" + "=>" + car.ModelYear + "|" +
        //        "DailyPrice" + "=>" + car.DailyPrice + "|" +
        //        "Description " + car.Description + "\n" + "|"
        //        );
        //}
        //Console.WriteLine("_______________________________________________________________________________________");


        //var car2 = new Car { Id = 12, BrandId = 11, ColorId = 9, ModelYear = 2021, DailyPrice = 150, Description = "Coupe" };


        //Console.WriteLine("             **********           N E W   C A R    P R O P E R T İ E S                  *****************");
        //Console.WriteLine("|" + "ID " + "=>" + car1.Id + "|" +
        //       "BrandID " + "=>" + car1.BrandId + "|" +
        //       "ColorID " + "=>" + car1.ColorId + "|" +
        //       "ModelYear" + "=>" + car1.ModelYear + "|" +
        //       "DailyPrice" + "=>" + car1.DailyPrice + "|" +
        //       "Description " + car1.Description + "\n" + "|"
        //       );

        //Console.WriteLine("_______________________________________________________________________________________");


        
    }

}

