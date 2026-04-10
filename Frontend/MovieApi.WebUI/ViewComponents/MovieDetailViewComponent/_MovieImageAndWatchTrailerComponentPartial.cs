using System;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.MovieDetailViewComponent;

public class _MovieImageAndWatchTrailerComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {

        return View();
    }
}
