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

    public class AddReplyController : IController
    {
	private const string REPLY_ERROR = "You cannot submit an empty reply!";
	private const int COMMAND_COUNT = 2;
	private const int TEXT_AREA_WIDTH = 37;
	private const int TEXT_AREA_HEIGHT = 6;
	private const int POST_MAX_LENGTH = 220;
	private static int centerTop = Position.ConsoleCenter().Top;
	private static int centerLeft = Position.ConsoleCenter().Left;
	public ReplyViewModel Reply { get; private set; }
	private TextArea TextArea { get; set; }
	private string ErrorMessage { get; set; }

	private enum Command
	{
	    Write, Post, Back
	}

	public enum AddReplyStatus
	{
	    Success, ContentError
	}

	public AddReplyController()
	{
	    ResetReply();
	}

	internal void ReplyToPost(string postTitle)
	{
	    Reply.PostTitle = postTitle;
	}

	public void ResetReply()
	{
	    ErrorMessage = String.Empty;
	    Reply = new ReplyViewModel();
	    TextArea = new TextArea(centerLeft - 18, centerTop - 6,
		TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
	}

	public IView GetView(string userName)
	{
	    Reply.Author = userName;
	    PostViewModel postViewModel = PostService.GetPostViewModel(Reply.PostTitle);
	    return new AddReplyView(postViewModel, ErrorMessage);
	}

	public void ReadContent()
	{
	    TextArea.Write();
	    Reply.Content = TextArea.Lines.ToList();
	}

	public MenuState ExecuteCommand(int index)
	{
	    switch ((Command)index)
	    {
		case Command.Write:
		    ReadContent();
		    return MenuState.AddReply;
		case Command.Post:
		    AddReplyStatus addReplyStatus = PostService.TrySaveReply(Reply);
		    switch (addReplyStatus)
		    {
			case AddReplyStatus.Success:
			    ResetReply();
			    return MenuState.ReplyAdded;
			case AddReplyStatus.ContentError:
			    ErrorMessage = REPLY_ERROR;
			    return MenuState.Error;
		    }
		    break;
		case Command.Back:
		    return MenuState.Back;
	    }
	    throw new InvalidCommandException();
	}
    }
}
