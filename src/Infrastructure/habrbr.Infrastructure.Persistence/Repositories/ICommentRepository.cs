namespace habrbr.Infrastructure.Persistence.Repositories;

using Models;

public interface ICommentRepository
{
    void Add(Comment comment);
    Comment? GetById(int id);
    void Update(Comment comment);
    void Delete(int id);
}

public class CommentRepository : ICommentRepository
{
    public void Add(Comment comment)
    {
        // Пустышка
    }

    public Comment? GetById(int id)
    {
        // Пустышка
        return null;
    }

    public void Update(Comment comment)
    {
        // Пустышка
    }

    public void Delete(int id)
    {
        // Пустышка
    }
}
