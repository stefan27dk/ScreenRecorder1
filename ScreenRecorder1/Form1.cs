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
        // Recording Size
        Size CaptureSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);



         // Capture Thread
        Thread captureThread;

        // Captured Frame
        Bitmap Frame_Bmp1;



        // Last image for disposing
        Bitmap LatImage;


        int count_FPS = 0;
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

            //!!!!!!!!!!!!!!!!!!!!!!!TEST

            this.BackColor = Color.Red;

          
            
        }


 


         

        // Load
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
            


            while (true)
            {
                    // Count Frames
                    count_FPS++;


                   //Display FPS:::START:::
                   if(check_Time == 1)
                   {

                      Invoke(new Action(() =>
                      {
                          current_fps_label.Text = count_FPS.ToString(); // Display FPS
                      }));

                     check_Time = 0; // Reset
                     count_FPS = 0; // Reset
                   }
                //Display FPS:::END:::



                // Image::::::START::::::::
                Frame_Bmp1 = new Bitmap(CaptureSize.Width, CaptureSize.Height); // BMP
                   Graphics g = Graphics.FromImage(Frame_Bmp1); // Graphics
                   g.CopyFromScreen(Point.Empty, Point.Empty, CaptureSize); // Screen To BMP
                   // Image::::::END::::::::






                // Display::::::START:::::::
                Invoke(new Action(() =>
                {
                    Player_pictureBox.BackgroundImage = Frame_Bmp1;
                    Player_pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                }));
                // Display::::::END:::::::





                //CLEAN:::::::START:::::::

                // Dispose Last Image
                if (Frame_Bmp1 != LatImage && LatImage != null)
                {
                    LatImage.Dispose();
                }


                // Assign Last Image 
                LatImage = Frame_Bmp1;
                g.Dispose();

                //CLEAN:::::::END:::::::




               
                //FPS::Settings:::::START:::::::
                int.TryParse(FPS_textBox.Text, out int fps);  
                Thread.Sleep(fps); // THREAD SLEEP   
                //FPS::Settings:::::END:::::::


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

