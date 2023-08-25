namespace Testing.Services
{
    // this service uses IEnumerable to capture all registered service of this type
    public class ManualService2
    {
        public IEnumerable<TransientService> TransientServices { get; set; }
        public ManualService2(IEnumerable<TransientService> transientServices) {
            this.TransientServices = transientServices;
            Console.WriteLine("ManualService2 created");
            Console.WriteLine("IEnumerable<TransientService> length: " + this.TransientServices.ToArray().Length);
        }
    }
}
