using System.IO;
using static System.Console;

namespace student_roulette
{
    //Agregar un cronometro que pueda ser elegido, por ejemplo podemos preguntar iniciando el programa si deseamos usar solamente el cronometro, tambien despues de haber elegido los estudiantes preguntar si se quiere ahi mismo cronometrar el desafio.
    // Agregar un reloj, para ver la hora actual en el programa, que se pueda elegir si mostrar o no.
    internal class Program
    {
        static string rolPath = AppDomain.CurrentDomain.BaseDirectory + "/rols.txt";
        static string studentsPath = AppDomain.CurrentDomain.BaseDirectory + "/students.txt"; 
        static string historyPath = AppDomain.CurrentDomain.BaseDirectory + "/history.csv";
        static string[] completionMenuOptions =
        {
            "Reiniciar Ruleta", "Salir del Programa"
        };

        static string[] initialMenuOptions =
        {
            "Iniciar Programa (Elegir Estudiantes)", "Estudiantes", "Roles", "Salir del Programa"
        };

        static string[] studentsOptions =
        {
            "Ver todos los estudiantes", "Ingresar nuevo Estudiante", "Modificar Estudiante", "Eliminar Estudiante", "Volver al menú"
        };

        static string[] rolsOptions =
        {
            "Ver todos los Roles", "Ingresar nuevo Rol", "Modificar Rol", "Eliminar Rol", "Volver al menú"
        };

        static List<string> students = GetList(studentsPath);
        static List<string> rols = GetList(rolPath);
        static List<int> repeatedNumbers = new();
        static bool exit = false, withAnimation = true;
        static int firstStudent, secondStudent;

        static void Main(string[] args)
        {
            CursorVisible = false;
            while (!exit)
            {
                Clear();
                InitialMenu();
                ReadKey(true);
                //if (!Login()) continue;
            }
        }

        static void GetStudents()
        {
            Clear();
            if (repeatedNumbers.Count == students.Count)
            {
                WriteLine("Ya han participado todos los estudiantes reiniciando ruleta...");
                //Write("Enter para continuar...");
                repeatedNumbers.Clear();
                CompleteMenu();
                //LoadingAnimation("\r\n ██▀███  ▓█████  ██▓ ███▄    █  ██▓ ▄████▄   ██▓ ▄▄▄       ███▄    █ ▓█████▄  ▒█████  \r\n▓██ ▒ ██▒▓█   ▀ ▓██▒ ██ ▀█   █ ▓██▒▒██▀ ▀█  ▓██▒▒████▄     ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒\r\n▓██ ░▄█ ▒▒███   ▒██▒▓██  ▀█ ██▒▒██▒▒▓█    ▄ ▒██▒▒██  ▀█▄  ▓██  ▀█ ██▒░██   █▌▒██░  ██▒\r\n▒██▀▀█▄  ▒▓█  ▄ ░██░▓██▒  ▐▌██▒░██░▒▓▓▄ ▄██▒░██░░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░\r\n░██▓ ▒██▒░▒████▒░██░▒██░   ▓██░░██░▒ ▓███▀ ░░██░ ▓█   ▓██▒▒██░   ▓██░░▒████▓ ░ ████▓▒░\r\n░ ▒▓ ░▒▓░░░ ▒░ ░░▓  ░ ▒░   ▒ ▒ ░▓  ░ ░▒ ▒  ░░▓   ▒▒   ▓▒█░░ ▒░   ▒ ▒  ▒▒▓  ▒ ░ ▒░▒░▒░ \r\n  ░▒ ░ ▒░ ░ ░  ░ ▒ ░░ ░░   ░ ▒░ ▒ ░  ░  ▒    ▒ ░  ▒   ▒▒ ░░ ░░   ░ ▒░ ░ ▒  ▒   ░ ▒ ▒░ \r\n  ░░   ░    ░    ▒ ░   ░   ░ ░  ▒ ░░         ▒ ░  ░   ▒      ░   ░ ░  ░ ░  ░ ░ ░ ░ ▒  \r\n   ░        ░  ░ ░           ░  ░  ░ ░       ░        ░  ░         ░    ░        ░ ░  \r\n                                   ░                                  ░               \r\n", withAnimation);
                Clear();
            }

            Random randomStudent = new();
            //LoadingAnimation("\r\n  ▄████ ▓█████  ███▄    █ ▓█████  ██▀███   ▄▄▄       ███▄    █ ▓█████▄  ▒█████  \r\n ██▒ ▀█▒▓█   ▀  ██ ▀█   █ ▓█   ▀ ▓██ ▒ ██▒▒████▄     ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒\r\n▒██░▄▄▄░▒███   ▓██  ▀█ ██▒▒███   ▓██ ░▄█ ▒▒██  ▀█▄  ▓██  ▀█ ██▒░██   █▌▒██░  ██▒\r\n░▓█  ██▓▒▓█  ▄ ▓██▒  ▐▌██▒▒▓█  ▄ ▒██▀▀█▄  ░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░\r\n░▒▓███▀▒░▒████▒▒██░   ▓██░░▒████▒░██▓ ▒██▒ ▓█   ▓██▒▒██░   ▓██░░▒████▓ ░ ████▓▒░\r\n ░▒   ▒ ░░ ▒░ ░░ ▒░   ▒ ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ▒░   ▒ ▒  ▒▒▓  ▒ ░ ▒░▒░▒░ \r\n  ░   ░  ░ ░  ░░ ░░   ░ ▒░ ░ ░  ░  ░▒ ░ ▒░  ▒   ▒▒ ░░ ░░   ░ ▒░ ░ ▒  ▒   ░ ▒ ▒░ \r\n░ ░   ░    ░      ░   ░ ░    ░     ░░   ░   ░   ▒      ░   ░ ░  ░ ░  ░ ░ ░ ░ ▒  \r\n      ░    ░  ░         ░    ░  ░   ░           ░  ░         ░    ░        ░ ░  \r\n                                                                ░               \r\n", withAnimation);

            while (true)
            {
                firstStudent = randomStudent.Next(0, students.Count);
                secondStudent = randomStudent.Next(0, students.Count);

                if (firstStudent != secondStudent)
                {
                    if (repeatedNumbers.Contains(firstStudent) || repeatedNumbers.Contains(secondStudent)) continue;

                    break;
                }
            }

            repeatedNumbers.Add(firstStudent);
            repeatedNumbers.Add(secondStudent);
        }

