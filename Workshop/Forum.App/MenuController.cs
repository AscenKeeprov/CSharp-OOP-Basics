namespace Forum.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.Controllers;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Views;

    internal class MenuController : IController
    {
	private const int DEFAULT_INDEX = 0;
	private IController[] controllers;
	private List<IController> controllerHistory;
	private int currentOptionIndex;
	private ForumViewEngine forumViewer;
	public string Username { get; set; }
	private IView currentView => GetView(Username);
	private IController currentController => controllerHistory.Last();
	internal ILabel CurrentLabel => currentView.Buttons[currentOptionIndex];

	public MenuController(IEnumerable<IController> controllers, ForumViewEngine forumViewer)
	{
	    this.controllers = controllers.ToArray();
	    this.forumViewer = forumViewer;
	    InitializeControllerHistory();
	    currentOptionIndex = DEFAULT_INDEX;
	    RenderCurrentView();
	}

	private void InitializeControllerHistory()
	{
	    controllerHistory = new List<IController>();
	    controllerHistory.Add(controllers.Single(c => c is MainController));
	}

	private void RenderCurrentView()
	{
	    forumViewer.RenderView(currentView);
	    currentOptionIndex = DEFAULT_INDEX;
	}

	public IView GetView(string username)
	{
	    return currentController.GetView(username);
	}

	internal void PreviousOption()
	{
	    currentOptionIndex--;
	    int totalOptions = currentView.Buttons.Length;
	    if (currentOptionIndex < 0)
		currentOptionIndex += totalOptions;
	    if (CurrentLabel.IsHidden) PreviousOption();
	}

	internal void NextOption()
	{
	    currentOptionIndex++;
	    int totalOptions = currentView.Buttons.Length;
	    if (currentOptionIndex >= totalOptions)
		currentOptionIndex -= totalOptions;
	    if (CurrentLabel.IsHidden) NextOption();
	}

	internal void SelectOption()
	{
	    MenuState newState = ExecuteCommand(currentOptionIndex);
	    IController controller = null;
	    switch (newState)
	    {
		case MenuState.Back:
		    RedirectToMenu(MenuState.Back);
		    break;
		case MenuState.Error:
		    goto default;
		case MenuState.Signup:
		    controller = controllers.SingleOrDefault(c => c is SignUpController);
		    break;
		case MenuState.SignedUp:
		    goto case MenuState.LoggedIn;
		case MenuState.Login:
		    controller = controllers.SingleOrDefault(c => c is LogInController);
		    break;
		case MenuState.LoggedIn:
		    LogIn();
		    break;
		case MenuState.LoggedOut:
		    LogOut();
		    break;
		case MenuState.Categories:
		    controller = controllers.SingleOrDefault(c => c is CategoriesController);
		    break;
		case MenuState.AddPost:
		    controller = controllers.SingleOrDefault(c => c is AddPostController);
		    break;
		case MenuState.PostAdded:
		    controller = controllers.SingleOrDefault(c => c is CategoryController);
		    if (currentController is AddPostController addPostController)
		    {
			string categoryName = addPostController.Post.Category;
			var categoryController = (CategoryController)controller;
			categoryController.BrowseCategory(categoryName);
			addPostController.ResetPost();
		    }
		    break;
		case MenuState.OpenCategory:
		    controller = controllers.SingleOrDefault(c => c is CategoryController);
		    if (currentView is CategoriesView categoriesView)
		    {
			string categoryName = categoriesView.CategoryNames[currentOptionIndex - 1];
			var categoryController = (CategoryController)controller;
			categoryController.BrowseCategory(categoryName);
		    }
		    break;
		case MenuState.ViewPost:
		    controller = controllers.SingleOrDefault(c => c is PostDetailsController);
		    if (currentView is CategoryView categoryView)
		    {
			string postTitle = categoryView.PostTitles[currentOptionIndex - 1];
			var postInfoController = (PostDetailsController)controller;
			postInfoController.ReadPost(postTitle);
		    }
		    break;
		case MenuState.Rerender:
		    goto default;
		case MenuState.AddReplyToPost:
		    controller = controllers.SingleOrDefault(c => c is AddReplyController);
		    if (currentController is PostDetailsController postDetailsController)
		    {
			string postTitle = postDetailsController.PostTitle;
			var replyController = (AddReplyController)controller;
			replyController.ReplyToPost(postTitle);
		    }
		    break;

		case MenuState.ReplyAdded:
		    controller = controllers.SingleOrDefault(c => c is PostDetailsController);
		    break;
		default:
		    RenderCurrentView();
		    break;
	    }
	    if (controller != null && controller.GetType().Name != currentController.GetType().Name)
	    {
		controllerHistory.Add(controller);
		RenderCurrentView();
	    }
	}

	public MenuState ExecuteCommand(int index)
	{
	    return currentController.ExecuteCommand(index);
	}

	private void RedirectToMenu(MenuState newState)
	{
	    IController controller = null;
	    switch (newState)
	    {
		case MenuState.Back:
		    if (currentController is SignUpController ||
			currentController is LogInController ||
			currentController is CategoriesController)
			controller = controllerHistory.LastOrDefault(c => c is MainController);
		    else if (currentController is CategoryController)
		    {
			controller = controllerHistory.LastOrDefault(c => c is CategoriesController);
			if (controller == null)
			    controller = controllers.SingleOrDefault(c => c is CategoriesController);
		    }
		    else if (currentController is PostDetailsController)
			controller = controllerHistory.LastOrDefault(c => c is CategoryController);
		    else if (currentController is AddReplyController)
			controller = controllerHistory.LastOrDefault(c => c is PostDetailsController);
		    break;
		case MenuState.Main:
		    controller = controllerHistory.LastOrDefault(c => c is MainController);
		    break;
	    }
	    controllerHistory.Add(controller);
	    RenderCurrentView();
	}

	private void LogIn()
	{
	    var loginController = (IReadUserInfoController)currentController;
	    Username = loginController.Username;
	    foreach (IController controller in controllers)
	    {
		if (controller is IUserRestrictedController userRestrictedController)
		    userRestrictedController.UserLogIn();
	    }
	    RedirectToMenu(MenuState.Main);
	}

	private void LogOut()
	{
	    Username = String.Empty;
	    foreach (IController controller in controllers)
	    {
		if (controller is IUserRestrictedController userRestrictedController)
		    userRestrictedController.UserLogOut();
	    }
	    RedirectToMenu(MenuState.Main);
	}
    }
}
