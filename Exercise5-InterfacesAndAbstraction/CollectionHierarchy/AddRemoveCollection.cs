using System.Linq;

public class AddRemoveCollection : AddCollection, IShrinkable
{
    public override int Add(string item)
    {
	Items.Insert(0, item);
	return 0;
    }

    public virtual string Remove()
    {
	string item = Items.Last();
	Items.RemoveAt(Items.Count - 1);
	return item;
    }
}
