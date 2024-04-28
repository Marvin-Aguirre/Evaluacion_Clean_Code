using System;

public class Vehiculo
{
    public string Modelo { get; set; }
    public string Color { get; set; }
    public string Marca { get; set; }

    public void Arrancar()
    {
        Console.WriteLine("El vehículo ha arrancado.");
    }

    public void Detenerse()
    {
        Console.WriteLine("El vehículo se ha detenido.");
    }

    public void Acelerar()
    {
        Console.WriteLine("El vehículo está acelerando.");
    }

    public void Frenar()
    {
        Console.WriteLine("El vehículo está frenando.");
    }
}
