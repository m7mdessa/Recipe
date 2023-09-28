using Recipe.Core.Data;
using Recipe.Core.Repository;
using Recipe.Core.Service;
using Recipe.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infra.Service
{
    public class PagesService : IPagesService
    {
        private readonly IPagesRepository pageRepository;
        public PagesService(IPagesRepository pageRepository)
        {
            this.pageRepository = pageRepository;
        }
        public void CreatePage(RecipePage Page)
        {
            pageRepository.CreatePage(Page);
        }

        public void DeletePage(int id)
        {
            pageRepository.DeletePage(id);
        }

        public List<RecipePage> GetAllPages()
        {
           return pageRepository.GetAllPages();
        }

        public RecipePage GetPageByTitle(string title)
        {
           return pageRepository.GetPageByTitle(title);
        }

        public void UpdatePage(RecipePage Page)
        {
            pageRepository.UpdatePage(Page);
        }
    }
}
