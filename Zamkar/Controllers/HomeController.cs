using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zamkar.Models;

namespace Zamkar.Controllers;

public class HomeController : Controller
{
    private readonly ZamkarContext _context;

    public HomeController(ZamkarContext context)
    {
        _context = context;

        if (!_context.Companies.Any())
        {
            Company oko = new() { Name = "oko" };
            Company dsoft = new() { Name = "dsoft" };
            Company dno = new() { Name = "dno" };
            Company kison = new() { Name = "kison" };

            User u1 = new() { Name = "Tom", Age = 19, Company = oko };
            User u2 = new() { Name = "Bob", Age = 22, Company = dsoft };
            User u3 = new() { Name = "Alex", Age = 20, Company = oko };
            User u4 = new() { Name = "Tony", Age = 18, Company = dsoft };
            User u5 = new() { Name = "Kan", Age = 25, Company = oko };
            User u6 = new() { Name = "Tyn", Age = 27, Company = oko };
            User u7 = new() { Name = "Alice", Age = 34, Company = dno };
            User u8 = new() { Name = "Lii", Age = 37, Company = kison };
            User u9 = new() { Name = "Den", Age = 28, Company = dno };
            User u10 = new() { Name = "Hin", Age = 30, Company = kison };

            _context.Companies.AddRange(oko, dsoft, dno, kison);
            _context.Users.AddRange(u1, u2, u3, u4, u5, u6, u7, u8, u9, u10);
            _context.SaveChanges();
        }
    }

    public async Task<IActionResult> Index(string name, int company = 0, int page = 1,
        SortState sort = SortState.NameAsc)
    {
        int size = 3;

        IQueryable<User> users = _context.Users.Include(x => x.Company);

        if (company != 0)
            users = users.Where(x => x.CompanyId == company);

        if (string.IsNullOrEmpty(name))
            users = users.Where(x => x.Name!.Contains(name));

        switch (sort)
        {
            case SortState.NameDesc:
                users = users.OrderByDescending(x => x.Name);
                break;
            case SortState.AgeAsc:
                users = users.OrderBy(x => x.Age);
                break;
            case SortState.AgeDesc:
                users = users.OrderByDescending(x => x.Age);
                break;
            case SortState.CompanyAsc:
                users = users.OrderBy(x => x.Company!.Name);
                break;
            case SortState.CompanyDesc:
                users = users.OrderByDescending(x => x.Company!.Name);
                break;
            default:
                users = users.OrderBy(x => x.Name);
                break;
        }

        var count = await users.CountAsync();
        var items = await users.Skip((page - 1) * size).Take(size).ToListAsync();

        IndexViewModel indexViewModel = new
        (
            items,
            new FilterViewModel(_context.Companies.ToList(), name, company),
            new PageViewModel(count, page, size),
            new SortViewModel(sort)
        );

        return View(indexViewModel);
    }
}