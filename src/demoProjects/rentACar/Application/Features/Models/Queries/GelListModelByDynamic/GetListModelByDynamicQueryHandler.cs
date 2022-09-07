using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GelListModelByDynamic;

public class GetListModelByDynamicQueryHandler : IRequestHandler<GelListModelByDynamicQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelByDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GelListModelByDynamicQuery request, CancellationToken cancellationToken)
    {
        var models = await _modelRepository.GetListByDynamicAsync(request.Dynamic,
            include: m => m.Include(table => table.Brand), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        return _mapper.Map<ModelListModel>(models);
    }
}