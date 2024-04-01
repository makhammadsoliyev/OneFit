using OneFit.Service.DTOs.Users;


namespace OneFit.Service.Services.Users;

public interface IUserService
{
    /// <summary>
    /// Creates new user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UserViewModel> CreateAsync(UserCreateModel user);

    /// <summary>
    /// Updates existing user via id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user);

    /// <summary>
    /// Deletes existing user via id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// Gets existing user via id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Gets list of existing users
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}