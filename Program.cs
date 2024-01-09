using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Ping
{
    internal class Program
    {
        static int ponstosl = 0;
        static int pontosr = 0;
        static int paddle1Y = 10;
        static int paddle2Y = 10;
        static int ballX = 20;
        static int ballY = 10;
        static int ballSpeedX = -1;
        static int ballSpeedY = 1;

        static void Main(string[] args)
        {
            



            Console.WindowHeight = 25;
            Console.WindowWidth = 80;
            Console.BufferHeight = 25;
            Console.BufferWidth = 80;


            while (true)
            {
                Draw();
                Input();
                Logic();
                Thread.Sleep(50);
            }
        }

        static void Draw()
        {
            Console.Clear();

            for (int i = 0; i < 7 ; i++)
            {
                Console.SetCursorPosition(0, paddle1Y + i);
                Console.Write("|");

                Console.SetCursorPosition(78, paddle2Y + i);
                Console.Write("|");
            }

            Console.SetCursorPosition(0, paddle1Y);
            Console.Write("|");

            Console.SetCursorPosition(78, paddle2Y);
            Console.Write("|");

            Console.SetCursorPosition(ballX, ballY);
            Console.Write("O");
        }

        static void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && paddle2Y > 0)
                {
                    paddle2Y = Math.Max(paddle2Y - 3, 0);
                }
                if (key.Key == ConsoleKey.DownArrow && paddle2Y < Console.WindowHeight - 7)
                {
                    paddle2Y = Math.Min(paddle2Y + 3, Console.WindowHeight - 7);
                }
                if (key.Key == ConsoleKey.W && paddle1Y > 0)
                {
                    paddle1Y = Math.Max(paddle1Y - 3, 0);
                }
                if (key.Key == ConsoleKey.S && paddle1Y < Console.WindowHeight - 7)
                {
                    paddle1Y = Math.Min(paddle1Y + 3, Console.WindowHeight - 7);
                }
            }
        }

        static void Logic()
        {
            ;
            ballX += ballSpeedX;
            ballY += ballSpeedY;

            if (ballX > Console.WindowWidth - 1)
            {
                ponstosl++;

            }
            if (ballX < 0)
            {
                pontosr++;

            }

            // Ball collision with paddles
            if ((ballX == 1 && ballY >= paddle1Y && ballY <= paddle1Y + 6) ||
                (ballX == 78 && ballY >= paddle2Y && ballY <= paddle2Y + 6))
            {
                ballSpeedX = -ballSpeedX;
            }

            // Ball collision with top and bottom
            if (ballY == 0 || ballY == Console.WindowHeight - 1)
            {
                ballSpeedY = -ballSpeedY;
            }

            // Ball out of bounds
            if (ballX < 0 || ballX > Console.WindowWidth - 1)
            {
                // Reset ball position
                ballX = Console.WindowWidth / 2;
                ballY = Console.WindowHeight / 2;


                Console.Clear();


              

                Console.WriteLine("Game OVER");
                Console.WriteLine($"PLACAR: {ponstosl} {pontosr}");

                Thread.Sleep(1000);

                ballSpeedX = - ballSpeedX;
            }
        }
    }
}
