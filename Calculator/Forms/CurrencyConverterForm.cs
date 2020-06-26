using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.CurrencyConverter;
using Calculator.Forms;

namespace Calculator
{
    public partial class CurrencyConverterForm : Form
    {
        CurrencyConverterEngine _cce = null;

        Dictionary<string, decimal> _baseCurrenciesDict { get; } = new Dictionary<string, decimal>
        {
            { "EUR", 1},
            { "GBP", 0.885281M},
            { "USD", 1.1711M}
        };

        public CurrencyConverterForm()
        {
            InitializeComponent();

            _cce = new CurrencyConverterEngine("EUR", _baseCurrenciesDict, "http://data.fixer.io/api/latest?access_key=f864890aa3760d6e4a3bdd0a33e655be");
        }

        private void CurrencyConverterForm_Load(object sender, EventArgs e)
        {
            TopMost = Program.GlobalTopMost;

            UpdateCurrenciesComboBoxes();

            UpdateCurrenciesRatesTextBoxes();

            statusLabel.Text = string.Empty;
        }

        private void CurrencyConverterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        #region Click events

        private async void ConvertButton_Click(object sender, EventArgs e)
        {
            await ConvertCurrency();
        }

        private void SwitchButton_Click(object sender, EventArgs e)
        {
            string tmpCurrencyFrom = currencyFromComboBox.SelectedItem.ToString();
            currencyFromComboBox.Text = currencyToComboBox.SelectedItem.ToString();
            currencyToComboBox.Text = tmpCurrencyFrom;

            _cce.SwitchAmounts();

            amountFromTextBox.Text = _cce.AmountFrom.ToString();
            amountToTextBox.Text = _cce.AmountTo.ToString();
        }

        private async void GetRatesButton_Click(object sender, EventArgs e)
        {
            DisableButtons();

            try
            {
                await UpdateCurrencyRates();
                updateCheckBox.Checked = false;
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error";
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableButtons();
            }
        }

        #endregion

        private void UpdateCurrenciesComboBoxes()
        {
            // default currencies to look for, if there are no selected items
            string currencyFrom = "EUR";
            string currencyTo = "GBP";

            // checking whether currencies comboboxes have any selected items
            if (currencyFromComboBox.SelectedIndex != -1 && currencyToComboBox.SelectedIndex != -1)
            {
                currencyFrom = currencyFromComboBox.SelectedItem.ToString();
                currencyTo = currencyToComboBox.SelectedItem.ToString();
            }

            _cce.PopulateCurrenciesList();

            // bind currencies list with currencies combobox
            currencyFromComboBox.DataSource = new BindingSource { DataSource = _cce.CurrenciesList };
            currencyToComboBox.DataSource = new BindingSource { DataSource = _cce.CurrenciesList };

            // select previously selected item, because of index reset after data source update
            currencyFromComboBox.SelectedIndex = currencyFromComboBox.Items.IndexOf(currencyFrom);
            currencyToComboBox.SelectedIndex = currencyToComboBox.Items.IndexOf(currencyTo);
        }

        private void UpdateCurrenciesRatesTextBoxes()
        {
            if (currencyFromComboBox.SelectedItem != null && currencyToComboBox.SelectedItem != null)
            {
                _cce.CalculateConversionRateTo(currencyFromComboBox.SelectedItem.ToString(), currencyToComboBox.SelectedItem.ToString());
            }

            rateToTextBox.Text = _cce.RateTo.ToString();
        }

        private async Task UpdateCurrencyRates()
        {
            statusLabel.Text = "Updating currency rates";

            await _cce.FetchData(useFileCheckBox.Checked);
            _cce.ProcessResponse();

            UpdateCurrenciesComboBoxes();

            UpdateCurrenciesRatesTextBoxes();

            baseCurrencyTextBox.Text = _cce.BaseCurrency;

            var dt = _cce.LocalTimeStamp;
            dateStampTextBox.Text = $"{dt.ToLongDateString()} {dt.ToLongTimeString()}";

            statusLabel.Text = "Currency rates updated";
        }

        private void CurrencyFromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrenciesRatesTextBoxes();
        }

        private void CurrencyToComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrenciesRatesTextBoxes();
        }

        private async void AmountFromTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!autoConvertCheckBox.Checked)
            {
                return;
            }

            await ConvertCurrency();
        }

        private async Task ConvertCurrency()
        {
            if (string.IsNullOrEmpty(amountFromTextBox.Text))
            {
                statusLabel.Text = "Amount textbox empty";
            }
            else
            {
                DisableButtons();
                statusLabel.Text = "Converting";

                try
                {
                    // make new http request only, if previous request generated error or this is the first request
                    if (updateCheckBox.Checked)
                    {
                        await UpdateCurrencyRates();
                        updateCheckBox.Checked = false;
                    }

                    _cce.ConvertCurrency(decimal.Parse(amountFromTextBox.Text));

                    amountToTextBox.Text = _cce.AmountTo.ToString();

                    statusLabel.Text = "Converted";
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "Error";
                    MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    EnableButtons();
                }
            }
        }

        private void EnableButtons()
        {
            getRatesButton.Enabled = true;
            convertButton.Enabled = true;
        }

        private void DisableButtons()
        {
            getRatesButton.Enabled = false;
            convertButton.Enabled = false;
        }

        private void RateToTextBox_Click(object sender, EventArgs e)
        {
            string rates = string.Empty;

            foreach (string key in _cce.CurrenciesDict.Keys)
            {
                rates += $"{key}\t{_cce.CurrenciesDict[key]}{Environment.NewLine}";
            }

            var ratesForm = new RatesForm();
            ratesForm.ratesTextBox.Text = rates;
            ratesForm.ShowDialog();
        }
    }
}
