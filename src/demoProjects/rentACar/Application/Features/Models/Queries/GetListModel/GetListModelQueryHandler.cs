using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModel;

public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
    {
        var models = await _modelRepository.GetListAsync(include: m => m.Include(table => table.Brand), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        return _mapper.Map<ModelListModel>(models);
    }
}