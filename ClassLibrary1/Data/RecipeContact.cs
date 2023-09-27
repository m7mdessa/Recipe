using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class RecipeContact
{
    public decimal Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime? Datecreated { get; set; }

    public decimal? Pagesid { get; set; }

    public virtual RecipePage? Pages { get; set; }
}
