namespace Zamkar.Models;

public class PageViewModel
{
    public int PageNumber { get; }
    public int TotalPage { get; }
    public bool HasPrevious => PageNumber > 1;
    public bool HasNext => PageNumber < TotalPage;

    public PageViewModel(int count, int number, int size)
    {
        PageNumber = number;
        TotalPage = (int)Math.Ceiling(count / (double)size);
    }
}