namespace Testing.Services
{
    // this will be registered in Program.cs as scoped
    public class ScopedService
    {
        public static int count = 0;    // indicates how many instances were created
        public Guid guid;           // 'G'lobal 'U'nique 'Id'entifier -> an id for each individual instance
        //public void func
        public ScopedService()
        {
            count++;
            this.guid = Guid.NewGuid();
            Console.WriteLine($"Scoped Dependency created: {this.guid}. Count: {count}");
        }
    }
}
