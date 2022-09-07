﻿namespace Application.Features.Models.Dtos;

public class ModelListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BrandName { get; set; }
    public string ImageUrl { get; set; }
    public decimal DailyPrice { get; set; }
}