namespace RendszerKez.Dtos
{
    public class CreateOrderDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
