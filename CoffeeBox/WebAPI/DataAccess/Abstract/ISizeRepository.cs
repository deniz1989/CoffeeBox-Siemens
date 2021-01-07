using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess.Abstract
{
    public interface ISizeRepository
    {
        /// <summary>
        /// Tüm içecek boylarını getirir.
        /// </summary>
        /// <returns></returns>
        List<Size> GetAll();
    }
}
