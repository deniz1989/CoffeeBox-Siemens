using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlavorsController : ControllerBase
    {
        private IFlavorService _flavorService;

        public FlavorsController(IFlavorService flavorService)
        {
            _flavorService = flavorService;
        }

        /// <summary>
        /// Ekstra (çeşni) ücretini hesaplar ve getirir.
        /// </summary>
        /// <param name="flavorId">çeşni id</param>
        /// <param name="numberOfFlavor">adet sayısı</param>
        /// <returns></returns>
        [HttpGet("getprice")]
        public IActionResult GetPrice(int flavorId, int numberOfFlavor)
        {
            if (flavorId < 0)
            {
                return BadRequest("Çeşni id 0'dan küçük olamaz!");
            }

            if (numberOfFlavor < 1)
            {
                return BadRequest("Çeşni sayısı 1'den küçük olamaz!");
            }

            int flavorPrice = _flavorService.GetPrice(flavorId);

            if (flavorPrice == -1)
            {
                return BadRequest(String.Format("Numarası {0} olan bir çeşni bulunmamaktadır!", flavorId));
            }

            //adet sayısına göre totalPrice hesaplanır. Kullanıcı 1 adet mocha sipariş ederken yanına söylediği süte bir sınırlama getirmedim.
            //Mocha'sını x10 sütlü de isteyebilsin (çalışan x10 milk girebilsin), işletme buna açık :)
            int totalPrice = flavorPrice * numberOfFlavor;

            return Ok(totalPrice);
        }

        public IActionResult GetPrice(int flavorId)
        {
            if (flavorId < 0)
            {
                return BadRequest("Çeşni id 0'dan küçük olamaz!");
            }

            int flavorPrice = _flavorService.GetPrice(flavorId);

            if (flavorPrice == -1)
            {
                return BadRequest(String.Format("Numarası {0} olan bir çeşni bulunmamaktadır!", flavorId));
            }

            return Ok(flavorPrice);
        }
    }
}