﻿namespace Forum.App.Controllers
{
    using System;
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Views;

    public class CategoriesController : IController, IPaginationController
    {
	public const int PAGE_OFFSET = 10;
	private const int COMMAND_COUNT = PAGE_OFFSET + 3;
	public int CurrentPage { get; set; }
	private string[] AllCategoryNames { get; set; }
	public string[] CurrentPageCategories { get; set; }
	private int LastPage => AllCategoryNames.Length / (PAGE_OFFSET + 1);
	private bool IsFirstPage => CurrentPage == 0;
	private bool IsLastPage => CurrentPage == LastPage;

	private enum Command
	{
	    Back = 0,
	    ViewCategory = 1,
	    PreviousPage = 11,
	    NextPage = 12
	}

	public CategoriesController()
	{
	    CurrentPage = 0;
	    LoadCategories();
	}

	public IView GetView(string userName)
	{
	    LoadCategories();
	    return new CategoriesView(CurrentPageCategories, IsFirstPage, IsLastPage);
	}

	private void LoadCategories()
	{
	    AllCategoryNames = PostService.GetAllCategoryNames();
	    CurrentPageCategories = AllCategoryNames
		.Skip(CurrentPage * PAGE_OFFSET)
		.Take(PAGE_OFFSET).ToArray();
	}

	public MenuState ExecuteCommand(int index)
	{
	    if (index > 1 && index < 11) index = 1;
	    switch ((Command)index)
	    {
		case Command.Back:
		    return MenuState.Back;
		case Command.ViewCategory:
		    return MenuState.OpenCategory;
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
	}
    }
}
