﻿namespace HouseforRentProject.Models.Entity
{
    public class Villa
    {
        public int VillaID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
        public int Room { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
    }
}
