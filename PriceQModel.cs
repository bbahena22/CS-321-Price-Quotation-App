using System.ComponentModel.DataAnnotations;

namespace PriceQModel.Models
{
    public class PriceQModel
    {
        [Required(ErrorMessage = "Please enter a monthly investment.")]
        [Range(1, 500, ErrorMessage = "Monthly Investment must be between 1 and 500.")]
        public decimal? MonthlyInvestment { get; set; }
        [Required(ErrorMessage = "Please enter a yearly interest rate.")]
        [Range(typeof(decimal), "0.1", "10.0", ErrorMessage = "Yearly interest rate must be between 0.1 and 10.0.")]
        public decimal? YearlyInterestRate { get; set; }
        [Required(ErrorMessage = "Please enter a number of years.")]
        [Range(1, 50, ErrorMessage = "Number of years must be between 1 and 50.")]
        public int? Years { get; set; }
        public decimal? CalculationPriceQ { get; private set; }

        public decimal CalculatePriceQ()
        {
            int months = (Years ?? 0) * 12;
            decimal monthlyInterestRate = (YearlyInterestRate ?? 0) / 12 / 100;
            decimal PriceQ = 0;

            for (int i = 0; i < months; i++)
            {
                PriceQ = (PriceQ + (MonthlyInvestment ?? 0)) * (1 + monthlyInterestRate);
            }

            CalculationPriceQ = PriceQ;
            return PriceQ;
        }
    }
}