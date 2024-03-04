namespace Models;

using System;
using System.Collections.Generic;

public class User
{
    public Guid ID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } // Предполагается, что пароль захеширован
    public DateTime RegistrationDate { get; set; }
    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}