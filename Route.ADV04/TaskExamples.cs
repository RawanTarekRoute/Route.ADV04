using System.Diagnostics.Tracing;

namespace Route.ADV04
{
    internal class TaskExamples
    {

        public async Task DoWorkAsync()
        {
            await Task.Delay(5000);
            Console.WriteLine("Task finished");
        }

        public async Task<int> CalculateAsync(int a, int b)
        {
            return await Task.FromResult(a + b);
        }


        // User -> Request,,  Server -> Database -> Data
        // Database -> Disk -> Server -> User

        // Load into the ram (memory)
        // User -> Request -> Server -> Cache (data loaded into the ram) -> result

        // Cache hit -> Data found into the cache -> return it.
        // Cache Miss -> Data is not found in the cache -> Database -> Date -> add in the cache -> Result -> Server -> User


        static readonly Dictionary<int, string> _students = new Dictionary<int, string>
        {
            [100] = "Mai",
            [200] = "Ali",
            [300] = "Hossam"
        };


        public ValueTask<string> GetCacheValue(int id)
        {
            if (_students.TryGetValue(id, out string? name))
                return new ValueTask<string>(name);

            return new ValueTask<string>(FetchStudetNameFromDatabaseAsync());

        }


        private async Task<string> FetchStudetNameFromDatabaseAsync()
        {
            await Task.Delay(5000);
            return "Name of student";
        }
    }
}
