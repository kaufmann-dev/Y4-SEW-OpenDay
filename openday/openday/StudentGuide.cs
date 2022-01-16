using System;
using System.Threading;

namespace openday {
    public class StudentGuide {
        public static SemaphoreSlim waitforcall = new SemaphoreSlim(0);
        public static SemaphoreSlim waitforend = new SemaphoreSlim(0);
        public void Run() {
            while(true)
            {
                VisitorGroup.waitforguide.Release();
                waitforcall.Wait();
                
                BeginningTour();
                VisitorGroup.waitforbeginn.Release();
                waitforend.Wait();
                
                EndingTour();
            }
        }
        private void BeginningTour(){
            Console.WriteLine("Beginning Tour");
            Thread.Sleep(500);
        }
        private void EndingTour(){
            Thread.Sleep(800);
            Console.WriteLine("Ending Tour");
        }

    }
}