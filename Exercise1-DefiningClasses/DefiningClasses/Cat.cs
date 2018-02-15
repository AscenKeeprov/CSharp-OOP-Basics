public class Cat
{
    public string Name { get; set; }
    public Breed Breed { get; set; }

    public override string ToString()
    {
	if (Breed.Name == "Cymric")
	    return $"{Breed.Name} {Name} {Breed.Trait:F2}";
	else return $"{Breed.Name} {Name} {Breed.Trait}";
    }
}
