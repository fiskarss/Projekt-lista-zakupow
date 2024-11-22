namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            int productCount = 0;
            bool isCorrect = false;


            do
            {
                Console.WriteLine("Podaj liczbę produktów: ");
                if (int.TryParse(Console.ReadLine(), out productCount) && productCount > 0)
                {
                    isCorrect = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("Błędna wartość, podaj liczbę produktów większą od 0.");
                    Console.ResetColor(); 
                }
            } while (!isCorrect);

            Product[] products = new Product[productCount];

            for (int i = 0; i < productCount; i++)
            {
                Product product = new Product();
                product.ID = i;
                Console.WriteLine($"Podaj nazwę produktu {i + 1}: ");
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Błędna wartość, podaj ilość produktów większą od 0.");
                        Console.ResetColor();
                    }
                } while (!isCorrect);

                isCorrect = false;
                do
                {
                    Console.WriteLine("Podaj cenę produktu: ");
                    double price = 0.0;
                    if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                    {
                        isCorrect = true;
                        product.Price = price;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Błędna wartość, podaj cenę produktu większą od 0.");
                        Console.ResetColor();
                    }
                } while (!isCorrect);


                products[i] = product;
            }

            
            Console.WriteLine("\nRACHUNEK:");
            double sumPrice = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10} {4,-10}", "Ilość", "Produkt", "Cena Jedn.", "Razem", "Suma");

            foreach (var product in products)
            {
                double totalPrice = product.Price * product.Count;
                Console.WriteLine("{0,-5} {1,-20} {2,-10:C} {3,-10:C} {4,-10:C}",
                    product.Count, product.Name, product.Price, totalPrice, totalPrice);
                sumPrice += totalPrice;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSuma do zapłaty: {0:C}", sumPrice);

            
            double cash = 0.0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Otrzymana gotówka:");
                if (double.TryParse(Console.ReadLine(), out cash) && cash > 0)
                {
                    double rest = cash - sumPrice;
                    if (rest >= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Reszta: {0:C}", rest);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("Nie stać Cię.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Błędna wartość, podaj kwotę.");
                    Console.ResetColor();
                }
            } while (true);


            bool close = false;
            do
            {
                Console.ResetColor();
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Pokaż najtańszy produkt");
                Console.WriteLine("2. Pokaż najdroższy produkt");
                Console.WriteLine("3. Pokaż liczbę wszystkich produktów");
                Console.WriteLine("4. Pokaż produkt, którego sprzedano najwięcej");
                Console.WriteLine("5. Pokaż produkt, którego sprzedano najmniej");
                Console.WriteLine("6. Wyjście");

                int opcja;
                do
                {
                    Console.WriteLine("Wybierz opcję (1-6): ");
                    if (int.TryParse(Console.ReadLine(), out opcja) && opcja >= 1 && opcja <= 6)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Błędna wartość, wybierz opcję z zakresu 1-6.");
                        Console.ResetColor();
                    }
                } while (true);

                switch (opcja)
                {
                    case 1:
                        var minPriceProduct = products.OrderBy(p => p.Price).First();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Najtańszy produkt: {minPriceProduct.Name}, cena: {minPriceProduct.Price:C}");
                        break;
                    case 2:
                        var maxPriceProduct = products.OrderByDescending(p => p.Price).First();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Najdroższy produkt: {maxPriceProduct.Name}, cena: {maxPriceProduct.Price:C}");
                        break;
                    case 3:
                        int totalCount = products.Sum(p => p.Count);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Łączna liczba sprzedanych produktów: {totalCount}");
                        break;
                    case 4:
                        var maxSoldProduct = products.OrderByDescending(p => p.Count).First();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Produkt, którego sprzedano najwięcej: {maxSoldProduct.Name}, ilość: {maxSoldProduct.Count}");
                        break;
                    case 5:
                        var minSoldProduct = products.OrderBy(p => p.Count).First();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Produkt, którego sprzedano najmniej: {minSoldProduct.Name}, ilość: {minSoldProduct.Count}");
                        break;
                    case 6:
                        close = true;
                        break;
                }
            } while (!close);
        }
    }
}



