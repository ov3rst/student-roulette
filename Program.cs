using static System.Console;

namespace student_roulette
{
    //Agregar un cronometro que pueda ser elegido, por ejemplo podemos preguntar iniciando el programa si deseamos usar solamente el cronometro, tambien despues de haber elegido los estudiantes preguntar si se quiere ahi mismo cronometrar el desafio.
    // Agregar un reloj, para ver la hora actual en el programa, que se pueda elegir si mostrar o no.
    internal class Program
    {
        private static string[] completionMenuOptions = {
            "Reiniciar Ruleta", "Salir del Programa"
        };

        private static string[] students = {
        "Juan Arias", "Pedro Diaz", "Maria Cuevas", "Oliver Tejeda", "Julio Perez","Juanita Contreras", "Wilfredo Carvajal", "Rafael Montas", "Camila Sierra", "Ernesto Lopez", "Francisco Gomez", "Manuel Almonte", "John Smith", "Yonatan Aquino","Jose Soto", "Orison Guerrero"
        };

        //private static int x, y;
        private static List<int> repeatedNumbers = new();
        private static bool exit = false, withAnimation = true;
        private static int firstStudent, secondStudent;

        static void Main(string[] args)
        {
            CursorVisible = false;
            while (!exit)
            {
                Clear();
                //if (!Login()) continue;
                GetStudents();
                DrawResult(firstStudent, secondStudent);
                ReadKey(true);
            }
        }

