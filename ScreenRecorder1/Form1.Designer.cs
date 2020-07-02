namespace ScreenRecorder1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Player_pictureBox = new System.Windows.Forms.PictureBox();
            this.FPS_textBox = new System.Windows.Forms.TextBox();
            this.current_fps_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Player_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Player_pictureBox
            // 
            this.Player_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Player_pictureBox.Location = new System.Drawing.Point(115, 64);
            this.Player_pictureBox.Name = "Player_pictureBox";
            this.Player_pictureBox.Size = new System.Drawing.Size(568, 323);
            this.Player_pictureBox.TabIndex = 0;
            this.Player_pictureBox.TabStop = false;
            // 
            // FPS_textBox
            // 
            this.FPS_textBox.Location = new System.Drawing.Point(115, 406);
            this.FPS_textBox.Name = "FPS_textBox";
            this.FPS_textBox.Size = new System.Drawing.Size(100, 20);
            this.FPS_textBox.TabIndex = 1;
            // 
            // current_fps_label
            // 
            this.current_fps_label.AutoSize = true;
            this.current_fps_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.current_fps_label.Location = new System.Drawing.Point(337, 409);
            this.current_fps_label.Name = "current_fps_label";
            this.current_fps_label.Size = new System.Drawing.Size(30, 13);
            this.current_fps_label.TabIndex = 2;
            this.current_fps_label.Text = "FPS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.current_fps_label);
            this.Controls.Add(this.FPS_textBox);
            this.Controls.Add(this.Player_pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Player_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Player_pictureBox;
        private System.Windows.Forms.TextBox FPS_textBox;
        private System.Windows.Forms.Label current_fps_label;
    }
}

