using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Veri Erişim işlemlerinin yapılacağı yer

    //Her zaman bir class oluşturmadan önce onun interfacesini oluşturmak gerekir. Bunu bir standart haline getir!. 

    //DAL -> Data Access Layer (Veri Erişim Katmanı)    |   JAVA-> DAO Data Access Object (Veri Erişim Objesi)
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();

        //interface metodları default olarak public'tir.
        //List<Car> GetAllCars();
        //List<Car> GetCoupeCars();

        //List<Car> GetExpensives();

        //List<Car> GetCheaps();

        //List<Car> GetSedans();

        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);


    }
}
