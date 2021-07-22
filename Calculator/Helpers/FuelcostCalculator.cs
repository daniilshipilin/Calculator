namespace Calculator.Helpers
{
    using System;

    public class FuelcostCalculator
    {
        public FuelcostCalculator(double tripDistance, double fuelEfficiency, decimal fuelPriceLiter, string currency = "EUR")
        {
            if (tripDistance <= 0)
            {
                throw new ArgumentException(null, nameof(tripDistance));
            }

            if (fuelEfficiency <= 0)
            {
                throw new ArgumentException(null, nameof(fuelEfficiency));
            }

            if (fuelPriceLiter <= 0)
            {
                throw new ArgumentException(null, nameof(fuelPriceLiter));
            }

            if (string.IsNullOrEmpty(currency))
            {
                throw new ArgumentException(null, nameof(currency));
            }

            this.TripDistance = tripDistance;
            this.FuelEfficiency = fuelEfficiency;
            this.FuelPriceLiter = fuelPriceLiter;
            this.Currency = currency;
        }

        public double TripDistance { get; }

        public double FuelEfficiency { get; }

        public decimal FuelPriceLiter { get; }

        public string Currency { get; set; }

        public double TripFuelUsedLiters => this.TripDistance / 100 * this.FuelEfficiency;

        public decimal TripCost => (decimal)this.TripFuelUsedLiters * this.FuelPriceLiter;

        public string GetTripCostFormatted() =>
            $"Distance: {Math.Round(this.TripDistance, 2)} KM{Environment.NewLine}" +
            $"Avg. fuel consumption: {Math.Round(this.FuelEfficiency, 2)} L/100KM{Environment.NewLine}" +
            $"Fuel cost: {Math.Round(this.FuelPriceLiter, 2)} {this.Currency}/L{Environment.NewLine}" +
            $"This trip will require {Math.Round(this.TripFuelUsedLiters, 2)} liter(s) of fuel, " +
            $"which amounts to a fuel cost of {Math.Round(this.TripCost, 2)} {this.Currency}";
    }
}
