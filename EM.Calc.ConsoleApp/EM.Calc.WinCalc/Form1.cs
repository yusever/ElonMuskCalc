using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EM.Calc.WinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Core.Calc Calc { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            Calc = new Core.Calc();

            string[] operations = Calc.Operations.Select(o => o.Name).ToArray();

            cbOperation.Items.AddRange(operations);
        }

        private void btnExec_Click(object sender, EventArgs e)
        {

            //получить операнды
            var values = tbInput.Text.Split(' ').Select(Convert.ToDouble).ToArray();

            //получить операции
            var operation = cbOperation.Text;

            //создаем калькулятор
            Calc = new Core.Calc();

            //делаем расчет
            var result = Calc.Execute(operation, values);

            //выводим результат
            //lblResult.Text = string.Format("Result = {0}", result);
            lblResult.Text = $"{result}";
        }
    }
}
