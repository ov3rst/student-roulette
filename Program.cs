using static System.Console;

namespace student_roulette
{
    internal class Program
    {
        private static string[] completionMenuOptions = {
            "Reiniciar Ruleta", "Salir del Programa"
        };
        private static int x, y;


        private static string[] students = {
        "Juan Arias", "Pedro Diaz", "Maria Cuevas", "Oliver Tejeda", "Julio Perez","Juanita Contreras", "Wilfredo Carvajal", "Rafael Montas", "Camila Sierra", "Ernesto Lopez", "Francisco Gomez", "Manuel Almonte", "John Smith", "Yonatan Aquino","Jose Soto", "Orison Guerrero"
        };

        private static List<int> repeatedNumbers = new();
        private static bool exit = false;

        private static int firstStudent, secondStudent;
        static void Main(string[] args)
        {
            while (!exit)
            {
                //WriteLine("Roulette");
                //getStudents();
                DrawResult(5, 12);
                ReadKey(true);
            }
        }

        static void getStudents()
        {
            if (repeatedNumbers.Count() == students.Length)
            {
                WriteLine("Ya han participado todos los estudiantes reiniciando ruleta...");
                //Write("Enter para continuar...");
                repeatedNumbers.Clear();
                CompleteMenu();
            }

            Random randomStudent = new();

            while (true)
            {
                firstStudent = randomStudent.Next(0, students.Length);
                secondStudent = randomStudent.Next(0, students.Length);

                if (firstStudent != secondStudent)
                {
                    if (repeatedNumbers.Contains(firstStudent) || repeatedNumbers.Contains(secondStudent)) continue;

                    break;
                }
            }

            repeatedNumbers.Add(firstStudent);
            repeatedNumbers.Add(secondStudent);
        }

        static void CompleteMenu()
        {
            bool loop = true;
            int selectedOption = 0;
            ConsoleKeyInfo key;

            CursorVisible = false;

            WriteLine("¿Desea continuar?");

            x = CursorLeft;
            y = CursorTop;

            Menu(completionMenuOptions, selectedOption);

            while (loop)
            {
                while ((key = ReadKey(true)).Key != ConsoleKey.Enter)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            if (selectedOption == completionMenuOptions.Length - 1) continue;
                            selectedOption++;
                            break;
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            if (selectedOption == 0) continue;
                            selectedOption--;
                            break;
                    }
                    CursorLeft = x;
                    CursorTop = y;
                    Menu(completionMenuOptions, selectedOption);
                }

                loop = false;

                switch (selectedOption)
                {
                    case 0:
                        return;
                    case 1:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static string Menu(string[] options, int optionResult)
        {
            string currentSelection = "";
            int destacado = 0;

            Clear();
            Array.ForEach(options, element =>
            {
                if (destacado == optionResult)
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    BackgroundColor = ConsoleColor.White;
                    WriteLine($"<< {element} >>");

                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                    currentSelection = element;
                }
                else
                {
                    Write(new string(' ', WindowWidth));
                    CursorLeft = 0;
                    WriteLine(element);
                }
                destacado++;
            });

            return currentSelection;
        }

        static void DrawResult(int liveDeveloper, int facilitator)
        {
            string first = CenterName(students[liveDeveloper], 23), second = CenterName(students[facilitator], 25);
            WriteLine("╔═══════════════════════╦═════════════════════════╗");
            WriteLine("║ Desarrollador en vivo ║ Facilitador de ejecicio ║");
            WriteLine("╠═══════════════════════╬═════════════════════════╣");
            WriteLine($"║{first}║{second}║");
            Write("╚═══════════════════════╩═════════════════════════╝");
        }

        //Esta funcion lo que hace es centrarme el nombre en el recuadro hecho añadiendo los espacios necesarios para que quede centrado.
        //Hay que arreglar el cuando el total de caracteres de un nombre no es par (quitando obviamente el espacio entre apellidos). queda eso pendiente en esta funcion.
        static string CenterName(string name, int space)
        {
            int whiteSpaces = space - name.Length;
            string spaces = "";

            for (int i = 0; i < whiteSpaces; i++)
            {
                if (spaces.Length == whiteSpaces / 2)
                {
                    name = name.Insert(0, spaces);
                    name = name.Insert(name.Length, spaces);
                    break;
                }
                spaces += " ";
            }

            return name;
        }
    }
}