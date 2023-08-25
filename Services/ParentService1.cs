namespace Testing.Services
{
    // this service uses the three services in line 10, it is the same as ParentService2
    public class ParentService1
    {
        public SingletonService SingletonService { get; set; }
        public ScopedService ScopedService { get; set; }
        public TransientService TransientService { get; set; }

        public ParentService1(SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            SingletonService = singletonService;
            ScopedService = scopedService;
            TransientService = transientService;
        }

        // show the guid of those services' instance
        public void Write()
        {
            Console.WriteLine($"From ParentService1: Singleton {SingletonService.guid}, Scoped: {ScopedService.guid}, Transient: {TransientService.guid}.");
        }
    }
}
