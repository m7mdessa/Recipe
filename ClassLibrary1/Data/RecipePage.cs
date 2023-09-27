using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class RecipePage
{
    public decimal Id { get; set; }

    public string? Content { get; set; }

    public string? Slide1 { get; set; }

    public string? Slide2 { get; set; }

    public string? Slide3 { get; set; }

    public string? Logo { get; set; }

    public string? Title { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<RecipeContact> RecipeContacts { get; set; } = new List<RecipeContact>();
}
