namespace Presentation.Models;

public class BookingResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
    public string? Id { get; set; }

}
public class BookingResult<T> : BookingResult
{
    public T? Data { get; set; }
}
