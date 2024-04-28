public class Vehiculo
{
    //Propiedad privada para el numero de serie del motor
    private string numeroSerieMotor;
    public string Modelo;
    public string Color ;
    public string Marca; 


    public void SetNumeroSerieMotor(String serie)
    {
       numeroSerieMotor=serie;
    }
    public string getNumeroSerie(){
        return numeroSerieMotor;
    }

    // Métodos públicos
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