using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]"), ApiController]
public class BrandsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddAsny([FromBody] CreateBrandCommand createBrandCommand) => Created("", await Mediator.Send(createBrandCommand));

    [HttpGet]
    public async Task<IActionResult> GetListAsnyc([FromQuery] PageRequest request)
    {
        var getListBrandQuery = new GetListBrandQuery() { PageRequest = request };
        return Ok(await Mediator.Send(getListBrandQuery));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdBrandQueryAsnyc([FromRoute] int id)
    {
        var getByIdBrandQuery = new GetByIdBrandQuery() { Id = id };
        return Ok(await Mediator.Send(getByIdBrandQuery));
    }
}