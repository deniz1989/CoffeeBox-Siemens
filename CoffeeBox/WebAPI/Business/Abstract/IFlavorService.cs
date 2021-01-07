using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Business.Abstract
{
    public interface IFlavorService
    {
        /// <summary>
        /// Çeşni ücretini getirir.
        /// </summary>
        /// <param name="flavorId"></param>
        /// <returns></returns>
        int GetPrice(int flavorId);

        /// <summary>
        /// Tüm çeşnileri getirir.
        /// </summary>
        /// <returns></returns>
        List<Flavor> GetAll();
    }
}
