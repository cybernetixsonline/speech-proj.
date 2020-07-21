using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CybernetixOnline
{
    public partial class Form1 : Form
    {
        Universe univers = new Universe();
        ModulRec modulRec;

        public Form1()
        {
            InitializeComponent();

            univers.form1 = this;
            modulRec = new ModulRec(univers);
            univers.modulRec.Run();
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            univers.modulRec.Sonjasay(" herzlich willkommen zu part 2 ");
        }

 
    }
}
