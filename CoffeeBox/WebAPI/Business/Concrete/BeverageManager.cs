using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Business.Abstract;
using WebAPI.DataAccess.Abstract;
using WebAPI.Models;

namespace WebAPI.Business.Concrete
{
    public class BeverageManager : IBeverageService
    {
        private IBeverageRepository _beverageRepository;

        public BeverageManager(IBeverageRepository beverageRepository)
        {
            _beverageRepository = beverageRepository;
        }

        public List<Beverage> GetAll()
        {
            return _beverageRepository.GetAll();
        }

        public int GetPrice(int beverageId)
        {
            var result = _beverageRepository.GetAll().FirstOrDefault(b => b.Id == beverageId);

            int price = (result == null) ? -1 : result.Price;

            return price;
        }
    }
}
