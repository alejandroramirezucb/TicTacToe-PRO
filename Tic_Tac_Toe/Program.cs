using System;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("---------------------------Tres en Raya---------------------------\n");
        Console.WriteLine("Ingrese el nombre del Usuario: ");
        string nombreUsuario = Console.ReadLine();
        Console.WriteLine("Ingrese el nombre del Oponente: ");
        string nombreOponente = Console.ReadLine();
        Console.ReadKey();
        consola Consola = new consola(nombreUsuario, nombreOponente);
        Consola.interfaz();
    }
}