using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Business.Abstract
{
    public interface ISizeService
    {
        /// <summary>
        /// İçecek boyunun % olarak ücretini getirir. Örneğin: 3 numaralı boy Venti'dir ve değeri 40 dır. İçecek ücreti hesaplandığı zaman, baz fiyata %40 eklenebilmesi için kurguladım.
        /// </summary>
        /// <param name="sizeId"></param>
        /// <returns></returns>
        int GetPercentageOfPrice(int sizeId);

        /// <summary>
        /// Tüm içecek boylarını getirir.
        /// </summary>
        /// <returns></returns>
        List<Size> GetAll();
    }
}
