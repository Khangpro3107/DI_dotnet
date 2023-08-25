namespace Testing.Services
{
    public interface IConsoleWriteServiceChild
    {
        void Write(string message);
    }

    // this service is the same as ConsoleWriteService, but it is meant to be its child
    public class ConsoleWriteServiceChild: IConsoleWriteServiceChild
    {
        public ConsoleWriteServiceChild()
        {
            Console.WriteLine("ConsoleWriteServiceChild created");
        }
        public void Write(string message) {
            Console.WriteLine(message);
        }
    }
}
