using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EM.Calc.Core;

namespace EM.Calc.WinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnExec.Enabled = false;
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

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            btnExec.Enabled = !string.IsNullOrEmpty(tbInput.Text);
        }

        private void cbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var operation = Calc.Operations
                .OfType<IExtOperation>()
                .FirstOrDefault(o => o.Name == cbOperation.Text)
                ;

            if (operation != null)
            {
                toolTip1.SetToolTip(cbOperation, operation.Description);
            }
            else toolTip1.SetToolTip(cbOperation, "Это старая операция");
        }
    }
}
