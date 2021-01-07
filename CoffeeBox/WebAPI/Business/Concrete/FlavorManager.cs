using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Business.Abstract;
using WebAPI.DataAccess.Abstract;
using WebAPI.Models;

namespace WebAPI.Business.Concrete
{
    public class FlavorManager : IFlavorService
    {
        private IFlavorRepository _flavorRepository;

        public FlavorManager(IFlavorRepository flavorRepository)
        {
            _flavorRepository = flavorRepository;
        }

        public int GetPrice(int flavorId)
        {
            var result = _flavorRepository.GetAll().FirstOrDefault(b => b.Id == flavorId);

            int price = (result == null) ? -1 : result.Price;

            return price;
        }

        public List<Flavor> GetAll()
        {
            return _flavorRepository.GetAll();
        }
    }
}
