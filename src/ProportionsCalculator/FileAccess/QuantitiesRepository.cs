using System.Text.Json;

namespace ProportionsCalculator.FileAccess;

public class QuantitiesRepository : IQuantitiesRepository
{
    public InputData GetInputs(string filePath)
    {
        string text = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<InputData>(text);
    }

    public void ValidateInputs(InputData inputData)
    {
        List<double>? initialQuantities = inputData.InitialQuantities;
        List<double>? desiredProportions = inputData.DesiredProportions;

        if (initialQuantities is null || desiredProportions is null)
        {
            throw new ArgumentException(
                "Cannot have empty initial quantities or desired proportions lists.");
        }

        if (initialQuantities.Count != desiredProportions.Count)
        {
            throw new ArgumentException(
                "The given lists are of different lengths! " +
                $"{initialQuantities.Count} vs {desiredProportions.Count}");
        }

        foreach (double quantity in initialQuantities)
        {
            if (quantity < 0)
            {
                throw new ArgumentException(
                $"Cannot have negative initial quantities.");
            }

        }
        foreach (double proportion in desiredProportions)
        {
            if (proportion <= 0)
            {
                throw new ArgumentException(
                $"Cannot have non-positive desired proportion.");
            }

        }
    }
}