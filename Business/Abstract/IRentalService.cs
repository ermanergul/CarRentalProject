using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rendalId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult  DeliveryDate(int carId);
        IResult UpdateReturnDate(int carId);
        IResult Update(Rental rentkal);

    }
}
