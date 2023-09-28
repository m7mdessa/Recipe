using Recipe.Core.Data;
using Recipe.Core.DTO;

namespace Recipe.Core.Service
{
	public interface ITestimonialService
	{
		List<Testimonials> GetAllTestimonials();
        public List<Testimonials> GetTestimonialByUserId(int userid);

        void CreateTestimonial(RecipeTestimonial testimonial);
		void DeleteTestimonial(int id);
		public void UpdateTestimonial(RecipeTestimonial testimonial);
        RecipeTestimonial GetTestimonialById(int id);
		public string GetUserEmail(int id);

	}
}
