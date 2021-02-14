using Business.Abstract;
using Business.Constans;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalMenager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalMenager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = DeliveryDate(rental.CarId);
            if (result.Success)
            {
                return new SuccessResult(RentalMessages.Added);
            }
            return new ErrorResult(RentalMessages.Error);
        }

        public IResult DeliveryDate(int carId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count==0)
            {
                return new SuccessResult(RentalMessages.Added);
            }
            return new ErrorResult(RentalMessages.Error);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(RentalMessages.NullData);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),RentalMessages.Listed);
        }

        public IDataResult<Rental> GetById(int rendalId)
        {
            var result = _rentalDal.Get(r => r.Id == rendalId);
            if (result.ReturnDate == null)
            {
                return new ErrorDataResult<Rental>(RentalMessages.NullData);
            }


            return new SuccessDataResult<Rental>();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(RentalMessages.NullData);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),RentalMessages.Listed);
        }

        public IResult UpdateReturnDate(int ıd)
        {
            var result = _rentalDal.GetAll(c=>c.CarId==ıd);
            var updatedRental = result.LastOrDefault();
            if (updatedRental.ReturnDate!=null)
            {
                return new ErrorResult(RentalMessages.Error);
            }
            updatedRental.ReturnDate = DateTime.UtcNow;
            _rentalDal.Update(updatedRental);
            return new SuccessResult();

            
        }
    }
}
