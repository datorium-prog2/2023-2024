using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HashsetExample
    {
        public HashsetExample() {
            var tezaurs = new Dictionary<string, string>();
            tezaurs.Add("Pulss", "Asinsvadu sienu periodisks viļņojums, ko rada to tilpuma, spiediena un asins plūsmas ātruma svārstības sirds sistoles un diastoles laikā.");
            tezaurs.Add("Pulkstenis", "Ierīce laika mērīšanai.");
            tezaurs.Add("Pulveris", "Smalki sasmalcināta kristāliska vai amorfa viela (daļiņu izmēri 10-8 līdz 10-3 m); iegūst ar fizikālmehāniskām metodēm (cietu vielu maļ, saberž) un fizikālķīmiskām metodēm (izgulsnējot, sublimējot, elektrolizējot, izmantojot zemas temperatūras plazmu); lieto dažādu pastu izgatavošanai..");

            var dictionary = new Dictionary<string, string[]>();

            dictionary.Add("Pul", new string[]{ "Pulss", "Pulkstenis", "Pulveris"});

            foreach (var item in dictionary["Pul"])
            {
                Console.WriteLine(tezaurs[item]);
            }
        }
    }
}
