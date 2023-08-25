namespace Testing.Services
{
    // this will be registered in Program.cs as transient
    // refer to ScopedService to understand the below logic
    public class TransientService
    {
        public static int count = 0;
        public Guid guid;
        public TransientService()
        {
            count++;
            this.guid = Guid.NewGuid();
            Console.WriteLine($"Transient Dependency created: {this.guid}. Count:  {count}");
        }
    }
}
