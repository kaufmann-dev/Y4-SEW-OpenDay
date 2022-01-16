using System;
using System.Threading; 
    
namespace openday {
    public class VisitorGroup
    {
        public static SemaphoreSlim waitforguide = new SemaphoreSlim(0);
        public static SemaphoreSlim waitforbeginn = new SemaphoreSlim(0);
        public static SemaphoreSlim nwtk = new SemaphoreSlim(2);
        public static SemaphoreSlim chiodo = new SemaphoreSlim(1);
        public void Run()
        {
            waitforguide.Wait();
            
            AcknowledgeGuide();
            StudentGuide.waitforcall.Release();
            waitforbeginn.Wait();
            
            nwtk.Wait();
            VisitCrypt();
            nwtk.Release();
            
            chiodo.Wait();
            VisitPhotoStation();
            chiodo.Release();
            
            Console.WriteLine("Left building");
            StudentGuide.waitforend.Release();
        }
        private void AcknowledgeGuide(){
            Console.WriteLine("Acknowleding Guide");
            Thread.Sleep(100);
        }
        private void VisitCrypt(){
            Console.WriteLine("Visiting Crypt");
            Thread.Sleep(1000);
        }
        private void VisitPhotoStation(){
            Console.WriteLine("Visiting Photostation");
            Thread.Sleep(1500);
        }

    }
}