using ProportionsCalculator.FileAccess;

namespace ProportionsCalculator.UI;

public interface IUserInteraction
{
    void ShowMessage(string message);
    void PrintInputs(InputData inputData);
    void PrintResults(List<double> finalQuantities, List<double> differences);
    void Exit();
}
