namespace Totito;

public class Totito
{
    private const int _margenIzquierdo = 5;
    private const int _margenSuperior = 1;
    private readonly short[,] _tablero = new short[3, 3];
    private readonly Posicion _posicion = new();
    private short _turno = 1;

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
                case ConsoleKey.X when _turno == 1:
                    LlenarCasillaYCambiarTurno(_posicion.Fila, _posicion.Columna, 1);
                    break;
                case ConsoleKey.O when _turno == 2:
                    LlenarCasillaYCambiarTurno(_posicion.Fila, _posicion.Columna, 2);
                    break;
                default:
                    LlenarCasillaYCambiarTurno(_posicion.Fila, _posicion.Columna, 0);
                    break;
            }

            if (tecla == ConsoleKey.X || tecla == ConsoleKey.O)
            {
                if (ComprobarGanador(out short ganador))
                {
                    Console.SetCursorPosition(_margenIzquierdo + 25, _margenSuperior + 6);
                    Console.WriteLine($"¡El jugador {ganador} ha ganado!");

                    return;
                }
                else
                {
                    if (HayEmpate())
                    {
                        Console.SetCursorPosition(_margenIzquierdo + 25, _margenSuperior + 6);
                        Console.WriteLine("¡El juego ha terminado en empate!");
                        return;
                    }
                }
            }

            tecla = Console.ReadKey().Key;
        }
    }

    private bool ComprobarGanador(out short ganador)
    {
        ganador = 0;

        for (int i = 0; i < 3; i++)
        {
            if (_tablero[i, 0] == _tablero[i, 1] && _tablero[i, 0] == _tablero[i, 2] && _tablero[i, 0] != 0)
            {
                ganador = _tablero[i, 0];
                break;
            }
            if (_tablero[0, i] == _tablero[1, i] && _tablero[0, i] == _tablero[2, i] && _tablero[0, i] != 0)
            {
                ganador = _tablero[0, i];
                break;
            }
        }

        if (_tablero[0, 0] == _tablero[1, 1] && _tablero[2, 2] == _tablero[0, 0] && _tablero[0, 0] != 0)
        {
            ganador = _tablero[0, 0];
        }
        else if (_tablero[0, 2] == _tablero[1, 1] && _tablero[0, 2] == _tablero[2, 0] && _tablero[0, 2] != 0)
        {
            ganador = _tablero[0, 2];
        }

        return ganador != 0;
    }

    private bool HayEmpate()
    {
        bool empate = true;

        for (int i = 0; i < 3; i++)
        {
            if (_tablero[i, 0] == 0 || _tablero[i, 1] == 0 || _tablero[i, 2] == 0)
            {
                empate = false;
            }
        }

        return empate;
    }

    private void LlenarCasillaYCambiarTurno(int fila, int columna, short valorCasilla)
    {
        _posicion.Mover(_posicion.Fila, _posicion.Columna);

        if (_tablero[fila, columna] == 0)
        {
            if (valorCasilla == 0)
            {
                Console.WriteLine(" ");
            }
            else
            {
                _tablero[fila, columna] = valorCasilla;
                DibujarJugada(valorCasilla);

                _turno = Convert.ToInt16(valorCasilla == 1 ? 2 : 1);
                DibujarTurno(_turno);
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
