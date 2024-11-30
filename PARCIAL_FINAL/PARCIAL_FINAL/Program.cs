
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el número de filas (N):");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el número de columnas (M):");
        int M = int.Parse(Console.ReadLine());

        // Crear y llenar la matriz con números aleatorios
        int[,] Matriz = GenerarMatriz(N, M);
        

        int X = 0, Y = 0;
        int Acumulado = 0;

        ConsoleKey tecla;

        do
        {
            Console.Clear();

            // Mostrar la matriz actual
            MostrarMatriz(Matriz, X, Y, Acumulado);

            Console.WriteLine("Usa las teclas de derecha, iquierda, arriba o abajo para moverte o ESC para salir.");

            // Leer tecla
            tecla = Console.ReadKey(true).Key;

            // Procesar movimiento
            (X, Y, Acumulado) = MoverJugador(tecla, X, Y, Matriz, Acumulado);
        }
        while (tecla != ConsoleKey.Escape);

        Console.Clear();
        Console.WriteLine("¡Juego terminado!");
        Console.WriteLine($"Suma total de los números: {Acumulado}");
        Console.WriteLine("Matriz final:");

        MostrarMatriz(Matriz, -1, -1, Acumulado);
    }

    private static (int X, int Y, int Acumulado) MoverJugador(ConsoleKey tecla, int x, int y, int[,] matriz, int acumulado)
    {
        
        {
            int PosX = x, PosY = y;

            switch (tecla)
            {
                case ConsoleKey.UpArrow:    // Arriba
                    PosX = Math.Max(0, x - 1);
                    break;
                case ConsoleKey.DownArrow: // Abajo
                    PosX = Math.Min(matriz.GetLength(0) - 1, x + 1);
                    break;
                case ConsoleKey.LeftArrow: // Izquierda
                    PosY = Math.Max(0, y - 1);
                    break;
                case ConsoleKey.RightArrow: // Derecha
                    PosY = Math.Min(matriz.GetLength(1) - 1, y + 1);
                    break;
            }

            // Si se mueve, acumular y marcar como visitado
            if (PosX != x || PosY != y)
            {
                acumulado += matriz[PosX,PosY];
                matriz[PosX, PosY] = 0; // Marcar celda como visitada
            }

            return (PosX, PosY, acumulado);
        }
    }

    static int[,] GenerarMatriz(int F, int C)
    {
        {
            int[,] matriz = new int[F, C];
            Random random = new Random();
            for (int i = 0; i < F; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    matriz[i, j] = random.Next (0, 10); // Números entre 0 y 9
                }
            }
            matriz[0, 0] = 0; // Posición inicial en 0
            return matriz;
        }
    }

    private static void MostrarMatriz(int[,] matriz, int JugaX, int JugaY, int Acumulado)
    {
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (i == JugaX && j == JugaY)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" 0 "); // Representar jugador
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($" {matriz[i, j]:D1} ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Suma acumulada: {Acumulado}");
        }
    }

       

        }
    





   

