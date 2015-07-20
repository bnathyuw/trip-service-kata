using NUnit.Framework;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
	[TestFixture]
	public class When_user_has_no_friends : IUserSession
	{
		[Test]
		public void Returns_no_trips()
		{
			var tripService = new TripService(this, null);
			var user = new User.User();

			var tripsByUser = tripService.GetTripsByUser(user);

			Assert.That(tripsByUser, Is.Empty);
		}

		public User.User GetLoggedUser()
		{
			return new User.User();
		}
	}
}