using Microsoft.VisualBasic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

public class Program
{

    static HttpClient client = new HttpClient();

    public async static Task Main()
    {
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
        {
            using HttpResponseMessage response = await client.GetAsync("https://data.gov.lv/dati/lv/api/3/action/datastore_search?resource_id=92ac6e57-c5a5-444e-aaca-ae90c120cc3d");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);
            var recycleObject = JsonSerializer.Deserialize<RecycleResponse>(responseBody);

            if (recycleObject == null || recycleObject.Result == null || recycleObject.Result.Records.Count == 0)
            {
                throw new Exception("Ir saņemts tukšs masīvs");
            }

            //Izvadīt attiecīgā atkritumu nodošanas punkta adresi, kurā var nodot baterijas un
            //akumulatorus(1 punkts).

            var batteries = recycleObject.Result.Records.Where(x => x.Batteries == "x");
            if (!batteries.Any())
            {
                Console.WriteLine("Baterijas nevar nodot nekur");
            }

            foreach (var battery in batteries)
            {
                Console.WriteLine(battery.Address);
                Console.WriteLine(battery.City);
            }

            var tires = recycleObject.Result.Records.Where(x => x.Tires == "x");
            if (!tires.Any())
            {
                Console.WriteLine("Riepas nevar nodot nekur");
            }

            foreach (var tire in tires)
            {
                Console.WriteLine(tire.Address);
                Console.WriteLine(tire.City);
            }

            var plastics = recycleObject.Result.Records.Where(x => x.Plastic == "x");
            if (!plastics.Any())
            {
                Console.WriteLine("Plastmasu nevar nodot nekur");
            }

            foreach (var plastic in plastics)
            {
                Console.WriteLine("Plastmasu var nodot " + plastic.Address);
                Console.WriteLine(plastic.City);
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }
}