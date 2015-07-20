using NUnit.Framework;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
	[TestFixture]
	public class When_user_is_not_friends_with_logged_in_user : IUserSession
	{
		[Test]
		public void Returns_no_trips()
		{
			var tripService = new TripService(this);
			var user = new User.User();
			user.AddTrip(new Trip.Trip());
			user.AddTrip(new Trip.Trip());
			user.AddFriend(new User.User());
			user.AddFriend(new User.User());

			var tripsByUser = tripService.GetTripsByUser(user);

			Assert.That(tripsByUser, Is.Empty);
		}

		public User.User GetLoggedUser()
		{
			return new User.User();
		}
	}
}