using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace PoisonousApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Search by Species Name: ");
            Console.WriteLine("2. Search by Species ID: ");
            Console.WriteLine("3. End: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Please enter the name of the animal you would like to search for: ");
                string animal = Console.ReadLine();
                await SearchBySpecies(animal);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Please enter the ID fo the animal you would like to search for: ");
                int TaxonID = Convert.ToInt32(Console.ReadLine());
                await SpeciesByTaxon(TaxonID);
            }
            else
            {
                return;
            }
            
        }
        private static async Task SpeciesByTaxon(int TaxonID)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://apps.des.qld.gov.au/species/?op=getspeciesbyid&taxonid=" + TaxonID);
            var speciesresult = await JsonSerializer.DeserializeAsync<GetSpeciesByID>(await streamTask);

            var msg = await streamTask;
            Console.Write(msg);
        }
        private static async Task SearchBySpecies(string animal)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"https://apps.des.qld.gov.au/species/?op=speciessearch&kingdom=animals&species={animal}");
            var speciesresult = await JsonSerializer.DeserializeAsync<SpeciesSearch>(await streamTask);

            var msg = await streamTask;
            Console.Write(msg);
        }
    }
}
