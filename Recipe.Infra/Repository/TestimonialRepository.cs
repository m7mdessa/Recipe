using Recipe.Core.Common;
using Recipe.Core.Data;
using Recipe.Core.Repository;
using Dapper;
using System.Data;
using Recipe.Core.DTO;

namespace Recipe.Infra.Repository
{
	public class TestimonialRepository : ITestimonialRepository
	{
		private readonly IDbContext DbContext;
		public TestimonialRepository(IDbContext dBContext)
		{
			DbContext = dBContext;
		}
		public void CreateTestimonial(RecipeTestimonial testimonial)
		{
			var p = new DynamicParameters();
			p.Add("u_testimonial", testimonial.Testimonial, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("t_user_id", testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("recipe_Testimonial_PACKAGE.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
		}

		public void DeleteTestimonial(int id)
		{
			var p = new DynamicParameters();
			p.Add("t_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("recipe_Testimonial_PACKAGE.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
		}

		public List<Testimonials> GetAllTestimonials()
		{
			IEnumerable<Testimonials> result = DbContext.Connection.Query<Testimonials>("recipe_Testimonial_PACKAGE.GetAllTestimonials", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}
        public List<Testimonials> GetTestimonialByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("t_user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Testimonials> result = DbContext.Connection.Query<Testimonials>("recipe_Testimonial_PACKAGE.GetTestimonialByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public RecipeTestimonial GetTestimonialById(int id)
		{
			var p = new DynamicParameters();
			p.Add("t_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			IEnumerable<RecipeTestimonial> result = DbContext.Connection.Query<RecipeTestimonial>("recipe_Testimonial_PACKAGE.GetTestimonialById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public void UpdateTestimonial(RecipeTestimonial testimonial)
		{
			var p = new DynamicParameters();
			p.Add("t_id", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("t_status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("recipe_Testimonial_PACKAGE.UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
		}
		public string GetUserEmail(int id)
		{
			var p = new DynamicParameters();
			p.Add("t_id", id, DbType.Int32, ParameterDirection.Input);

			var result = DbContext.Connection.Query<string>("recipe_Testimonial_PACKAGE.GetUserEmail", p, commandType: CommandType.StoredProcedure).SingleOrDefault();

			return !string.IsNullOrEmpty(result) ? result : "Email not found";
		}
	}
}
