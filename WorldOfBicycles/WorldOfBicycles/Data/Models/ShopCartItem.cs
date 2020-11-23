namespace WorldOfBicycles.Data.Models
{
	public class ShopCartItem
	{
		public int Id { get; set; }
		public Product Product { get; set; }
		public int ProductId { get; set; }
		public string ShopCartId { get; set; } 

	}
}
