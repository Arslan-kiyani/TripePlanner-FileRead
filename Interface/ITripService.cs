using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Requestes;
using TripPlanner.Response;

namespace TripPlanner.Interface
{
    public interface ITripService
    {
        Task AddTripAsync(TripRequest tripRequest);
        Task<Trip> GetTripByIdAsync(int tripId);
        Task<IEnumerable<TripResponse>> GetAllTripsAsync();
        Task<int> UpdateTripAsync(int tripId, TripRequest tripRequest);
        Task<string> DeleteTripAsync(int tripId);
    }
}