        static void InitialMenu()
        {
            while (true)
            {
                Clear();
                int selectedOption = Menu(initialMenuOptions);

                switch (selectedOption)
                {
                    case 0:
                        GetStudents();
                        break;
                    case 1:
                        OperationsMenu(studentsPath, studentsOptions, students);
                        break;
                    case 2:
                        OperationsMenu(rolPath, rolsOptions, rols);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void OperationsMenu(string path, string[] options, List<string> data)
        {
            while (true)
            {
                data = GetList(path);
                int selectedOption = Menu(options);
                Clear();

                switch (selectedOption)
                {
                    case 0:
                        ShowAll(path);
                        break;
                    case 1:
                        Add(path, "Por favor ingrese el nombre el estudiante");
                        break;
                    case 2:
                        Edit(path);
                        break;
                    case 3:
                        Delete(path, data);
                        break;
                    case 4:
                        return;
                }
            }
        }

        static void CompleteMenu()
        {
            int selectedOption = Menu(completionMenuOptions);

            switch (selectedOption)
            {
                case 0:
                    return;
                case 1:
                    Environment.Exit(0);
                    break;
            }

            //while (loop)
            //{
            //    while ((key = ReadKey(true)).Key != ConsoleKey.Enter)
            //    {
            //        switch (key.Key)
            //        {
            //            case ConsoleKey.DownArrow:
            //            case ConsoleKey.S:
            //                if (selectedOption == completionMenuOptions.Length - 1) continue;
            //                selectedOption++;
            //                break;
            //            case ConsoleKey.UpArrow:
            //            case ConsoleKey.W:
            //                if (selectedOption == 0) continue;
            //                selectedOption--;
            //                break;
            //        }

            //        DrawMenu(completionMenuOptions, selectedOption);
            //    }

            //    loop = false;

            //    switch (selectedOption)
            //    {
            //        case 0:
            //            return;
            //        case 1:
            //            Environment.Exit(0);
            //            break;
            //    }
            //}
        }

        static int Menu(string[] options)
        {
            int selectedOption = 0;
            ConsoleKeyInfo key;

            DrawMenu(options, selectedOption);
            while ((key = ReadKey(true)).Key != ConsoleKey.Enter)
            {
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (selectedOption == options.Length - 1) continue;
                        selectedOption++;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (selectedOption == 0) continue;
                        selectedOption--;
                        break;
                }

                DrawMenu(options, selectedOption);
            }

            return selectedOption;
        }

        static bool DeleteConfirmMenu()
        {
            bool confirm = false;
            ConsoleKeyInfo key;
            int x, y;
            string yes = "Si", no = "No";
            Clear();
            ResetColor();
            WriteLine("¿Esta seguro que desea eliminar a este estudiante?");
            SetCursorPosition(CursorLeft + 10, CursorTop + 1);
            Write(yes);
            SetCursorPosition(CursorLeft + 25, CursorTop);
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;
            Write(no);

            x = 38; // yes esta en la posición 11, y no esta en la posición 38
            y = CursorTop; // 3

            while ((key = ReadKey(true)).Key != ConsoleKey.Enter)
            {
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (CursorLeft == 39) continue;
                        ResetColor();
                        SetCursorPosition(10, CursorTop);
                        Write(yes);
                        SetCursorPosition(37, CursorTop);
                        BackgroundColor = ConsoleColor.White;
                        ForegroundColor = ConsoleColor.Black;
                        Write(no);
                        confirm = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (CursorLeft == 13) continue;
                        ResetColor();
                        SetCursorPosition(37, CursorTop);
                        Write(no);
                        SetCursorPosition(10, CursorTop);
                        BackgroundColor = ConsoleColor.White;
                        ForegroundColor = ConsoleColor.Black;
                        Write(yes);
                        confirm = true;
                        break;
                }
            }

            ResetColor();
            return confirm;
        }

        static string DrawMenu(string[] options, int optionResult)
        {
            string currentSelection = "";
            int destacado = 0;

            Clear();
            WriteLine("¿Desea continuar?\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (destacado == optionResult)
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    BackgroundColor = ConsoleColor.White;
                    WriteLine($"<< {options[i]} >>");

                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                    currentSelection = options[i];
                }
                else
                {
                    Write(new string(' ', WindowWidth));
                    CursorLeft = 0;
                    WriteLine($"<< {options[i]} >>");
                }
                destacado++;
            }

            //Array.ForEach(options, element =>
            //{
            //    if (destacado == optionResult)
            //    {
            //        ForegroundColor = ConsoleColor.DarkBlue;
            //        BackgroundColor = ConsoleColor.White;
            //        WriteLine($"<< {element} >>");

            //        ForegroundColor = ConsoleColor.White;
            //        BackgroundColor = ConsoleColor.Black;
            //        currentSelection = element;
            //    }
            //    else
            //    {
            //        Write(new string(' ', WindowWidth));
            //        CursorLeft = 0;
            //        WriteLine(element);
            //    }
            //    destacado++;
            //});

            return currentSelection;
        }

