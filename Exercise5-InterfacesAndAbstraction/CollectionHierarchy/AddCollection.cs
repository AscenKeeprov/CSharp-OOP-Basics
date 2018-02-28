using System.Linq;

public class AddCollection : Collection, IExpandable
{
    public virtual int Add(string item)
    {
	Items.Insert(Items.Count, item);
	return Items.Count - 1;
    }
}
