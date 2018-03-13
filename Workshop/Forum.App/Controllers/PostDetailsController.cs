namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.UserInterface.Views;

    public class PostDetailsController : IController, IUserRestrictedController
    {
	public bool LoggedInUser { get; set; }
	public string PostTitle { get; private set; }

	public enum Command
	{
	    Back, AddReply
	}

	public IView GetView(string userName)
	{
	    PostViewModel postViewModel = PostService.GetPostViewModel(PostTitle);
	    return new PostDetailsView(postViewModel, LoggedInUser);
	}

	public void UserLogIn()
	{
	    LoggedInUser = true;
	}

	public void UserLogOut()
	{
	    LoggedInUser = false;
	}

	public void ReadPost(string postTitle)
	{
	    PostTitle = postTitle;
	}

	public MenuState ExecuteCommand(int index)
	{
	    switch ((Command)index)
	    {
		case Command.Back:
		    ForumViewEngine.ResetBuffer();
		    return MenuState.Back;
		case Command.AddReply:
		    return MenuState.AddReplyToPost;
	    }
	    throw new InvalidCommandException();
	}
    }
}
