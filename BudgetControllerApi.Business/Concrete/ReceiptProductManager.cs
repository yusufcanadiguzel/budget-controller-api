using AutoMapper;
using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.ReceiptProduct;

namespace BudgetControllerApi.Business.Concrete
{
    public class ReceiptProductManager : IReceiptProductService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;

        public ReceiptProductManager(IRepositoryService repositoryService, IMapper mapper)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
        }

        public async Task CreateOneReceiptProduct(ReceiptProductDtoForCreate receiptProductDtoForCreate)
        {
            var receiptProduct = _mapper.Map<ReceiptProduct>(receiptProductDtoForCreate);

            _repositoryService.ReceiptProductRepository.CreateOneReceiptProduct(receiptProduct);

            await _repositoryService.SaveAsync();
        }

        public async Task<ReceiptProductDto> GetOneReceiptProductDto(int id, bool trackChanges)
        {
            var receiptProduct = await _repositoryService.ReceiptProductRepository.GetOneReceiptProduct(id, trackChanges);

            var receiptProductDto = _mapper.Map<ReceiptProductDto>(receiptProduct);

            return receiptProductDto;
        }
    }
}
