using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zamkar.Models;

public class FilterViewModel
{
    public string Name { get; }
    public int Company { get; }
    public SelectList Companies { get; }

    public FilterViewModel(List<Company> companies, string name, int company)
    {
        companies.Insert(0, new Company() { Id = 0, Name = "Vse"});
        Companies = new SelectList(companies, "Id", "Name", company);
        Name = name;
        Company = company;
    }
}