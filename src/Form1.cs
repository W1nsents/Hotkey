using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hotkeyer
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            KeysConverter Key = new KeysConverter();

            Program.keys = (Keys)Key.ConvertFromString(comboBox1.SelectedItem.ToString());
        }
    }
}
