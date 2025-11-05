using UserManagement.Api.DTOs;

namespace UserManagement.Api.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponse>> GetUsersAsync(CancellationToken cancellationToken = default);
    Task<UserResponse?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
    Task<UserResponse?> UpdateUserAsync(Guid id, UpdateUserRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
}
