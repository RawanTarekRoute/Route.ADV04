namespace Route.ADV04
{
    internal class SyncDataServices
    {
        public string FetchDataFromDatabase()
        {
            Console.WriteLine($"{Environment.CurrentManagedThreadId} fetching data from database");
            Thread.Sleep(2000); // external response => replied
            return "Data from database";
        }

        public string FetchDataFromAPI()
        {
            Console.WriteLine($"{Environment.CurrentManagedThreadId} fetching data from API");
            Thread.Sleep(2000);
            return "Data from API";
        }

        public string Calculate(int price)
        {
            Console.WriteLine($"{Environment.CurrentManagedThreadId} calculating");
            Thread.Sleep(1000);

            return $"Calculated data is {price}";

        }
    }
}
