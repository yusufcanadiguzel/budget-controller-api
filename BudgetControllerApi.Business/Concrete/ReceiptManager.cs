using AutoMapper;
using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Entities.Exceptions.Concrete;
using BudgetControllerApi.Shared.Dtos.Receipt;
using BudgetControllerApi.Shared.Dtos.ReceiptProduct;

namespace BudgetControllerApi.Business.Concrete
{
    public class ReceiptManager : IReceiptService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IReceiptProductService _receiptProductService;
        private readonly IMapper _mapper;

        public ReceiptManager(IRepositoryService repositoryService, IMapper mapper, IReceiptProductService receiptProductService)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
            _receiptProductService = receiptProductService;
        }

        public async Task<ReceiptDto> CreateOneReceiptAsync(ReceiptDtoForCreate receiptDtoForCreate)
        {
            var receipt = _mapper.Map<Receipt>(receiptDtoForCreate);

            _repositoryService.ReceiptRepository.CreateOneReceipt(receipt);

            await _repositoryService.SaveAsync();

            foreach (var productId in receiptDtoForCreate.ProductIds)
            {
                await _receiptProductService.CreateOneReceiptProduct(new ReceiptProductDtoForCreate { ReceiptId = receipt.Id, ProductId = productId });
            }

            await _repositoryService.SaveAsync();

            var receiptDto = _mapper.Map<ReceiptDto>(receipt);

            return receiptDto;
        }

        public async Task DeleteOneReceiptAsync(int id)
        {
            var receipt = await GetOneReceiptByIdAndCheckExists(id: id, trackChanges: false);

            _repositoryService.ReceiptRepository.DeleteOneReceipt(receipt);

            await _repositoryService.SaveAsync();
        }

        public async Task<IEnumerable<ReceiptDto>> GetAllReceiptsAsync(bool trackChanges)
        {
            var receipts = await _repositoryService.ReceiptRepository.GetAllReceiptsAsync(trackChanges: false);

            foreach (var receipt in receipts)
            {
                receipt.Store = await _repositoryService.StoreRepository.GetOneStoreByIdAsync(id: receipt.StoreId, trackChanges: false);
                receipt.ReceiptProducts = await _repositoryService.ReceiptProductRepository.GetAllReceiptProductsByReceiptId(receipt.Id, false);

                for (int i = 0; i < receipt.ReceiptProducts.Count; i++)
                {
                    receipt.ReceiptProducts[i] = await _repositoryService.ReceiptProductRepository.GetOneReceiptProduct(id: receipt.Id, trackChanges: false);
                }
            }

            var receiptDtos = _mapper.Map<IEnumerable<ReceiptDto>>(receipts);

            return receiptDtos;
        }

        public async Task<ReceiptDto> GetOneReceiptByIdAsync(int id, bool trackChanges)
        {
            var receipt = await GetOneReceiptByIdAndCheckExists(id: id, trackChanges: trackChanges);

            receipt.Store = await _repositoryService.StoreRepository.GetOneStoreByIdAsync(id: receipt.StoreId, trackChanges: false);
            receipt.ReceiptProducts = await _repositoryService.ReceiptProductRepository.GetAllReceiptProductsByReceiptId(receipt.Id, false);

            for (int i = 0; i < receipt.ReceiptProducts.Count; i++)
            {
                receipt.ReceiptProducts[i] = await _repositoryService.ReceiptProductRepository.GetOneReceiptProduct(id: receipt.Id, trackChanges: false);
            }

            var receiptDto = _mapper.Map<ReceiptDto>(receipt);

            return receiptDto;
        }

        public async Task<ReceiptDto> UpdateOneReceiptAsync(ReceiptDtoForUpdate receiptDtoForUpdate, bool trackChanges)
        {
            var receipt = await GetOneReceiptByIdAndCheckExists(id: receiptDtoForUpdate.Id, trackChanges: false);

            receipt = _mapper.Map<Receipt>(receiptDtoForUpdate);

            _repositoryService.ReceiptRepository.UpdateOneReceipt(receipt: receipt);

            await _repositoryService.SaveAsync();

            var receiptDto = _mapper.Map<ReceiptDto>(receipt);

            return receiptDto;
        }

        private async Task<Receipt> GetOneReceiptByIdAndCheckExists(int id, bool trackChanges)
        {
            var receipt = await _repositoryService.ReceiptRepository.GetOneReceiptByIdAsync(id: id, trackChanges: trackChanges);

            if (receipt is null)
                throw new ReceiptNotFoundException(id: id);

            return receipt;
        }
    }
}
