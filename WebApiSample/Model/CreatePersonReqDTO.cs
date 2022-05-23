namespace WebApiSample.Model;

public class CreatePersonReqDTO
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int Age { get; set; }
    public bool IsMale { get; set; }
}
