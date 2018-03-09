using System;
using System.Linq;
using Forum.App.Controllers.Contracts;
using Forum.App.Services;
using Forum.App.UserInterface;
using Forum.App.UserInterface.Contracts;
using Forum.App.UserInterface.Input;
using Forum.App.UserInterface.ViewModels;
using Forum.App.UserInterface.Views;

namespace Forum.App.Controllers
{
    public class AddReplyController : IController
    {
	private const int COMMAND_COUNT = 2;
	private const int TEXT_AREA_WIDTH = 37;
	private const int TEXT_AREA_HEIGHT = 18;
	private const int POST_MAX_LENGTH = 220;
	private static int centerTop = Position.ConsoleCenter().Top;
	private static int centerLeft = Position.ConsoleCenter().Left;
	public ReplyViewModel Reply { get; private set; }
	private TextArea TextArea { get; set; }
	public bool Error { get; private set; }

	private enum Command
	{
	    Write, Post
	}

	public AddReplyController()
	{
	    ResetReply();
	}

	public void ResetReply()
	{
	    Error = false;
	    Reply = new ReplyViewModel();
	    TextArea = new TextArea(centerLeft - 18, centerTop - 7,
		TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
	}

	public IView GetView(string userName)
	{
	    Reply.Author = userName;
	    PostViewModel postViewModel = PostService.GetPostViewModel(Reply.PostId);
	    return new AddReplyView(postViewModel, Reply, TextArea, Error);
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
		    bool validReply = PostService.TrySaveReply(Reply);
		    if (!validReply)
		    {
			Error = true;
			return MenuState.Rerender;
		    }
		    return MenuState.ReplyAdded;
	    }
	    throw new InvalidOperationException();
	}
    }
}
