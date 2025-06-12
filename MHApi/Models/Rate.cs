namespace MHMinApi.Models.Models;

public class Rate
{
    public int Id { get; set; }
    public string LoanType { get; set; } = string.Empty;
    public int Term { get; set; }
}