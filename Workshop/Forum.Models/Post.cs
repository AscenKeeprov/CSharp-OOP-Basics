namespace Forum.Models
{
    using System.Collections.Generic;

    public class Post
    {
	public int Id { get; set; }
	public string Title { get; set; }
	public string Content { get; set; }
	public int CategoryId { get; set; }
	public int AuthorId { get; set; }
	public ICollection<int> ReplyIds { get; set; }

	public Post()
	{
	    ReplyIds = new List<int>();
	}

	public Post(int id, string title, string content, int categoryId, int authorId) : this()
	{
	    Id = id;
	    Title = title;
	    Content = content;
	    CategoryId = categoryId;
	    AuthorId = authorId;
	}

	public Post(int id, string title, string content, int categoryId, int authorId, List<int> replyIds)
	    : this(id, title, content, categoryId, authorId)
	{
	    ReplyIds = replyIds;
	}
    }
}
