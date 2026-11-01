using System;
using System.Collections.Generic;
using System.Text;

namespace Route.ADV04
{
    internal class AsyncDataServices
    {
        public async Task<string> FetchFromDatabaseAsync()
        {
            Console.WriteLine($"{Environment.CurrentManagedThreadId} fetching data from database");
            await Task.Delay(2000);

            Console.WriteLine($"{Environment.CurrentManagedThreadId} fetching data from database");

            return "Data from database";

        }

        public async Task<string> FetchFromApiAsync()
        {
            Console.WriteLine($"{Environment.CurrentManagedThreadId} fetching data from API");
            await Task.Delay(2000);

            Console.WriteLine($"{Environment.CurrentManagedThreadId} fetching data from API");

            return "Data from API";

        }


        public async Task<string> CalculateAsync(int price)
        {
            Console.WriteLine($"{Environment.CurrentManagedThreadId} calculating");
            await Task.Delay(1000);

            Console.WriteLine($"{Environment.CurrentManagedThreadId} calculating");

            return $"Calculated data is {price}";
        }

        public async Task<string> DownloadFile (string fileName)
        {
            await Task.Delay(5000);
            return "File downloaded successfully";
        }
    }
}
