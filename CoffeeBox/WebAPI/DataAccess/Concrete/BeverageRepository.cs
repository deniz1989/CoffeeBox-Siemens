﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess.Abstract;
using WebAPI.Models;

namespace WebAPI.DataAccess.Concrete
{
    public class BeverageRepository : IBeverageRepository
    {
        public List<Beverage> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
