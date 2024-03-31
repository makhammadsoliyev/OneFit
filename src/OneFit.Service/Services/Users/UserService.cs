using AutoMapper;
using OneFit.DataAccess.Repositories.Users;
using OneFit.Domain.Entities;
using OneFit.Service.DTOs.Users;
using OneFit.Service.Exceptions;

namespace OneFit.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<UserViewModel> CreateAsync(UserCreateModel user)
    {
        var existUser = (await userRepository.SelectAllAsync())
            .FirstOrDefault(u => u.Phone == user.Phone);

        if (existUser is not null)
            throw new CustomException(409, "User already exists");

        var createdUser = await userRepository.InsertAsync(mapper.Map<User>(user));

        return mapper.Map<UserViewModel>(createdUser);
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user)
    {
        var existUser = await userRepository.SelectByIdASync(id)
            ?? throw new CustomException(404, "User not found");

        var mappedUser = mapper.Map(user, existUser);
        var updatedUser = await userRepository.UpdateAsync(mappedUser);

        return mapper.Map<UserViewModel>(updatedUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await userRepository.SelectByIdASync(id)
            ?? throw new CustomException(404, "User not found");

        return await userRepository.DeleteAsync(id);
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var existUser = await userRepository.SelectByIdASync(id)
                        ?? throw new CustomException(404, "User not found");

        return mapper.Map<UserViewModel>(existUser);
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var users = await userRepository.SelectAllAsync();

        return mapper.Map<IEnumerable<UserViewModel>>(users);
    }
}