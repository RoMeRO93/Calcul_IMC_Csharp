using System;

public class Program
{
    public static void Main()
    {
        Calculator calculator = new Calculator();

        bool continua = true;
        while (continua)
        {
            AfisareMeniu();

            string optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    Console.Write("Introduceti primul numar: ");
                    int numar1 = int.Parse(Console.ReadLine());
                    Console.Write("Introduceti al doilea numar: ");
                    int numar2 = int.Parse(Console.ReadLine());
                    int suma = calculator.CalculeazaSuma(numar1, numar2);
                    Console.WriteLine("Suma este: " + suma);
                    break;

                case "2":
                    Console.Write("Introduceti greutatea (kg): ");
                    double greutate = double.Parse(Console.ReadLine());
                    Console.Write("Introduceti inaltimea (cm): ");
                    double inaltime = double.Parse(Console.ReadLine());
                    double imc = calculator.CalculeazaIndiceMasaCorporala(greutate, inaltime);
                    Console.WriteLine("Indicele de masa corporala este: " + imc);
                    calculator.AfisareStarePonderala(imc);
                    break;

                case "x":
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Optiune invalida. Va rugam selectati o optiune valida!");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void AfisareMeniu()
    {
        Console.WriteLine("########## MENIU ##########");
        Console.WriteLine("1. Calculeaza suma a doua numere");
        Console.WriteLine("2. Calculeaza indicele de masa corporala");
        Console.WriteLine("x. Iesire");
        Console.WriteLine("###########################");
        Console.Write("Selectati o optiune: ");
    }
}

public class Calculator
{
    public int CalculeazaSuma(int a, int b)
    {
        return a + b;
    }

    public double CalculeazaIndiceMasaCorporala(double greutate, double inaltime)
    {
        if (inaltime == 0)
        {
            throw new ArgumentException("Inaltimea trebuie sa fie diferita de zero!");
        }

        double inaltimeMetri = inaltime / 100; // Convertim inaltimea in metri
        double indiceMasaCorporala = greutate / (inaltimeMetri * inaltimeMetri);
        return Math.Round(indiceMasaCorporala, 2);
    }

    public void AfisareStarePonderala(double imc)
    {
        string starePonderala = string.Empty;

        if (imc <= 18.49)
        {
            starePonderala = "Subponderal";
        }
        else if (imc >= 18.50 && imc <= 24.99)
        {
            starePonderala = "Greutate normala";
        }
        else if (imc >= 25.00 && imc <= 29.99)
        {
            starePonderala = "Supraponderal";
        }
        else if (imc >= 30.00 && imc <= 34.99)
        {
            starePonderala = "Obezitate (gradul I)";
        }
        else if (imc >= 35.00 && imc <= 39.99)
        {
            starePonderala = "Obezitate (gradul II)";
        }
        else if (imc >= 40.00)
        {
            starePonderala = "Obezitate morbidă";
        }
        Console.WriteLine("Starea ponderală: " + starePonderala);
    }
}

