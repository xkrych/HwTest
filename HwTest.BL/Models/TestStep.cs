using HwTest.BL.Interfaces;

namespace HwTest.BL.Models;

public class TestStep(string name) : ITestStep
{
    public string Name { get; set; } = name;
    public string State { get; set; } = "init";
}
