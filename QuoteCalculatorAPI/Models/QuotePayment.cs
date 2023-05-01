namespace QuoteCalculatorAPI.Models
{
    public class QuotePayment
    {
        public QuoteInformation? QuoteInformation { get; set; } 
        public int QuoteInformationId { get; set; }
        public int Id { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public decimal MonthlyPayments { get; set; }
        public decimal TotalRepayments { get; set; }
        public decimal EstablishmentFee { get; set; }
        public decimal InterestFee { get; set; }
     
    }
}
