namespace SchoolChat
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Heading = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // Heading
            // 
            Heading.AutoSize = true;
            Heading.BackColor = Color.FromArgb(44, 44, 44);
            Heading.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Heading.ForeColor = SystemColors.ButtonFace;
            Heading.Location = new Point(241, 19);
            Heading.Name = "Heading";
            Heading.Size = new Size(304, 54);
            Heading.TabIndex = 0;
            Heading.Text = "School ChatGPT";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(44, 44, 44);
            pictureBox1.Location = new Point(-8, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 90);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(58, 58, 58);
            pictureBox2.Location = new Point(-8, 76);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(800, 30);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(44, 44, 44);
            pictureBox3.Location = new Point(-8, 639);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(800, 30);
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(44, 44, 44);
            pictureBox4.Location = new Point(-8, 106);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(200, 564);
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 33, 33);
            ClientSize = new Size(784, 661);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(Heading);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Heading;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}