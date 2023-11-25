using System.IO;
using static System.Console;

namespace student_roulette
{
    internal class Program
    {
        static string rolPath = AppDomain.CurrentDomain.BaseDirectory + "/rols.txt";
        static string studentsPath = AppDomain.CurrentDomain.BaseDirectory + "/students.txt";
        static string historyPath = AppDomain.CurrentDomain.BaseDirectory + "/history.csv";
        static string[] rolsSelected = Array.Empty<string>();
        static List<string> students = GetList(studentsPath);
        static List<string> rols = GetList(rolPath);
        static List<int> repeatedNumbers = new();
        static bool drawLast = true, withAnimation = false;
        static int firstStudent, secondStudent, centerPosition;
        static string[] completionMenuOptions =
        {
            "Elegir nuevos estudiantes", "Cronometro", "Cambiar Rol al primer estudiante", "Cambiar Rol al segundo estudiante", "Volver al menu principal"
        };

        static string[] initialMenuOptions =
        {
            "Iniciar Programa (Elegir Estudiantes) Sin animacion","Iniciar Programa (Elegir Estudiantes) Con animacion", "Estudiantes", "Roles", "Salir del Programa"
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
            //OutputEncoding = System.Text.Encoding.Unicode;

            Clear();
            InitialMenu();
            //if (!Login()) continue;

        }

