namespace Totito
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;

            while (opcion != 3)
            {
                Console.Clear();
                DibujarMenu();

                string? input = Console.ReadLine();

                if (int.TryParse(input, out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            ComenzarJuego();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:
                            Console.SetCursorPosition(5, 10);
                            Console.WriteLine("Ingrese una opción válida");
                            break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(5, 10);
                    Console.WriteLine("Ingrese una opción válida");
                }

                Console.SetCursorPosition(5, 10);
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            
            Console.Clear();
        }

        static void DibujarMenu(int margenIzquierdo = 5, int margenSuperior = 1)
        {
            Console.SetCursorPosition(margenIzquierdo, margenSuperior);
            Console.WriteLine(new string('-', 25));

            Console.SetCursorPosition(margenIzquierdo, margenSuperior + 8);
            Console.WriteLine(new string('-', 25));

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(margenIzquierdo, margenSuperior + i + 1);
                Console.WriteLine("|" + new string(' ', 23) + "|");
            }

            Console.SetCursorPosition(margenIzquierdo + 10, margenSuperior + 1);
            Console.WriteLine("TOTITO");

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 3);
            Console.WriteLine("1. Jugar");

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 4);
            Console.WriteLine("2. Instrucciones");

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 5);
            Console.WriteLine("3. Salir");

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 7);
            Console.Write("Elija una opción: ");
        }

        static void ComenzarJuego()
        {
            Console.Clear();
            DibujarTablero();

            Console.SetCursorPosition(7, 4);
            var t = Console.ReadKey();

            if (t.Key == ConsoleKey.Escape)
            {

            }
        }

        static void DibujarTablero(int margenIzquierdo = 5, int margenSuperior = 1)
        {
            Console.SetCursorPosition(margenIzquierdo, margenSuperior + 2);
            Console.WriteLine(new string('-', 17));

            Console.SetCursorPosition(margenIzquierdo, margenSuperior + 4);
            Console.WriteLine(new string('-', 17));

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(margenIzquierdo + 5, margenSuperior + i);
                Console.WriteLine("|");

                Console.SetCursorPosition(margenIzquierdo + 11, margenSuperior + i);
                Console.WriteLine("|");
            }

            Console.SetCursorPosition(margenIzquierdo + 25, margenSuperior + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("X jugador 1");

            Console.SetCursorPosition(margenIzquierdo + 25, margenSuperior + 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("O jugador 2");

            Console.ResetColor();
            Console.SetCursorPosition(margenIzquierdo + 25, margenSuperior + 4);
            Console.WriteLine("Presione ESC para volver al menú");

            Console.SetCursorPosition(margenIzquierdo + 25, margenSuperior + 6);
            Console.WriteLine("Turno del jugador 1");
        }
    }
}