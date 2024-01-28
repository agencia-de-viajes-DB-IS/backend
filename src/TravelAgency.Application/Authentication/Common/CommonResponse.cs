namespace TravelAgency.Application.Authentication.Common;
public interface ICommonResponse<T> 
{
    public string? ErrorMessage { get; set; }
    public T? Data { get; set; }
    public bool Success { get; set; }
    public Object? Error { get; set; }
}