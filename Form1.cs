namespace XBLA_AUTOCSHARP
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer tmr;

        public Form1()
        {
            InitializeComponent();
            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                this.Close();
            };
            tmr.Interval = (int)TimeSpan.FromMinutes(0.0025).TotalMilliseconds;
            tmr.Start();
        }
    }
}