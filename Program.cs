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
        static string[] rolsSelected = { };
        static List<string> students = GetList(studentsPath);
        static List<string> rols = GetList(rolPath);
        static List<int> repeatedNumbers = new();
        static bool exit = false, withAnimation = true;
        static int firstStudent, secondStudent;
        static string[] completionMenuOptions =
        {
            "Elegir nuevos estudiantes", "Cambiar Rol al primer estudiante", "Cambiar Rol al segundo estudiante", "Salir del Programa"
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

        static void Main(string[] args)
        {
            CursorVisible = false;
            while (!exit)
            {
                Clear();
                GetStudents();
                ReadKey(true);
                //if (!Login()) continue;
            }
        }

        static void GetStudents()
        {
            bool play = true, newStudent = true;

            Clear();
            if (repeatedNumbers.Count + 1 == students.Count)
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

            while (play)
            {
                Clear();
                while (newStudent)
                {
                    firstStudent = randomStudent.Next(0, students.Count);
                    secondStudent = randomStudent.Next(0, students.Count);

                    if (firstStudent != secondStudent)
                    {
                        if (repeatedNumbers.Contains(firstStudent) || repeatedNumbers.Contains(secondStudent)) continue;

                        break;
                    }
                }

                if (rolsSelected.Length == 0)
                    rolsSelected = GetOrChangeRols(rols);

                //DrawResult(firstStudent, secondStudent, rolsSelected);
                newStudent = CompleteMenu();
            }

            repeatedNumbers.Add(firstStudent);
            repeatedNumbers.Add(secondStudent);
        }

        static void InitialMenu()
        {
            while (true)
            {
                Clear();
                int selectedOption = Menu(initialMenuOptions, "\r\n ▄▄▄▄    ██▓▓█████  ███▄    █ ██▒   █▓▓█████  ███▄    █  ██▓▓█████▄  ▒█████  \r\n▓█████▄ ▓██▒▓█   ▀  ██ ▀█   █▓██░   █▒▓█   ▀  ██ ▀█   █ ▓██▒▒██▀ ██▌▒██▒  ██▒\r\n▒██▒ ▄██▒██▒▒███   ▓██  ▀█ ██▒▓██  █▒░▒███   ▓██  ▀█ ██▒▒██▒░██   █▌▒██░  ██▒\r\n▒██░█▀  ░██░▒▓█  ▄ ▓██▒  ▐▌██▒ ▒██ █░░▒▓█  ▄ ▓██▒  ▐▌██▒░██░░▓█▄   ▌▒██   ██░\r\n░▓█  ▀█▓░██░░▒████▒▒██░   ▓██░  ▒▀█░  ░▒████▒▒██░   ▓██░░██░░▒████▓ ░ ████▓▒░\r\n░▒▓███▀▒░▓  ░░ ▒░ ░░ ▒░   ▒ ▒   ░ ▐░  ░░ ▒░ ░░ ▒░   ▒ ▒ ░▓   ▒▒▓  ▒ ░ ▒░▒░▒░ \r\n▒░▒   ░  ▒ ░ ░ ░  ░░ ░░   ░ ▒░  ░ ░░   ░ ░  ░░ ░░   ░ ▒░ ▒ ░ ░ ▒  ▒   ░ ▒ ▒░ \r\n ░    ░  ▒ ░   ░      ░   ░ ░     ░░     ░      ░   ░ ░  ▒ ░ ░ ░  ░ ░ ░ ░ ▒  \r\n ░       ░     ░  ░         ░      ░     ░  ░         ░  ░     ░        ░ ░  \r\n      ░                           ░                          ░               \r\n");

                switch (selectedOption)
                {
                    case 0:
                        GetStudents();
                        break;
                    case 1:
                        OperationsMenu(studentsPath, studentsOptions, students, "Estudiante");
                        break;
                    case 2:
                        OperationsMenu(rolPath, rolsOptions, rols, "Rol");
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void OperationsMenu(string path, string[] options, List<string> data, string prompt)
        {
            while (true)
            {
                int selectedOption = Menu(options, "Elija la opcion deseada\n");
                Clear();

                switch (selectedOption)
                {
                    case 0:
                        ShowAll(path);
                        break;
                    case 1:
                        Add(path, prompt);
                        break;
                    case 2:
                        Edit(path, prompt, data);
                        break;
                    case 3:
                        Delete(path, data, prompt);
                        break;
                    case 4:
                        return;
                }

                data = GetList(path);
            }
        }

        static bool CompleteMenu()
        {
            int selectedOption = Menu(completionMenuOptions, "\n¿Que desea realizar?\n\n", true);

            switch (selectedOption)
            {
                case 0:
                    return true;
                case 1:
                    rolsSelected = GetOrChangeRols(rols, rolsSelected[0]);
                    break;
                case 2:
                    rolsSelected = GetOrChangeRols(rols, rolsSelected[1]);
                    break;
                case 3:

                    break;
            }

            return false;
        }

        static int Menu(string[] options, string prompt, bool clear = false)
        {
            int selectedOption = 0;
            ConsoleKeyInfo key;

            DrawMenu(options, prompt, selectedOption, clear);
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

                DrawMenu(options, prompt, selectedOption, clear);
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

        static string DrawMenu(string[] options, string prompt, int optionResult, bool clear)
        {
            string currentSelection = "";
            int destacado = 0;

            Clear();

            if (clear) DrawResult(firstStudent, secondStudent, rolsSelected);

            WriteLine(prompt);

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

            return currentSelection;
        }

        static void DrawResult(int liveDeveloper, int facilitator, string[] rolsSelected)
        {
            string first = CenterName(students[liveDeveloper], 23), second = CenterName(students[facilitator], 25);
            WriteLine("╔═══════════════════════╦═════════════════════════╗");
            WriteLine($"║ {rolsSelected[0]} ║ {rolsSelected[1]} ║");
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

        #region Login
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
        #endregion

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
            string data = ValidateText($"Por favor ingrese el nuevo {prompt}");

            using FileStream fs = new FileStream(path, FileMode.Append);
            using StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(data.Trim());
        }

        static void Edit(string path, string prompt, List<string> data)
        {
            int selected;
            string[] newData = data.ToArray();
            string editName = string.Empty;
            ConsoleKeyInfo key;

            while (true)
            {
                selected = Menu(newData, $"Elija el {prompt} que desea eliminar\n\n");
                editName = ValidateText($"{prompt} a Editar \"{newData[selected]}\"\nIngrese el nombre editado del {prompt}");

                if (editName.Length == 0) continue;
                while (true)
                {
                    WriteLine($"Presione Enter para confirmar, Esc volver a elegir un {prompt} y R para salir al menu Estudiantes...");
                    key = ReadKey(true);
                    if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.R) break;
                    Clear();
                }

                if (key.Key == ConsoleKey.Enter) break;
                else if (key.Key == ConsoleKey.Escape) continue;
                else if (key.Key == ConsoleKey.R) return;
            }

            data[selected] = editName;

            using FileStream fs = new FileStream(path, FileMode.Create);
            using StreamWriter writer = new StreamWriter(fs);
            {
                for (int i = 0; i < data.Count; i++)
                {
                    writer.WriteLine(data[i]);
                }
            }

        }

        static void Delete(string path, List<string> data, string prompt)
        {
            string[] options = data.ToArray();
            int optionSelected = Menu(options, $"Elija el {prompt} que desea eliminar\n");
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

        static string[] GetOrChangeRols(List<string> rols, string rolToChange = "")
        {
            string[] result = new string[2];
            int count = 0;

            if (rolToChange == "")
            {
                for (int i = 0; i < rols.Count; i++)
                {
                    if (rols[i].Contains("(default)"))
                    {
                        result[count] = rols[i].Remove(rols[i].IndexOf(" (")).Trim();
                        count++;
                    }
                }
            }
            else
            {
                result = rolsSelected;
                int change = Menu(rols.ToArray(), $"\n\nElija el Nuevo rol del estudiante (antiguo rol: {rolToChange}\n", true);

                //Se debe resolver el asunto de que aqui siempre devolvera -1 porque los roles guardados en result no tienen los caracteres "(defaul) por ende la comparacion siempre devolvera -1"
                int exist = Array.IndexOf(result, rols[change]);

                if (exist == -1)
                {
                    for(int i = 0; i < result.Length; i++)
                    {
                        if (result[i] == rolToChange) result[i] = rols[change].Remove(rols[change].IndexOf(" (")).Trim();
                    }
                }
                else
                {
                    Clear();
                    Write("Ambos estudiantes no pueden tener el mismo rol...");
                    Thread.Sleep(1000);
                    Clear();
                }

                //for (int i = 0; i < result.Length; i++)
                //{
                //    //if (result[i].Contains(rolToChange) && !(result[1].Contains(rolToChange)))
                //    if ((Array.IndexOf(result, rols[change]) == -1))
                //    {
                //        //result[i] = rols[change];
                //        result[i] = rols[change].Contains("(default)") ? rols[change].Remove(rols[change].IndexOf(" (")).Trim() : rols[change];
                //    }
                //    else
                //    {
                        
                //    }
                //}
            }

            return result;
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