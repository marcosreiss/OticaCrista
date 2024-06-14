﻿using SistOtica.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistOtica.Models.Sale
{
    public class PaymentModel
    {
        public int Id { get; set; }

        [ForeignKey("SaleId")]
        public int SaleId { get; set; }
        public SaleModel Sale { get; set; } = null!;

        public double Discount { get; set; }

        public PaymentMethod Method { get; set; }

        public double DownPayment { get; set; } //entrada

        public int Installments { get; set; }

        public DateOnly DueDate { get; set; }
    }
}
