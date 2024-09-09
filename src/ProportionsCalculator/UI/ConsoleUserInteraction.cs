using ProportionsCalculator.FileAccess;
using System.Text.Json;

namespace ProportionsCalculator.UI;

public class ConsoleUserInteraction : IUserInteraction
{
    public static readonly string Separator = Environment.NewLine;
    public static readonly JsonSerializerOptions SerializationOptions =
        new() { WriteIndented = true };

    public void PrintInputs(InputData inputData)
    {
        ShowMessage("Received information:");
        ShowMessage(
            JsonSerializer.Serialize(
                inputData, SerializationOptions));
    }
    public void PrintResults(List<double> finalQuantities, List<double> differences)
    {
        ShowMessage($"{Separator}========== RESULT ==========");
        ShowMessage($"{Separator}Desired amounts:");
        PrintDoubleList(finalQuantities);
        ShowMessage($"{Separator}To get these, you need to add the following amounts:");
        PrintDoubleList(differences);
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void Exit()
    {
        ShowMessage($"{Separator}Press any key to close.");
        Console.ReadKey();
    }
    private void PrintDoubleList(List<double> finalQuantities)
    {
        ShowMessage(
            JsonSerializer.Serialize(
                finalQuantities, SerializationOptions));
    }

}
