using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTest
{
    public partial class LMS : Form
    {
        public LMS()
        {
            InitializeComponent();

            this.IsMdiContainer = true;

            InitMenu();
        }

        protected void InitMenu()
        {
            var mainMenu = new MainMenu();

            var TAS = new MenuItem("TAS");
            mainMenu.MenuItems.Add(TAS);

            var s = new MenuItem("Samples");
            s.Click += To_Click;
            TAS.MenuItems.Add( s);

            var to = new MenuItem("Test Object Explorer");
            to.Click += To_Click1;
            TAS.MenuItems.Add(to);

            var stat = new MenuItem("Statistics");
            stat.Click += Stat_Click;
            TAS.MenuItems.Add(stat);

            this.Menu = mainMenu;            
        }

        private void Stat_Click(object sender, EventArgs e)
        {
            var form = new Statistics();
            form.MdiParent = this;
            form.Show();
        }

        private void To_Click1(object sender, EventArgs e)
        {
            var form = new TestObjectExplorer();
            form.MdiParent = this;
            form.Show();
        }

        private void To_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.MdiParent = this;
            form.Show();
        }
    }
}
