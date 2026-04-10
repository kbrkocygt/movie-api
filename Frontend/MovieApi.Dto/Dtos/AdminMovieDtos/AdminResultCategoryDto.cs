using System;

namespace MovieApi.Dto.Dtos.AdminMovieDtos;

public class AdminResultCategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }


    public int MovieCount { get; set; }
    public int ReviewCount { get; set; }
    public double AvgRating { get; set; }
    public bool IsActive { get; set; }
}

