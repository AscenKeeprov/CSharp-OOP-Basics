public interface ICar
{
    string Model { get; set; }
    string Driver { get; set; }

    void PushGasPedal();
    void PushBrakes();
}
