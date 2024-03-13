namespace habrbr.Infrastructure.Persistence.Repositories;

using Models;
public interface IBlogRepository
{
    void Add(Blog blog);
    Blog? GetById(int id);
    void Update(Blog blog);
    void Delete(int id);
}

public class BlogRepository : IBlogRepository
{
    public void Add(Blog blog)
    {
        // Пустышка
    }

    public Blog? GetById(int id)
    {
        // Пустышка
        return null;
    }

    public void Update(Blog blog)
    {
        // Пустышка
    }

    public void Delete(int id)
    {
        // Пустышка
    }
}
