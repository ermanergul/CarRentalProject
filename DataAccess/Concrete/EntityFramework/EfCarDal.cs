using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car,RentACarContext>,ICarDal
    {

        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandID equals b.BrandId
                             join clr in context.Colors
                             on c.ColorID equals clr.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarID,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
      
        //public void Add(Car entity)
        //{
        //    //using içerisinde yazılan nesnler, using bitince anında garbage collector tarafından atılır
        //    //garbage collector performansı arttırmak için 
        //    //IDısposable pattern iöplementation of c#


        //    // Rentacarcontextten bir nesne oluştur
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        //addedEntity : Eklenen varlık
        //        //Renacarcontext'e bu entity'i bağla
        //        var addedEntity = context.Entry(entity);
        //        //Ekle
        //        addedEntity.State = EntityState.Added;
        //        //Kaydet
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        ////public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        //Eğer filtre göndermemişse 
        //        //Veri Kaynağındaki tüm datayı getir
        //        //Filtre Vermişse
        //        //Filtreyi Uygla
        //        //context.set<T>().ToList() : Dataya yerleş ve listele
        //        //rentacarcontext'de class proplarında data tabloları belirli

        //        return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        //    }
        //}
      

        //public void Update(Car entity)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}
    }
}
