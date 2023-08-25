using Microsoft.AspNetCore.Mvc;
using Testing.Services;

namespace Testing.Controllers
{
    public class LifetimeController: Controller
    {
        // this two services are the same, but they use those "lifetime services" for demonstrating the diffs between dep lifetimes
        public ParentService1 ParentService1 { get; set; }
        public ParentService2 ParentService2 { get; set; }
        public LifetimeController(ParentService1 parentService1, ParentService2 parentService2)
        {
            ParentService1 = parentService1;
            ParentService2 = parentService2;
        }

        [Route("/lifetime")]            // when the app is run, nevigate to this route to see this demonstration in effect
        public string Get()
        {
            this.ParentService1.Write();
            this.ParentService2.Write();
            return "LifetimeController";
        }
    }
}
