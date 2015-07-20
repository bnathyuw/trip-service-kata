using System.Collections.Generic;
using System.Linq;

namespace TripServiceKata.User
{
	public class User
	{
		private readonly List<User> _friends = new List<User>();

		public void AddFriend(User user)
		{
			_friends.Add(user);
		}

		public bool IsFriendsWith(User loggedUser)
		{
			return _friends.Any(friend => friend == loggedUser);
		}
	}
}