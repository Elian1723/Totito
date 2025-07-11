namespace Totito;

public class Totito
{
    private const int _margenIzquierdo = 5;
    private const int _margenSuperior = 1;
    private readonly short[,] _tablero = new short[3, 3];
    private readonly Posicion _posicion = new();
    private class Posicion
    {
        public int Fila { get; set; }
        public int Columna { get; set; }

        public void Mover(int fila, int columna)
        {
            this.Fila = fila;
            this.Columna = columna;

            Console.SetCursorPosition(_margenIzquierdo + 2 + columna * 6, _margenSuperior + 1 + fila * 2);
        }
    }

    public void Jugar()
    {
        Console.Clear();
        DibujarTablero();

        _posicion.Mover(0, 0);
        ConsoleKey? tecla = Console.ReadKey().Key;

        while (tecla != ConsoleKey.Escape)
        {
            switch (tecla)
            {
                case ConsoleKey.UpArrow:
                    _posicion.Mover(_posicion.Fila == 0 ? 2 : _posicion.Fila - 1, _posicion.Columna);
                    break;
                case ConsoleKey.DownArrow:
                    _posicion.Mover(_posicion.Fila == 2 ? 0 : _posicion.Fila + 1, _posicion.Columna);
                    break;
                case ConsoleKey.LeftArrow:
                    _posicion.Mover(_posicion.Fila, _posicion.Columna == 0 ? 2 : _posicion.Columna - 1);
                    break;
                case ConsoleKey.RightArrow:
                    _posicion.Mover(_posicion.Fila, _posicion.Columna == 2 ? 0 : _posicion.Columna + 1);
                    break;
                case ConsoleKey.X:
                    LlenarCasillaYCambiarTurno(_posicion.Fila, _posicion.Columna, 1);
                    break;
                case ConsoleKey.O:
                    LlenarCasillaYCambiarTurno(_posicion.Fila, _posicion.Columna, 2);
                    break;
                default:
                    LlenarCasillaYCambiarTurno(_posicion.Fila, _posicion.Columna, 0);
                    break;
            }

            tecla = Console.ReadKey().Key;
        }
    }

    private void LlenarCasillaYCambiarTurno(int fila, int columna, short valor)
    {
        _posicion.Mover(_posicion.Fila, _posicion.Columna);

        if (_tablero[fila, columna] == 0)
        {
            if (valor == 0)
            {
                Console.WriteLine(" ");
            }
            else
            {
                DibujarJugada(valor);
                _tablero[fila, columna] = valor;
                DibujarTurno(valor == 1 ? 2 : 1);
            }
        }
        else
        {
            DibujarJugada(_tablero[fila, columna]);
        }

        _posicion.Mover(_posicion.Fila, _posicion.Columna);
    }

    private void DibujarTurno(int jugador)
    {
        Console.SetCursorPosition(_margenIzquierdo + 25, _margenSuperior + 6);
        Console.WriteLine($"Turno del jugador {jugador}");
    }

    private void DibujarJugada(short valor)
    {
        if (valor == 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('X');
        }
        else if (valor == 2)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('O');
        }
        Console.ResetColor();
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
