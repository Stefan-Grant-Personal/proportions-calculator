namespace ProportionsCalculator.UI;

public interface IUserInteraction
{
    void ShowMessage(string message);
    void PrintResults(List<double> finalQuantities, List<double> differences);
    void Exit();
}
