namespace AllogProject2.Api.Entities;

public class Author {
    public int Id {get; set;}
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;
    public List<Course> Courses {get; set;} = new();

    public Author(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Id: {Id}\nFirstName: {FirstName}\nLastName: {LastName}";
    }
}