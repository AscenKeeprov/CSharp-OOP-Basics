namespace Forum.App
{
    using System;
    using System.Collections.Generic;
    using Forum.App.Controllers;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;

    public class Engine
    {
	private ForumViewEngine forumViewer;
	private MenuController menuController;
	private IEnumerable<IController> controllers;

	public Engine()
	{
	    forumViewer = new ForumViewEngine();
	    controllers = InitializeControllers();
	    menuController = new MenuController(controllers, forumViewer);
	}

	internal void Run()
	{
	    while (true)
	    {
		forumViewer.Mark(menuController.CurrentLabel);

		var keyInfo = Console.ReadKey(true);
		var key = keyInfo.Key;

		forumViewer.Mark(menuController.CurrentLabel, false);

		switch (key)
		{
		    case ConsoleKey.LeftArrow:
		    case ConsoleKey.UpArrow:
			menuController.PreviousOption();
			break;
		    case ConsoleKey.Tab:
		    case ConsoleKey.RightArrow:
		    case ConsoleKey.DownArrow:
			menuController.NextOption();
			break;
		    case ConsoleKey.Enter:
			menuController.SelectOption();
			break;
		}
	    }
	}

	private IEnumerable<IController> InitializeControllers()
	{
	    var controllers = new List<IController>
	    {
				new MainController(),
				new SignUpController(),
				new LogInController(),
				new CategoriesController(),
				new CategoryController(),
				new AddPostController(),
				new PostDetailsController(),
				new AddReplyController()
	    };
	    return controllers;
	}
    }
}
