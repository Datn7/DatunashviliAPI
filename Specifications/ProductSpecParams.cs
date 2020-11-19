using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatunashviliAPI.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        private int pageSize = 6;

        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? WineTypeId { get; set; }
        public int? WineYearId { get; set; }
        public string Sort { get; set; }

        private string search;
        public string Search
        {
            get => search;
            set => search = value.ToLower();
        }

    }
}
