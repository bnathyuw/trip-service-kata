using System.Collections.Generic;

namespace TripServiceKata.Trip
{
	public class UserTripFinder : IUserTripFinder
	{
		public List<Trip> FindTripsByUser(User.User user)
		{
			return TripDAO.FindTripsByUser(user);
		}
	}
}