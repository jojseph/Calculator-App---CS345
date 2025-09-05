namespace calculator
{
    public partial class Form1 : Form
    {
        string currentInput = "";
        double result = 0.0;
        string operation = "";
        bool operationPending = false;
        bool justComputed = false; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Evaluate()
        {
            if (operationPending && !string.IsNullOrEmpty(currentInput))
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
                        case "×":
                            result *= number;
                            break;
                        case "÷":
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
                    }

                    textBox.Text = result.ToString();
                    textBox1.Text = ""; 
                    currentInput = "";
                    operation = "";
                    operationPending = false;
                    justComputed = true;
                }
                else
                {
                    MessageBox.Show("Invalid input");
                    Clear();
                }
            }
        }

        private void Clear()
        {
            currentInput = "";
            result = 0.0;
            operation = "";
            operationPending = false;
            justComputed = false;
            textBox.Text = "";
            textBox1.Text = "";
        }

        private void ShowPreview()
        {
            if (operationPending && !string.IsNullOrEmpty(currentInput))
            {
                double number;
                if (double.TryParse(currentInput, out number))
                {
                    double previewResult = result;
                    switch (operation)
                    {
                        case "+":
                            previewResult += number;
                            break;
                        case "-":
                            previewResult -= number;
                            break;
                        case "×":
                            previewResult *= number;
                            break;
                        case "÷":
                            if (number != 0)
                                previewResult /= number;
                            else
                            {
                                textBox1.Text = "Error: Division by zero";
                                return;
                            }
                            break;
                    }
                    textBox1.Text = previewResult.ToString();
                }
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (justComputed)
            {
                textBox.Text = "";
                justComputed = false;
            }

            currentInput += button.Text;

            if (operationPending)
            {
                textBox.Text = result.ToString() + operation + currentInput;
            }
            else
            {
                textBox.Text = currentInput;
            }

            ShowPreview();
        }

        private void button0_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button1_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button2_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button3_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button4_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button5_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button6_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button7_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button8_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button9_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(currentInput))
            {
                if (operationPending)
                {
                    Evaluate();

                    if (!string.IsNullOrEmpty(textBox.Text))
                    {
                        result = double.Parse(textBox.Text);
                    }
                }
                else
                {
                    result = double.Parse(currentInput);
                }

                operation = button.Text;
                operationPending = true;
                justComputed = false;
                textBox.Text = result.ToString() + operation;
                currentInput = "";
                textBox1.Text = ""; 
            }
            else if (justComputed && !string.IsNullOrEmpty(textBox.Text))
            {
                result = double.Parse(textBox.Text);
                operation = button.Text;
                operationPending = true;
                justComputed = false;
                textBox.Text = result.ToString() + operation;
                currentInput = "";
                textBox1.Text = "";
            }
        }

        private void buttonplus_Click(object sender, EventArgs e) { OperationButton_Click(sender, e); }
        private void buttonminus_Click(object sender, EventArgs e) { OperationButton_Click(sender, e); }
        private void buttonmultiply_Click(object sender, EventArgs e) { OperationButton_Click(sender, e); }
        private void buttondivide_Click(object sender, EventArgs e) { OperationButton_Click(sender, e); }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonequals_Click(object sender, EventArgs e)
        {
            Evaluate();
        }

        private void button_percent_Click(object sender, EventArgs e)
        {
            double number;
            if (double.TryParse(currentInput, out number))
            {
                number /= 100.0;
                currentInput = number.ToString();

                if (operationPending)
                {
                    textBox.Text = result.ToString() + operation + currentInput;
                }
                else
                {
                    textBox.Text = currentInput;
                }

                ShowPreview();
            }
            else
            {
                MessageBox.Show("Invalid input for percentage");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_backspace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);

                if (operationPending)
                {
                    textBox.Text = result.ToString() + operation + currentInput;
                }
                else
                {
                    textBox.Text = currentInput;
                }

                ShowPreview();
            }
            else if (operationPending && !string.IsNullOrEmpty(operation))
            {
                operation = "";
                operationPending = false;
                currentInput = result.ToString();
                textBox.Text = currentInput;
                textBox1.Text = ""; 
            }
            else if (!operationPending && !string.IsNullOrEmpty(textBox.Text))
            {
                string displayText = textBox.Text;
                if (displayText.Length > 1)
                {
                    displayText = displayText.Substring(0, displayText.Length - 1);
                    textBox.Text = displayText;
                    currentInput = displayText;
                }
                else
                {
                    Clear();
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                if (justComputed)
                {
                    textBox.Text = "";
                    justComputed = false;
                }

                if (string.IsNullOrEmpty(currentInput))
                {
                    currentInput = "0.";
                }
                else
                {
                    currentInput += ".";
                }

                if (operationPending)
                {
                    textBox.Text = result.ToString() + operation + currentInput;
                }
                else
                {
                    textBox.Text = currentInput;
                }

                ShowPreview();
            }
        }
    }
}