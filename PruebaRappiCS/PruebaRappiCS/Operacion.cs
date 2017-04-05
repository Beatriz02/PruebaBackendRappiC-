using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaRappiCS
{
    public class Operacion
    {
        private int[,] matriz;

        private void iniciarJuego()
        {
            matriz = new int[4, 4];
            Random _ran = new Random();
            for (int f = 0; f < 4; f++)
            {
                for (int c = 0; c < 4; c++)
                {
                    int i = _ran.Next(0, 2);
                    int a = i * 2;
                    matriz[f, c] = a;
                }
            }
            Console.Write("\n-----Bienvenido al juego 2048-----\n");
            Imprimir();
        }



        private void Imprimir()
        {
            for (int f = 0; f < 4; f++)
            {
                for (int c = 0; c < 4; c++)
                {
                    Console.Write("| " + matriz[f, c] + " ");
                }
                Console.WriteLine();
            }            
        }



        private void izquierda()
        {
            for (int f = 0; f < 4; f++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (c < 3)
                    {
                        if (matriz[f, c] == 2048)
                        {
                        }
                        else
                        {
                            if (matriz[f, c] == matriz[f, c + 1])
                            {
                                matriz[f, c] = matriz[f, c] + matriz[f, c + 1];
                                matriz[f, c + 1] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void acomodoIzquierda()
        {
            for (int f = 0; f < 4; f++)
            {
                for (int c = 3; c > 0; c--)
                {
                    if (c > 0)
                    {
                        if (matriz[f, c] > 0 && matriz[f, c - 1] == 0)
                        {
                            matriz[f, c - 1] = matriz[f, c];
                            matriz[f, c] = 0;
                            c = 4;
                        }
                    }

                }
            }
        }

        private void derecha()
        {
            for (int f = 0; f < 4; f++)
            {
                for (int c = 3; c > 0; c--)
                {
                    if (c > 0)
                    {
                        if (matriz[f, c] == 2048)
                        {
                        }
                        else
                        {
                            if (matriz[f, c] == matriz[f, c - 1])
                            {
                                matriz[f, c] = matriz[f, c] + matriz[f, c - 1];
                                matriz[f, c - 1] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void acomodoDerecha()
        {
            for (int f = 0; f < 4; f++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (c < 3)
                    {
                        if (matriz[f, c] > 0 && matriz[f, c + 1] == 0)
                        {
                            matriz[f, c + 1] = matriz[f, c];
                            matriz[f, c] = 0;
                            c = -1;
                        }
                    }
                }
            }
        }

        private void arriba()
        {
            for (int f = 0; f < 4; f++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (f < 3)
                    {
                        if (matriz[f, c] == 2048)
                        {
                        }
                        else
                        {
                            if (matriz[f, c] == matriz[f + 1, c])
                            {
                                matriz[f, c] = matriz[f, c] + matriz[f + 1, c];
                                matriz[f + 1, c] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void acomodoArriba()
        {
            for (int f = 3; f >= 0; f--)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (f > 0)
                    {
                        if (matriz[f, c] > 0 && matriz[f - 1, c] == 0)
                        {
                            matriz[f - 1, c] = matriz[f, c];
                            matriz[f, c] = 0;
                            c = 4;
                            f = 4;
                        }
                    }
                }
            }
        }

        private void abajo()
        {
            for (int f = 3; f >= 0; f--)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (f > 0)
                    {
                        if (matriz[f, c] == 2048)
                        {
                        }
                        else
                        {
                            if (matriz[f, c] == matriz[f - 1, c])
                            {
                                matriz[f, c] = matriz[f, c] + matriz[f - 1, c];
                                matriz[f - 1, c] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void acomodoAbajo()
        {
            for (int f = 0; f < 4; f++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (f < 3)
                    {
                        if (matriz[f, c] > 0 && matriz[f + 1, c] == 0)
                        {
                            matriz[f + 1, c] = matriz[f, c];
                            matriz[f, c] = 0;
                            c = 4;
                            f = -1;
                        }
                    }
                }
            }
        }

        private int calcularMovimientos(int numero)
        {
            int res = (int)Math.Pow(10, 5);
            if (1 <= numero && numero <= res)
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        private void nuevaCasilla()
        {
            int encontrado = 0;
            for (int f = 0; f < 4; f++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (matriz[f, c] == 0)
                    {
                        matriz[f, c] = 2;
                        encontrado = 1;
                        c = 4;
                    }
                }
                if (encontrado == 1)
                {
                    break;
                }
            }
        }

        public void jugar()
        {
            try
            {
                this.iniciarJuego();
                int _movimientos;
                _movimientos = this.calcularMovimientos(this.validarNumero("Introduce el número de movimientos: "));
                for (int i = 0; i < _movimientos; i++)
                {
                    int _opcion;
                    _opcion = this.validarNumero("Elige un movimiento \n 1.- Izquierda " + "\n 2.- Derecha " + "\n 3.- Arriba " + "\n 4.- Abajo");
                    switch (_opcion)
                    {
                        case 1:
                            this.acomodoIzquierda();
                            this.izquierda();
                            this.acomodoIzquierda();
                            this.nuevaCasilla();
                            Console.Write("\n-----Izquierda-----\n");
                            this.Imprimir();
                            break;
                        case 2:
                            this.acomodoDerecha();
                            this.derecha();
                            this.acomodoDerecha();
                            this.nuevaCasilla();
                            Console.Write("\n-----Derecha-----\n");
                            this.Imprimir();
                            break;
                        case 3:
                            this.acomodoArriba();
                            this.arriba();
                            this.acomodoArriba();
                            this.nuevaCasilla();
                            Console.Write("\n-----Arriba-----\n");
                            this.Imprimir();
                            break;
                        case 4:
                            this.acomodoAbajo();
                            this.abajo();
                            this.acomodoAbajo();
                            this.nuevaCasilla();
                            Console.Write("\n-----Abajo-----\n");
                            this.Imprimir();
                            break;
                        default:
                            Console.Write("\n**Elige un movimiento valido**\n");
                            i = i - 1;
                            break;
                    }
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("\n Ocurrio un error " + _ex.Message);
                Console.WriteLine("\n Fin del Juego");
                Console.ReadKey();
            }
            Console.WriteLine("\n Tus movimientos terminaron");
            Console.WriteLine("\n Fin del Juego");
            Console.ReadKey();
        }

        public int validarNumero(string mensaje)
        {
            while (true)
            {
                try
                {
                    string _linea;
                    Console.Write("\n " + mensaje + " \n");
                    _linea = Console.ReadLine();
                    int num = int.Parse(_linea);
                    return num;
                }
                catch (Exception _ex)
                {
                    Console.Write("\nError: Ingresa solo numeros");
                }
            }            
        }
    }
}
