namespace Store.Application.Features.Products.Queries.GetProductsList;

public class GetProductsListVM
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string CategoryId { get; set; }

    public string CategoryName { get; set; }
}
