namespace ProportionsCalculator.FileAccess
{
    public interface IQuantitiesRepository
    {
        InputData GetInputs(string filePath);
        void ValidateInputs(InputData inputData);
    }
}