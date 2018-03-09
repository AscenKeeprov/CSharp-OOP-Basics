using System;
using Forum.App.Controllers.Contracts;
using Forum.App.UserInterface.Contracts;
using Forum.App.UserInterface.Views;

namespace Forum.App.Controllers
{
    public class MainController : IController, IUserRestrictedController
    {
	private const int COMMAND_COUNT = 3;
	public bool LoggedInUser { get; private set; }

	private enum UserCommand
	{
	    Categories, AddPost, LogOut
	}

	private enum GuestCommand
	{
	    Categories, Login, SignUp
	}

	public MainController()
	{
	    LoggedInUser = false;
	}

	public IView GetView(string userName)
	{
	    return new MainView(userName);
	}

	public MenuState ExecuteCommand(int index)
	{
	    if (LoggedInUser)
	    {
		switch ((UserCommand)index)
		{
		    case UserCommand.Categories:
			return MenuState.Categories;
		    case UserCommand.AddPost:
			return MenuState.AddPost;
		    case UserCommand.LogOut:
			return MenuState.LoggedOut;
		}
	    }
	    else
	    {
		switch ((GuestCommand)index)
		{
		    case GuestCommand.Categories:
			return MenuState.Categories;
		    case GuestCommand.Login:
			return MenuState.Login;
		    case GuestCommand.SignUp:
			return MenuState.Signup;
		}
	    }
	    throw new InvalidOperationException();
	}

	public void UserLogIn()
	{
	    LoggedInUser = true;
	}

	public void UserLogOut()
	{
	    LoggedInUser = false;
	}
    }
}
