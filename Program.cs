namespace Totito
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarMenu();
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

        static void MostrarMenu()
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
                            break;
                        case 2:
                            break;
                        case 3:
                            Console.SetCursorPosition(5, 10);
                            Console.WriteLine("¡Nos vemos!");
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
        }
    }
}