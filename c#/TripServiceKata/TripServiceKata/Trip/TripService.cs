using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
	public interface IUserSession
	{
		User.User GetLoggedUser();
	}

	public interface IUserTripFinder
	{
		List<Trip> FindTripsByUser(User.User user);
	}

	public class TripService
	{
		private readonly IUserSession _userSession;
		private readonly IUserTripFinder _userTripFinder;

		public TripService()
		{
			_userTripFinder = new UserTripFinder();
			_userSession = UserSession.GetInstance();
		}

		public TripService(IUserSession userSession, IUserTripFinder userTripFinder)
		{
			_userTripFinder = userTripFinder;
			_userSession = userSession;
		}

		public List<Trip> GetTripsByUser(User.User user)
		{
			var loggedUser = _userSession.GetLoggedUser();

			if (loggedUser == null)
				throw new UserNotLoggedInException();
			
			if (!IsFriend(user, loggedUser)) 
				return new List<Trip>();
			
			return _userTripFinder.FindTripsByUser(user);
		}

		private static bool IsFriend(User.User user, User.User loggedUser)
		{
			return user.GetFriends().Any(friend => friend == loggedUser);
		}
	}
}