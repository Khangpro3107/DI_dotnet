namespace Testing.Services
{
    public class ManualService
    {
        public string id;
        public IConsoleWriteService writeService;
        // in the below ctor, note that aside from the dep writeService, an id is passed in
        public ManualService(IConsoleWriteService writeService, string id) {
            this.writeService = writeService;
            this.id = id;
            Console.WriteLine("ManualService created" + this.id);
        }
    }
}
