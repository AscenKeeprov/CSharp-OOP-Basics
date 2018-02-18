using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
	Hospital hospital = new Hospital();
	string input;
	while (!(input = Console.ReadLine().Trim()).ToUpper().Equals("OUTPUT"))
	{
	    string[] hospitalInfo = input.Split();
	    string wardName = hospitalInfo[0];
	    Ward ward = new Ward(wardName);
	    if (hospital.Wards.Any(w => w.Name == ward.Name))
		ward = hospital.Wards.First(w => w.Name == ward.Name);
	    else hospital.Wards.Add(ward);
	    string doctorName = $"{hospitalInfo[1]} {hospitalInfo[2]}";
	    Doctor doctor = new Doctor(doctorName);
	    if (hospital.Staff.Any(d => d.Name == doctor.Name))
		doctor = hospital.Staff.First(d => d.Name == doctor.Name);
	    else hospital.Staff.Add(doctor);
	    string patientName = hospitalInfo[3];
	    Patient patient = new Patient(patientName);
	    if (!doctor.Patients.Any(p => p.Name == patient.Name))
		doctor.Patients.Add(patient);
	    AccommodatePatient(ward, patient);
	}
	while (!(input = Console.ReadLine().Trim()).ToUpper().Equals("END"))
	{
	    string[] wantedData = input.Split();
	    if (wantedData.Length == 1) Print(wantedData, hospital.Wards);
	    if (wantedData.Length == 2) Print(wantedData, hospital.Wards, hospital.Staff);
	}
    }

    private static void AccommodatePatient(Ward ward, Patient patient)
    {
	bool patientAlreadyInWard = ward.Patients.Any(p => p.Name == patient.Name);
	if (!patientAlreadyInWard)
	{
	    bool wardHasFreeBeds = ward.Rooms.Any(r => r.Beds.Any(b => b.Patient == null));
	    if (wardHasFreeBeds)
	    {
		Room room = ward.Rooms.First(r => r.Beds.Any(b => b.Patient == null));
		Bed bed = room.Beds.First(b => b.Patient == null);
		bed.Patient = patient;
		ward.Patients.Add(patient);
	    }
	}
    }

    private static void Print(string[] wantedData, List<Ward> wards)
    {
	string wardName = wantedData[0];
	Ward ward = wards.First(w => w.Name == wardName);
	foreach (Room room in ward.Rooms.Where(r => r.Beds.Any(b => b.Patient != null)))
	{
	    foreach (Bed bed in room.Beds.Where(b => b.Patient != null))
	    {
		Console.WriteLine(bed.Patient.Name);
	    }
	}
    }

    private static void Print(string[] wantedData, List<Ward> wards, List<Doctor> doctors)
    {
	if (int.TryParse(wantedData[1], out int roomNumber))
	{
	    string wardName = wantedData[0];
	    Ward ward = wards.First(w => w.Name == wardName);
	    Room room = ward.Rooms.First(r => r.Number == roomNumber);
	    foreach (Bed bed in room.Beds
		.Where(b => b.Patient != null).OrderBy(b => b.Patient.Name))
	    {
		Console.WriteLine(bed.Patient.Name);
	    }
	}
	else
	{
	    string doctorName = $"{wantedData[0]} {wantedData[1]}";
	    Doctor doctor = doctors.First(d => d.Name == doctorName);
	    foreach (Patient patient in doctor.Patients.OrderBy(p => p.Name))
	    {
		Console.WriteLine(patient.Name);
	    }
	}
    }
}
