namespace Models;

using System;
using System.Collections.Generic;

public class Article
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public virtual User Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public virtual ICollection<string> Tags { get; set; } = new List<string>();
    public int Rating { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}