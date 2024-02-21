namespace Business.Responses.Application;

public class GetByIdApplicationResponse
{
    public int Id { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationStateName { get; set; }

}
