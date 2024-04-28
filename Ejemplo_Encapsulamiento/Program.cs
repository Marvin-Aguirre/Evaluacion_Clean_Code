class Program
{
    static void Main()
    {
        Vehiculo miAuto = new Vehiculo();

        miAuto.Modelo = "Corolla";
        miAuto.Color = "Azul";
        miAuto.Marca = "Toyota";
        //miAuto.numeroSerieMotor="121221"; Atributo no accesible
        miAuto.SetNumeroSerieMotor("12345");

        Console.WriteLine("Detalles del vehículo:");
        Console.WriteLine("Modelo: " + miAuto.Modelo);
        Console.WriteLine("Color: " + miAuto.Color);
        Console.WriteLine("Marca: " + miAuto.Marca);
        Console.WriteLine("Número de serie del motor: " + miAuto.getNumeroSerie());

    }
}
