using System.Collections.Generic;
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

	public class UserTripFinder : IUserTripFinder
	{
		public List<Trip> FindTripsByUser(User.User user)
		{
			return TripDAO.FindTripsByUser(user);
		}
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
			List<Trip> tripList = new List<Trip>();
			User.User loggedUser = _userSession.GetLoggedUser();
			bool isFriend = false;
			if (loggedUser != null)
			{
				foreach (User.User friend in user.GetFriends())
				{
					if (friend.Equals(loggedUser))
					{
						isFriend = true;
						break;
					}
				}
				if (isFriend)
				{
					tripList = _userTripFinder.FindTripsByUser(user);
				}
				return tripList;
			}
			else
			{
				throw new UserNotLoggedInException();
			}
		}
	}
}