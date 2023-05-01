namespace QuoteCalculatorAPI.Models.DTO
{
    public abstract class BaseQuoteInformationDTO
    {
        public decimal AmountRequired { get; set; }
        public int Term { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }

    public class QuoteInformationDTO : BaseQuoteInformationDTO
    {
        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }
    }
    public class QuoteInformationCreateDTO : BaseQuoteInformationDTO
    {
        public string DateOfBirth { get; set; } = string.Empty;
    }

    public class SavedQuotePaymentAndInformationDTO
    {
        public QuoteInformationDTO? QuoteInformation { get; set; }
        public QuotePaymentDTO? QuotePayment { get; set; }
    }

}
