using System;
using System.Drawing;
using System.Threading;
using VisioForge.Controls.UI.WinForms;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Emgu.CV;
using VideoCapture = Emgu.CV.VideoCapture;

namespace Multi_Threading_Camera
{
    class Program
    {
        public static void ChildThread1()
        {
            Console.WriteLine("Child 1 thread starts");

            VideoCapture capture = new VideoCapture(); //create a camera capture
            Bitmap image1 = capture.QueryFrame().ToBitmap(); //take a picture
            //Saving photos into folder
            string FileName = System.IO.Path.Combine(@"C:\Users\jiacheng\Downloads", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image1.Save(FileName + ".jpg");
            Console.WriteLine("Child thread 1 saved an image in the folder");
        }
        public static void ChildThread2()
        {
            Console.WriteLine("Child 2 thread starts");

            VideoCapture capture = new VideoCapture(1); //create a camera capture
            Bitmap image = capture.QueryFrame().ToBitmap(); //take a picture

            // the thread is paused for 1500 milliseconds
            int sleepfor = 1500;

            Console.WriteLine("Child Thread 2 Paused for {0} seconds", sleepfor / 1000);
            Thread.Sleep(sleepfor);
            Console.WriteLine("Child thread 2 resumes");

            //Saving photos into folder
            string FileName = System.IO.Path.Combine(@"C:\Users\jiacheng\Downloads", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image.Save(FileName + ".jpg");
            Console.WriteLine("Child thread 2 saved an image in the folder");
        }

        static void Main(string[] args)
        {
            System.Threading.ThreadStart childref1 = new ThreadStart(ChildThread1);
            System.Threading.ThreadStart childref2 = new ThreadStart(ChildThread2);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread2 = new Thread(childref2);
            childThread2.Start();

            Thread childThread1 = new Thread(childref1);
            childThread1.Start();
            Console.ReadKey();
        }
    }
}
