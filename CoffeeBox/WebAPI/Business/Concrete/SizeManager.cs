using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Business.Abstract;
using WebAPI.DataAccess.Abstract;
using WebAPI.Models;

namespace WebAPI.Business.Concrete
{
    public class SizeManager : ISizeService
    {
        private ISizeRepository _sizeRepository;

        public SizeManager(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public int GetPercentageOfPrice(int sizeId)
        {
            var result = _sizeRepository.GetAll().FirstOrDefault(s => s.Id == sizeId);

            int price = (result == null) ? -1 : result.Price;

            return price;
        }

        public List<Size> GetAll()
        {
            return _sizeRepository.GetAll();
        }
    }
}
