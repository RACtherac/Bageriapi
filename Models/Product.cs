public class Product
{
    public string ArticleNumber {get; set;}
    public int ProductId {get; set;}
    public string Name {get; set;}
    public ICollection<SupplierProduct> SupplierProducts {get; set;}
}