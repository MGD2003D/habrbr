namespace habrbr.Infrastructure.Persistence.Repositories;

using Models;

public interface IArticleRepository
{
    void Add(Article article);
    Article? GetById(int id);
    void Update(Article article);
    void Delete(int id);
}

public class ArticleRepository : IArticleRepository
{
    public void Add(Article article)
    {
        // Пустышка
    }

    public Article? GetById(int id)
    {
        // Пустышка
        return null;
    }

    public void Update(Article article)
    {
        // Пустышка
    }

    public void Delete(int id)
    {
        // Пустышка
    }
}
