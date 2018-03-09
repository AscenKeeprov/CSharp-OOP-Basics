using System;
using System.Collections.Generic;
using System.Linq;
using Forum.App.Controllers;
using Forum.App.Controllers.Contracts;
using Forum.App.Services;
using Forum.App.UserInterface;
using Forum.App.UserInterface.Contracts;

namespace Forum.App
{
    internal class MenuController
    {
	private const int DEFAULT_INDEX = 0;
	private IController[] controllers;
	private Stack<int> controllerHistory;
	private int currentOptionIndex;
	private ForumViewEngine forumViewer;
	private string Username { get; set; }
	private IView CurrentView { get; set; }
	private MenuState State => (MenuState)controllerHistory.Peek();
	private int CurrentControllerIndex => this.controllerHistory.Peek();
	private IController CurrentController => this.controllers[CurrentControllerIndex];
	internal ILabel CurrentLabel => CurrentView.Buttons[currentOptionIndex];

	public MenuController(IEnumerable<IController> controllers, ForumViewEngine forumViewer)
	{
	    this.controllers = controllers.ToArray();
	    this.forumViewer = forumViewer;
	    InitializeControllerHistory();
	    this.currentOptionIndex = DEFAULT_INDEX;
	}

	private void InitializeControllerHistory()
	{
	    if (controllerHistory != null)
		throw new InvalidOperationException($"{nameof(controllerHistory)} already initialized!");
	    int mainControllerIndex = 0;
	    this.controllerHistory = new Stack<int>();
	    this.controllerHistory.Push(mainControllerIndex);
	    this.RenderCurrentView();
	}

	internal void PreviousOption()
	{
	    this.currentOptionIndex--;
	    if (this.currentOptionIndex < 0)
		this.currentOptionIndex += CurrentView.Buttons.Length;
	    if (CurrentLabel.IsHidden) PreviousOption();
	}

	internal void NextOption()
	{
	    this.currentOptionIndex++;
	    int totalOptions = this.CurrentView.Buttons.Length;
	    if (this.currentOptionIndex >= totalOptions)
		this.currentOptionIndex -= totalOptions;
	    if (CurrentLabel.IsHidden) NextOption();
	}

	internal void Back()
	{
	    if (State == MenuState.Categories || State == MenuState.ViewCategory)
	    {
		IPaginationController currentController = (IPaginationController)CurrentController;
		currentController.CurrentPage = 0;
	    }
	    if (controllerHistory.Count > 1)
	    {
		controllerHistory.Pop();
		this.currentOptionIndex = DEFAULT_INDEX;
	    }
	    RenderCurrentView();
	}

	internal void ExecuteCommand()
	{
	    MenuState newState = CurrentController.ExecuteCommand(currentOptionIndex);
	    switch (newState)
	    {
		case MenuState.PostAdded:
		    AddPost();
		    break;
		case MenuState.OpenCategory:
		    OpenCategory();
		    break;
		case MenuState.ViewPost:
		    ViewPost();
		    break;
		case MenuState.SuccessfulLogIn:
		    SuccessfulLogin();
		    break;
		case MenuState.LoggedOut:
		    LogOut();
		    break;
		case MenuState.Back:
		    this.Back();
		    break;
		case MenuState.ViewCategory:
		case MenuState.Error:
		    RenderCurrentView();
		    break;
		case MenuState.AddReplyToPost:
		    RedirectToAddReply();
		    break;
		case MenuState.ReplyAdded:
		    AddReply();
		    break;
		default:
		    RedirectToMenu(newState);
		    break;
	    }
	}

	private void LogOut()
	{
	    Username = String.Empty;
	    LogOutUser();
	    RenderCurrentView();
	}

	private void SuccessfulLogin()
	{
	    var loginController = (IReadUserInfoController)CurrentController;
	    Username = loginController.Username;
	    LogInUser();
	    RedirectToMenu(MenuState.Main);
	}

	private void ViewPost()
	{
	    var categoryController = (CategoryController)CurrentController;
	    int categoryId = categoryController.CategoryId;
	    var posts = PostService.GetPostsByCategory(categoryId).ToArray();
	    int postIndex = categoryController.CurrentPage * CategoriesController.PAGE_OFFSET + currentOptionIndex;
	    int postId = posts[postIndex - 1].Id;
	    var postController = (PostDetailsController)controllers[(int)MenuState.ViewPost];
	    postController.SetPostId(postId);
	    RedirectToMenu(MenuState.ViewPost);
	}

	private void OpenCategory()
	{
	    var categoriesController = (CategoriesController)CurrentController;
	    int categoryIndex = categoriesController.CurrentPage * CategoriesController.PAGE_OFFSET + currentOptionIndex;
	    var categoryController = (CategoryController)controllers[(int)MenuState.OpenCategory];
	    categoryController.SetCategory(categoryIndex);
	    RedirectToMenu(MenuState.OpenCategory);
	}

	private void AddPost()
	{
	    var addPostController = (AddPostController)CurrentController;
	    int postId = addPostController.Post.PostId;
	    var postViewer = (PostDetailsController)controllers[(int)MenuState.ViewPost];
	    postViewer.SetPostId(postId);
	    addPostController.ResetPost();
	    this.controllerHistory.Pop();
	    RedirectToMenu(MenuState.ViewPost);
	}

	private void AddReply()
	{
	    Back();
	}

	private void RedirectToAddReply()
	{
	    var postDetailsController = (PostDetailsController)CurrentController;
	    var addReplyController = (AddReplyController)controllers[(int)MenuState.AddReply];
	    addReplyController.Reply.PostId = postDetailsController.PostId;
	    RedirectToMenu(MenuState.AddReplyToPost);
	}

	private void RenderCurrentView()
	{
	    CurrentView = CurrentController.GetView(Username);
	    this.currentOptionIndex = DEFAULT_INDEX;
	    this.forumViewer.RenderView(CurrentView);
	}

	private bool RedirectToMenu(MenuState newState)
	{
	    if (State != newState)
	    {
		controllerHistory.Push((int)newState);
		RenderCurrentView();
		return true;
	    }
	    return false;
	}

	private void LogInUser()
	{
	    foreach (IController controller in controllers)
	    {
		if (controller is IUserRestrictedController userRestrictedController)
		    userRestrictedController.UserLogIn();
	    }
	}

	private void LogOutUser()
	{
	    foreach (IController controller in controllers)
	    {
		if (controller is IUserRestrictedController userRestrictedController)
		    userRestrictedController.UserLogOut();
	    }
	}
    }
}
