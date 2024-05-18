using TripPlanner.Models;
using TripPlanner.Requestes;
using TripPlanner.Response;

namespace TripPlanner.Interface
{
    public interface IUserTableService
    {
        Task AddUserAsync(UserTableRequest userTableRequest);
        Task<List<TripDetails>> GetAllUsersAsync();
        Task<UserTable> GetUserByIdAsync(int userId);
        Task<int> UpdateUserAsync(int id, UserTableRequest userTableRequest);
        Task DeleteUserAsync(int userId);
    }
}
