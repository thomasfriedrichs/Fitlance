using Fitlance.Data;

namespace Fitlance.Controllers;

public class ContextController
{
    private readonly FitlanceContext _context;

    public ContextController(FitlanceContext context)
    {
        _context = context;
    }
}
