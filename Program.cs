using FordonsBesiktning.Data;
using FordonsBesiktning.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace FordonsBesiktning
{
    class Program
    {
        static FBContext Context = new FBContext();
        static void Main(string[] args)
        {
            bool notExit = true;

            while (notExit)
            {
                WriteLine();
                WriteLine(" ".PadRight(10) + "MENYVAL");
                WriteLine("\n" + " ".PadLeft(10) + "1. Ny reservation");
                WriteLine("\n" + " ".PadLeft(10) + "2. Lista reservationer");
                Write("\n" + " ".PadLeft(10) + "3. Avsluta");
                SetCursorPosition(10, 14);

                ConsoleKeyInfo keyPressed = ReadKey(true);

                Clear();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        AddReservation();
                        ReadKey(true);
                        Clear();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ListResrvations();
                        ReadKey(true);
                        Clear();
                        break;                    
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        notExit = false;
                        break;
                }
            }
        }

        private static void ListResrvations()
        {
            List<Reservation> resList = new List<Reservation>();
            resList = Context.Reservation.ToList();
            WriteLine("Reservationer");
            WriteLine();
            WriteLine("Fordon \t\t\t Datum");
            WriteLine("----------------------------------------------------");

            foreach (Reservation boka in resList)
            {
                WriteLine($"{boka.RegistrationNumber} \t\t\t {boka.Date}");              
            }           
        }

        private static void AddReservation()
        {
            bool nixExit = true;
          
            while (nixExit)
            {
                Write("\n" + " ".PadLeft(10) + "Registreringsnummer: ");
                string regNr = ReadLine().ToUpper();
                Write("\n" + " ".PadLeft(10) + "Datum(yyyy - MM - dd hh: mm): ");
                DateTime date = DateTime.Parse(ReadLine());
               
                WriteLine();
                Write("\n" + " ".PadLeft(10) + "Är detta korrekt? (J)a eller(N)ej: ");

                ConsoleKeyInfo answer = ReadKey(true);

                bool trueanswer = (answer.Key == ConsoleKey.J || answer.Key == ConsoleKey.N);

                if (trueanswer)
                {
                    switch (answer.Key)
                    {
                        case ConsoleKey.J:
                            Reservation reservation = new Reservation(regNr, date);
                            RegisterReservation(reservation);
                            nixExit = false;
                            break;
                        case ConsoleKey.N:
                            break;
                    }
                }
                else
                    nixExit = false;
            }
        }

        private static void RegisterReservation(Reservation reservation)
        {           
            Context.Reservation.Add(reservation);

            Context.SaveChanges();
        }
    }
}
