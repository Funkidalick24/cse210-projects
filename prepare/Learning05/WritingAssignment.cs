public class WritingAssignment(string studentName, string topic, string title) : Assignment(studentName, topic)
{
    private readonly string _title = title;

    public string GetWritingInformation()
    {
        // Notice that we are calling the getter here because _studentName is private in the base class
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}