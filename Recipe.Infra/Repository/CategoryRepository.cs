using Dapper;
using Recipe.Core.Common;
using Recipe.Core.Data;
using Recipe.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext DbContext;
        public CategoryRepository(IDbContext dBContext)
        {
            DbContext = dBContext;
        }

        public void CreateCategory(RecipeCategory category)
        {
            var p = new DynamicParameters();
            p.Add("c_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("c_image", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            DbContext.Connection.Execute("recipe_Category_PACKAGE.CreateCategory", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("c_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            DbContext.Connection.Execute("recipe_Category_PACKAGE.DeleteCategory", p, commandType: CommandType.StoredProcedure);
        }

        public List<RecipeCategory> GetAllCategories()
        {
            IEnumerable<RecipeCategory> result = DbContext.Connection.Query<RecipeCategory>("recipe_Category_PACKAGE.GetAllCategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public RecipeCategory GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("c_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<RecipeCategory> result = DbContext.Connection.Query<RecipeCategory>("recipe_Category_PACKAGE.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateCategory(RecipeCategory category)
        {
            var p = new DynamicParameters();
            p.Add("c_id", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("c_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("c_image", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            DbContext.Connection.Execute("recipe_Category_PACKAGE.UpdateCategory", p, commandType: CommandType.StoredProcedure);
        }
    }
}
