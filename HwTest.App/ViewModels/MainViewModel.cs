using HwTest.BL.Models;
using System.Collections.ObjectModel;

namespace HwTest.App.ViewModels;

public class MainViewModel
{
    public MainViewModel()
    {
    }

    public ObservableCollection<TestStep> TestSteps { get; set; } = new();
}
