namespace Application.Dtos
{
    public record ProductRequest
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public bool Status { get; set; }
    }
}
