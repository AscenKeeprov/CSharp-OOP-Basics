namespace Forum.App.Controllers
{
    using System;
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Views;

    public class CategoryController : IController, IPaginationController
    {
	public const int PAGE_OFFSET = 10;
	private const int COMMAND_COUNT = PAGE_OFFSET + 3;
	public int CurrentPage { get; set; }
	private string[] PostTitles { get; set; }
	private int PostsCount;
	private int LastPage => PostsCount / PAGE_OFFSET;
	public string CategoryName { get; private set; }

	private enum Command
	{
	    Back = 0,
	    ViewPost = 1,
	    PreviousPage = 11,
	    NextPage = 12
	}

	public CategoryController()
	{
	    CurrentPage = 0;
	}

	public IView GetView(string userName)
	{
	    GetPosts();
	    return new CategoryView(CategoryName, PostTitles, CurrentPage, LastPage);
	}

	private void GetPosts()
	{
	    var allCategoryPosts = PostService.GetPostsByCategory(CategoryName);
	    PostsCount = allCategoryPosts.Count();
	    PostTitles = allCategoryPosts.Skip(CurrentPage * PAGE_OFFSET)
		.Take(PAGE_OFFSET).Select(p => p.Title).ToArray();
	}

	public void BrowseCategory(string categoryName)
	{
	    CategoryName = categoryName;
	}

	public MenuState ExecuteCommand(int index)
	{
	    if (index > 1 && index < 11) index = 1;
	    switch ((Command)index)
	    {
		case Command.Back:
		    CurrentPage = 0;
		    return MenuState.Back;
		case Command.ViewPost:
		    return MenuState.ViewPost;
		case Command.PreviousPage:
		    ChangePage(false);
		    return MenuState.Rerender;
		case Command.NextPage:
		    ChangePage(true);
		    return MenuState.Rerender;
	    }
	    throw new InvalidOperationException();
	}

	private void ChangePage(bool forward = true)
	{
	    CurrentPage += forward ? 1 : -1;
	    GetPosts();
	}
    }
}
