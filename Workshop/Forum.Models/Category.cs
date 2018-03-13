namespace Forum.Models
{
    using System.Collections.Generic;

    public class Category
    {
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<int> PostIds { get; set; }

	public Category()
	{
	    PostIds = new List<int>();
	}

	public Category(int id, string name) : this()
	{
	    Id = id;
	    Name = name;
	}

	public Category(int id, string name, ICollection<int> postIds) : this(id, name)
	{
	    PostIds = postIds;
	}
    }
}
