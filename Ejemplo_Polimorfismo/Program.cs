class Program
{
    static void Main()
    {

        Vehiculo vehiculo1 = new Automovil();
        Vehiculo vehiculo2 = new Motocicleta();
        Vehiculo vehiculo3 = new Camioneta();

        vehiculo1.Conducir(); 
        vehiculo2.Conducir(); 
        vehiculo3.Conducir(); 
    }
}