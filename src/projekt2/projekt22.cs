

using projekt.models;

int productCount = 0;
bool isCorrect = false;
do
{
    Console.WriteLine("Podaj liczbę produktów: ");
    // Naprawa warunku - poprawnie sprawdzamy czy wartość jest liczbą i czy jest większa niż 0
    if (int.TryParse(Console.ReadLine(), out productCount) && productCount > 0)
    {
        isCorrect = true;
    }
    else
    {
        Console.WriteLine("Błędna wartość, podaj liczbę produktów większą od 0.");
    }
} while (!isCorrect);

Product[] products = new Product[productCount];
for (int i = 0; i < productCount; i++)
{
    Product product = new Product();
    product.ID = i;
    Console.WriteLine("Podaj nazwe produktu: " + i);

    product.Name = Console.ReadLine();

    isCorrect = false;
    do
    {
        Console.WriteLine("Podaj ilość produktów: ");
        int count = 0;
        if (int.TryParse(Console.ReadLine(), out count) && count > 0)
        {
            isCorrect = true;
            product.Count = count;
        }
        else
        {
            Console.WriteLine("Błędna wartość, podaj ilość produktów większą od 0.");
        }
    } while (!isCorrect);

    isCorrect = false;
    do
    {
        Console.WriteLine("Podaj cene produktu: ");
        double price = 0.0;
        if (double.TryParse(Console.ReadLine(), out price) && price > 0)
        {
            isCorrect = true;
            product.Price = price;
        }
        else
        {
            Console.WriteLine("Błędna wartość, podaj cene produktu większą od 0.");
        }
    } while (!isCorrect);


    products[i] = product;
}

Console.WriteLine("RACHUNEK:");
double sumPrice = 0;
for (int i = 0; i < products.Length; i++)
{
    double totalPrice = products[i].Price * products[i].Count;
    Console.WriteLine(products[i].Count + " x " + products[i].Name + ' ' + products[i].Price + "zł " + totalPrice + "zł");
    sumPrice += totalPrice;
}
Console.WriteLine("Suma do zapłaty: " + Math.Round(sumPrice, 2) + "zł");

do
{
    Console.WriteLine("Otrzymana gotówka:");
    double cash = 0.0;
    isCorrect = false;
    if (double.TryParse(Console.ReadLine(), out cash) && cash > 0)
    {
        double rest = cash - sumPrice;
        if (rest >= 0)
        {
            Console.WriteLine("Reszta:" + Math.Round(rest, 2) + "zł");
            isCorrect = true;
        }
        else
        {
            Console.WriteLine("Nie stać Cię.");
        }
    }
    else
    {
        Console.WriteLine("Błędna wartość, podaj cene produktu większą od 0.");
    }
} while (!isCorrect);

var close = false;
do
{
    Console.WriteLine("1. Pokaż najtańszy produkt:");
    Console.WriteLine("2. Pokaż najdroższy produkt:");
    Console.WriteLine("3. Pokaż liczbę wszystkich produktów:");
    Console.WriteLine("4. Pokaż produkt którego sprzedano najwięcej:");
    Console.WriteLine("5. Pokaż produkt którego sprzedano najmniej:");
    Console.WriteLine("6. Wyjście");
    var opcja = 0;
    isCorrect = false;
    do
    {
        Console.WriteLine("Wybierz opcję (1-4): ");
        // Naprawa warunku sprawdzającego poprawność opcji
        if (int.TryParse(Console.ReadLine(), out opcja) && opcja >= 1 && opcja <= 4)
        {
            isCorrect = true;
        }
        else
        {
            Console.WriteLine("Błędna wartość, wybierz opcję z zakresu 1-4.");
        }
    } while (!isCorrect);

    switch (opcja)
    {
        case 1:
            Product minPrice = products.OrderBy(product => product.Price).First();
            Console.WriteLine(minPrice.Name + ' ' + minPrice.Price + "zł ");

            break;
        case 2:
            Product maxPrice = products.OrderBy(product => product.Price).Last();
            Console.WriteLine(maxPrice.Name + ' ' + maxPrice.Price + "zł ");

            break;
        case 3:
            int totalCount = 0;
            foreach (var item in products)
            {
                totalCount += item.Count;
            }

            Console.WriteLine("Sprzedano " + totalCount + " produktów");
            break;
        case 4:
            Product maxCount = products.OrderBy(product => product.Count).Last();
            foreach (var item in products)
            {
                if (item.Count == maxCount.Count)
                {
                    Console.WriteLine(item.Name + " x " + item.Count);
                }
            }
            break;
        case 5:
            Product minCount = products.OrderBy(product => product.Count).Last();
            foreach (var item in products)
            {
                if (item.Count == minCount.Count)
                {
                    Console.WriteLine(item.Name + " x " + item.Count);
                }
            }
            break;
        case 6:
            close = true;
            break;
    }
} while (!close);