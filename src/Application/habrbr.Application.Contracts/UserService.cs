using Models;
using habrbr.Infrastructure.Persistence.Repositories;

namespace habrbr.Application.Contracts;


public interface IUserService
{
    void RegisterUser(User user);
    User? GetUserById(int id);
    void UpdateUser(User user);
    void DeleteUser(int id);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void RegisterUser(User user)
    {
        _userRepository.Add(user);
    }

    public User? GetUserById(int id)
    {
        return _userRepository.GetById(id);
    }

    public void UpdateUser(User user)
    {
        _userRepository.Update(user);
    }

    public void DeleteUser(int id)
    {
        _userRepository.Delete(id);
    }
}