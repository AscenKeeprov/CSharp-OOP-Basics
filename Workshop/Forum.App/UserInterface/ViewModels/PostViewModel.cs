using System;
using System.Collections.Generic;
using System.Linq;
using Forum.App.Services;
using Forum.Models;

namespace Forum.App.UserInterface.ViewModels
{
    public class PostViewModel
    {
	private const int LINE_LENGTH = 37;
	public int PostId { get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public string Category { get; set; }
	public IList<string> Content { get; set; }
	public IList<ReplyViewModel> Replies { get; set; }

	public PostViewModel()
	{
	    Content = new List<string>();
	}

	public PostViewModel(Post post)
	{
	    PostId = post.Id;
	    Title = post.Title;
	    Content = GetLines(post.Content);
	    Author = UserService.GetUser(post.AuthorId).Username;
	    Category = PostService.GetCategory(post.CategoryId).Name;
	    Replies = PostService.GetPostReplies(post.Id);
	}

	private IList<string> GetLines(string content)
	{
	    char[] contentChars = content.ToCharArray();
	    IList<string> lines = new List<string>();
	    for (int c = 0; c < contentChars.Length; c += LINE_LENGTH)
	    {
		char[] lineChars = contentChars.Skip(c).Take(LINE_LENGTH).ToArray();
		string line = String.Join("", lineChars);
		lines.Add(line);
	    }
	    return lines;
	}
    }
}
