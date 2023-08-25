namespace Testing.Services
{
    // interface for ConsoleWriteService
    public interface IConsoleWriteService
    {
        void Write(string message);
    }

    // a service that simply logs
    public class ConsoleWriteService: IConsoleWriteService
    {
        public ConsoleWriteServiceChild serviceChild;
        //public IServiceProvider serviceProvider;      // refer to line 20

        public ConsoleWriteService(ConsoleWriteServiceChild consoleWriteServiceChild)
        {
            Console.WriteLine("ConsoleWriteService created");
            this.serviceChild = consoleWriteServiceChild;
        }

        // the below ctor (line 22) uses IServiceProvider to retrieve deps manually (instead of relying on the default DI)

        //public ConsoleWriteService(ConsoleWriteServiceChild consoleWriteServiceChild, IServiceProvider serviceProvider)
        //{
        //    Console.WriteLine("ConsoleWriteService created");
        //    this.serviceChild = consoleWriteServiceChild;
        //    this.serviceProvider = serviceProvider;
        //    Console.WriteLine("Here: " + serviceProvider.GetRequiredService<SingletonService>().guid);
        //}


        public void Write(string message) {
            Console.WriteLine(message);
            this.serviceChild.Write("Child " + message);
        }
    }

    public class ConsoleWriteService2: IConsoleWriteService     // this is meant for demonstrating using one interface to create many services, not used
    {
        public void Write(string message)
        {
            Console.WriteLine(message + "2");
        }
    }
}
