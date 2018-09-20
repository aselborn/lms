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
    public partial class TestObjectExplorer : Form
    {
        public TestObjectExplorer()
        {
            InitializeComponent();

            PopulateTreeView();

            treeViewTO.AfterSelect += TreeViewTO_AfterSelect;
        }

        private void TreeViewTO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TestObject to = treeViewTO.SelectedNode.Tag as TestObject;

            if (to != null)
            {
                this.textBoxTOName.Text = to.Name;
            }
        }

        List<TestObject> GetTOs()
        {
            var tos = new List<TestObject>();

            for (int n = 1; n < 10; n++)
            {
                TestObject to = new TestObject() { Id = n.ToString(), Name = $"VX97235_AX_{n}", Version = $"1.2.7.{n}" };

                to.Children.Add(new TestObject() { Id = n.ToString(), Name = $"{to.Name}_12AZ33", Version = $"1.2.7.{n}" });
                to.Children.Add(new TestObject() { Id = n.ToString(), Name = $"{to.Name}_2Z_ALC", Version = $"1.2.7.{n}" });
                tos.Add(to);
            }

            foreach (var t in tos)
            {
                t.QualityParameters.Add(new Parameter() { Name = "Parameter", Description = "Description", Value = 99 });
            }

            return tos;
        }
        void PopulateTreeView()
        {
            var tos = GetTOs();

            foreach (var t in tos)
            {
                treeViewTO.Nodes.Add(new TreeNode() { Text = t.Name, Tag = t });

                foreach(var x in t.Children)
                {
                    treeViewTO.Nodes[tos.IndexOf(t)].Nodes.Add(new TreeNode() { Text=x.Name, Tag=x });
                }
            }
        }
    }
}
