using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess.Abstract
{
    public interface IFlavorRepository
    {
        /// <summary>
        /// Tüm çeşnileri getirir.
        /// </summary>
        /// <returns></returns>
        List<Flavor> GetAll();
    }
}
