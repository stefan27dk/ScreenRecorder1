using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenRecorder1
{
    public partial class Form1 : Form
    {
        Thread captureThread;
        Bitmap bmp1;

        Bitmap LatImage;
        int count_FPS;
        int check_Time = 0;


        public Form1()
        {
            InitializeComponent();  
        }




        //Timer
        System.Windows.Forms.Timer TimerSec;


        // FPS - Timer Settings
        private void TimerSec_Settings()
        {
            TimerSec = new System.Windows.Forms.Timer();
            TimerSec.Interval = 1000;
            TimerSec.Tick += new EventHandler(TimerSec_Tick);
            TimerSec.Enabled = true;
            TimerSec.Start();

        }


         // FPS -Timer - Tick
        void TimerSec_Tick(object sender, EventArgs e)
        {
            check_Time = 1;
        }


 
         


        private void Form1_Load(object sender, EventArgs e)
        {

            // Timer
            TimerSec_Settings();


            // Capture - Thread
            captureThread = new Thread(CaptureScreen);
            captureThread.IsBackground = true;
            captureThread.Start();     
        }




             

       // Capture Screen
        private void CaptureScreen()
        {
           
            while(true)
            {
                  
                   Rectangle screenBounds = Screen.GetBounds(Point.Empty);  // Screen Size
                   bmp1 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // BMP
                   Graphics g = Graphics.FromImage(bmp1); // Graphics
                   g.CopyFromScreen(Point.Empty, Point.Empty, screenBounds.Size); // Screen To BMP


                // Display
                Invoke(new Action(() =>
                {

                    Player_pictureBox.BackgroundImage = bmp1;
                    Player_pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                     
                }));    

                 // Dispose Last Image
                if (bmp1 != LatImage && LatImage != null)
                {
                    LatImage.Dispose();
                }

                // Assign Last Image 
                LatImage = bmp1;


                g.Dispose();
                //bmp1.Dispose();

                int.TryParse(FPS_textBox.Text, out int fps);
                Thread.Sleep(fps);



                //if (DateTime.Now.AddSeconds(1) <= 1000)
                //{
                //    count_FPS = count_FPS + 1;
                //}
                //else
                //{
                //    count_FPS = 0;
                //}
                //

                //count_FPS = count_FPS + 1;
                

                Invoke(new Action(() =>
                {
                    //current_fps_label.Text = count_FPS.ToString();
                    current_fps_label.Text = DateTime.Now.AddSeconds(1);

                }));

            }

         
                     
        }




        // Aborts the Thread On Form Close // Stops Crashing on Form CLose
        protected override void OnClosing(CancelEventArgs e)
        {
            if(captureThread.IsAlive)
            {
                captureThread.Abort();
            }

            base.OnClosing(e);
        }






    }




}

