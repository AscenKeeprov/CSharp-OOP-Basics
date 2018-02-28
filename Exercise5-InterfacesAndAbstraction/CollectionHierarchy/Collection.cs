using System.Collections.Generic;

public abstract class Collection
{
    protected List<string> Items { get; set; }

    public Collection()
    {
	Items = new List<string>();
    }
}
