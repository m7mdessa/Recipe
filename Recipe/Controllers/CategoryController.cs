using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Core.Data;
using Recipe.Core.Service;

namespace Recipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public List<RecipeCategory> GetAllCategories()
        {
            return categoryService.GetAllCategories();
        }

        [HttpPost]
        public void CreateCategory(RecipeCategory category)
        {
            categoryService.CreateCategory(category);
        }

        [HttpPut]
        public void UpdateCategory(RecipeCategory category)
        {
            categoryService.UpdateCategory(category);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteCategory(int id)
        {
            categoryService.DeleteCategory(id);
        }

        [HttpGet]
        [Route("getCategoryById/{id}")]
        public RecipeCategory GetCategoryById(int id)
        {
            return categoryService.GetCategoryById(id);
        }


        [Route("uploadImage")]
        [HttpPost]
        public RecipeCategory UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            RecipeCategory item = new RecipeCategory();
            item.Image = fileName;
            return item;
        }

    }
}
