using ProportionsCalculator.Calculations;
using ProportionsCalculator.FileAccess;
using ProportionsCalculator.UI;
using System.Text.Json;

namespace ProportionsCalculator.App;

public class ProportionsCalculatorApp
{
    private readonly IUserInteraction _userInteraction;
    private readonly IQuantitiesRepository _quantitiesRepository;

    public ProportionsCalculatorApp(
        IUserInteraction userInteraction,
        IQuantitiesRepository quantitiesRepository)
    {
        _userInteraction = userInteraction;
        _quantitiesRepository = quantitiesRepository;
    }

    public void Run(string filePath)
    {
        _userInteraction.ShowMessage($"Getting information from {filePath}...");

        try
        {
            // Get and validate user input
            InputData inputData = _quantitiesRepository.GetInputs(filePath);
            _quantitiesRepository.ValidateInputs(inputData);

            _userInteraction.ShowMessage("Received information:");
            _userInteraction.ShowMessage(JsonSerializer.Serialize(inputData));

            // Calculate desired amounts
            _userInteraction.ShowMessage($"{ConsoleUserInteraction.Separator}Calculating desired amounts...");
            List<double> finalQuantities = RatiosCalculator.CalculateFinalQuantities(inputData);
            List<double> differences = RatiosCalculator.GetDifferences(inputData, finalQuantities);

            _userInteraction.PrintResults(finalQuantities, differences);
        }
        catch (Exception ex)
        {
            _userInteraction.ShowMessage($"Unexpected error: {ex.Message}");
        }

        _userInteraction.Exit();
    }
}

