namespace Forum.App.Services
{
    using System;
    using System.Linq;
    using Forum.Data;
    using Forum.Models;
    using static Forum.App.Controllers.SignUpController;

    public static class UserService
    {
	public static bool TryLogInUser(string username, string password)
	{
	    if (String.IsNullOrWhiteSpace(username)
		|| String.IsNullOrWhiteSpace(password)) return false;
	    ForumData forumData = new ForumData();
	    bool userExists = forumData.Users
		.Any(u => u.Username == username && u.Password == password);
	    return userExists;
	}

	public static SignUpStatus TrySignUpUser(string username, string password)
	{
	    bool isUsernameValid = !String.IsNullOrWhiteSpace(username) && username.Length > 3;
	    bool isPasswordValid = !String.IsNullOrWhiteSpace(password) && password.Length > 3;
	    if (!isUsernameValid || !isPasswordValid) return SignUpStatus.DetailsError;
	    ForumData forumData = new ForumData();
	    bool userExists = forumData.Users.Any(u => u.Username == username);
	    if (!userExists)
	    {
		int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
		User user = new User(userId, username, password);
		forumData.Users.Add(user);
		forumData.SaveChanges();
		return SignUpStatus.Success;
	    }
	    else return SignUpStatus.UsernameTakenError;
	}

	public static User GetUser(int userId)
	{
	    ForumData forumData = new ForumData();
	    User user = forumData.Users.Find(u => u.Id == userId);
	    return user;
	}
    }
}
