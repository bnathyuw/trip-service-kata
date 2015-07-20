using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
	[TestFixture]
	public class When_user_is_not_logged_in : IUserSession
	{
		[Test]
		public void Throws_exception()
		{
			var tripService = new TripService(this);

			Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(new User.User()));
		}

		public User.User GetLoggedUser()
		{
			return null;
		}
	}
}
