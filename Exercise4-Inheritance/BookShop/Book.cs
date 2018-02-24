using System;
using System.Text;

public class Book
{
    private string title;
    private const string InvalidTitle = "Title not valid!";
    private string author;
    private const string InvalidAuthor = "Author not valid!";
    private decimal price;
    private const string InvalidPrice = "Price not valid!";

    public string Title
    {
	get { return title; }
	protected set
	{
	    if (value.Length < 3) throw new ArgumentException(InvalidTitle);
	    title = value;
	}
    }

    public string Author
    {
	get { return author; }
	protected set
	{
	    string[] authorNames = value.Split();
	    if (authorNames.Length > 1 && Char.IsDigit(authorNames[1][0]))
		throw new ArgumentException(InvalidAuthor);
	    author = value;
	}
    }

    public virtual decimal Price
    {
	get { return price; }
	protected set
	{
	    if (value <= 0) throw new ArgumentException(InvalidPrice);
	    price = value;
	}
    }

    public Book(string author, string title, decimal price)
    {
	Author = author;
	Title = title;
	Price = price;
    }

    public override string ToString()
    {
	StringBuilder bookInfo = new StringBuilder();
	bookInfo.AppendLine($"Type: {GetType().Name}")
	    .AppendLine($"Title: {Title}")
	    .AppendLine($"Author: {Author}")
	    .AppendLine($"Price: {Price:F2}");
	return bookInfo.ToString().TrimEnd();
    }
}
