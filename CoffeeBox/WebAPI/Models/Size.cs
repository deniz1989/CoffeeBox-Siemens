using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// <summary>
    /// İçecek boyu sınıfı.
    /// </summary>
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// % olarak artış anlamını taşır.
        /// </summary>
        public int Price { get; set; }
    }
}
