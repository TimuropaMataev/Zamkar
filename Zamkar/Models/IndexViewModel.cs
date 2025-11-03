namespace Zamkar.Models;

public class IndexViewModel
{
    public IEnumerable<User> Users { get; }
    public FilterViewModel FilterViewModel { get; }
    public PageViewModel PageViewModel { get; }
    public SortViewModel SortViewModel { get; }

    public IndexViewModel(IEnumerable<User> users, FilterViewModel filterViewModel,
        PageViewModel pageViewModel, SortViewModel sortViewModel)
    {
        Users = users;
        FilterViewModel = filterViewModel;
        PageViewModel = pageViewModel;
        SortViewModel = sortViewModel;
    }
}