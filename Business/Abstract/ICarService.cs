using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetByDailyPrice(int min, int max);

        IDataResult<List<CarDetailDto>> GetDetails();

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        



    }
}
