namespace InventorySystem_API.DTOs
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int CNIC { get; set; }
        public string? City { get; set; }
        public int CustomerPendings { get; set; }
        public string? ImageUrl { get; set; }
    }
}
