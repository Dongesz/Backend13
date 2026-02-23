namespace RendszerKez.Dtos
{
    public class OrderSummaryDto
    {
        public string Username { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
