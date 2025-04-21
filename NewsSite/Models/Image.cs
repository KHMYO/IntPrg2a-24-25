using System;
using System.Collections.Generic;

namespace NewsSite.Models;

public partial class Image
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public string CreateDate { get; set; } = null!;
}
