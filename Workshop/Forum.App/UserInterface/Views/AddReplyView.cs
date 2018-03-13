namespace Forum.App.UserInterface.Views
{
    using System.Collections.Generic;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.ViewModels;

    public class AddReplyView : IView
    {
	private const int AUTHOR_OFFSET = 8;
	private const int LEFT_OFFSET = 18;
	private const int TOP_OFFSET = 7;

	public AddReplyView(PostViewModel postViewModel, string errorMessage = null)
	{
	    Post = postViewModel;
	    SetBuffer();
	    if (errorMessage != null) ErrorMessage = errorMessage;
	    InitalizeLabels();
	}

	private string ErrorMessage { get; set; } = "";

	public ILabel[] Labels { get; private set; }

	public ILabel[] Buttons { get; private set; }

	private PostViewModel Post { get; }

	private void SetBuffer()
	{
	    int totalLines = 25 + this.Post.Content.Count;

	    if (totalLines > 30)
	    {
		ForumViewEngine.SetBufferHeight(totalLines);
	    }
	}

	private void InitalizeLabels()
	{
	    Position consoleCenter = Position.ConsoleCenter();

	    Position errorPosition =
		new Position(consoleCenter.Left - 18, consoleCenter.Top - 12);
	    Position titlePosition =
		new Position(consoleCenter.Left - this.Post.Title.Length / 2, consoleCenter.Top - 10);
	    Position authorPosition =
		new Position(consoleCenter.Left - this.Post.Author.Length, consoleCenter.Top - 9);

	    var labels = new List<ILabel>()
	    {
		new Label(ErrorMessage, errorPosition),
		new Label(Post.Title, titlePosition),
		new Label($"Author: {Post.Author}", authorPosition),
	    };

	    int leftPosition = consoleCenter.Left - LEFT_OFFSET;

	    int lineCount = this.Post.Content.Count;

	    // Add post contents
	    for (int i = 0; i < lineCount; i++)
	    {
		Position position = new Position(leftPosition, consoleCenter.Top - (TOP_OFFSET - i));
		ILabel label = new Label(this.Post.Content[i], position);
		labels.Add(label);
	    }

	    int currentRow = consoleCenter.Top - (TOP_OFFSET - lineCount) + 1;

	    InitializeButtons(leftPosition, currentRow);

	    this.Labels = labels.ToArray();
	}

	private void InitializeButtons(int left, int top)
	{
	    this.Buttons = new ILabel[3];

	    this.Buttons[0] = new Label("Write", new Position(left + 28, top - 1));
	    this.Buttons[1] = new Label("Submit", new Position(left + 28, top + 12));
	    this.Buttons[2] = new Label("Back", new Position(left + 28, top + 13));
	}
    }
}
