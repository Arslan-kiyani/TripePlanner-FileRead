using TripPlanner.Models;
using TripPlanner.Requestes;
using TripPlanner.Response;

namespace TripPlanner.Interface
{
    public interface IUserTripRepository
    {
        Task AddUserTripAsync(UserTripRequest userTripRequest);
        Task DeleteUserTripAsync(int userTripId);
        Task<IEnumerable<UserTripResponse>> GetAllUserTripsAsync();
        Task<UserTripResponse> GetUserTripByIdAsync(int userTripId);
        Task<int> UpdateUserTripAsync(int id, UserTripRequest userTripRequest);
    }
}
