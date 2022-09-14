using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFrameworkDll
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Text = "123";
            form.ShowDialog();

        }
    }
}
