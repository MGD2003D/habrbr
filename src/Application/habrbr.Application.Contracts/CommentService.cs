public interface ICommentService
{
    void AddComment(Comment comment);
    Comment GetCommentById(int id);
    void UpdateComment(Comment comment);
    void DeleteComment(int id);
}

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public void AddComment(Comment comment)
    {
        _commentRepository.Add(comment);
    }

    public Comment GetCommentById(int id)
    {
        return _commentRepository.GetById(id);
    }

    public void UpdateComment(Comment comment)
    {
        _commentRepository.Update(comment);
    }

    public void DeleteComment(int id)
    {
        _commentRepository.Delete(id);
    }
}