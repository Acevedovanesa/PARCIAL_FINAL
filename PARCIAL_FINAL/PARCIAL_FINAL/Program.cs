
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
        Random random = new Random();

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

    private static int[,] GenerarMatriz(int n, int m)
    {
        throw new NotImplementedException();
    }
}
   

