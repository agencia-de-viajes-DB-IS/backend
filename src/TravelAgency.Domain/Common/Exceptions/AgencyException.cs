namespace TravelAgency.Domain.Common.Exceptions;

public class TravelAgencyException : Exception
{
    public int Status { get; set; }
    public string Details { get; set; } = string.Empty;
    public TravelAgencyException(string message, string Details = "", int status = 500) : base(message)
    {
        Details = Details;
        Status = status;
    }
}