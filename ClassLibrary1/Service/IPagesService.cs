﻿using Recipe.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Core.Service
{
    public interface IPagesService
    {
        List<RecipePage> GetAllPages();
        void CreatePage(RecipePage Page);
        void DeletePage(int id);
        RecipePage GetPageByTitle(string title);
        public void UpdatePage(RecipePage Page);
    }
}
