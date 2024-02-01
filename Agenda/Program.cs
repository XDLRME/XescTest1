using System.Net;

internal class Program
{
    public static void Main(string[] args) //Declaro el main
    {
        Alta();
        
    }


    public static void Alta()
    {
        StreamWriter fitxer;
        fitxer = new StreamWriter(@".\prova.txt");
        
        string nom, cognom, dni;
        Console.WriteLine("Escriu el teu nom amb la primera lletra en majúscules: ");
        nom = Console.ReadLine();
        nom = new string(nom.Where(char.IsLetter).ToArray());
        nom = char.ToUpper(nom[0]) + nom.Substring(1).ToLower(); 
        Console.WriteLine("Escriu el teu cognom: ");
        cognom = Console.ReadLine();
        cognom = new string(nom.Where(char.IsLetter).ToArray());
        cognom = char.ToUpper(nom[0]) + nom.Substring(1).ToLower();
       
        //DNI
        Console.WriteLine("Escriu el teu DNI: ");
        bool sonNumeros = true;
        do
        {
            Console.Write("Por favor, ingrese su DNI: ");
            dni = Console.ReadLine();

            

            if (dni.Length == 9)
            {
                int i = 0;

                while (i < 8 && sonNumeros)
                {
                    sonNumeros = char.IsDigit(dni[i]);
                    i++;
                }

                if (!(sonNumeros && char.IsLetter(dni[8])))
                {
                    Console.WriteLine("El DNI NO es válido. Por favor, inténtelo de nuevo.");
                }              
            }
            else
            {
                Console.WriteLine("Longitud de DNI incorrecta. Por favor, inténtelo de nuevo.");
                sonNumeros = false; 
            }

        } while (dni.Length != 9 || !char.IsLetter(dni[8]) || !sonNumeros );

        //Telèfon
        string telefon;
        sonNumeros = true;
        do
        {
            Console.Write("Si us plau, introduïu el vostre número de telèfon (9 dígits): ");
            telefon = Console.ReadLine();

            

            if (telefon.Length == 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    sonNumeros = char.IsDigit(telefon[i]);

                    if (!sonNumeros)
                    {
                        break;
                    }
                }

                if (!(sonNumeros))
                {
                    Console.WriteLine("El número de telèfon NO és vàlid. Si us plau, torneu a intentar-ho.");
                }
            }
            else
            {
                Console.WriteLine("Longitud del número de telèfon incorrecta. Si us plau, torneu a intentar-ho.");
            }

        } while (telefon.Length != 9 || !sonNumeros);

        //Data naixement
        string dataN;
        bool formatValid = false;
        do
        {
            Console.Write("Introdueix la seva data de naixement en format ddmmaaaa: ");
            dataN = Console.ReadLine();

            

            if (dataN.Length == 8)
            {
                 sonNumeros = true;

                for (int i = 0; i < 8; i++)
                {
                    sonNumeros = sonNumeros && char.IsDigit(dataN[i]);
                }

                if (sonNumeros)
                {
                    formatValid = true;
                }
            }

            if (!(formatValid))
            {
                Console.WriteLine("Format incorrecte. Torna-ho a intentar");
            }
        } while (!formatValid);

        //Correu electrònic
        string correuElectrònic;
        bool formatCorrecte = false;
        do
        {
            Console.Write("Introdueix el teu correu electrònic: ");
            correuElectrònic = Console.ReadLine();

            // Convertir tot a minúscula per fer la verificació no sensible a majúscules
            correuElectrònic = correuElectrònic.ToLower();

            // Verificar format del correu electrònic sense utilitzar Split
            int arrobaIndex = correuElectrònic.IndexOf('@');
            int puntIndex = correuElectrònic.LastIndexOf('.');

            if (arrobaIndex >= 0 && puntIndex >= 0 && puntIndex > arrobaIndex + 1)
            {
                string nomUsuari = correuElectrònic.Substring(0, arrobaIndex);
                string domini = correuElectrònic.Substring(arrobaIndex + 1, puntIndex - arrobaIndex - 1);
                string extensioDomini = correuElectrònic.Substring(puntIndex + 1);

                if (nomUsuari.Length >= 3 && domini.Length >= 3 && extensioDomini.Length >= 2)
                {
                    formatCorrecte = true;
                }
            }

            if (!(formatCorrecte))
            {
                Console.WriteLine("Format incorrecte. Intenta-ho de nou.");
            }
        } while (!formatCorrecte);

