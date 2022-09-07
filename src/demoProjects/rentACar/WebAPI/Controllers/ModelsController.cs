using Application.Features.Models.Queries.GelListModelByDynamic;
using Application.Features.Models.Queries.GetListModel;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]"), ApiController]
public class ModelsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var getListModelQuery = new GetListModelQuery() { PageRequest = pageRequest };
        return Ok(await Mediator.Send(getListModelQuery));
    }

    [HttpPost]
    public async Task<IActionResult> GetListByDyanmicAsync([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        var getListModelByDynamicQuery = new GelListModelByDynamicQuery() { Dynamic = dynamic, PageRequest = pageRequest };
        return Ok(await Mediator.Send(getListModelByDynamicQuery));
    }
}