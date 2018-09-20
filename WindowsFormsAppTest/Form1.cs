using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsAppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Init();
        }


        BindingSource bsTestObjects = new BindingSource();
        BindingSource bsParameters = new BindingSource();
        BindingSource bsQualityParameters = new BindingSource();

        public void Init()
        {
            InitBS();

            dataGridView1.DataSource = bsTestObjects;
            dataGridViewParameters.DataSource = bsParameters;
            dataGridViewQualityParameters.DataSource = bsQualityParameters;

            InitChart();
        }

        void InitBS()
        {
            bsTestObjects.DataSource = TestWorld.GetTestObjects();
            bsParameters.DataSource = bsTestObjects;
            bsParameters.DataMember = "Parameters";

            bsQualityParameters.DataSource = bsTestObjects;
            bsQualityParameters.DataMember = "QualityParameters";

            textBoxDescription.DataBindings.Add("Text", bsTestObjects, "Id");
            textBoxName.DataBindings.Add("Text", bsTestObjects, "Name");
        }

        void InitChart()
        {
            this.chart1.Series.Clear();

            this.chart1.Titles.Add("Total test performed");

            Series series = this.chart1.Series.Add("Total test performed");
            series.ChartType = SeriesChartType.Spline;
            series.Points.AddXY("September", 100);
            series.Points.AddXY("October", 300);
            series.Points.AddXY("November", 800);
            series.Points.AddXY("December", 200);
            series.Points.AddXY("January", 600);
            series.Points.AddXY("February", 400);
            series.Points.AddXY("Mars", 300);
            series.Points.AddXY("April", 500);


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chart1.Series!=null && chart1.Series.Count > 0)
                this.chart1.Series[0].ChartType = SeriesChartType.RangeColumn;
        }
    }

    public class TestWorld
    {
        public static List<TestObject> GetTestObjects()
        {
            var tos = new List<TestObject>();


            for (int n = 1; n < 20; n++)
            {
                var to = new TestObject()
                {
                    Id = $"Test object {n}", Name=$"Name {n}",
                    Parameters = new List<Parameter>()
                    { new Parameter() { Name="ReadXIOEmz", Description="Xenon IO Emz Measurement", Value=9},
                      new Parameter() { Name="ReadXIOAph", Description="Xenon IO Aph Measurement", Value=7}}
                };

                for(int j=1; j < 20; j++)
                {
                    to.Parameters.Add(new Parameter() { Name = $"{n} ReadXIOAph {j}", Description = "Xenon IO Aph Measurement", HejHa=$"Hej och hå nr {j}", Value = j });
                    to.QualityParameters.Add(new Parameter() { Name = $"{n} Quality {j}", Description = "xxxx", HejHa = $"Hej och hå nr {j}", Value = j });
                }

                tos.Add(to);
            }
            return tos;
        }
    }

    public class TestObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();
        public List<Parameter> QualityParameters { get; set; } = new List<Parameter>();
        public List<TestObject> Children { get; set; }= new List<TestObject>();
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public string HejHa { get; set; }
    }
}
