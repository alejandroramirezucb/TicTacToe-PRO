using System;
using System.Reflection.Metadata.Ecma335;

public class consola
{
    private jugador usuario;
    private jugador oponente;
    private tablero tablero;

    public consola(string nombreUsuario, string nombreOponente)
    {
        this.usuario = new jugador(nombreUsuario);
        this.oponente = new jugador(nombreOponente);
        this.tablero = new tablero();
    }

    public void interfaz()
    {
        Console.Clear();
        int simbolo = 0;
        char simboloUsuario = '_';
        char simboloOponente = '_';
        Random r = new Random();
        Console.WriteLine($"------------------------Bienvenido {usuario.getNombreDeUsuario()}------------------------");
        while (simbolo == 0)
        {
            Console.WriteLine("                          1. 'O' | 2. 'X'\n");
            Console.WriteLine("Elige tu simbolo: ");
            if (!int.TryParse(Console.ReadLine(), out simbolo))
            {
                Console.WriteLine("ERROR: Valor invalido");
                continue;
            }
            else
            {
                if (simbolo == 1)
                {
                    simboloUsuario = 'O';
                    simboloOponente = 'X';
                    break;
                }
                else if (simbolo == 2)
                {
                    simboloUsuario = 'X';
                    simboloOponente = '0';
                    break;
                }
                else
                {
                    simbolo = 0;
                    Console.WriteLine("ERROR: Valor invalido");
                    continue;
                }
            }
        }
        Console.Clear();
        int ronda = 1;
        while (tablero.existenCasillasLibres() && tablero.verificarGanador() == '_')
        {
            Console.Clear();
            // Turno de Usuario
            Console.WriteLine($"-----------------------------------{ronda}°Ronda-----------------------------------\n");
            tablero.mostrar_tablero();
            Console.WriteLine("-------------------------Turno del usuario " + usuario.getNombreDeUsuario() + "-------------------------\n");
            int fila, columna;
            Console.WriteLine("Ingrese la fila (Empezamos desde la fila 0)");
            if (!int.TryParse(Console.ReadLine(), out fila))
            {
                Console.WriteLine("ERROR: Valor invalido");
                continue;
            }
            Console.WriteLine("Ingrese la columna (Empezamos desde la columna 0)");
            if (!int.TryParse(Console.ReadLine(), out columna))
            {
                Console.WriteLine("ERROR: Valor invalido");
                continue;
            }
            if (!tablero.actualizar_tablero(fila, columna, simboloUsuario))
            {
                Console.WriteLine("ERROR: Movimiento invalido");
                continue;
            }
            if (tablero.verificarGanador() != '_' || !tablero.existenCasillasLibres())
            {
                break;
            }
            Console.Clear();
            // Turno del Oponente
            Console.WriteLine($"-----------------------------------{ronda}°Ronda-----------------------------------\n");
            tablero.mostrar_tablero();
            Console.WriteLine("-------------------------Turno del oponente " + oponente.getNombreDeUsuario() + "-------------------------\n");
            bool movimientoAutomatico = false;
            int aFila = 0, aColumna = 0;
            // Celda ramdon
            while (!movimientoAutomatico && tablero.existenCasillasLibres())
            {
                aFila = r.Next(0, 3);
                aColumna = r.Next(0, 3);
                movimientoAutomatico = tablero.actualizar_tablero(aFila, aColumna, simboloOponente);
            }
            Console.WriteLine("El oponente " + oponente.getNombreDeUsuario() + " agrego " + simboloOponente + " en la posicion [" + aFila + ", " + aColumna + "]\n");
            Console.ReadKey();
            ++ronda;
        }
        Console.Clear();
        Console.WriteLine($"-------------------------------------Resultados-------------------------------------\n");
        tablero.mostrar_tablero();
        char ganador = tablero.verificarGanador();
        if (ganador != '_')
        {
            if (ganador == simboloUsuario)
            {
                Console.WriteLine("¡Juego terminado! El ganador es: " + usuario.getNombreDeUsuario());
            }
            else
            {
                Console.WriteLine("¡Juego terminado! El ganador es: " + oponente.getNombreDeUsuario());
            }
        }
        else
        {
            Console.WriteLine("¡Juego terminado! Ha sido un empate");
        }
    }
}