        string frase="";
        frase += nom += cognom += dni += telefon += dataN += correuElectrònic; 
        Console.WriteLine(frase);


        Thread.Sleep(15100);



        MenuMatematic();
    }

   
    static void CenterText(string text) //Centro el text de forma automatica al iniciar
    {
        int screenWidth = Console.WindowWidth;
        int stringWidth = text.Length;
        int leftMargin = (screenWidth - stringWidth) / 2;
        Console.SetCursorPosition(leftMargin, Console.CursorTop);
        Console.WriteLine(text);
    }

    public static void MenuMatematic() //Faig la part visual del programa
    {
        Console.Clear();
        CenterText("              MENU               ");
        CenterText("*********************************");
        CenterText("*   1.-MCD                      *");
        CenterText("*   2.-mcm                      *");
        CenterText("*   3.-Factorial                *");
        CenterText("*   4.-Combinatori              *");
        CenterText("*   5.-MostrarDivisorMajor      *");
        CenterText("*   6.-EsPrimer                 *");
        CenterText("*   7.-NPrimersPrimers          *");
        CenterText("*   8.-Maxim                    *");
        CenterText("*   9.-Sortir                   *");
        CenterText("*********************************");
        ValorVariable();
    }

    public static void ValorVariable()//Al ser inicialitzat pel menú, espero per un input i enter i depenent del valor, obro una opció del switch
    {
        char opcio;
        Console.WriteLine(" ");
        Console.WriteLine("Escriu opcio menu: ");
        opcio = Convert.ToChar(Console.ReadLine());

        switch (opcio)
        {
            case '1':
                MCD();
                Console.Clear();
                MenuMatematic();
                break;

            case '2':
                mcm();
                Console.Clear();
                MenuMatematic();
                break;

            case '3':
                Factorial();
                Console.Clear();
                MenuMatematic();
                break;

            case '4':
                Combinatori();
                Console.Clear();
                MenuMatematic();
                break;

            case '5':
                DivMajor();
                Console.Clear();
                MenuMatematic();
                break;

            case '6':
                EsPrimer();
                Console.Clear();
                MenuMatematic();
                break;

            case '7':
                NPrimPrim();
                Console.Clear();
                MenuMatematic();
                break;

            case '8':
                Maxim();
                Console.Clear();
                MenuMatematic();
                break;

            case '9':
                Console.WriteLine();
                Console.WriteLine("Adéu!");
                break; //Tanca el programa
        }
    }

    //Programo la funció de cada opció
    public static void MCD()
    {
        Console.Clear();
        int num1, num2, vlimit, valordisplay = 1, valorcorrecte = 0;
        Console.WriteLine("Escriu un numero: ");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Escriu un altre numero: ");
        num2 = Convert.ToInt32(Console.ReadLine());
        if (num1 > num2) { vlimit = num2; }
        else { vlimit = num1; }
        do
        {
            if (num1 % valordisplay == 0 && num2 % valordisplay == 0) { valorcorrecte = valordisplay; }
            valordisplay++;
        }
        while (valordisplay <= vlimit);
        if (valorcorrecte == 0) { Console.WriteLine(1); }
        else if (valorcorrecte > 0) { Console.Clear(); Console.WriteLine("El MCD entre " + num1 + " i " + num2 + " és: " + valorcorrecte); }
        Thread.Sleep(1100);
        Temporitzador();
    }

    public static void mcm()
    {
        Console.Clear();
        int num1, num2, resultado = 0;
        bool encontrado = false;
        Console.WriteLine("Escriu un numero: ");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Escriu un numero: ");
        num2 = Convert.ToInt32(Console.ReadLine());
        int maximo = Math.Max(num1, num2);
        while (!encontrado)
        {
            if (maximo % num1 == 0 && maximo % num2 == 0)
            {
                resultado = maximo;
                encontrado = true;
            }
            maximo++;
        }
        Console.Clear();
        Console.WriteLine("El mcm entre " + num1 + " i " + num2 + " és: " + resultado);
        Thread.Sleep(1100);
        Temporitzador();
    }

    public static void Factorial()
    {
        Console.Clear();
        int num = 0, factorial = 1;
        Console.WriteLine("Escriu un numero: ");
        num = Convert.ToInt32(Console.ReadLine());
        for (int i = 2; i <= num; i++)
        {
            factorial *= i;
        }
        Console.Clear();
        Console.WriteLine("El factorial de " + num + " és: " + factorial);
        Thread.Sleep(1100);
        Temporitzador();
    }

    public static void Combinatori()
    {
        Console.Clear();
        Console.WriteLine("Escriu un numero: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Escriu un altre numero: ");
        int num2 = Convert.ToInt32(Console.ReadLine());
        int coeficientBinomial = 1;
        if (num2 > num1 - num2)
            num2 = num2 - num2;

        for (int i = 1; i <= num2; i++)
        {
            coeficientBinomial *= num1 - (num2 - i);
            coeficientBinomial /= i;
        }
        Console.Clear();
        Console.WriteLine($"El combinatori C({num1}, {num2}) es: {coeficientBinomial}");
        Thread.Sleep(1100);
        Temporitzador();
    }

    public static void DivMajor()
    {
        Console.Clear();
        Console.Write("Introdueix un número enter positiu: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num > 0)
        {
            int divisorMajor = 1;

            int i = num / 2;
            while (i >= 1 && divisorMajor == 1)
            {
                if (num % i == 0)
                {
                    divisorMajor = i;
                }
                i--;
            }
            Console.Clear();
            Console.WriteLine($"El divisor més gran de {num} és: {divisorMajor}");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Si us plau, introdueix un número enter positiu vàlid.");
        }
        Thread.Sleep(1100);
        Temporitzador();
    }
    public static void EsPrimer()
    {
        Console.Clear();
        Console.Write("Introdueix un número per verificar si és primer: ");
        int numero = Convert.ToInt32(Console.ReadLine());

        bool esPrim = true;
        int limit = (int)Math.Sqrt(numero);
        for (int i = 2; i <= limit && esPrim; i++)
        {
            if (numero % i == 0)
            {
                esPrim = false;
            }
        }
        if (esPrim && numero > 1)
        {
            Console.Clear();
            Console.WriteLine($"{numero} és un número primer.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"{numero} no és un número primer.");
        }
        Thread.Sleep(1100);
        Temporitzador();
    }

    public static void NPrimPrim()
    {
        Console.Clear();
        Console.Write("Introdueix el valor de N per als primers números primers: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write($"Els primers {n} números primers són: ");
        int contador = 0;
        int numero = 2;
        while (contador < n)
        {
            bool esPrim = true;

            int i = 2;
            while (i <= Math.Sqrt(numero) && esPrim)
            {
                if (numero % i == 0)
                {
                    esPrim = false;
                }
                i++;
            }
            if (esPrim)
            {
                Console.Clear();
                Console.Write($"{numero} ");
                contador++;
            }
            numero++;
        }
        Thread.Sleep(1100);
        Temporitzador();
    }

    public static void Maxim()
    {
        Console.Clear();
        Console.WriteLine("Introdueix una seqüència de números (introdueix 0 per acabar):");
        int maxim = int.MinValue;
        string entrada = Console.ReadLine();
        while (entrada != "0")
        {
            if (int.TryParse(entrada, out int numero))
            {
                if (numero > maxim)
                {
                    maxim = numero;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Entrada no vàlida. Introdueix un número enter o 0 per finalitzar.");
            }
            entrada = Console.ReadLine();
        }
        Console.Clear();
        Console.WriteLine($"El número màxim és: {maxim}");
        Thread.Sleep(1100);
        Temporitzador();
    }

    public static void Temporitzador() //Cada opció acaba anant al temporitzador on després de contar, portará al menú on s'executarà 'ValorVariable'
    {
        Console.WriteLine(" ");
        for (int i = 4; i > 0; i--)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("           Tornant al menú en: " + i + " segons.");
            Thread.Sleep(950);
        }
        MenuMatematic();
    }
}

