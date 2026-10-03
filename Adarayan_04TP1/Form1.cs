using System.Runtime.InteropServices;

namespace Adarayan_04TP1
{
    public partial class FrmTrackThread : Form
    {
        Thread threadA;
        Thread threadB;
        Thread threadC;
        Thread threadD;
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public FrmTrackThread()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "-Thread is running-";
            AllocConsole();
            threadA = new Thread(MyThreadClass.Thread1);
            threadA.Name = "threadA";
            threadA.Priority = ThreadPriority.Highest;


            threadB = new Thread(MyThreadClass.Thread2);
            threadB.Name = "threadB";
            threadB.Priority = ThreadPriority.Normal;


            threadC = new Thread(MyThreadClass.Thread1);
            threadC.Name = "threadC";
            threadC.Priority = ThreadPriority.AboveNormal;


            threadD = new Thread(MyThreadClass.Thread2);
            threadD.Name = "threadD";
            threadD.Priority = ThreadPriority.BelowNormal;

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();
             
            Console.WriteLine("\n");

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            Console.WriteLine("-End of Thread-");
            label1.Text = "-End of Thread-";

        }
    }

}
