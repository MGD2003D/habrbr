namespace Models;

using System;
using System.Collections.Generic;

public class UserRightsInBlog
{
    public Guid ID { get; set; }
    public virtual User User { get; set; }
    public virtual Blog Blog { get; set; }
    public string UserRole { get; set; } // Можно использовать enum для определения ролей
    public DateTime RightsAssignmentDate { get; set; }
}