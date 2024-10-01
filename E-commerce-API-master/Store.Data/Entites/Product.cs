using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entites
{
    public class Product : BaseEntity<int>
    {

        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public ProductType Type { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand Brand { get; set; }
        public int ProductBrandId { get; set; }




    }
}
