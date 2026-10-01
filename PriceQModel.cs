using System.ComponentModel.DataAnnotations;

namespace PriceQModel.Models
{
    public class PriceQModel
    {
        [Required(ErrorMessage = "Please enter a Subtotal Amount is required.")]
        [Range(1, 1000, ErrorMessage = "Subtotal Amount must be between 1 and 1000.")]
        public decimal? Subtotal { get; set; }
        [Required(ErrorMessage = "Please enter a Discount Percentage is required.")]
        [Range(typeof(decimal), "0.1", "100.0", ErrorMessage = "Discount Percentage must be between 0.1 and 100.0.")]
        public decimal? Discount_Amount { get; set; }
        public decimal? DiscountAmount { get; private set; }

        public decimal PercentageAmount()
        {
            return (Subtotal ?? 0) * (Discount_Amount ?? 0) / 100;
        }
        public decimal? CalculationPriceQ { get; private set; }

        public decimal CalculatePriceQ()
        {
            DiscountAmount = PercentageAmount();
            CalculationPriceQ = (Subtotal ?? 0) - DiscountAmount;
            return CalculationPriceQ ?? 0;
        }
    }
}