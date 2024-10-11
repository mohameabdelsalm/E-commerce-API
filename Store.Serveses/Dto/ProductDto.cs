﻿using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string TypeName { get; set; }
        public string BrandName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
