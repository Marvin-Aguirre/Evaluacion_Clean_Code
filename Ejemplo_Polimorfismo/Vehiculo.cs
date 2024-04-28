using System;

// Clase base o interfaz Vehiculo 
public class Vehiculo
{
    public virtual void Conducir()
    {
        Console.WriteLine("Conduciendo un vehículo genérico.");
    }
}

public class Automovil : Vehiculo
{

    public override void Conducir()
    {
        Console.WriteLine("Conduciendo un automóvil.");
    }
}

public class Motocicleta : Vehiculo
{
    public override void Conducir()
    {
        Console.WriteLine("Conduciendo una motocicleta.");
    }
}


public class Camioneta : Vehiculo
{

    public override void Conducir()
    {
        Console.WriteLine("Conduciendo una camioneta.");
    }
}


