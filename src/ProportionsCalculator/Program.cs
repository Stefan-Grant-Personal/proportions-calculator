using ProportionsCalculator.App;
using ProportionsCalculator.FileAccess;
using ProportionsCalculator.UI;

const string filePath = "input.json";

ProportionsCalculatorApp proportionsCalculatorApp =
    new(
        new ConsoleUserInteraction(),
        new QuantitiesRepository()
        );

proportionsCalculatorApp.Run(filePath);
