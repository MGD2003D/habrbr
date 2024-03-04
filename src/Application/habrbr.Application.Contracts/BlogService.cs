public interface IBlogService
{
    void CreateBlog(Blog blog);
    Blog GetBlogById(int id);
    void UpdateBlog(Blog blog);
    void DeleteBlog(int id);
}

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;

    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public void CreateBlog(Blog blog)
    {
        _blogRepository.Add(blog);
    }

    public Blog GetBlogById(int id)
    {
        return _blogRepository.GetById(id);
    }

    public void UpdateBlog(Blog blog)
    {
        _blogRepository.Update(blog);
    }

    public void DeleteBlog(int id)
    {
        _blogRepository.Delete(id);
    }
}