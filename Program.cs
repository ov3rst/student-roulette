using static System.Console;

namespace student_roulette
{
    //Agregar un cronometro que pueda ser elegido, por ejemplo podemos preguntar iniciando el programa si deseamos usar solamente el cronometro, tambien despues de haber elegido los estudiantes preguntar si se quiere ahi mismo cronometrar el desafio.
    // Agregar un reloj, para ver la hora actual en el programa, que se pueda elegir si mostrar o no.
    internal class Program
    {
        static string rolPath = AppDomain.CurrentDomain.BaseDirectory + "/roles.txt";
        static string studentsPath = AppDomain.CurrentDomain.BaseDirectory + "/students.txt";
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
            "Ingresar nuevo Estudiante", "Modificar Estudiante", "Eliminar Estudiante", "Volver al menú"
        };

        static List<string> students = GetListOfStudents(studentsPath);

        static List<int> repeatedNumbers = new();
        static bool exit = false, withAnimation = true;
        static int firstStudent, secondStudent;

        static void Main(string[] args)
        {
            CursorVisible = false;
            while (!exit)
            {
                Clear();
                //StudentsMenu();
                EditStudent();
                //GetStudents();
                //DrawResult(firstStudent, secondStudent);
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

        static void StudentsMenu()
        {
            int selectedOption = Menu(studentsOptions);

            switch (selectedOption)
            {
                case 0:
                    AddStudent();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        //Hay que abstraer la funcionalidad de elegir opcion en el menu para poder utilizarla en mas sitios.(Por ejemplo para elegir si queremos o no animaciones).
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

        static void InsertRol(string rol)
        {
            using (FileStream fs = new FileStream(rolPath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(rol);
            }
        }

        static void GetRoles()
        {
            using (var fs = new FileStream(rolPath, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
                while (!sr.EndOfStream)
                {
                    WriteLine(sr.ReadLine());
                }
        }

        static List<string> GetListOfStudents(string path)
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

        static void AddStudent()
        {
            //Clear();
            //string student;
            //CursorVisible = true;
            //while (true)
            //{
            //    Write("Por favor ingrese el nombre completo del estudiante: ");
            //    student = ReadLine()!;
            //    if (!string.IsNullOrWhiteSpace(student)) break;


            //    WriteLine("No se debe dejar el nombre vacio o ingresar solamente espacios");
            //    Write("Presione una tecla Para intentar otra vez...");
            //    ReadKey(true);
            //    Clear();
            //}

            string student = ValidateText("Por favor ingrese el nombre completo del estudiante");

            using FileStream fs = new FileStream(studentsPath, FileMode.Append);
            using StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(student.Trim());
        }

        static void EditStudent()
        {
            string[] newStudents = students.ToArray();
            string editName = string.Empty;

            while (true)
            {
                int student = Menu(newStudents);

                WriteLine($"Estudiante a Editar \"{students[student]}\"");
                editName = ValidateText("Ingrese el nombre editado del estudiante");
                if (editName == string.Empty) return;
                WriteLine("Presione Enter para confirmar, Esc para cancelar y volver a elegir estudiantes y Ctrl + R para salir al menu Estudiantes");
                if (ReadKey(true).Key == ConsoleKey.Enter) break;
                else if (ReadKey(true).Key == ConsoleKey.Escape) continue;
                else if (ReadKey(true).Modifiers == ConsoleModifiers.Control && ReadKey(true).Key == ConsoleKey.R) return;
            }


            for (int i = 0; i < newStudents.Length; i++)
            {
            }
        }

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

                if ((ReadKey(true).Key) == ConsoleKey.Escape) break;
                Clear();
            }

            CursorVisible = false;

            return student;
        }
    }
}