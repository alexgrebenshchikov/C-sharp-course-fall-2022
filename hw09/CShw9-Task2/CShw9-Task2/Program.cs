using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Student
{
    public Student(decimal studentId, string firstName, string lastName, int age, Group group)
    {
        StudentId = studentId;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Group = group;
    }

    public decimal StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Group Group { get; set; }

    public override string ToString()
    {
        return string.Format("Student(id: {0}, first name: {1}, last name: {2}, age: {3})", StudentId, FirstName,
            LastName, Age);
    }
}

[Serializable]
public class Group
{
    public Group(decimal groupId, string name)
    {
        GroupId = groupId;
        Name = name;
        Students = new List<Student>();
    }

    public decimal GroupId { get; set; }
    public string Name { get; set; }

    public List<Student> Students
    {
        get => students;
        set
        {
            students = value;
            studentsCount = value.Count;
        }
    }

    public int StudentsCount => studentsCount;

    private List<Student> students;

    [NonSerialized] private int studentsCount;

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        studentsCount = students.Count;
    }

    public override string ToString()
    {
        var groupIdStr = string.Format("GroupId: {0}", GroupId);
        var groupNameStr = string.Format("Name: {0}", Name);
        var studentsStrList = Students.Select(student => student.ToString());
        return groupIdStr + "\n" + groupNameStr + "\n" + "Students:" + "\n" + string.Join("\n", studentsStrList);
    }
}

public class GroupSerializer
{
    public static MemoryStream SerializeGroup(Group group)
    {
        var formatter = new BinaryFormatter();
        var stream = new MemoryStream();
        formatter.Serialize(stream, group);
        stream.Position = 0;
        return stream;
    }

    public static Group DeserializeGroup(Stream stream)
    {
        var formatter = new BinaryFormatter();
        return (Group)formatter.Deserialize(stream);
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        var group = new Group(decimal.Zero, "b09");
        var student1 = new Student(decimal.Zero, "Li", "Ghang", 23, group);
        var student2 = new Student(decimal.One, "Chen", "Xyowing", 22, group);
        group.Students = new List<Student> { student1, student2 };
        Console.WriteLine(group.ToString());
        var group2 = GroupSerializer.DeserializeGroup(GroupSerializer.SerializeGroup(group));
        Console.WriteLine(group2.ToString());
    }
}