﻿using Recipe.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Core.Repository
{
    public interface ICategoryRepository
    {
        List<RecipeCategory> GetAllCategories();
        void CreateCategory(RecipeCategory category);
        void DeleteCategory(int id);
        RecipeCategory GetCategoryById(int id);
        public void UpdateCategory(RecipeCategory category);
    }
}
