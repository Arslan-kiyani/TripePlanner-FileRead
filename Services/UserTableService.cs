using TripPlanner.Interface;
using TripPlanner.Models;
using TripPlanner.Repository;
using TripPlanner.Requestes;
using TripPlanner.Response;

namespace TripPlanner.Services
{
    public class UserTableService : IUserTableService
    {

        private readonly IUserTableRepository _userTableRepository;
        private readonly ITripRepository _tripRepository;

        public UserTableService(IUserTableRepository userTableRepository,ITripRepository tripRepository)
        {
            _userTableRepository = userTableRepository;
            _tripRepository = tripRepository;
        }
        public async Task AddUserAsync(UserTableRequest userTableRequest)
        {
            // Map the request to UserTable model
            var userTable = new UserTable
            {
                Name = userTableRequest.Name,
                Email = userTableRequest.Email,
                Address = userTableRequest.Address,
                PhoneNumber = userTableRequest.PhoneNumber,
                TripId = userTableRequest.TripId
            };

            await _userTableRepository.AddUserAsync(userTable);
        }

        public async Task DeleteUserAsync(int userId)
        {
            // Check if the user exists
            var user = await _userTableRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            await _userTableRepository.DeleteUserAsync(userId);
        }


        public async Task<List<TripDetails>> GetAllUsersAsync()
        {
            return await _userTableRepository.GetAllUsersAsync();
        }

        public async Task<UserTable> GetUserByIdAsync(int userId)
        {
            return await _userTableRepository.GetUserByIdAsync(userId);
        }

        public async Task<int> UpdateUserAsync(int id, UserTableRequest userTableRequest)
        {
           return await _userTableRepository.UpdateUserAsync(id, userTableRequest);
        }
    }
}
