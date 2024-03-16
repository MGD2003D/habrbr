using Models;
using habrbr.Infrastructure.Persistence.Repositories;

namespace habrbr.Application.Contracts;

public interface IUserRightsInBlogService
{
    void AssignRights(UserRightsInBlog userRightsInBlog);
    UserRightsInBlog? GetRightsById(int id);
    void UpdateRights(UserRightsInBlog userRightsInBlog);
    void RevokeRights(int id);
}

public class UserRightsInBlogService : IUserRightsInBlogService
{
    private readonly IUserRightsInBlogRepository _userRightsInBlogRepository;

    public UserRightsInBlogService(IUserRightsInBlogRepository userRightsInBlogRepository)
    {
        _userRightsInBlogRepository = userRightsInBlogRepository;
    }

    public void AssignRights(UserRightsInBlog userRightsInBlog)
    {
        _userRightsInBlogRepository.Add(userRightsInBlog);
    }

    public UserRightsInBlog? GetRightsById(int id)
    {
        return _userRightsInBlogRepository.GetById(id);
    }

    public void UpdateRights(UserRightsInBlog userRightsInBlog)
    {
        _userRightsInBlogRepository.Update(userRightsInBlog);
    }

    public void RevokeRights(int id)
    {
        _userRightsInBlogRepository.Delete(id);
    }
}