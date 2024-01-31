namespace TravelAgency.Domain.Common.Exceptions;

public class AgencyException : Exception
{
    public int Status { get; set; }
    public string Detail { get; set; }
    public AgencyException(string message, string detail = "", int status = 500) : base(message)
    {
        Detail = detail;
        Status = status;
    }
}