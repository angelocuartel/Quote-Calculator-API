using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuoteCalculatorAPI.Models;
using QuoteCalculatorAPI.Models.DTO;
using QuoteCalculatorAPI.Repositories.Interfaces;
using System.Net;

namespace QuoteCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteRepository<QuoteInformation> _qouteRepo;
        private readonly IQuotePaymentRepository<QuotePayment> _quotePaymentRepo;

        private readonly string _baseEndpoint;

        public QuoteController(IQuoteRepository<QuoteInformation> qouteRepo, IQuotePaymentRepository<QuotePayment> quotePaymentRepo, IConfiguration config)
        {
            _qouteRepo = qouteRepo;
            _quotePaymentRepo = quotePaymentRepo;

            _baseEndpoint = config.GetValue<string>("quoteCalculatorBaseEndpoint");
        }
        
        [HttpPost]
        [EnableCors("All")]
        public async Task<IActionResult> CreateQuoteInformation(QuoteInformationCreateDTO dto)
        {
            try
            {
                QuoteInformation quoteInformation = new QuoteInformation
                { 
                    AmountRequired = dto.AmountRequired,
                    DateOfBirth = DateTime.Parse(dto.DateOfBirth),
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Term = dto.Term,
                    MobileNo = dto.MobileNo,
                    Title = dto.Title
                };


                string hashedId = await _qouteRepo.CreateAndGetLatestHashedIdAsync(quoteInformation);

                return Ok(new { url = $"{_baseEndpoint}Quote?hashedId={hashedId}"});
            }
            catch(Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{hashedId}")]
        public async Task<IActionResult> GetQuoteInformationById(string hashedId)
        {
            QuoteInformation quoteModel = await _qouteRepo.GetByHashedIdAsync(hashedId);

            QuoteInformationDTO response = new QuoteInformationDTO
            {
                AmountRequired = quoteModel.AmountRequired,
                DateOfBirth = quoteModel.DateOfBirth,
                Email = quoteModel.Email,
                FirstName = quoteModel.FirstName,
                LastName = quoteModel.LastName,
                MobileNo = quoteModel.MobileNo,
                Term = quoteModel.Term,
                Id = quoteModel.Id,
                Title = quoteModel.Title
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("payment")]
        public async Task<IActionResult> PostPayment([FromBody] SavedQuotePaymentAndInformationDTO dto)
        {
            try
            {
                QuoteInformation model = new QuoteInformation
                {
                    Id = dto.QuoteInformation.Id,
                    AmountRequired = dto.QuoteInformation.AmountRequired,
                    DateOfBirth = dto.QuoteInformation.DateOfBirth,
                    FirstName = dto.QuoteInformation.FirstName,
                    LastName = dto.QuoteInformation.LastName,
                    Email = dto.QuoteInformation.Email,
                    Term = dto.QuoteInformation.Term,
                    MobileNo = dto.QuoteInformation.MobileNo,
                    Title = dto.QuoteInformation.Title
                };

                await _qouteRepo.UpdateAsync(model);

                QuotePayment payment = new QuotePayment
                {
                    QuoteInformationId = dto.QuoteInformation.Id,
                    MonthlyPayments = dto.QuotePayment.MonthlyPayments,
                    EstablishmentFee = dto.QuotePayment.EstablishmentFee,
                    InterestFee = dto.QuotePayment.InterestFee,
                    TotalRepayments = dto.QuotePayment.TotalRepayments
                };

                await _quotePaymentRepo.CreateAsync(payment);

                return Ok();
            }

            catch(Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
