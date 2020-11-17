using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatunashviliAPI.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public WineType WineType { get; set; }
        public int WineTypeId { get; set; }
        public WineYear WineYear { get; set; }
        public int WineYearId { get; set; }


    }
}
