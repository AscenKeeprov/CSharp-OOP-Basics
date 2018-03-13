namespace Forum.App.Controllers
{
    using System;
    using Forum.App;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Views;

    public class SignUpController : IController, IReadUserInfoController
    {
	private const string DETAILS_ERROR = "Invalid Username or Password!";
	private const string USERNAME_TAKEN_ERROR = "Username already in use!";
	public string Username { get; private set; }
	private string Password { get; set; }
	private bool Error { get; set; }
	private string ErrorMessage { get; set; }

	private enum Command
	{
	    ReadUsername, ReadPassword, SignUp, Back
	}

	public enum SignUpStatus
	{
	    Success, DetailsError, UsernameTakenError
	}

	private void ResetSignUp()
	{
	    ErrorMessage = String.Empty;
	    Username = String.Empty;
	    Password = String.Empty;
	}

	public IView GetView(string userName)
	{
	    IView signUpView = new SignUpView(ErrorMessage);
	    if (Error)
	    {
		ResetSignUp();
		Error = false;
	    }
	    return signUpView;
	}

	public MenuState ExecuteCommand(int index)
	{
	    switch ((Command)index)
	    {
		case Command.ReadUsername:
		    ReadUsername();
		    return MenuState.Signup;
		case Command.ReadPassword:
		    ReadPassword();
		    return MenuState.Signup;
		case Command.SignUp:
		    SignUpStatus signUpStatus = UserService.TrySignUpUser(Username, Password);
		    switch (signUpStatus)
		    {
			case SignUpStatus.Success:
			    return MenuState.SignedUp;
			case SignUpStatus.DetailsError:
			    ErrorMessage = DETAILS_ERROR;
			    Error = true;
			    return MenuState.Error;
			case SignUpStatus.UsernameTakenError:
			    ErrorMessage = USERNAME_TAKEN_ERROR;
			    Error = true;
			    return MenuState.Error;
		    }
		    break;
		case Command.Back:
		    ResetSignUp();
		    return MenuState.Back;
	    }
	    throw new InvalidCommandException();
	}

	public void ReadUsername()
	{
	    Username = ForumViewEngine.ReadRow();
	    ForumViewEngine.HideCursor();
	}

	public void ReadPassword()
	{
	    Password = ForumViewEngine.ReadRow();
	    ForumViewEngine.HideCursor();
	}
    }
}
