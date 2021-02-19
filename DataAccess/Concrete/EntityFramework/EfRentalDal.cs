using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars
                             on rental.CarId equals car.CarID
                             join customer in context.Customers
                             on rental.CustomerId equals customer.UserId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 CustomerId = rental.CustomerId,
                                 CarName = car.CarName,
                                 CustomerName = customer.CompanyName,
                                 CarId = car.CarID,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 UserName = user.FirstName + " " + user.LastName
                             };

                return result.ToList();
            }
        }
    }
}
