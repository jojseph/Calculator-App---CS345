namespace calculator
{
    public partial class Form1 : Form
    {
        string currentInput = "";
        double result = 0.0;
        string operation = "";
        bool operationPending = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Evaluate()
        {
            double number;
            if (double.TryParse(currentInput, out number))
            {
                switch (operation)
                {
                    case "+":
                        result += number;
                        break;
                    case "-":
                        result -= number;
                        break;
                    case "*":
                        result *= number;
                        break;
                    case "/":
                        if (number != 0)
                        {
                            result /= number;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero");
                            Clear();
                            return;
                        }
                        break;
                    default:
                        result = number;
                        break;
                }
                textBox.Text = result.ToString();
                currentInput = result.ToString();
                operationPending = false;
            }
            else
            {
                MessageBox.Show("Invalid input");
                Clear();
            }
        }

        private void Clear()
        {
            currentInput = "";
            result = 0.0;
            operation = "";
            operationPending = false;
            textBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }

        private void buttonplus_Click(object sender, EventArgs e)
        {
            if(operationPending)
            {
                Evaluate();
            }
            operation = "+";
            operationPending = true;
            result = double.Parse(currentInput);
            currentInput = "";
            textBox.Text = currentInput;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox.Text = currentInput;
        }

        private void buttondivide_Click(object sender, EventArgs e)
        {
            if (operationPending)
            {
                Evaluate();
            }
            operation = "/";
            operationPending = true;
            result = double.Parse(currentInput);
            currentInput = "";
            textBox.Text = currentInput;
        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            if (operationPending)
            {
                Evaluate();
            }
            operation = "-";
            operationPending = true;
            result = double.Parse(currentInput);
            currentInput = "";
            textBox.Text = currentInput;
        }

        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            if (operationPending)
            {
                Evaluate();
            }
            operation = "*";
            operationPending = true;
            result = double.Parse(currentInput);
            currentInput = "";
            textBox.Text = currentInput;
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonequals_Click(object sender, EventArgs e)
        {
            Evaluate();
        }
    }
}
