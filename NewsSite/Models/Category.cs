using System;
using System.Collections.Generic;

namespace NewsSite.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Menu { get; set; }

    public int IsActive { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
