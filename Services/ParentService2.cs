namespace Testing.Services
{
    // the same as ParentService1
    public class ParentService2
    {
        public SingletonService SingletonService { get; set; }
        public ScopedService ScopedService { get; set; }
        public TransientService TransientService { get; set; }

        public ParentService2(SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            SingletonService = singletonService;
            ScopedService = scopedService;
            TransientService = transientService;
        }

        public void Write()
        {
            Console.WriteLine($"From ParentService2: Singleton {SingletonService.guid}, Scoped: {ScopedService.guid}, Transient: {TransientService.guid}.");
        }
    }
}
