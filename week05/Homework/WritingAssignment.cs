public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Encapsulation: Using the getter method instead of directly accessing _studentName
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}
