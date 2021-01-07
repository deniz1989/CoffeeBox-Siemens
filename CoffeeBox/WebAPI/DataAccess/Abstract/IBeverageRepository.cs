using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess.Abstract
{
    public interface IBeverageRepository
    {
        /// <summary>
        /// Tüm içecekleri getirir.
        /// </summary>
        /// <returns></returns>
        List<Beverage> GetAll();
    }
}