        static void GetStudents()
        {
            int newStudent = 1;
            Random randomStudent = new();

            Clear();

            while (newStudent != 3)
            {
                Clear();

                LoadingAnimation("\r\n         ▓█████  ██▓     ██▓  ▄████  ██▓▓█████  ███▄    █ ▓█████▄  ▒█████                   \r\n         ▓█   ▀ ▓██▒    ▓██▒ ██▒ ▀█▒▓██▒▓█   ▀  ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒                 \r\n         ▒███   ▒██░    ▒██▒▒██░▄▄▄░▒██▒▒███   ▓██  ▀█ ██▒░██   █▌▒██░  ██▒                 \r\n         ▒▓█  ▄ ▒██░    ░██░░▓█  ██▓░██░▒▓█  ▄ ▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░                 \r\n         ░▒████▒░██████▒░██░░▒▓███▀▒░██░░▒████▒▒██░   ▓██░░▒████▓ ░ ████▓▒░                 \r\n         ░░ ▒░ ░░ ▒░▓  ░░▓   ░▒   ▒ ░▓  ░░ ▒░ ░░ ▒░   ▒ ▒  ▒▒▓  ▒ ░ ▒░▒░▒░                  \r\n          ░ ░  ░░ ░ ▒  ░ ▒ ░  ░   ░  ▒ ░ ░ ░  ░░ ░░   ░ ▒░ ░ ▒  ▒   ░ ▒ ▒░                  \r\n            ░     ░ ░    ▒ ░░ ░   ░  ▒ ░   ░      ░   ░ ░  ░ ░  ░ ░ ░ ░ ▒                   \r\n            ░  ░    ░  ░ ░        ░  ░     ░  ░         ░    ░        ░ ░                   \r\n                                                           ░                                \r\n▓█████   ██████ ▄▄▄█████▓ █    ██ ▓█████▄  ██▓ ▄▄▄       ███▄    █ ▄▄▄█████▓▓█████   ██████ \r\n▓█   ▀ ▒██    ▒ ▓  ██▒ ▓▒ ██  ▓██▒▒██▀ ██▌▓██▒▒████▄     ██ ▀█   █ ▓  ██▒ ▓▒▓█   ▀ ▒██    ▒ \r\n▒███   ░ ▓██▄   ▒ ▓██░ ▒░▓██  ▒██░░██   █▌▒██▒▒██  ▀█▄  ▓██  ▀█ ██▒▒ ▓██░ ▒░▒███   ░ ▓██▄   \r\n▒▓█  ▄   ▒   ██▒░ ▓██▓ ░ ▓▓█  ░██░░▓█▄   ▌░██░░██▄▄▄▄██ ▓██▒  ▐▌██▒░ ▓██▓ ░ ▒▓█  ▄   ▒   ██▒\r\n░▒████▒▒██████▒▒  ▒██▒ ░ ▒▒█████▓ ░▒████▓ ░██░ ▓█   ▓██▒▒██░   ▓██░  ▒██▒ ░ ░▒████▒▒██████▒▒\r\n░░ ▒░ ░▒ ▒▓▒ ▒ ░  ▒ ░░   ░▒▓▒ ▒ ▒  ▒▒▓  ▒ ░▓   ▒▒   ▓▒█░░ ▒░   ▒ ▒   ▒ ░░   ░░ ▒░ ░▒ ▒▓▒ ▒ ░\r\n ░ ░  ░░ ░▒  ░ ░    ░    ░░▒░ ░ ░  ░ ▒  ▒  ▒ ░  ▒   ▒▒ ░░ ░░   ░ ▒░    ░     ░ ░  ░░ ░▒  ░ ░\r\n   ░   ░  ░  ░    ░       ░░░ ░ ░  ░ ░  ░  ▒ ░  ░   ▒      ░   ░ ░   ░         ░   ░  ░  ░  \r\n   ░  ░      ░              ░        ░     ░        ░  ░         ░             ░  ░      ░  \r\n                                   ░                                                        \r\n", withAnimation);

                while (newStudent == 1)
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

                DrawResult(students[firstStudent], students[secondStudent], rolsSelected[0], rolsSelected[1]);
                newStudent = CompleteMenu();

                if (newStudent == 1 || newStudent == 3)
                {
                    Log(firstStudent, secondStudent, rolsSelected, historyPath);
                    repeatedNumbers.Add(firstStudent);
                    repeatedNumbers.Add(secondStudent);
                }

                if (repeatedNumbers.Count == students.Count - 1 || repeatedNumbers.Count == students.Count)
                {
                    int aloneStudent = -1;
                    for (int i = 0; i < repeatedNumbers.Count; i++)
                    {
                        if (repeatedNumbers.Contains(i)) continue;
                        else aloneStudent = i;
                    }

                    Clear();
                    if (aloneStudent != -1)
                        WriteLine($"El estudiante \"{students[aloneStudent]}\" se quedo sin participar, volviendo al menú...");
                    else
                        WriteLine("Ya han participado todos los estudiantes volviendo al menu...");

                    Thread.Sleep(3000);

                    repeatedNumbers.Clear();
                    LoadingAnimation("\r\n ██▀███  ▓█████  ██▓ ███▄    █  ██▓ ▄████▄   ██▓ ▄▄▄       ███▄    █ ▓█████▄  ▒█████  \r\n▓██ ▒ ██▒▓█   ▀ ▓██▒ ██ ▀█   █ ▓██▒▒██▀ ▀█  ▓██▒▒████▄     ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒\r\n▓██ ░▄█ ▒▒███   ▒██▒▓██  ▀█ ██▒▒██▒▒▓█    ▄ ▒██▒▒██  ▀█▄  ▓██  ▀█ ██▒░██   █▌▒██░  ██▒\r\n▒██▀▀█▄  ▒▓█  ▄ ░██░▓██▒  ▐▌██▒░██░▒▓▓▄ ▄██▒░██░░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░\r\n░██▓ ▒██▒░▒████▒░██░▒██░   ▓██░░██░▒ ▓███▀ ░░██░ ▓█   ▓██▒▒██░   ▓██░░▒████▓ ░ ████▓▒░\r\n░ ▒▓ ░▒▓░░░ ▒░ ░░▓  ░ ▒░   ▒ ▒ ░▓  ░ ░▒ ▒  ░░▓   ▒▒   ▓▒█░░ ▒░   ▒ ▒  ▒▒▓  ▒ ░ ▒░▒░▒░ \r\n  ░▒ ░ ▒░ ░ ░  ░ ▒ ░░ ░░   ░ ▒░ ▒ ░  ░  ▒    ▒ ░  ▒   ▒▒ ░░ ░░   ░ ▒░ ░ ▒  ▒   ░ ▒ ▒░ \r\n  ░░   ░    ░    ▒ ░   ░   ░ ░  ▒ ░░         ▒ ░  ░   ▒      ░   ░ ░  ░ ░  ░ ░ ░ ░ ▒  \r\n   ░        ░  ░ ░           ░  ░  ░ ░       ░        ░  ░         ░    ░        ░ ░  \r\n                                   ░                                  ░               \r\n", withAnimation);
                    break;
                }
            }
        }

