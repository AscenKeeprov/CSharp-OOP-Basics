namespace Forum.App.Controllers
{
    using System;
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.UserInterface.Views;

    public class AddPostController : IController
    {
	private const string POST_ERROR = "Invalid {0}!";
	private const int COMMAND_COUNT = 4;
	private const int TEXT_AREA_WIDTH = 37;
	private const int TEXT_AREA_HEIGHT = 18;
	private const int POST_MAX_LENGTH = 660;
	private static int centerTop = Position.ConsoleCenter().Top;
	private static int centerLeft = Position.ConsoleCenter().Left;
	public PostViewModel Post { get; private set; }
	private TextArea TextArea { get; set; }
	private string ErrorMessage { get; set; }

	private enum Command
	{
	    AddTitle, AddCategory, Write, Post
	}

	public enum AddPostStatus
	{
	    Success, TitleError, CategoryError, ContentError
	}

	public AddPostController()
	{
	    ResetPost();
	}

	public void ResetPost()
	{
	    ErrorMessage = String.Empty;
	    Post = new PostViewModel();
	    TextArea = new TextArea(centerLeft - 18, centerTop - 7,
		TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
	}

	public IView GetView(string username)
	{
	    Post.Author = username;
	    return new AddPostView(Post, TextArea, ErrorMessage);
	}

	public void ReadTitle()
	{
	    Post.Title = ForumViewEngine.ReadRow();
	    ForumViewEngine.HideCursor();
	}

	public void ReadCategory()
	{
	    Post.Category = ForumViewEngine.ReadRow();
	    ForumViewEngine.HideCursor();
	}

	public void ReadContent()
	{
	    TextArea.Write();
	    Post.Content = TextArea.Lines.ToList();
	}

	public MenuState ExecuteCommand(int index)
	{
	    switch ((Command)index)
	    {
		case Command.AddTitle:
		    ReadTitle();
		    return MenuState.AddPost;
		case Command.AddCategory:
		    ReadCategory();
		    return MenuState.AddPost;
		case Command.Write:
		    ReadContent();
		    return MenuState.AddPost;
		case Command.Post:
		    AddPostStatus addPostStatus = PostService.TrySavePost(Post);
		    switch (addPostStatus)
		    {
			case AddPostStatus.Success:
			    return MenuState.PostAdded;
			case AddPostStatus.TitleError:
			    ErrorMessage = String.Format(POST_ERROR, nameof(Post.Title).ToLower());
			    return MenuState.Error;
			case AddPostStatus.CategoryError:
			    ErrorMessage = String.Format(POST_ERROR, nameof(Post.Category).ToLower());
			    return MenuState.Error;
			case AddPostStatus.ContentError:
			    ErrorMessage = String.Format(POST_ERROR, nameof(Post.Content).ToLower());
			    return MenuState.Error;
		    }
		    break;
	    }
	    throw new InvalidCommandException();
	}
    }
}
