using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal 
    {

        //Global değişkenler _ ile başlar. Bu Bir isimlendirme standardıdır.
        //Veri varmış gibi davranacağımız için ürün listesi oluşturduk
        List<Car> _cars;
        public InMemoryCarDal()//Bellekte referans aldığı zaman muhakkak çalışacak. (Contructor) (Pythondaki Self Gibi)
        {
            _cars = new List<Car> {
                //new Car{ID=1,BrandId=1,ColorId=1,ModelYear="2012",DailyPrice=56,Description="Cabrio"},
                //new Car{ID=2,BrandId=4,ColorId=2,ModelYear="2015",DailyPrice=70,Description="Sport"},
                //new Car{ID=3,BrandId=3,ColorId=1,ModelYear="2020",DailyPrice=100,Description="Hatchback"},
                //new Car{ID=4,BrandId=3,ColorId=3,ModelYear="2017",DailyPrice=120,Description="Coupe"},
                //new Car{ID=5,BrandId=7,ColorId=4,ModelYear="2000",DailyPrice=33,Description="Cabrio"},
                //new Car{ID=6,BrandId=5,ColorId=1,ModelYear="2011",DailyPrice=80,Description="Comfort"},
                //new Car{ID=7,BrandId=6,ColorId=2,ModelYear="2004",DailyPrice=54,Description="Sedan"},
                //new Car{ID=8,BrandId=2,ColorId=1,ModelYear="2003",DailyPrice=50,Description="Hatchback"},
                //new Car{ID=9,BrandId=2,ColorId=5,ModelYear="2021",DailyPrice=150,Description="Coupe"}

            };
        }
        public void Add(Car car)//
        {
            _cars.Add(car);
        }
        public void Delete(Car car)//------->LINQ
        {
            //_cars.Remove(car) ---> Çalışmaz çünkü arayüzden gönderilen car'ın bilgilerinin aynı olması önemli değil, çünkü aynı referansa sahip değiller.!!
            //Bu işlemde primary key'den faydalanılır. Id eşleştirmesi yapılır. LINQ burda devreye girer.


            //      LINQ ' SİZ KULLANIM
            Car carToDelete = null;//Referans Oluşturmayacak Şekilde Değişken Oluştur
            //foreach (var c in _cars)//datayı ile gez
            //{
            //    if (c.Id == car.Id)
            //    {
            //        carToDelete = c;//Id'ler üzerinden eşleştirme işlemi ile referanslar eşitlenmiş oldu
            //    }
            //}
            //_cars.Remove(carToDelete);//remove ile datadan sil

            //      LINQ
            //SingleOrDefault -> Tek bir eleman bulmaya yarar. 
            carToDelete = _cars.SingleOrDefault(c=>c.CarID==car.CarID);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()//Hepsini getirmek için veritabanındaki datayı businesse vermemiz gerekir.
        {
            return _cars;//veritabanını olduğu gibi dön
        }
        public List<Car> GetCheaps()
        {
            var result = _cars.Where(c => c.DailyPrice < 80);
            return result.ToList();
        }
        public List<Car> GetCoupeCars()
        {
            var result = _cars.Where(c => c.Descriptions == "Coupe").ToList();
            return result;
        }

       

        public List<Car> GetExpensives()
        {
            var result = from c in _cars
                         where c.DailyPrice > 100
                         select c;
            return result.ToList();
        }
        public List<Car> GetSedans()
        {
            var result = _cars.Where(c => c.Descriptions == "Sedan").ToList();
            return result;
        }
        public void Update(Car car)
        {
            //Gönderilen carıd'sine sahip olan car id'sini bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarID == car.CarID);

            carToUpdate.CarID = car.CarID;
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;

        }
    }
}
