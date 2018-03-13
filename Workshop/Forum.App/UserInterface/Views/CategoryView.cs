namespace Forum.App.UserInterface.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.UserInterface.Contracts;

    public class CategoryView : IView
    {
	private const int PREV_BUTTON = 1;
	private const int NEXT_BUTTON = 2;
	private const int NAME_MAX_LENGTH = 14;
	private const int WHITESPACE_COUNT = 27;
	private static int centerTop = Console.WindowHeight / 2;
	private static int centerLeft = Console.WindowWidth / 2;
	private string categoryName;
	public int CurrentPage { get; private set; }
	public int LastPage { get; private set; }

	public CategoryView(string categoryName, string[] postTitles, int currentPage, int lastPage)
	{
	    this.categoryName = categoryName;
	    PostTitles = postTitles;
	    CurrentPage = currentPage;
	    LastPage = lastPage;
	    InitializeLabels();
	}

	public ILabel[] Labels { get; private set; }

	public ILabel[] Buttons { get; private set; }

	public string[] PostTitles { get; private set; }

	private void InitializeLabels()
	{
	    Position consoleCenter = Position.ConsoleCenter();

	    InitializeStaticLabels(consoleCenter);

	    InitializeButtons(consoleCenter);
	}

	private void InitializeButtons(Position consoleCenter)
	{
	    string[] defaultButtonContent = new string[] { "Back", "Previous Page", "Next Page" };
	    Position[] defaultButtonPositions = new Position[]
	    {
		new Position(consoleCenter.Left + 15, consoleCenter.Top - 10), // Back
		new Position(consoleCenter.Left - 21, consoleCenter.Top + 12), // Previous Page
		new Position(consoleCenter.Left + 15, consoleCenter.Top + 12), // Next Page
            };

	    Position[] categoryButtonPositions = new Position[]
	    {
		new Position(consoleCenter.Left - 18, consoleCenter.Top - 8),
		new Position(consoleCenter.Left - 18, consoleCenter.Top - 6),
		new Position(consoleCenter.Left - 18, consoleCenter.Top - 4),
		new Position(consoleCenter.Left - 18, consoleCenter.Top - 2),
		new Position(consoleCenter.Left - 18, consoleCenter.Top),
		new Position(consoleCenter.Left - 18, consoleCenter.Top + 2),
		new Position(consoleCenter.Left - 18, consoleCenter.Top + 4),
		new Position(consoleCenter.Left - 18, consoleCenter.Top + 6),
		new Position(consoleCenter.Left - 18, consoleCenter.Top + 8),
		new Position(consoleCenter.Left - 18, consoleCenter.Top + 10),
	    };

	    IList<ILabel> buttons = new List<ILabel>();
	    buttons.Add(new Label(defaultButtonContent[0], defaultButtonPositions[0]));
	    for (int i = 0; i < categoryButtonPositions.Length; i++)
	    {
		string currentCategoryName = string.Empty;

		if (i < this.PostTitles.Length)
		{
		    currentCategoryName = this.PostTitles[i];
		}

		ILabel label = new Label(currentCategoryName, categoryButtonPositions[i], currentCategoryName == string.Empty);

		buttons.Add(label);
	    }
	    if (CurrentPage > 0 && LastPage > 0)
		buttons.Add(new Label(defaultButtonContent[1], defaultButtonPositions[1]));
	    else buttons.Add(new Label(defaultButtonContent[1], defaultButtonPositions[1], true));
	    if (CurrentPage < LastPage && LastPage > 0)
		buttons.Add(new Label(defaultButtonContent[2], defaultButtonPositions[2]));
	    else buttons.Add(new Label(defaultButtonContent[2], defaultButtonPositions[2], true));
	    this.Buttons = buttons.ToArray();
	}

	private void InitializeStaticLabels(Position consoleCenter)
	{
	    string[] labelContent = new string[] { String.Format("CATEGORY: {0}", this.categoryName), "Posts:", /*"Replies"*/ };
	    Position[] labelPositions = new Position[]
	    {
		new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // CategoryName
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // PostsColumn
                //new Position(consoleCenter.Left + 14, consoleCenter.Top - 10), // RepliesColumn
            };

	    IList<ILabel> labels = new List<ILabel>();

	    for (int i = 0; i < labelContent.Length; i++)
	    {
		labels.Add(new Label(labelContent[i], labelPositions[i]));
	    }

	    this.Labels = labels.ToArray();
	}
    }
}
