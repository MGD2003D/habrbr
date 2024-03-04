public interface IArticleService
{
    void AddArticle(Article article);
    Article GetArticleById(int id);
    void UpdateArticle(Article article);
    void DeleteArticle(int id);
}

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public void AddArticle(Article article)
    {
        _articleRepository.Add(article);
    }

    public Article GetArticleById(int id)
    {
        return _articleRepository.GetById(id);
    }

    public void UpdateArticle(Article article)
    {
        _articleRepository.Update(article);
    }

    public void DeleteArticle(int id)
    {
        _articleRepository.Delete(id);
    }
}