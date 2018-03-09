using System.Collections.Generic;

namespace Forum.Models
{
    public class User
    {
	public int Id { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public ICollection<int> PostIds { get; set; }

	public User()
	{
	    PostIds = new List<int>();
	}

	public User(int id, string username, string password) : this()
	{
	    Id = id;
	    Username = username;
	    Password = password;
	}

	public User(int id, string username, string password, ICollection<int> postIds)
	    : this(id, username, password)
	{
	    PostIds = postIds;
	}
    }
}
