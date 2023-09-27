using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class RecipeCategory
{
    public decimal Id { get; set; }

    public string? Categoryname { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
