using ReactiveUI;

namespace ProgrammingLab2.ViewModels;

public class ProgrammWindowViewModel: ViewModelBase
{

    private bool _isChecked = false;

    public bool IsChecked
    {
        get => _isChecked;
        set => this.RaiseAndSetIfChanged(ref _isChecked, value);
    }

    public ProgrammWindowViewModel()
    {
        // IsChecked = true;
    }
}