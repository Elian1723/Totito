namespace Totito;

public class Totito
{
    private const int _margenIzquierdo = 5;
    private const int _margenSuperior = 1;

    public void Jugar()
    {
        Console.Clear();
        DibujarTablero();

        Console.SetCursorPosition(_margenIzquierdo + 2, _margenSuperior + 1);
        var t = Console.ReadKey();

        if (t.Key == ConsoleKey.Escape)
        {

        }
    }

    private void DibujarTablero()
    {
        Console.SetCursorPosition(_margenIzquierdo, _margenSuperior + 2);
        Console.WriteLine(new string('-', 17));

        Console.SetCursorPosition(_margenIzquierdo, _margenSuperior + 4);
        Console.WriteLine(new string('-', 17));

        for (int i = 0; i < 7; i++)
        {
            Console.SetCursorPosition(_margenIzquierdo + 5, _margenSuperior + i);
            Console.WriteLine("|");

            Console.SetCursorPosition(_margenIzquierdo + 11, _margenSuperior + i);
            Console.WriteLine("|");
        }

        Console.SetCursorPosition(_margenIzquierdo + 25, _margenSuperior + 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("X jugador 1");

        Console.SetCursorPosition(_margenIzquierdo + 25, _margenSuperior + 2);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("O jugador 2");

        Console.ResetColor();
        Console.SetCursorPosition(_margenIzquierdo + 25, _margenSuperior + 4);
        Console.WriteLine("Presione ESC para volver al menú");

        Console.SetCursorPosition(_margenIzquierdo + 25, _margenSuperior + 6);
        Console.WriteLine("Turno del jugador 1");
    }
}