        static void InitialMenu()
        {
            while (true)
            {
                Clear();

                int selectedOption = Menu(initialMenuOptions, "\r\n ▄▄▄▄    ██▓▓█████  ███▄    █ ██▒   █▓▓█████  ███▄    █  ██▓▓█████▄  ▒█████  \r\n▓█████▄ ▓██▒▓█   ▀  ██ ▀█   █▓██░   █▒▓█   ▀  ██ ▀█   █ ▓██▒▒██▀ ██▌▒██▒  ██▒\r\n▒██▒ ▄██▒██▒▒███   ▓██  ▀█ ██▒▓██  █▒░▒███   ▓██  ▀█ ██▒▒██▒░██   █▌▒██░  ██▒\r\n▒██░█▀  ░██░▒▓█  ▄ ▓██▒  ▐▌██▒ ▒██ █░░▒▓█  ▄ ▓██▒  ▐▌██▒░██░░▓█▄   ▌▒██   ██░\r\n░▓█  ▀█▓░██░░▒████▒▒██░   ▓██░  ▒▀█░  ░▒████▒▒██░   ▓██░░██░░▒████▓ ░ ████▓▒░\r\n░▒▓███▀▒░▓  ░░ ▒░ ░░ ▒░   ▒ ▒   ░ ▐░  ░░ ▒░ ░░ ▒░   ▒ ▒ ░▓   ▒▒▓  ▒ ░ ▒░▒░▒░ \r\n▒░▒   ░  ▒ ░ ░ ░  ░░ ░░   ░ ▒░  ░ ░░   ░ ░  ░░ ░░   ░ ▒░ ▒ ░ ░ ▒  ▒   ░ ▒ ▒░ \r\n ░    ░  ▒ ░   ░      ░   ░ ░     ░░     ░      ░   ░ ░  ▒ ░ ░ ░  ░ ░ ░ ░ ▒  \r\n ░       ░     ░  ░         ░      ░     ░  ░         ░  ░     ░        ░ ░  \r\n      ░                           ░                          ░               \r\n");

                drawLast = false;

                switch (selectedOption)
                {
                    case 0:
                        GetStudents();
                        break;
                    case 1:
                        withAnimation = true;
                        GetStudents();
                        break;
                    case 2:
                        OperationsMenu(studentsPath, studentsOptions, students, "Estudiante");
                        break;
                    case 3:
                        OperationsMenu(rolPath, rolsOptions, rols, "Rol");
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
                drawLast = true;
                withAnimation = false;
            }
        }

        static void OperationsMenu(string path, string[] options, List<string> data, string prompt)
        {
            while (true)
            {
                int selectedOption = Menu(options, "\t\t\tElija la opcion deseada\n");
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

        static int CompleteMenu()
        {
            while (true)
            {
                int selectedOption = Menu(completionMenuOptions, "\n¿Que desea realizar?\n\n", true);

                switch (selectedOption)
                {
                    case 0:
                        return 1;
                    case 1:
                        StopWatch();
                        break;
                    case 2:
                        rolsSelected = GetOrChangeRols(rols, rolsSelected[0]);
                        break;
                    case 3:
                        rolsSelected = GetOrChangeRols(rols, rolsSelected[1]);
                        break;
                    case 4:
                        return 3;
                }
            }
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

        static bool DeleteConfirmMenu(string prompt)
        {
            bool confirm = false;
            ConsoleKeyInfo key;
            string yes = "Si", no = "No";
            Clear();
            ResetColor();
            WriteLine($"¿Esta seguro que desea eliminar a este {prompt}?");
            SetCursorPosition(CursorLeft + 10, CursorTop + 1);
            Write(yes);
            SetCursorPosition(CursorLeft + 25, CursorTop);
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;
            Write(no);

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
            string[] Last = GetLastStudents(historyPath);

            Clear();

            if (clear) DrawResult(students[firstStudent], students[secondStudent], rolsSelected[0], rolsSelected[1]);

            if (drawLast && !Last.Contains<string>("Primer Estudiante"))
            {
                prompt = "";
                WriteLine("Ultimos Participantes\n");
                DrawResult(Last[0], Last[1], Last[2], Last[3]);
            }

            WriteLine(prompt);

            for (int i = 0; i < options.Length; i++)
            {
                if (destacado == optionResult)
                {
                    ForegroundColor = ConsoleColor.Black;
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

        static void DrawResult(string liveDeveloper, string facilitator, string rolLiveDeveloper, string rolFacilitator)
        {
            //Aqui basicamente lo que hago es verificar si el nombre del estudiante ocupara mas en el recuadro que el rol que el tenga, es decir, si la cantidad de caracteres del nombre es mayor yo debo dibujar un recuadro de acuerdo al tamaño del nombre, si de lo contario la cantidad de caracteres del rol es mas grande entonces debo dibujar el recuadro de acuerdo a ese tamaño.
            //int firstBox = students[liveDeveloper].Length > rolsSelected[rolLiveDeveloper].Length ? students[liveDeveloper].Length : rolsSelected[rolLiveDeveloper].Length;
            //int secondBox = students[facilitator].Length > rolsSelected[rolFacilitator].Length ? students[facilitator].Length : rolsSelected[rolFacilitator].Length;
            int firstBox = liveDeveloper.Length > rolLiveDeveloper.Length ? liveDeveloper.Length : rolLiveDeveloper.Length;
            int secondBox = facilitator.Length > rolFacilitator.Length ? facilitator.Length : rolFacilitator.Length;

            //centerPosition = (WindowWidth / 2) - (firstBox + secondBox) / 2;

            //Se le suma 2 para que siempre tenga al menos 1 espacio en cada lado, porque en ocaciones el rol y el nombre tienen la misma cantidad de caracteres.
            string firstRol = CenterString(rolLiveDeveloper, firstBox + 2), secondRol = CenterString(rolFacilitator, secondBox + 2);
            string first = CenterString(liveDeveloper, firstBox + 2), second = CenterString(facilitator, secondBox + 2);

            //SetCursorPosition(centerPosition, 2);
            Write("╔");
            for (int i = 0; i < firstBox + 2; i++)
            {
                Write("═");
            }
            Write("╦");
            for (int i = 0; i < secondBox + 2; i++)
            {
                Write("═");
            }
            WriteLine("╗");
            //SetCursorPosition(centerPosition, CursorTop);
            WriteLine($"║{firstRol}║{secondRol}║");
            //SetCursorPosition(centerPosition, CursorTop);
            Write("╠");
            for (int i = 0; i < firstBox + 2; i++)
            {
                Write("═");
            }
            Write("╬");
            for (int i = 0; i < secondBox + 2; i++)
            {
                Write("═");
            }
            WriteLine("╣");
            //SetCursorPosition(centerPosition, CursorTop);
            WriteLine($"║{first}║{second}║");
            //SetCursorPosition(centerPosition, CursorTop);
            Write("╚");
            for (int i = 0; i < firstBox + 2; i++)
            {
                Write("═");
            }
            Write("╩");
            for (int i = 0; i < secondBox + 2; i++)
            {
                Write("═");
            }
            WriteLine("╝");
        }

        //Esta funcion lo que hace es centrar el texto en el recuadro añadiendo los espacios necesarios para que quede bien centrado.
        static string CenterString(string name, int space)
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

        static void LoadingAnimation(string prompt, bool withAnimation)
        {
            const byte time = 50;
            Clear();
            if (withAnimation)
            {
                Write(prompt);
                SetCursorPosition(10, 22);
                ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < time; i++)
                {
                    Write("█");
                }

                SetCursorPosition(10, 22);
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
                    WriteLine($"\n\nPresione Enter para confirmar, Esc volver a elegir un {prompt} y R para salir al menu...");
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
            if (DeleteConfirmMenu(prompt))
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
                int change = Menu(rols.ToArray(), $"\n\nElija el Nuevo rol del estudiante (antiguo rol: {rolToChange})\n", true);
                string newRol = rols[change].Contains("(default)") ? rols[change].Remove(rols[change].IndexOf(" (")) : rols[change];
                int exist = Array.IndexOf(result, newRol);

                if (exist == -1)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] == rolToChange) result[i] = newRol;
                    }
                }
                else
                {
                    Clear();
                    Write("No se puede repetir un rol");
                    Thread.Sleep(1000);
                    Clear();
                }
            }

            return result;
        }

        static void Log(int firstStudent, int secondStudent, string[] rols, string path)
        {
            string line = $"{students[firstStudent]},{students[secondStudent]},{rols[0]},{rols[1]},{DateTime.Now}";

            using FileStream fs = new FileStream(path, FileMode.Append);
            using StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(line);
        }

        static string[] GetLastStudents(string path)
        {
            string[] result = File.ReadAllLines(path);
            string[] lastStudents = result[result.Length - 1].Split(",");

            return lastStudents;
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

        static void StopWatch()
        {
            int min;
            while (true)
            {
                Clear();
                Write("Ingrese los minutos deseados (limite de 180 minutos): ");
                if (int.TryParse(ReadLine(), out min) && min > 0 && min <= 180) break;

                WriteLine("Debe ingresar un numero valido, no se aceptan valores negativos o mayores a 180");
                Write("Presione Cualquier tecla para intentar nuevamente, ESC para salir del cronometro");

                if (ReadKey(true).Key == ConsoleKey.Escape) return;
            }

            Clear();
            string marker = "|";
            for (int i = 0; i < min; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    DrawResult(students[firstStudent], students[secondStudent], rolsSelected[0], rolsSelected[1]);
                    WriteLine("Cronometro");
                    WriteLine($"{(i > 9 ? "" : "0")}{i}:{(j > 9 ? "" : "0")}{j}       {marker}");
                    WriteLine("\n\nPresione cualquier Tecla para salir...");

                    if (KeyAvailable) return;
                    Thread.Sleep(500);

                    Clear();
                    if (marker.Equals("\\")) marker = "|";
                    if (marker.Equals("-")) marker = "\\";
                    if (marker.Equals("/")) marker = "-";
                    if (marker.Equals("|")) marker = "/";
                }
            }
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
    }
}