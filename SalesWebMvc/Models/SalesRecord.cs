using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models;

public class SalesRecord
{
    public int SalesRecordId { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public SalesStatus Status { get; set; }
    public int SellerId { get; set; }
    public Seller? Seller { get; set; }

    public SalesRecord() { }

    public SalesRecord(int salesRecordId, DateTime date, double amount, SalesStatus status, int sellerId, Seller? seller)
    {
        SalesRecordId = salesRecordId;
        Date = date;
        Amount = amount;
        Status = status;
        SellerId = sellerId;
        Seller = seller;
    }
}
