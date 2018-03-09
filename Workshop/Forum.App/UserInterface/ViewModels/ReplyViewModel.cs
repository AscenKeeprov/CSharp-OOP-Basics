using System;
using System.Collections.Generic;
using System.Linq;
using Forum.App.Services;
using Forum.Models;

namespace Forum.App.UserInterface.ViewModels
{
    public class ReplyViewModel
    {
	private const int LINE_LENGTH = 37;
	public int ReplyId { get; set; }
	public int PostId { get; set; }
	public string Author { get; set; }
	public IList<string> Content { get; set; }

	public ReplyViewModel()
	{
	    Content = new List<string>();
	}

	public ReplyViewModel(Reply reply)
	{
	    ReplyId = reply.Id;
	    PostId = reply.PostId;
	    Author = UserService.GetUser(reply.AuthorId).Username;
	    Content = GetLines(reply.Content);
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
