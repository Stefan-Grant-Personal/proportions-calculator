using ProportionsCalculator.Calculations;
using ProportionsCalculator.FileAccess;
using ProportionsCalculator.UI;

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
            _userInteraction.PrintInputs(inputData);

            // Calculate desired amounts
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

