using System;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.MovieDetailViewComponent;

public class _MovieDetailRateComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {

        return View();
    }

}
