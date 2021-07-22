namespace Calculator
{
    using System;
    using System.Windows.Forms;
    using Calculator.Helpers;

    public partial class FuelcostCalculatorForm : Form
    {
        public FuelcostCalculatorForm()
        {
            this.InitializeComponent();
        }

        private void FuelcostCalculatorForm_Load(object sender, EventArgs e)
        {
            this.tripDistanceTextBox.Text = "100";
            this.fuelEfficiencyTextBox.Text = "6.0";
            this.fuelPriceLiterTextBox.Text = "1.55";
            this.resultLabel.Text = "Result will be displayed here.";
        }

        private void FuelcostCalculatorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            this.resultLabel.Text = string.Empty;

            try
            {
                if (!double.TryParse(this.tripDistanceTextBox.Text, out double tripDistance))
                {
                    throw new ArgumentException(nameof(tripDistance));
                }

                if (!double.TryParse(this.fuelEfficiencyTextBox.Text, out double fuelEfficiency))
                {
                    throw new ArgumentException(nameof(fuelEfficiency));
                }

                if (!decimal.TryParse(this.fuelPriceLiterTextBox.Text, out decimal fuelPriceLiter))
                {
                    throw new ArgumentException(nameof(fuelPriceLiter));
                }

                var fuelCalculator = new FuelcostCalculator(tripDistance, fuelEfficiency, fuelPriceLiter);
                this.resultLabel.Text = fuelCalculator.GetTripCostFormatted();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private static void ShowExceptionMessage(Exception ex)
        {
            MessageBox.Show(
                new Form { TopMost = true },
                ex.Message,
                ex.GetType().ToString(),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
