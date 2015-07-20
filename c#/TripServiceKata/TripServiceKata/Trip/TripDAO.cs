using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
	public class TripDAO
	{
		public static List<Trip> FindTripsByUser(User.User user)
		{
			throw new DependentClassCallDuringUnitTestException(
				"TripDAO should not be invoked in a unit test.");
		}
	}
}