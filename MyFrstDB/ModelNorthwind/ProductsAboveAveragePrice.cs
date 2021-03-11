using System;
using System.Collections.Generic;

#nullable disable

namespace MyFrstDB.ModelNorthwind
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
