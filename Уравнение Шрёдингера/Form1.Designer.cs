namespace Уравнение_Шрёдингера
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            timer = new System.Windows.Forms.Timer(components);
            Plot = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Plot).BeginInit();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            // 
            // Plot
            // 
            Plot.BackColor = SystemColors.Control;
            Plot.Dock = DockStyle.Fill;
            Plot.Location = new Point(0, 0);
            Plot.Margin = new Padding(0);
            Plot.Name = "Plot";
            Plot.Size = new Size(782, 553);
            Plot.TabIndex = 0;
            Plot.TabStop = false;
            Plot.WaitOnLoad = true;
            Plot.Paint += Plot_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(Plot);
            Name = "Form1";
            ShowIcon = false;
            Text = "Schrodinger equation";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Plot).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private PictureBox Plot;
    }
}