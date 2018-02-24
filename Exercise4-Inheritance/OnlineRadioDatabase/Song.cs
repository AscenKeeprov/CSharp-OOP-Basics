using System;

public class Song
{
    private string title;
    private const int MinNameLength = 3;
    private const int MaxSongTitleLength = 30;
    private const string InvalidName = "{0} name should be between {1} and {2} symbols.";
    private string artist;
    private const int MaxArtistNameLength = 20;
    private const int MinRecordLength = 0;
    private const string InvalidRecordLength = "Invalid song length.";
    private int lengthInMinutes;
    private const int MaxRecordLengthInMinutes = 14;
    private const string InvalidRecordLengthInMinutes = "Song minutes should be between {0} and {1}.";
    private int lengthInSeconds;
    private const int MaxRecordLengthInSeconds = 59;
    private const string InvalidRecordLengthInSeconds = "Song seconds should be between {0} and {1}.";

    public string Title
    {
	get { return title; }
	protected set
	{
	    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) ||
		value.Length < MinNameLength || value.Length > MaxSongTitleLength)
		throw new ArgumentException(String.Format(
		    InvalidName, GetType().Name, MinNameLength, MaxSongTitleLength));
	    title = value;
	}
    }

    public string Artist
    {
	get { return artist; }
	protected set
	{
	    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) ||
		value.Length < MinNameLength || value.Length > MaxArtistNameLength)
		throw new ArgumentException(String.Format(
		    InvalidName, nameof(Artist), MinNameLength, MaxArtistNameLength));
	    artist = value;
	}
    }

    public int LengthInMinutes
    {
	get { return lengthInMinutes; }
	protected set { lengthInMinutes = value; }
    }

    public int LengthInSeconds
    {
	get { return lengthInSeconds; }
	protected set { lengthInSeconds = value; }
    }

    public Song(string artist, string title, string length)
    {
	Artist = artist;
	Title = title;
	int[] validRecordLength = ValidateRecordLength(length);
	LengthInMinutes = validRecordLength[0];
	LengthInSeconds = validRecordLength[1];
    }

    private int[] ValidateRecordLength(string length)
    {
	string[] lengthsByType = length.Split(':');
	if (lengthsByType.Length != 2 ||
	    !int.TryParse(lengthsByType[0], out int lengthInMinutes) ||
	    !int.TryParse(lengthsByType[1], out int lengthInSeconds))
	    throw new ArgumentException(InvalidRecordLength);
	if (lengthInMinutes < MinRecordLength || lengthInMinutes > MaxRecordLengthInMinutes)
	    throw new ArgumentException(String.Format(
		InvalidRecordLengthInMinutes, MinRecordLength, MaxRecordLengthInMinutes));
	if (lengthInSeconds < MinRecordLength || lengthInSeconds > MaxRecordLengthInSeconds)
	    throw new ArgumentException(String.Format(
		InvalidRecordLengthInSeconds, MinRecordLength, MaxRecordLengthInSeconds));
	return new int[] { lengthInMinutes, lengthInSeconds };
    }
}
