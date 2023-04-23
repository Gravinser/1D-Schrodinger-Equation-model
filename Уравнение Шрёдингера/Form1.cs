namespace Уравнение_Шрёдингера
{
    public partial class Form1 : Form
    {
        static int n = 5000;
        static float dt = 0.0002F;
        static float dx = 1;
        static int l = 300;

        static float h = 1;
        static float m = 1;

        float[][] f = new float[l][];
        float[] U = new float[l];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < l; i++)
            {
                f[i] = new float[2];
                //f[i][0] = (float)Math.Sin(((double)i) / l * Math.PI * 5);
                f[i][0] = (float)Math.Exp(-Math.Pow(i - l / 2 + 100, 2) / 300);
                f[i][1] = 0;
                U[i] = (float)Math.Pow((i - l / 2), 2) / 100000;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int ni = 0; ni < n; ni++)
            {
                float[][] f1 = new float[l][];
                for (int i = 1; i < l - 1; i++)
                {
                    f1[i] = new float[2];
                    f1[i][0] = f[i][0] + (-(f[i - 1][1] + f[i + 1][1] - 2 * f[i][1]) / (dx * dx) * h / (2 * m) + U[i] * f[i][1] / h) * h * dt;
                    f1[i][1] = f[i][1] + ((f[i - 1][0] + f[i + 1][0] - 2 * f[i][0]) / (dx * dx) * h / (2 * m) - U[i] * f[i][0] / h) * dt;
                }
                for (int i = 1; i < l - 1; i++)
                {
                    f[i][0] = f1[i][0];
                    f[i][1] = f1[i][1];
                }
            }
            norm();
            Plot.Invalidate();
        }

        private void norm()
        {
            float sum = 0;
            for (int i = 0; i < l; i++)
                sum += (f[i][0] * f[i][0] + f[i][1] * f[i][1]) / l;
            for (int i = 0; i < l; i++)
            {
                f[i][0] *= (float)(1 / Math.Sqrt(sum));
                f[i][1] *= (float)(1 / Math.Sqrt(sum));
            }
        }

        private void Plot_Paint(object sender, PaintEventArgs e)
        {
            int sx = Plot.Size.Width;
            int sy = Plot.Size.Height;
            Point[] fr = new Point[l];
            Point[] fi = new Point[l];
            Point[] fm = new Point[l];
            Point[] u = new Point[l];
            for (int i = 0; i < l; i++)
            {
                fr[i] = new Point((int)(((float)i) / (l - 1) * sx), (int)(-f[i][0] * 20 + sy / 2));
                fi[i] = new Point((int)(((float)i) / (l - 1) * sx), (int)(-f[i][1] * 20 + sy / 2));
                fm[i] = new Point((int)(((float)i) / (l - 1) * sx), (int)(-(f[i][0] * f[i][0] + f[i][1] * f[i][1]) * 20 + sy / 2));
                u[i] = new Point((int)(((float)i) / (l - 1) * sx), (int)(-U[i] * 1000 + sy / 2));
            }
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawLines(new Pen(Color.Black, 2), u);
            e.Graphics.DrawLines(new Pen(Color.Red, 2), fr);
            e.Graphics.DrawLines(new Pen(Color.Blue, 2), fi);
            e.Graphics.DrawLines(new Pen(Color.Green, 2), fm);
        }
    }
}