namespace ProportionsCalculator.FileAccess;

public readonly struct InputData
{
    public List<double>? InitialQuantities { get; init; }
    public List<double>? DesiredProportions { get; init; }
}