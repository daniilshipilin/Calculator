namespace Calculator.Forms;

using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Forms;
using Calculator.Helpers;

public partial class CurrencyConverterForm : Form
{
    public CurrencyConverterForm()
    {
        this.InitializeComponent();
    }

    private void CurrencyConverterForm_Load(object sender, EventArgs e)
    {
        this.TopMost = AppSettings.TopMost;
        this.UpdateCurrenciesComboBoxes();
        this.UpdateCurrenciesRatesTextBoxes();
        this.statusLabel.Text = string.Empty;
    }

    private void CurrencyConverterForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }

    private async void ConvertButton_Click(object sender, EventArgs e) => await this.ConvertCurrency();

    private void SwitchButton_Click(object sender, EventArgs e)
    {
        string? tmpCurrencyFrom = this.currencyFromComboBox.SelectedItem.ToString();
        this.currencyFromComboBox.Text = this.currencyToComboBox.SelectedItem.ToString();
        this.currencyToComboBox.Text = tmpCurrencyFrom;

        CurrencyConverter.SwapAmounts();

        this.amountFromTextBox.Text = CurrencyConverter.AmountFrom.ToString();
        this.amountToTextBox.Text = CurrencyConverter.AmountTo.ToString();
    }

    private async void GetRatesButton_Click(object sender, EventArgs e)
    {
        this.DisableButtons();

        try
        {
            await this.UpdateCurrencyRates();
            this.updateCheckBox.Checked = false;
        }
        catch (Exception ex)
        {
            this.statusLabel.Text = "Error";
            MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            this.EnableButtons();
        }
    }

    private void UpdateCurrenciesComboBoxes()
    {
        // default currencies to look for, if there are no selected items
        string? currencyFrom = "EUR";
        string? currencyTo = "GBP";

        // checking whether currencies comboboxes have any selected items
        if (this.currencyFromComboBox.SelectedIndex != -1 && this.currencyToComboBox.SelectedIndex != -1)
        {
            currencyFrom = this.currencyFromComboBox.SelectedItem.ToString();
            currencyTo = this.currencyToComboBox.SelectedItem.ToString();
        }

        // bind currencies list with currencies combobox
        this.currencyFromComboBox.DataSource = new BindingSource { DataSource = CurrencyConverter.Currencies.Rates.Keys };
        this.currencyToComboBox.DataSource = new BindingSource { DataSource = CurrencyConverter.Currencies.Rates.Keys };

        // select previously selected item, because of index reset after data source update
        this.currencyFromComboBox.SelectedIndex = this.currencyFromComboBox.Items.IndexOf(currencyFrom);
        this.currencyToComboBox.SelectedIndex = this.currencyToComboBox.Items.IndexOf(currencyTo);
    }

    private void UpdateCurrenciesRatesTextBoxes()
    {
        if (this.currencyFromComboBox.SelectedItem is null || this.currencyToComboBox.SelectedItem is null)
        {
            return;
        }

        string? currencyFrom = this.currencyFromComboBox.SelectedItem.ToString();
        string? currencyTo = this.currencyToComboBox.SelectedItem.ToString();

        if (!string.IsNullOrEmpty(currencyFrom) && !string.IsNullOrEmpty(currencyTo))
        {
            CurrencyConverter.CalculateConversionRateTo(currencyFrom, currencyTo);
        }

        this.rateToTextBox.Text = CurrencyConverter.RateTo.ToString();
    }

    private async Task UpdateCurrencyRates()
    {
        this.statusLabel.Text = "Updating currency rates";

        await CurrencyConverter.UpdateCurrenciesAsync();

        this.UpdateCurrenciesComboBoxes();

        this.UpdateCurrenciesRatesTextBoxes();

        this.baseCurrencyTextBox.Text = CurrencyConverter.Currencies.Base;

        this.dateStampTextBox.Text = CurrencyConverter.Currencies.TimestampLocalDateTime.ToString();

        this.statusLabel.Text = "Currency rates updated";
    }

    private void CurrencyFromComboBox_SelectedIndexChanged(object sender, EventArgs e) => this.UpdateCurrenciesRatesTextBoxes();

    private void CurrencyToComboBox_SelectedIndexChanged(object sender, EventArgs e) => this.UpdateCurrenciesRatesTextBoxes();

    private async void AmountFromTextBox_TextChanged(object sender, EventArgs e)
    {
        if (!this.autoConvertCheckBox.Checked)
        {
            return;
        }

        await this.ConvertCurrency();
    }

    private async Task ConvertCurrency()
    {
        if (string.IsNullOrEmpty(this.amountFromTextBox.Text))
        {
            this.statusLabel.Text = "Amount textbox empty";
        }
        else
        {
            this.DisableButtons();
            this.statusLabel.Text = "Converting";

            try
            {
                // make new http request only, if previous request generated error or this is the first request
                if (this.updateCheckBox.Checked)
                {
                    await this.UpdateCurrencyRates();
                    this.updateCheckBox.Checked = false;
                }

                CurrencyConverter.ConvertCurrency(decimal.Parse(this.amountFromTextBox.Text));

                this.amountToTextBox.Text = CurrencyConverter.AmountTo.ToString();

                this.statusLabel.Text = "Converted";
            }
            catch (Exception ex)
            {
                this.statusLabel.Text = "Error";
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.EnableButtons();
            }
        }
    }

    private void EnableButtons()
    {
        this.getRatesButton.Enabled = true;
        this.convertButton.Enabled = true;
    }

    private void DisableButtons()
    {
        this.getRatesButton.Enabled = false;
        this.convertButton.Enabled = false;
    }

    private void RateToTextBox_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();

        foreach (var pair in CurrencyConverter.Currencies.Rates)
        {
            sb.AppendLine($"{pair.Key}: {pair.Value}");
        }

        var ratesForm = new RatesForm();
        ratesForm.ratesTextBox.Text = sb.ToString();
        ratesForm.ShowDialog();
    }
}
