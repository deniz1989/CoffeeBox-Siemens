using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Business.Abstract
{
    public interface IBeverageService
    {
        /// <summary>
        /// İçecek ücretini getirir.
        /// </summary>
        /// <param name="beverageId"></param>
        /// <returns></returns>
        int GetPrice(int beverageId);

        /// <summary>
        /// Tüm içecekleri getirir.
        /// </summary>
        /// <returns></returns>
        List<Beverage> GetAll();
    }
}
