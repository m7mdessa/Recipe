using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Core.Data;
using Recipe.Core.Service;

namespace Recipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {

        private readonly IPagesService pageService;
        public PagesController(IPagesService pageService)
        {
            this.pageService = pageService;
        
        }


        [HttpPost]
        public void CreatePage(RecipePage Page)
        {
            pageService.CreatePage(Page);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeletePage(int id)
        {
            pageService.DeletePage(id);
        }

        [HttpGet]
        public List<RecipePage> GetAllPages()
        {
            return pageService.GetAllPages();
        }


        [HttpGet]
        [Route("GetPageByTitle/{title}")]

        public RecipePage GetPageByTitle(string title)
        {
            return pageService.GetPageByTitle(title);
        }


        [HttpPut]
        public void UpdatePage(RecipePage Page)
        {
            pageService.UpdatePage(Page);
        }

        [HttpPost]
        [Route("Slide1")]
        public RecipePage Slide1()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            RecipePage item = new RecipePage();
            item.Slide1 = fileName;
            return item;
        }

        [HttpPost]
        [Route("Slide2")]
        public RecipePage Slide2()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            RecipePage item = new RecipePage();
            item.Slide2 = fileName;
            return item;
        }

        [HttpPost]
        [Route("Slide3")]
        public RecipePage Slide3()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            RecipePage item = new RecipePage();
            item.Slide3 = fileName;
            return item;
        }

        [HttpPost]
        [Route("Logo")]
        public RecipePage Logo()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            RecipePage item = new RecipePage();
            item.Logo = fileName;
            return item;
        }
    }
}
