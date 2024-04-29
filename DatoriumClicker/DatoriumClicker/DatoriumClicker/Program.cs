
using DatoriumClicker;

class CookieClicker
{
    static CookieService CookieService = new CookieService();
    static void Main(string[] args) //FRONTENDS
    {
        Thread backgroundThread = new Thread(Background);
        backgroundThread.IsBackground = true;
        backgroundThread.Start();

        Console.WriteLine("Spied SPACE, lai iegūtu cepumus.");
        Console.WriteLine("Q, lai izietu no spēles");

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                CookieService.AddCookie();
            }
            else if (keyInfo.Key == ConsoleKey.Q)
            {
                Console.WriteLine($"Paldies, ka spēlēji. Tu spēli beidzi ar {CookieService.Cookies} cepumiem!");
                break;
            }
            else if (keyInfo.Key == ConsoleKey.D1)
            {
                CookieService.BuyItem(new Elchin());
            }
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                CookieService.BuyItem(new Stove());
            }
            PrintMenu();
        }
    }

    static void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine($"Tu ieguvi cepumu! Tagad tev ir: {CookieService.Cookies} cepumi!");
        foreach (var item in CookieService.Items)
        {
            Console.WriteLine($"Tev pieder {item.Count} {item.Name}! Jauns maksā: {item.Price} cepumus!");
        }
    }

    static void Background()
    {
        while (true)
        {
            Thread.Sleep(5000);
            CookieService.AddPassiveCookies();
            PrintMenu();
        }
    }
}