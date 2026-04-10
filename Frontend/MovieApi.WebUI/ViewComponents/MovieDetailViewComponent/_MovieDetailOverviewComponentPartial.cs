using System;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.MovieDetailViewComponent;

public class _MovieDetailOverviewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke(string overview)
    {
        return View(model: overview);
    }

}
