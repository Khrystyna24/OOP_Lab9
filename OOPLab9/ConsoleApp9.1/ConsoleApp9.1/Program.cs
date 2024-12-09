using System;

interface ITaxCalculator
{
    double CalculateTax();
}

class LandTax : ITaxCalculator
{
    public double Area { get; set; } 
    public double Rate { get; set; } 

    public LandTax(double area, double rate)
    {
        Area = area;
        Rate = rate;
    }

    public double CalculateTax()
    {
        return Area * Rate;
    }
}

class CarTax : ITaxCalculator
{
    public double EngineCapacity { get; set; } 
    public double RatePerLitre { get; set; }  

    public CarTax(double engineCapacity, double ratePerLitre)
    {
        EngineCapacity = engineCapacity;
        RatePerLitre = ratePerLitre;
    }

    public double CalculateTax()
    {
        return EngineCapacity * RatePerLitre;
    }
}

class IncomeTax : ITaxCalculator
{
    public double Income { get; set; } 
    public double TaxRate { get; set; } 

    public IncomeTax(double income, double taxRate)
    {
        Income = income;
        TaxRate = taxRate;
    }

    public double CalculateTax()
    {
        return Income * TaxRate / 100;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ITaxCalculator landTax = new LandTax(500, 2.5);
        ITaxCalculator carTax = new CarTax(2.0, 300);
        ITaxCalculator incomeTax = new IncomeTax(5000, 18);

        Console.WriteLine($"Земельний податок: {landTax.CalculateTax()} UAH");
        Console.WriteLine($"Податок на автомобіль: {carTax.CalculateTax()} UAH");
        Console.WriteLine($"Податок на прибуток: {incomeTax.CalculateTax()} UAH");
        Console.WriteLine("Натисніть будь-яку клавішу, щоб закрити програму...");
        Console.ReadKey();
    }
}
