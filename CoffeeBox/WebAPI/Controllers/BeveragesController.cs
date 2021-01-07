using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business.Abstract;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        private IBeverageService _beverageService;
        private ISizeService _sizeService;

        public BeveragesController(IBeverageService beverageService, ISizeService sizeService)
        {
            _beverageService = beverageService;
            _sizeService = sizeService;
        }

        /// <summary>
        /// İçeceğin ücretini, içecek türüne ve boyuna göre hesaplar ve getirir
        /// </summary>
        /// <param name="beverageId">İçecek id numarası</param>
        /// <param name="sizeId">Boy id numarası</param>
        /// <returns></returns>
        [HttpGet("getprice")]
        public IActionResult GetPrice(int beverageId, int sizeId)
        {
            if (beverageId < 0 || sizeId < 0)
            {
                return BadRequest("İçecek id veya boy id 0'dan küçük olamaz!");
            }

            int beveragePrice = _beverageService.GetPrice(beverageId);
             
            if (beveragePrice == -1)
            {
                return BadRequest(String.Format("Numarası {0} olan bir içecek bulunmamaktadır!", beverageId));
            }

            int percentageOfPrice = _sizeService.GetPercentageOfPrice(sizeId);

            if (percentageOfPrice == -1)
            {
                return BadRequest(String.Format("Numarası {0} olan bir içecek boyu bulunmamaktadır!", sizeId));
            }

            int totalPrice = beveragePrice + beveragePrice * percentageOfPrice / 100;

            return Ok(totalPrice);
        }
    }
}