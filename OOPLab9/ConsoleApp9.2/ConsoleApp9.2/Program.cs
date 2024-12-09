using System;
using System.Collections;
using System.Collections.Generic;

class Product : IComparable<Product>
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Price { get; set; }
    public int Quality { get; set; }

    public Product(string name, double weight, double price, int quality)
    {
        Name = name;
        Weight = weight;
        Price = price;
        Quality = quality;
    }

    public int CompareTo(Product other)
    {
        return Weight.CompareTo(other.Weight);
    }

    public override string ToString()
    {
        return $"{Name}: Вага={Weight}, Ціна={Price}, Якість={Quality}";
    }
}

class ProductPriceComparer : IComparer<Product>
{
    public int Compare(Product x, Product y)
    {
        return x.Price.CompareTo(y.Price);
    }
}

class ProductQualityComparer : IComparer<Product>
{
    public int Compare(Product x, Product y)
    {
        return x.Quality.CompareTo(y.Quality);
    }
}

class ProductCollection : IEnumerable<Product>
{
    private List<Product> products = new List<Product>();

    public void Add(Product product)
    {
        products.Add(product);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        products.Sort(new ProductPriceComparer()); 
        return products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var products = new ProductCollection();
        products.Add(new Product("Виріб А", 2.5, 100, 8));
        products.Add(new Product("Виріб В", 1.0, 150, 7));
        products.Add(new Product("Виріб C", 3.0, 120, 9));

        Console.WriteLine("Сортувати вироби за ціною:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine("\nСортування виробів за вагою:");
        List<Product> productList = new List<Product>(products);
        productList.Sort(); 
        productList.ForEach(Console.WriteLine);

        Console.WriteLine("\nСортування виробів за якістю:");
        productList.Sort(new ProductQualityComparer());
        productList.ForEach(Console.WriteLine);
        Console.WriteLine("Натисніть будь-яку клавішу, щоб закрити програму...");
        Console.ReadKey();
    }
}
