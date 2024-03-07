namespace Models;

using System;
using System.Collections.Generic;

public class Comment
{
    public int ID { get; set; }
    public string Text { get; set; }
    public virtual User Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Rating { get; set; }
    public virtual Article ParentArticle { get; set; }
}