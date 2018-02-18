public class Room
{
    public int Number { get; set; }
    public Bed[] Beds { get; set; }

    public Room()
    {
	Beds = new Bed[3];
	for (int b = 0; b < Beds.Length; b++)
	{
	    Beds[b] = new Bed();
	}
    }
}
