using System;

public class AnimalFactory : Factory
{
    internal Animal Produce(string[] animalInfo)
    {
	Animal animal = null;
	Type typeOfAnimal = ToProperType(animalInfo[0]);
	string name = animalInfo[1];
	double weight = double.Parse(animalInfo[2]);
	if (double.TryParse(animalInfo[3], out double wingSize))
	    animal = (Animal)Activator.CreateInstance(typeOfAnimal, name, weight, wingSize);
	else
	{
	    string habitat = animalInfo[3];
	    if (animalInfo.Length > 4)
	    {
		string breed = animalInfo[4];
		animal = (Animal)Activator.CreateInstance(typeOfAnimal, name, weight, habitat, breed);
	    }
	    else animal = (Animal)Activator.CreateInstance(typeOfAnimal, name, weight, habitat);
	}
	return animal;
    }
}
