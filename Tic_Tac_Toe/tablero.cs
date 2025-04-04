public class tablero
{
    private char[,] matriz;

    public tablero()
    {
        matriz = new char[3, 3];
        limpiar_tablero();
    }

    public bool actualizar_tablero(int fila, int columna, char simbolo)
    {
        if (!(fila >= 0 && columna >= 0 && fila < 3 && columna < 3))
        {
            return false;
        }
        else
        {
            if (matriz[fila, columna] == '_')
            {
                matriz[fila, columna] = simbolo;
                if (verificarGanador() == simbolo)
                {
                    declararGanador(simbolo);
                }
                return true;
            }
            return false;
        }
    }
    public void mostrar_tablero()
    {
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void limpiar_tablero()
    {
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                matriz[i, j] = '_';
            }
        }
    }

    public bool existenCasillasLibres()
    {
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                if (matriz[i, j] == '_')
                {
                    return true;
                }
            }
        }
        return false;
    }
    public char verificarGanador()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (matriz[i, 0] != '_' && matriz[i, 0] == matriz[i, 1] && matriz[i, 1] == matriz[i, 2])
            {
                return matriz[i, 0];
            }
        }
        for (int j = 0; j < 3; ++j)
        {
            if (matriz[0, j] != '_' && matriz[0, j] == matriz[1, j] && matriz[1, j] == matriz[2, j])
            {
                return matriz[0, j];
            }
        }
        if (matriz[0, 0] != '_' && matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2])
        {
            return matriz[0, 0];
        }
        if (matriz[0, 2] != '_' && matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
        {
            return matriz[0, 2];
        }
        return '_';
    }

    public char declararGanador(char ganador)
    {
        return ganador;
    }
}
