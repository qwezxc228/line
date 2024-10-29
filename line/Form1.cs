namespace line
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            private Random random = new Random();
        private Point line1Start;
        private Point line1End;
        private Point line2Start;
        private Point line2End;

        public LineIntersectionForm()
        {
            this.ClientSize = new Size(800, 600);
            this.Text = "Line Intersection";
            this.Paint += new PaintEventHandler(OnPaint);

           
            GenerateRandomLines();
        }

        private void GenerateRandomLines()
        {
            line1Start = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
            line1End = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
            line2Start = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
            line2End = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Рисуем линии
            e.Graphics.DrawLine(Pens.Black, line1Start, line1End);
            e.Graphics.DrawLine(Pens.Green, line2Start, line2End);

            // Проверка пересечения
            bool intersection = DoIntersect(line1Start, line1End, line2Start, line2End);
            if (intersection)
            {
                MessageBox.Show("Линии пересекаются");
            }
            else
            {
                MessageBox.Show("Линии не пересекаются");
            }
        }

        private bool DoIntersect(Point p1, Point q1, Point p2, Point q2)
        {
            int o1 = Orientation(p1, q1, p2);
            int o2 = Orientation(p1, q1, q2);
            int o3 = Orientation(p2, q2, p1);
            int o4 = Orientation(p2, q2, q1);

            // Общий случай
            if (o1 != o2 && o3 != o4)
            {
                return true;
            }

            return false; 
        }

        private int Orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            if (val == 0)
            {
                return 0;
            }
            return (val > 0) ? 1 : 2; // 1 - по часовой стрелке, 2 - против часовой стрелки
        }

        [STAThread]
        public static void Main()
        {
            Application.Run(new LineIntersectionForm());
        }
    }
}
        
            
    
    
