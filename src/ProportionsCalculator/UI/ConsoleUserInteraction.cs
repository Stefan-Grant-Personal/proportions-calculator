using System.Text.Json;

namespace ProportionsCalculator.UI;

public class ConsoleUserInteraction : IUserInteraction
{
    public static readonly string Separator = Environment.NewLine;
    public static readonly JsonSerializerOptions SerializationOptions =
        new() { WriteIndented = true };
    public void PrintResults(List<double> finalQuantities, List<double> differences)
    {
        ShowMessage("Calculations have been successful.");
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
    private static void PrintDoubleList(List<double> finalQuantities)
    {
        Console.WriteLine(
            JsonSerializer.Serialize(
                finalQuantities, SerializationOptions));
    }

}
