using Recipe.Core.Data;
using Recipe.Core.DTO;

namespace Recipe.Core.Repository
{
	public interface ITestimonialRepository
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
