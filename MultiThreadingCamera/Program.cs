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
            Console.WriteLine("Child thread 1 created camera capture");
            Bitmap image1 = capture.QueryFrame().ToBitmap(); //take a picture
            Console.WriteLine("Child thread 1 took a photo");
            //Saving photos into folder
            string FileName = System.IO.Path.Combine(@"C:\Users\jiacheng\Downloads", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image1.Save(FileName + ".jpg");
            Console.WriteLine("Child thread 1 saved an image in the folder");
        }
        public static void ChildThread2()
        {
            Console.WriteLine("Child 2 thread starts");

            VideoCapture capture = new VideoCapture(1); //create a camera capture
            Console.WriteLine("Child thread 2 created camera capture");
            Bitmap image2 = capture.QueryFrame().ToBitmap(); //take a picture
            Console.WriteLine("Child thread 2 took a photo");
            // the thread is paused for 1500 milliseconds
            //int sleepfor = 1500;

            //Console.WriteLine("Child Thread 2 Paused for {0} seconds", sleepfor / 1000);
            //Thread.Sleep(sleepfor);
            //Console.WriteLine("Child thread 2 resumes");

            //Saving photos into folder
            string FileName = System.IO.Path.Combine(@"C:\Users\jiacheng\Downloads", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image2.Save(FileName + ".jpg");
            Console.WriteLine("Child thread 2 saved an image in the folder");
        }

        public static void ChildThread3()
        {
            Console.WriteLine("Child 3 thread starts");

            VideoCapture capture = new VideoCapture(2); //create a camera capture
            Console.WriteLine("Child thread 3 created camera capture");
            Bitmap image3 = capture.QueryFrame().ToBitmap(); //take a picture
            Console.WriteLine("Child thread 3 took a photo");
            // the thread is paused for 1500 milliseconds
            //int sleepfor = 1500;

            //Console.WriteLine("Child Thread 2 Paused for {0} seconds", sleepfor / 1000);
            //Thread.Sleep(sleepfor);
            //Console.WriteLine("Child thread 2 resumes");

            //Saving photos into folder
            string FileName = System.IO.Path.Combine(@"C:\Users\jiacheng\Downloads", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image3.Save(FileName + ".jpg");
            Console.WriteLine("Child thread 3 saved an image in the folder");
        }

        static void Main(string[] args)
        {

            System.Threading.ThreadStart childref1 = new ThreadStart(ChildThread1);
            System.Threading.ThreadStart childref2 = new ThreadStart(ChildThread2);
            System.Threading.ThreadStart childref3 = new ThreadStart(ChildThread3);

            Console.WriteLine("In Main: Creating the Child threads");

            Thread childThread1 = new Thread(childref1);
            childThread1.Start();

            Thread childThread2 = new Thread(childref2);
            childThread2.Start();

            Thread childThread3 = new Thread(childref3);
            childThread3.Start();

            Console.ReadKey();
        }
    }
}
