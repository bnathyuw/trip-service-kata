using System.Collections.Generic;
using NUnit.Framework;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
	[TestFixture]
	public class When_user_is_friends_with_logged_in_user : IUserSession, IUserTripFinder
	{
		private readonly User.User _loggedInUser = new User.User();
		private readonly List<Trip.Trip> _expectedTrips = new List<Trip.Trip> {new Trip.Trip(), new Trip.Trip()};

		[Test]
		public void Returns_no_trips()
		{
			var tripService = new TripService(this, this);
			var user = new User.User();
			user.AddFriend(new User.User());
			user.AddFriend(_loggedInUser);

			var tripsByUser = tripService.GetTripsByUser(user);

			Assert.That(tripsByUser, Is.EqualTo(_expectedTrips));
		}

		public User.User GetLoggedUser()
		{
			return _loggedInUser;
		}

		public List<Trip.Trip> FindTripsByUser(User.User user)
		{
			return _expectedTrips;
		}
	}
}