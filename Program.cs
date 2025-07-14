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
                            var totito = new Totito();
                            totito.Jugar();
                            break;
                        case 2:
                            DibujarInstrucciones();
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

                // Console.SetCursorPosition(5, 10);
                Console.WriteLine("Presione cualquier tecla para continuar...");
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

        static void DibujarInstrucciones(int margenIzquierdo = 5, int margenSuperior = 1)
        {
            Console.Clear();

            Console.SetCursorPosition(margenIzquierdo, margenSuperior);
            Console.WriteLine(new string('=', 50));

            Console.SetCursorPosition(margenIzquierdo + 18, margenSuperior + 1);
            Console.WriteLine("INSTRUCCIONES");

            Console.SetCursorPosition(margenIzquierdo, margenSuperior + 2);
            Console.WriteLine(new string('=', 50));

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 4);
            Console.WriteLine("OBJETIVO:");
            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 5);
            Console.WriteLine("Conseguir tres símbolos iguales en línea");
            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 6);
            Console.WriteLine("(horizontal, vertical o diagonal)");

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 8);
            Console.WriteLine("CONTROLES:");

            Console.SetCursorPosition(margenIzquierdo + 4, margenSuperior + 9);
            Console.WriteLine("Flechas del teclado: Mover cursor");

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 12);
            Console.WriteLine("JUGADORES:");

            Console.SetCursorPosition(margenIzquierdo + 4, margenSuperior + 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Jugador 1 (X): ");
            Console.ResetColor();
            Console.WriteLine("Presiona la tecla 'X'");

            Console.SetCursorPosition(margenIzquierdo + 4, margenSuperior + 14);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Jugador 2 (O): ");
            Console.ResetColor();
            Console.WriteLine("Presiona la tecla 'O'");

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 16);
            Console.WriteLine("TURNOS:");
            Console.SetCursorPosition(margenIzquierdo + 4, margenSuperior + 17);
            Console.WriteLine("• El Jugador 1 (X) siempre comienza");
            Console.SetCursorPosition(margenIzquierdo + 4, margenSuperior + 18);
            Console.WriteLine("• Los turnos se alternan automáticamente");
            Console.SetCursorPosition(margenIzquierdo + 4, margenSuperior + 19);
            Console.WriteLine("• Solo puedes jugar en tu turno");

            Console.SetCursorPosition(margenIzquierdo + 2, margenSuperior + 21);
            Console.WriteLine("SALIR:");
            Console.SetCursorPosition(margenIzquierdo + 4, margenSuperior + 22);
            Console.WriteLine("ESC: Volver al menú principal");

            Console.SetCursorPosition(margenIzquierdo, margenSuperior + 24);
            Console.WriteLine(new string('=', 50));
        }
    }
}