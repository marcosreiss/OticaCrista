﻿using SistOtica.Models.Sale;

namespace SistOtica.Models.Service
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }

    }
}
