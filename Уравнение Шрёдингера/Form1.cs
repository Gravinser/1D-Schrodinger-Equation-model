namespace Уравнение_Шрёдингера
{
    public partial class Form1 : Form
    {
        const int n = 1000;
        const double dt = 0.001;
        const double dx = 1;
        const int l = 300;
        const double h = 1;
        const double m = 1;

        double[][] f = new double[l][];
        double[][] f1 = new double[l][];
        double[] U = new double[l];

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < l; i++)
            {
                f[i] = new double[2];
                f1[i] = new double[2];
                //f[i][0] = (float)Math.Sin(((double)i) / l * Math.PI * 5);
                f[i][0] = Math.Exp(-Math.Pow(i - l / 2 + 100, 2) / 300 / Math.Sqrt(2));
                f[i][1] = 0;
                U[i] = Math.Pow((i - l / 2), 2) / 100000;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int ni = 0; ni < n; ni++)
            {
                for (var i = 0; i < l; i++)
                    f1[i][0] = f[i][0] + dtf(f, i, 0) * dt;
                for (var i = 0; i < l; i++)
                    f[i][0] = f1[i][0];
                for (var i = 0; i < l; i++)
                    f1[i][1] = f[i][1] + dtf(f, i, 1) * dt;
                for (var i = 0; i < l; i++)
                    f[i][1] = f1[i][1];
            }
            norm();
            Plot.Invalidate();
        }
        private double dtf(double[][] f, int i, int r)
        {
            int ri = 1 - r, k = 2 * ri - 1;
            return -k * (-dx2f(f, i, ri) * h * h / (2 * m) + U[i] * f[i][ri]) / h;
        }
        private double dx2f(double[][] f, int i, int r)
        {
            return (f[mod(i + 1, l)][r] + f[mod(i - 1, l)][r] - 2 * f[i][r]) / (dx * dx);
        }
        private int mod(int a, int b)
        {
            if (a >= 0) return a % b;
            else return b + (a + 1) % b - 1;
        }
        private void norm()
        {
            double sum = 0;
            for (int i = 0; i < l; i++)
                sum += (f[i][0] * f[i][0] + f[i][1] * f[i][1]) / l;
            for (int i = 0; i < l; i++)
            {
                f[i][0] /= Math.Sqrt(sum);
                f[i][1] /= Math.Sqrt(sum);
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
                fm[i] = new Point((int)(((float)i) / (l - 1) * sx), (int)(-(f[i][0] * f[i][0] + f[i][1] * f[i][1]) * 10 + sy / 2));
                u[i] = new Point((int)(((float)i) / (l - 1) * sx), (int)(-U[i] * 1000 + sy / 2));
            }
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawLines(new Pen(Color.Black, 2), u);
            e.Graphics.DrawLines(new Pen(Color.Red, 2), fr);
            e.Graphics.DrawLines(new Pen(Color.Blue, 2), fi);
            e.Graphics.DrawLines(new Pen(Color.Green, 2), fm);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
                for (int i = 0; i < l; i++)
                {
                    f[i][0] = Math.Exp(-Math.Pow(i - l / 2 + 100, 2) / 300 / Math.Sqrt(2));
                    f[i][1] = 0;
                }
        }
    }
}