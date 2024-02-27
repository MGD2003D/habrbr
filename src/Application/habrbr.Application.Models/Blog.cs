namespace Models;

using System;
using System.Collections.Generic;

public class Blog
{
    public Guid ID { get; set; }
    public string BlogName { get; set; }
    public string Description { get; set; }
    public virtual User Creator { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}