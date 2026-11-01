using System.Diagnostics;

namespace Route.ADV04
{
 
    internal class Program
    {
        public static async Task<string> GreetUserWithName(string name)
        {
            await Task.Delay(5000);
            return $"Hello {name}";
        }


        static async Task Main(string[] args)
        {
            #region Synchronous vs asyncronous

            // Core idea [Synchronous]: Synchronous operations block the thread until the heavy operation is complete, which can lead to inefficiencies and poor responsiveness in applications.
            // I/O operation examples: Reading a file, making a network request, querying a database, etc.
            // CPU-bound operation examples: Complex calculations, data processing, image rendering, etc.


            // Core idea [Asynchronous]: Asynchronous operations allow the thread to continue executing other tasks while waiting for the heavy operation to complete, improving efficiency and responsiveness.


            //SyncDataServices syncDataServices = new();

            //Stopwatch stopwatch = Stopwatch.StartNew();

            //string dbResult = syncDataServices.FetchDataFromDatabase();
            //string apiResult = syncDataServices.FetchDataFromAPI();
            //string calculatedResult = syncDataServices.Calculate(100);

            //stopwatch.Stop();

            //Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");




            //AsyncDataServices asyncDataServices = new();

            //Stopwatch stopwatch = Stopwatch.StartNew();

            //string dbResult = await asyncDataServices.FetchFromDatabaseAsync();
            //string apiResult = await asyncDataServices.FetchFromApiAsync();
            //string calculatedResult = await asyncDataServices.CalculateAsync(100);

            //stopwatch.Stop();
            //Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");



            #endregion

            #region Task

            // Task: Represents an asynchronous operation that can be awaited.
            // It allows you to perform work in the background without blocking the main thread.

            // 1. Task.Run: It is used to run a task on a separate thread from the thread pool.
            // 2. Task.Delay: It creates a task that completes after a specified time delay.
            // 3. Task.Result: It blocks the calling thread until the task completes and returns the result. (Not recommended in async code)
            // 4. Task.Wait: It blocks the calling thread until the task completes. (Not recommended in async code)
            // 5. Task.FromResult: It creates a completed task with a specified result. 


            // Task States
            // 1. Created: The task has been initialized but not yet started.
            // 2. WaitingForActivation: The task is waiting for another task to complete before it can start executing.
            // 3. Running: The task is currently executing.
            // 4. RanToCompletion: The task has completed successfully.
            // 5. Faulted: The task has completed with an unhandled exception.
            // 6. Canceled: The task has been canceled before it could complete.


            //TaskExamples taskExamples = new();
            ////await taskExamples.DoWorkAsync();
            ////Console.WriteLine("Task finished");

            //string cacheHit = await taskExamples.GetCacheValue(100);
            //Console.WriteLine(cacheHit);


            //string cacheMiss = await taskExamples.GetCacheValue(400);
            //Console.WriteLine(cacheMiss);


            //Task<int> task = Task.Run(async () =>
            //{
            //    await Task.Delay(2000);

            //    //....
            //    return 20;
            //});

            //await task;

            //Console.WriteLine(task.Status);
            //Console.WriteLine(task.IsCompleted);


            //Task task = Task.Run(async () =>
            //{
            //    throw new InvalidOperationException("Invalid Operation happened");
            //});


            ////.....

            //try
            //{
            //    await task;
            //}
            //catch
            //{
            //    Console.WriteLine("Exception");
            //}


            //Console.WriteLine(task.Status);
            //Console.WriteLine(task.IsCompleted);
            //Console.WriteLine(task.IsCompletedSuccessfully);
            //Console.WriteLine(task.IsFaulted);
            #endregion

            #region Sync vs async

            //Console.WriteLine(Environment.CurrentManagedThreadId);
            //string message = await GreetUserWithName("Rawan");
            //Console.WriteLine(Environment.CurrentManagedThreadId);

            //Task<string> task = GreetUserWithName("Rawan");
            //Console.WriteLine(task.IsCompleted);



            #endregion

            #region WhenAll() & WhenAny()

            // 1. Task.WhenAll: It is used to wait for multiple tasks to complete.
            //      - It returns a task that completes when all the provided tasks have completed.


            // 2. Task.WhenAny: It is used to wait for any one of the provided tasks to complete.
            //      - First task to complete will be returned, and the rest of the tasks will continue executing in the background.
            //      - Timeout: You can use Task.WhenAny in combination with Task.Delay to implement a timeout mechanism for tasks.
            //      - If the specified timeout duration elapses before any of the tasks complete, you can handle the timeout scenario accordingly.


            //AsyncDataServices services = new AsyncDataServices();

            //Stopwatch stopwatch = Stopwatch.StartNew();
            //string[] results = await Task.WhenAll(services.FetchFromDatabaseAsync(), services.FetchFromApiAsync(), services.CalculateAsync(200));

            //stopwatch.Stop();
            //Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");



            AsyncDataServices services = new AsyncDataServices();

            //Stopwatch stopwatch = Stopwatch.StartNew();
            //Task<string> winnerTask = await Task.WhenAny(services.FetchFromDatabaseAsync(), services.FetchFromApiAsync(), services.CalculateAsync(200));

            //stopwatch.Stop();
            //Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");

            //Console.WriteLine(await winnerTask);


            Task<string> downloadTask = services.DownloadFile("File 01");

            Task timeoutTask = Task.Delay(1000);
            Task winner = await Task.WhenAny(downloadTask, timeoutTask);


            if (winner == downloadTask)
                Console.WriteLine("download task is the winner");
            else
                Console.WriteLine("timeout task is the winner");

            #endregion

            #region HandleExceptions

            // Exception in any async method is stored inside the Task object.
            // When you await the task, the exception is re-thrown, allowing you to handle it using try-catch blocks.

            // If we have multiple tasks and one of them throws an exception, you can check the InnerExceptions property of the AggregateException to access all the exceptions thrown by the tasks.




            #endregion

        }
    }
}
