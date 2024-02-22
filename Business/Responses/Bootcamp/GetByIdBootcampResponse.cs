namespace Business.Responses.Bootcamp;

public class GetByIdBootcampResponse
{
    public string Name { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string BootcampStateName { get; set; }
}
