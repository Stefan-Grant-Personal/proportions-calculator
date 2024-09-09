using ProportionsCalculator.FileAccess;

namespace ProportionsCalculator.Calculations;

public class RatiosCalculator
{
    private const int MaxDecimalPlaces = 2;

    public static List<double> CalculateFinalQuantities(InputData inputData)
    {
        var initialQuantities = inputData.InitialQuantities;
        var desiredProportions = inputData.DesiredProportions;

        double multiplier = GetMultiplier(initialQuantities, desiredProportions);

        return MultiplyList(multiplier, desiredProportions);
    }
    public static List<double> GetDifferences(
        InputData inputData, List<double> finalQuantities)
    {
        List<double> differences = new();
        for (int ii = 0; ii < finalQuantities.Count; ii++)
        {
            double diff = finalQuantities[ii] - inputData.InitialQuantities[ii];
            if (diff < 0)
            {
                throw new Exception(
                    $"Final quantity at index {ii} cannot be lower than initial. Diff: {diff}");
            }
            differences.Add(diff);
        }
        return differences;
    }


    private static double GetMultiplier(List<double> initialQuantities, List<double> desiredProportions)
    {
        // This function returns the maximum value of q_i / r_i over all i,
        // see README.md for the mathematics.
        double multiplier = 0;
        for (int ii = 0; ii < initialQuantities.Count; ii++)
        {
            double temp = initialQuantities[ii] / desiredProportions[ii];
            if (temp > multiplier)
            {
                multiplier = temp;
            }
        }
        return multiplier;
    }
    private static List<double> MultiplyList(
        double multiplier,
        List<double> desiredProportions)
    {
        List<double> result = new();
        foreach (double number in desiredProportions)
        {
            // Round to the desired number of decimal places
            double finalNum = Math.Round(multiplier * number, MaxDecimalPlaces);
            result.Add(finalNum);
        }
        return result;
    }
}