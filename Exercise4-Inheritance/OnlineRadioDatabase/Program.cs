using System;
using System.Collections.Generic;

public class Program
{
    private const string InvalidSong = "Invalid song.";

    static void Main()
    {
	List<Song> playlist = new List<Song>();
	int songsCount = int.Parse(Console.ReadLine());
	for (int s = 1; s <= songsCount; s++)
	{
	    try
	    {
		string[] songInfo = Console.ReadLine().Split(';');
		if (IsSongValid(songInfo)) AddSongToPlaylist(songInfo, playlist);
	    }
	    catch (ArgumentException exception)
	    {
		Console.WriteLine(exception.Message);
	    }
	}
	Console.WriteLine($"Songs added: {playlist.Count}");
	Console.WriteLine(CalculatePlaylistLength(playlist));
    }

    private static bool IsSongValid(string[] songInfo)
    {
	if (songInfo.Length != 3)
	    throw new ArgumentException(InvalidSong);
	return true;
    }

    private static void AddSongToPlaylist(string[] songInfo, List<Song> playlist)
    {
	string artist = songInfo[0];
	string title = songInfo[1];
	string length = songInfo[2];
	Song song = new Song(artist, title, length);
	playlist.Add(song);
	Console.WriteLine("Song added.");
    }

    private static string CalculatePlaylistLength(List<Song> playlist)
    {
	int seconds = 0;
	int minutes = 0;
	int hours = 0;
	foreach (Song song in playlist)
	{
	    seconds += song.LengthInSeconds;
	    minutes += song.LengthInMinutes;
	}
	if (seconds > 59)
	{
	    minutes += seconds / 60;
	    seconds %= 60;
	}
	if (minutes > 59)
	{
	    hours += minutes / 60;
	    minutes %= 60;
	}
	return $"Playlist length: {hours}h {minutes}m {seconds}s";
    }
}
