using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace ScreenRecorder1
{
    public partial class Form1 : Form
    {
        // Recording Size
        Size CaptureSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);



         // Capture Thread 1
        Thread captureThread1;      
                                   
        
         // Capture Thread 2
        Thread captureThread2;      



         // Capture Thread 3
        Thread captureThread3;      

                              
        // Capture Thread 4
        Thread captureThread4;      




        
          

        // Captured Frame
        Bitmap Frame_Bmp1;



        // Last image for disposing
        Bitmap LastImage;


        int count_FPS = 0;
        int check_Time = 0;

        private readonly object obj_lock = new object();


        public Form1()
        {
            InitializeComponent();  
        }





         //FPS:::::::::::::::::::::START:::::::

        //Timer FPS - Display
        System.Windows.Forms.Timer FPS_TimerSec;
  
        
        // FPS - Timer Settings
        private void FPS_TimerSec_Settings()
        {
            FPS_TimerSec = new System.Windows.Forms.Timer();
            FPS_TimerSec.Interval = 1000;
            FPS_TimerSec.Tick += new EventHandler(FPS_TimerSec_Tick);
            FPS_TimerSec.Enabled = true;
            FPS_TimerSec.Start();
            
        }


         // FPS -Timer - Tick
        void FPS_TimerSec_Tick(object sender, EventArgs e)
        {
              
            current_fps_label.Text = count_FPS.ToString(); // Display FPS
            count_FPS = 0;
           
        }

        //FPS:::::::::::::::::::::END:::::::














        // Load
        private void Form1_Load(object sender, EventArgs e)
        {

            // Timer
            FPS_TimerSec_Settings();


            // Capture - Thread
            captureThread1 = new Thread(Record12);
            captureThread1.IsBackground = true;
            captureThread1.Start();


            //// Capture - Thread 2
            //captureThread2 = new Thread(Record12);
            //captureThread2.IsBackground = true;
            //captureThread2.Start();


            //// Capture - Thread 3
            //captureThread3 = new Thread(Record12);
            //captureThread3.IsBackground = true;
            //captureThread3.Start();





            //Player - Settings
            Player_pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

         
          
        }





        //private void Recording()
        //{


        //        Thread.Sleep(10);



        //     Task.Run(() => CaptureScreen());




        //}




       
        public void CaptureScreen()
        {

            // Count Frames
            count_FPS++;


     


            // Image::::::START::::::::
            Frame_Bmp1 = new Bitmap(CaptureSize.Width, CaptureSize.Height); // BMP
            Graphics g = Graphics.FromImage(Frame_Bmp1); // Graphics
            g.CopyFromScreen(Point.Empty, Point.Empty, CaptureSize); // Screen To BMP
                                                                     //Image::::::END::::::::

            g.Dispose();
            //var buffer = new byte[CaptureSize.Width * CaptureSize.Height * 4];

            //using (Frame_Bmp1 = new Bitmap(CaptureSize.Width, CaptureSize.Height))
            //using (Graphics g = Graphics.FromImage(Frame_Bmp1))
            //{

            //    g.CopyFromScreen(0, 0, 0, 0, CaptureSize);
            //    var bits = Frame_Bmp1.LockBits(new Rectangle(0, 0, CaptureSize.Width, CaptureSize.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            //    Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
            //    Frame_Bmp1.UnlockBits(bits);

            //    // Should also capture the mouse cursor here, but skipping for simplicity
            //    // For those who are interested, look at http://www.codeproject.com/Articles/12850/Capturing-the-Desktop-Screen-with-the-Mouse-Cursor



            //}






            //// Display::::::START:::::::
            //Invoke(new Action(() =>
            //{
            //    Player_pictureBox.BackgroundImage = Frame_Bmp1;
            //    Player_pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            //}));


            //// Display::::::END:::::::








            ////CLEAN:::::::START:::::::

            //// Dispose Last Image
            //if (Frame_Bmp1 != LastImage && LastImage != null)
            //{
            //    LastImage.Dispose();
            //}



            //// Assign Last Image 
            //LastImage = Frame_Bmp1;
            //g.Dispose();
            ////CLEAN:::::::END:::::::




            //FPS::Settings:::::START:::::::
            int.TryParse(FPS_textBox.Text, out int fps);
            Thread.Sleep(fps); // THREAD SLEEP   
                               //FPS::Settings:::::END:::::::



        }









        // Aborts the Thread On Form Close // Stops Crashing on Form CLose
        protected override void OnClosing(CancelEventArgs e)
        {
            if(captureThread1.IsAlive)
            {
                captureThread1.Abort();
            }

            base.OnClosing(e);
        }




            
           public  void Record12()
           {
                  //Bitmap bmp = null;


              while(true)
              {

               
               
                        Task.Delay(40).Wait();


                    Task.Run(() =>
                    {
                        count_FPS++;




                        //CaptureScreen();



                        CaptureImage();



                              


                        ////CLEAN:::::::START:::::::

                        //// Dispose Last Image
                        //if (Frame_Bmp1 != LastImage && LastImage != null)
                        //{
                        //    LastImage.Dispose();
                        //}



                        //// Assign Last Image 
                        //LastImage = Frame_Bmp1;
                        ////g.Dispose();    
                        ////CLEAN:::::::END:::::::


                    });
         

              }
        }








    
        private  Bitmap CaptureImage()
        {
            Bitmap b = new Bitmap(CaptureSize.Width, CaptureSize.Height);
             

            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(0, 0, 0, 0, CaptureSize, CopyPixelOperation.SourceCopy);

            }


            Invoke(new Action(() =>
            {
                if (Player_pictureBox.Image != null) Player_pictureBox.Image.Dispose();

                Player_pictureBox.Image = b.Clone(
                new Rectangle(0, 0, b.Width, b.Height),
                System.Drawing.Imaging.PixelFormat.DontCare);


                //Player_pictureBox.BackgroundImage = 
                //Player_pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            }));

            return b;

        }











































        ////private void button1_Click(object sender, EventArgs e)
        ////{
        ////    Bitmap bmp = null;
        ////    sw.Restart();
        ////    for (int i = 0; i < 1000; i++)
        ////    {
        ////        bmp = CaptureImage(390, 420);

        ////        // Display::::::START:::::::
        ////        Invoke(new Action(() =>
        ////        {
        ////            Player_pictureBox.BackgroundImage = bmp;
        ////            Player_pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
        ////        }));


        //    }
        //    sw.Stop();
        //    Console.WriteLine(sw.ElapsedMilliseconds);
        //}
























        //public Task MethodA()
        //{

        //    while(true)
        //    {
        //      Task.Run(() => CaptureScreen());

        //    }


        //}







        //private void RecordScreen()
        //{
        //    var stopwatch = new Stopwatch();
        //    var buffer = new byte[CaptureSize.Width * CaptureSize.Height * 4];

        //    Task videoWriteTask = null;

        //    IAsyncResult videoWriteResult = null;

        //    var isFirstFrame = true;
        //    var shotsTaken = 0;
        //    var timeTillNextFrame = TimeSpan.Zero;
        //    stopwatch.Start();

        //    while (!stopThread.WaitOne(timeTillNextFrame))
        //    {
        //        GetScreenshot(buffer);
        //        shotsTaken++;

        //        // Wait for the previous frame is written
        //        if (!isFirstFrame)
        //        {

        //            videoWriteTask.Wait();

        //            videoStream.EndWriteFrame(videoWriteResult);

        //            videoFrameWritten.Set();
        //        }

        //        //if (audioStream != null)
        //        //{
        //        //    var signalled = WaitHandle.WaitAny(new WaitHandle[] { audioBlockWritten, stopThread });
        //        //    if (signalled == 1)
        //        //        break;
        //        //}

        //        // Start asynchronous (encoding and) writing of the new frame

        //        videoWriteTask = videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length);

        //        videoWriteResult = videoStream.BeginWriteFrame(true, buffer, 0, buffer.Length, null, null);


        //        timeTillNextFrame = TimeSpan.FromSeconds(shotsTaken / (double)writer.FramesPerSecond - stopwatch.Elapsed.TotalSeconds);
        //        if (timeTillNextFrame < TimeSpan.Zero)
        //            timeTillNextFrame = TimeSpan.Zero;

        //        isFirstFrame = false;
        //    }

        //    stopwatch.Stop();

        //    // Wait for the last frame is written
        //    if (!isFirstFrame)
        //    {

        //        videoWriteTask.Wait();

        //        videoStream.EndWriteFrame(videoWriteResult);

        //    }
        //}

        //private void GetScreenshot(byte[] buffer)
        //{
        //    using (var bitmap = new Bitmap(screenWidth, screenHeight))
        //    using (var graphics = Graphics.FromImage(bitmap))
        //    {
        //        graphics.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(screenWidth, screenHeight));
        //        var bits = bitmap.LockBits(new Rectangle(0, 0, screenWidth, screenHeight), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
        //        Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
        //        bitmap.UnlockBits(bits);

        //        // Should also capture the mouse cursor here, but skipping for simplicity
        //        // For those who are interested, look at http://www.codeproject.com/Articles/12850/Capturing-the-Desktop-Screen-with-the-Mouse-Cursor
        //    }
        //}





















    }




}

