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
            VideoCapture capture1 = new VideoCapture(0); //create a camera capture
            Console.WriteLine("Child thread 1 created camera capture");
            Bitmap image1 = capture1.QueryFrame().ToBitmap(); //take a picture
            Console.WriteLine("Child thread 1 took a photo");
            //Saving photos into folder
            string FileName = System.IO.Path.Combine(@"C:\Users\Admin\Downloads\JC", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image1.Save(FileName +"1" + ".jpg");
            Console.WriteLine("Child thread 1 saved an image in the folder");
        }
        public static void ChildThread2()
        {
            Console.WriteLine("Child 2 thread starts");
            VideoCapture capture2 = new VideoCapture(1); //create a camera capture
            Console.WriteLine("Child thread 2 created camera capture");
            Bitmap image2 = capture2.QueryFrame().ToBitmap(); //take a picture
            Console.WriteLine("Child thread 2 took a photo");

            string FileName = System.IO.Path.Combine(@"C:\Users\Admin\Downloads\JC", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image2.Save(FileName + "2" + ".jpg");
            Console.WriteLine("Child thread 2 saved an image in the folder");
        }

        public static void ChildThread3()
        {
            Console.WriteLine("Child 3 thread starts");
            VideoCapture capture3 = new VideoCapture(2); //create a camera capture
            Console.WriteLine("Child thread 3 created camera capture");
            Bitmap image3 = capture3.QueryFrame().ToBitmap(); //take a picture
            Console.WriteLine("Child thread 3 took a photo");

            string FileName = System.IO.Path.Combine(@"C:\Users\Admin\Downloads\JC", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image3.Save(FileName + "3" + ".jpg");
            Console.WriteLine("Child thread 3 saved an image in the folder");
        }

        public static void ChildThread4()
        {
            Console.WriteLine("Child 4 thread starts");
            VideoCapture capture4 = new VideoCapture(3); //create a camera capture
            Console.WriteLine("Child thread 4 created camera capture");
            Bitmap image4 = capture4.QueryFrame().ToBitmap(); //take a picture
            Console.WriteLine("Child thread 4 took a photo");

            string FileName = System.IO.Path.Combine(@"C:\Users\Admin\Downloads\JC", DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss"));
            image4.Save(FileName + "4" + ".jpg");
            Console.WriteLine("Child thread 4 saved an image in the folder");
        }

        static void Main(string[] args)
        {
            int start = 1;
            while (start == 1)
            {
                //ChildThread1();
                //ChildThread2();
                //ChildThread3();
                //ChildThread4();
                System.Threading.ThreadStart childref1 = new ThreadStart(ChildThread1);
                System.Threading.ThreadStart childref2 = new ThreadStart(ChildThread2);
                System.Threading.ThreadStart childref3 = new ThreadStart(ChildThread3);
                System.Threading.ThreadStart childref4 = new ThreadStart(ChildThread4);

                //Console.WriteLine("In Main: Creating the Child threads");
                Thread childThread1 = new Thread(childref1);
                childThread1.Start();

                Thread childThread2 = new Thread(childref2);
                childThread2.Start();

                Thread childThread3 = new Thread(childref3);
                childThread3.Start();

                Thread childThread4 = new Thread(childref4);
                childThread4.Start();

                Console.Write("Another image? (1 or 0): ");
                start = Convert.ToInt32(Console.ReadLine());
            }
            
            
        }
    }
}
