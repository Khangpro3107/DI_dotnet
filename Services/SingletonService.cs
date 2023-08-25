namespace Testing.Services
{
    // this will be registered in Program.cs as singleton
    // refer to ScopedService to understand the below logic
    public class SingletonService
    {
        public static int count = 0;
        public Guid guid;
        public SingletonService()
        {
            count++;
            this.guid = Guid.NewGuid();
            Console.WriteLine($"Singleton Dependency created: {this.guid}. Count: {count}");
        }
    }
}
