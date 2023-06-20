﻿using HouseforRentProject.Models.Entity;

namespace HouseforRentProject.Models.MVVM
{
    public class VillaUpdateViewModel : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
        public int Room { get; set; }
        public bool Status { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
    }
}
