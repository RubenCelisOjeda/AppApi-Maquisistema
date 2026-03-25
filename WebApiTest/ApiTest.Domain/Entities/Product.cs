namespace ApiProduct.Domain.Entities
{
    public class Product
    {
        public int ProductId { get;private set; }
        public string Name { get;private set; }
        public string StatusName { get;private set; }
        public int Stock { get;private set; }
        public string Descripcion { get;private set; }
        public decimal Price { get;private set; }
    }
}
