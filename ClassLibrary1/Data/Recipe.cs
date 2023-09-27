using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class Recipe
{
    public decimal Id { get; set; }

    public string? Recipename { get; set; }

    public string? Recipedescription { get; set; }

    public decimal? Sale { get; set; }

    public decimal? Price { get; set; }

    public string? Image { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public decimal? Categoryid { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Userid { get; set; }

    public virtual RecipeCategory? Category { get; set; }

    public virtual RecipeUser? User { get; set; }
}
