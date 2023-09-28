using Recipe.Core.Data;
using Recipe.Core.DTO;
using Recipe.Core.Repository;
using Recipe.Core.Service;

namespace Recipe.Infra.Service
{

	public class TestimonialService : ITestimonialService
	{
		private readonly ITestimonialRepository testimonialRepository;
		public TestimonialService(ITestimonialRepository testimonialRepository)
		{
			this.testimonialRepository = testimonialRepository;
		}
		public List<Testimonials> GetAllTestimonials()
		{
			return testimonialRepository.GetAllTestimonials();
		}
        public List<Testimonials> GetTestimonialByUserId(int userId)
        {
			
            return testimonialRepository.GetTestimonialByUserId(userId);
        }
        public void CreateTestimonial(RecipeTestimonial testimonial)
		{
			testimonialRepository.CreateTestimonial(testimonial);
		}
		public void DeleteTestimonial(int id)
		{
			testimonialRepository.DeleteTestimonial(id);
		}
		public void UpdateTestimonial(RecipeTestimonial testimonial)
		{
			testimonialRepository.UpdateTestimonial(testimonial);
		}
		public RecipeTestimonial GetTestimonialById(int id)
		{
			return testimonialRepository.GetTestimonialById(id);
		}

		public string GetUserEmail(int id)
		{
			return testimonialRepository.GetUserEmail(id);
		}
	}

}
