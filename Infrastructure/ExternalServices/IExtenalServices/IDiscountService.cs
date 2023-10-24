namespace Infrastructure.ExternalServices.IExtenalServices
{
    public interface IDiscountService
    {
        Task<int> GetDiscountPercentageAsync(Guid productId);
    }
}
