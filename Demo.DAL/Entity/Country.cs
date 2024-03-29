﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    [Table ("Country")]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> City { get; set; }
    }
}
