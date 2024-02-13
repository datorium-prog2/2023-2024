using System.Text;
using System.Text.Json;

namespace DataStructures
{
    public class Cars
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }

    public class FilesExample
    {
        
        private string path = ".\\information.txt";
        public FilesExample() {
            CreateInformation();
            var car = ReadFileInformation();
            Console.WriteLine(car.Name);
            Console.WriteLine(car.Description);
            Console.WriteLine(car.Brand);
            Console.WriteLine(car.Color);
        }

        public void CreateInformation()
        {
            var car = new Cars()
            {
                Name = "winterbeaters",
                Brand = "BMW",
                Description = "Apraksts",
                Color = "Black"
            };
            var stream = File.Create(path); //Izveido failu konkrētajā atrašanās vietā un atver stream

            var serializedCar = JsonSerializer.Serialize(car); //Pārveido cars objektu uz string
            byte[] bytes = Encoding.ASCII.GetBytes(serializedCar); // Pārveido string uz byte[]

            stream.Write(bytes); //Ievada byte masīvu failā
            stream.Close(); // Aizver stream
        }

        public Cars ReadFileInformation()
        {
            StreamReader sr = File.OpenText(path); //atver failu un atver Stream
            string information = sr.ReadToEnd(); // Nolasam byte[] no faila un pārveidojam uz string

            return JsonSerializer.Deserialize<Cars>(information); //string pārveidojam uz cars objektu
        }
    }
}
