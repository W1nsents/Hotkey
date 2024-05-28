using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotkeyer
{
    class Program
    {

        public static Form1 form;

        public static bool toggleHandle = false;    

        public static Keys keys = Keys.X;

        public static void Main(string[] args)
        {
            form = new Form1();

            Console.WriteLine("[+] Run hotkeys");
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(RunHotkeys);
            timer.Start();

            Console.WriteLine("[+] Run applications");
            form.ShowDialog();

            Console.ReadLine();
        }

        private static void RunHotkeys(object sender, EventArgs e)
        {
            if (Hotkeys.isKeyPress(keys, ref toggleHandle))
            {
                form.checkBox1.Checked = !form.checkBox1.Checked;
            }
        }
    }

    class Hotkeys
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public static bool isKeyHold(Keys key)
        {
            if (GetAsyncKeyState(key) < 0)
            {
                return true;
            }
            return false;
        }

        public static bool isKeyUp(Keys key)
        {
            if (GetAsyncKeyState(key) >= 0)
            {
                return true;
            }
            return false;
        }

        public static bool isKeyPress(Keys key, ref bool handled)
        {
            if ((GetAsyncKeyState(key) < 0) && handled == false)
            {
                handled = true;
                return true;
            }
            else if (GetAsyncKeyState(key) == 0)
            {
                handled = false;
            }
            return false;
        }
    }
}
