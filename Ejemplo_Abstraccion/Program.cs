using System;

class Program
{
    static void Main()
    {
        Vehiculo miAuto = new Vehiculo();

        miAuto.Marca = "Toyota";
        miAuto.Modelo = "Corolla";
        miAuto.Color = "Azul";

        /*Console.WriteLine("Marca: " + miAuto.Marca);
        Console.WriteLine("Modelo: " + miAuto.Modelo);
        Console.WriteLine("Color: " + miAuto.Color);*/

        miAuto.Arrancar();
        miAuto.Acelerar();
        miAuto.Frenar();
        miAuto.Detenerse();

        Console.ReadLine();
    }
}



