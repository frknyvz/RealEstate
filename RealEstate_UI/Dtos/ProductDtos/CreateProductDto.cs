﻿namespace RealEstate_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public int productID { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string coverImage { get; set; }
        public string type { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string categoryid { get; set; }
        public string address { get; set; }
    }
}
