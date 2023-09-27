using Recipe.Core.Data;
using Recipe.Core.Repository;
using Recipe.Core.Service;


namespace Recipe.Infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void CreateCategory(RecipeCategory category)
        {
            categoryRepository.CreateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
        }

        public List<RecipeCategory> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public RecipeCategory GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public void UpdateCategory(RecipeCategory category)
        {
            categoryRepository.UpdateCategory(category);
        }
    }
}