        static void GetStudents()
        {
            Clear();
            if (repeatedNumbers.Count == students.Length)
            {
                WriteLine("Ya han participado todos los estudiantes reiniciando ruleta...");
                //Write("Enter para continuar...");
                repeatedNumbers.Clear();
                CompleteMenu();
                LoadingAnimation("\r\n ██▀███  ▓█████  ██▓ ███▄    █  ██▓ ▄████▄   ██▓ ▄▄▄       ███▄    █ ▓█████▄  ▒█████  \r\n▓██ ▒ ██▒▓█   ▀ ▓██▒ ██ ▀█   █ ▓██▒▒██▀ ▀█  ▓██▒▒████▄     ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒\r\n▓██ ░▄█ ▒▒███   ▒██▒▓██  ▀█ ██▒▒██▒▒▓█    ▄ ▒██▒▒██  ▀█▄  ▓██  ▀█ ██▒░██   █▌▒██░  ██▒\r\n▒██▀▀█▄  ▒▓█  ▄ ░██░▓██▒  ▐▌██▒░██░▒▓▓▄ ▄██▒░██░░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░\r\n░██▓ ▒██▒░▒████▒░██░▒██░   ▓██░░██░▒ ▓███▀ ░░██░ ▓█   ▓██▒▒██░   ▓██░░▒████▓ ░ ████▓▒░\r\n░ ▒▓ ░▒▓░░░ ▒░ ░░▓  ░ ▒░   ▒ ▒ ░▓  ░ ░▒ ▒  ░░▓   ▒▒   ▓▒█░░ ▒░   ▒ ▒  ▒▒▓  ▒ ░ ▒░▒░▒░ \r\n  ░▒ ░ ▒░ ░ ░  ░ ▒ ░░ ░░   ░ ▒░ ▒ ░  ░  ▒    ▒ ░  ▒   ▒▒ ░░ ░░   ░ ▒░ ░ ▒  ▒   ░ ▒ ▒░ \r\n  ░░   ░    ░    ▒ ░   ░   ░ ░  ▒ ░░         ▒ ░  ░   ▒      ░   ░ ░  ░ ░  ░ ░ ░ ░ ▒  \r\n   ░        ░  ░ ░           ░  ░  ░ ░       ░        ░  ░         ░    ░        ░ ░  \r\n                                   ░                                  ░               \r\n", withAnimation);
                Clear();
            }

            Random randomStudent = new();
            LoadingAnimation("\r\n  ▄████ ▓█████  ███▄    █ ▓█████  ██▀███   ▄▄▄       ███▄    █ ▓█████▄  ▒█████  \r\n ██▒ ▀█▒▓█   ▀  ██ ▀█   █ ▓█   ▀ ▓██ ▒ ██▒▒████▄     ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒\r\n▒██░▄▄▄░▒███   ▓██  ▀█ ██▒▒███   ▓██ ░▄█ ▒▒██  ▀█▄  ▓██  ▀█ ██▒░██   █▌▒██░  ██▒\r\n░▓█  ██▓▒▓█  ▄ ▓██▒  ▐▌██▒▒▓█  ▄ ▒██▀▀█▄  ░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░\r\n░▒▓███▀▒░▒████▒▒██░   ▓██░░▒████▒░██▓ ▒██▒ ▓█   ▓██▒▒██░   ▓██░░▒████▓ ░ ████▓▒░\r\n ░▒   ▒ ░░ ▒░ ░░ ▒░   ▒ ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ▒░   ▒ ▒  ▒▒▓  ▒ ░ ▒░▒░▒░ \r\n  ░   ░  ░ ░  ░░ ░░   ░ ▒░ ░ ░  ░  ░▒ ░ ▒░  ▒   ▒▒ ░░ ░░   ░ ▒░ ░ ▒  ▒   ░ ▒ ▒░ \r\n░ ░   ░    ░      ░   ░ ░    ░     ░░   ░   ░   ▒      ░   ░ ░  ░ ░  ░ ░ ░ ░ ▒  \r\n      ░    ░  ░         ░    ░  ░   ░           ░  ░         ░    ░        ░ ░  \r\n                                                                ░               \r\n", withAnimation);

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

        //Hay que abstraer la funcionalidad de elegir opcion en el menu para poder utilizarla en mas sitios.(Por ejemplo para elegir si queremos o no animaciones).
        static void CompleteMenu()
        {
            bool loop = true;
            int selectedOption = 0;
            ConsoleKeyInfo key;

            CursorVisible = false;

            DrawMenu(completionMenuOptions, selectedOption);

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

                    DrawMenu(completionMenuOptions, selectedOption);
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

        private static string DrawMenu(string[] options, int optionResult)
        {
            string currentSelection = "";
            int destacado = 0;

            Clear();
            WriteLine("¿Desea continuar?\n");
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

        //Esta funcion lo que hace es centrar el nombre en el recuadro hecho añadiendo los espacios necesarios para que quede bien centrado.
        static string CenterName(string name, int space)
        {
            int whiteSpaces = space - name.Length, nameLenght = name.Length;
            string spaces = "";

            for (int i = 0; i <= whiteSpaces; i++)
            {
                if (spaces.Length == whiteSpaces / 2 && name.Length == nameLenght)
                {
                    name = name.Insert(0, spaces);
                    spaces = "";
                }
                else if (i == whiteSpaces)
                {
                    name = name.Insert(name.Length, spaces);
                }
                spaces += " ";
            }

            return name;
        }

        //Falta validar si el usuario deja el campo vacio y tambien que no se pase de la logitud permitida.
        private static bool Login()
        {
            string userName = string.Empty, password = string.Empty;
            LoadingAnimation("\r\n ▄▄▄▄    ██▓▓█████  ███▄    █ ██▒   █▓▓█████  ███▄    █  ██▓▓█████▄  ▒█████  \r\n▓█████▄ ▓██▒▓█   ▀  ██ ▀█   █▓██░   █▒▓█   ▀  ██ ▀█   █ ▓██▒▒██▀ ██▌▒██▒  ██▒\r\n▒██▒ ▄██▒██▒▒███   ▓██  ▀█ ██▒▓██  █▒░▒███   ▓██  ▀█ ██▒▒██▒░██   █▌▒██░  ██▒\r\n▒██░█▀  ░██░▒▓█  ▄ ▓██▒  ▐▌██▒ ▒██ █░░▒▓█  ▄ ▓██▒  ▐▌██▒░██░░▓█▄   ▌▒██   ██░\r\n░▓█  ▀█▓░██░░▒████▒▒██░   ▓██░  ▒▀█░  ░▒████▒▒██░   ▓██░░██░░▒████▓ ░ ████▓▒░\r\n░▒▓███▀▒░▓  ░░ ▒░ ░░ ▒░   ▒ ▒   ░ ▐░  ░░ ▒░ ░░ ▒░   ▒ ▒ ░▓   ▒▒▓  ▒ ░ ▒░▒░▒░ \r\n▒░▒   ░  ▒ ░ ░ ░  ░░ ░░   ░ ▒░  ░ ░░   ░ ░  ░░ ░░   ░ ▒░ ▒ ░ ░ ▒  ▒   ░ ▒ ▒░ \r\n ░    ░  ▒ ░   ░      ░   ░ ░     ░░     ░      ░   ░ ░  ▒ ░ ░ ░  ░ ░ ░ ░ ▒  \r\n ░       ░     ░  ░         ░      ░     ░  ░         ░  ░     ░        ░ ░  \r\n      ░                           ░                          ░               \r\n", withAnimation);

            CursorVisible = true;
            DrawLogin();
            CursorTop = 1;
            CursorLeft = 13;
            userName = ReadLine()!.ToLower();

            CursorTop = 3;
            CursorLeft = 13;
            password = HidePassword();
            CursorVisible = true;
            return userName == "ov3rst" && password == "123456";
        }

        private static void DrawLogin()
        {
            WriteLine("╔══════════╦══════════╗");
            WriteLine("║  Login   ║          ║");
            WriteLine("╠══════════╬══════════╣");
            WriteLine("║ Password ║          ║");
            Write("╚══════════╩══════════╝");
        }

        private static string HidePassword()
        {
            string password = string.Empty;
            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;

                password += Convert.ToString(key.KeyChar);
                Write("*");
            }

            return password;
        }

        private static void LoadingAnimation(string prompt, bool withAnimation)
        {
            const byte time = 50;
            Clear();
            if (withAnimation)
            {
                Write(prompt);
                SetCursorPosition(10, 15);
                ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < time; i++)
                {
                    Write("█");
                }

                SetCursorPosition(10, 15);
                ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < time; i++)
                {
                    Write("█");
                    Thread.Sleep(50);
                }

                Clear();
                ResetColor();
            }
        }
    }
}