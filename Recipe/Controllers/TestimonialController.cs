using Recipe.Core.Data;
using Recipe.Core.Service;
using Recipe.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using Recipe.Core.DTO;

namespace Recipe.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class TestimonialController : Controller
	{
		private readonly ITestimonialService TestimonialService;
		private readonly IEmailService emailService;

		public TestimonialController(ITestimonialService TestimonialService, IEmailService emailService)
		{
			this.TestimonialService = TestimonialService;
			this.emailService = emailService;

		}

		[HttpGet]
		public List<Testimonials> GetAllTestimonials()
		{
			return TestimonialService.GetAllTestimonials();
		}

        [HttpGet]
        [Route("GetTestimonialByUserId/{userId}")]
        public List<Testimonials> GetTestimonialByUserId(int userId)
        {
            return TestimonialService.GetTestimonialByUserId(userId);
        }


        [HttpPost]
		public void CreateTestimonial(RecipeTestimonial Testimonial)
		{
			TestimonialService.CreateTestimonial(Testimonial);
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public void DeleteTestimonial(int id)
		{
			TestimonialService.DeleteTestimonial(id);
		}

		[HttpGet]
		[Route("GetTestimonialById/{id}")]
		public RecipeTestimonial GetTestimonialById(int id)
		{
			return TestimonialService.GetTestimonialById(id);
		}


		[HttpPut]
		public void UpdateTestimonial(RecipeTestimonial Testimonial)
		{
			TestimonialService.UpdateTestimonial(Testimonial);
			if (Testimonial.Status == "Accepted")

			{
				string userEmail = TestimonialService.GetUserEmail((int)Testimonial.Id);
				var emailSubject = "Testimonial Accepted";
				var emailBody = $@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
            }}
            .header {{
                font-size: 20px;
                font-weight: bold;
                color: #333;
            }}
            .details {{
                font-size: 16px;
                color: #666;
            }}
        </style>
    </head>
    <body>
        <div class='details'>
            <p>Your testimonial is accepted</p>
            <p> Details:</p>
            <ul>
                <li>Date: {DateTime.Now}</li>
            </ul>
        </div>
    </body>
    </html>";


				_ = emailService.SendEmailAsync(userEmail, emailSubject, emailBody);

			}
			else if (Testimonial.Status == "Rejected")

			{
				string userEmail = TestimonialService.GetUserEmail((int)Testimonial.Id);

				_ = emailService.SendEmailAsync(userEmail, "Testimonial Rejected", "Sorry your testimonial has been rejected");

			}
		}


	}

}
