namespace habrbr.Infrastructure.Persistence.Repositories;

using Models;
public interface IUserRepository
{
    void Add(User user);
    User? GetById(int id);
    void Update(User user);
    void Delete(int id);
}

public class UserRepository : IUserRepository
{
    public void Add(User user)
    {
        // Пустышка
    }

    public User? GetById(int id)
    {
        // Пустышка
        return null;
    }

    public void Update(User user)
    {
        // Пустышка
    }

    public void Delete(int id)
    {
        // Пустышка
    }
}
