using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.User
{
	public class UserSession : IUserSession
	{
		private static readonly IUserSession userSession = new UserSession();

		private UserSession()
		{
		}

		public static IUserSession GetInstance()
		{
			return userSession;
		}

		public bool IsUserLoggedIn(User user)
		{
			throw new DependentClassCallDuringUnitTestException(
				"UserSession.IsUserLoggedIn() should not be called in a unit test");
		}

		public User GetLoggedUser()
		{
			throw new DependentClassCallDuringUnitTestException(
				"UserSession.GetLoggedUser() should not be called in a unit test");
		}
	}
}