        static void DrawResult(int liveDeveloper, int facilitator)
        {
            string first = CenterName(students[liveDeveloper], 23), second = CenterName(students[facilitator], 25);
            WriteLine("╔═══════════════════════╦═════════════════════════╗");
            WriteLine($"║ {rols[0]} ║ {rols[1]} ║");
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
        static bool Login()
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

        static void DrawLogin()
        {
            WriteLine("╔══════════╦══════════╗");
            WriteLine("║  Login   ║          ║");
            WriteLine("╠══════════╬══════════╣");
            WriteLine("║ Password ║          ║");
            Write("╚══════════╩══════════╝");
        }

        static string HidePassword()
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

        static void LoadingAnimation(string prompt, bool withAnimation)
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

        #region Operations functions
        static List<string> GetList(string path)
        {
            List<string> result = new List<string>();
            using (var fs = new FileStream(path, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine()!);
                }

            return result;
        }

        static void ShowAll(string path)
        {
            while (true)
            {
                using (var fs = new FileStream(path, FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                    while (!sr.EndOfStream)
                    {
                        WriteLine($"{sr.ReadLine()}");
                    }


                WriteLine("\n\nPresione ESC para volver atras");
                if (ReadKey(true).Key == ConsoleKey.Escape) return;
                Clear();
            }
        }

        static void Add(string path, string prompt)
        {
            string student = ValidateText(prompt);

            using FileStream fs = new FileStream(path, FileMode.Append);
            using StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(student.Trim());
        }

        static void Edit(string path)
        {
            int student;
            string[] newStudents = students.ToArray();
            string editName = string.Empty;
            ConsoleKeyInfo key;

            while (true)
            {
                student = Menu(newStudents);
                editName = ValidateText($"Estudiante a Editar \"{students[student]}\"\nIngrese el nombre editado del estudiante");

                if (editName.Length == 0) continue;
                while (true)
                {
                    WriteLine("Presione Enter para confirmar, Esc volver a elegir estudiantes y R para salir al menu Estudiantes...");
                    key = ReadKey(true);
                    if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.R) break;
                    Clear();
                }

                if (key.Key == ConsoleKey.Enter) break;
                else if (key.Key == ConsoleKey.Escape) continue;
                else if (key.Key == ConsoleKey.R) return;
            }

            students[student] = editName;

            using FileStream fs = new FileStream(path, FileMode.Create);
            using StreamWriter writer = new StreamWriter(fs);
            {
                for (int i = 0; i < students.Count; i++)
                {
                    writer.WriteLine(students[i]);
                }
            }

        }

        static void Delete(string path, List<string> data)
        {
            string[] studentOptions = data.ToArray();
            int optionSelected = Menu(studentOptions);
            if (DeleteConfirmMenu())
            {
                using FileStream fs = new FileStream(path, FileMode.Create);
                using StreamWriter writer = new StreamWriter(fs);
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (i == optionSelected) continue;
                        writer.WriteLine(data[i]);
                    }
                }
            }
        }

        static string[] GetDefaultRols(string path)
        {
            string[] result = new string[2];
            int count = 0;

            using (var fs = new FileStream(path, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine()!;
                    if(line.Contains("default"))
                    {
                        result[count] = line;
                        count++;
                    }
                }


            return [];
        }
        #endregion

        static string ValidateText(string prompt)
        {
            Clear();
            string student = string.Empty;
            CursorVisible = true;
            while (true)
            {
                Write($"{prompt}: ");
                student = ReadLine()!;
                if (!string.IsNullOrWhiteSpace(student)) break;


                WriteLine("No se debe dejar el nombre vacio o ingresar solamente espacios");
                Write("Presione una tecla Para intentar otra vez, ESCAPE para salir...");

                if ((ReadKey(true).Key) == ConsoleKey.Escape) return "";
                Clear();
            }

            CursorVisible = false;

            return student;
        }
    }
}