public class Resume
{
    // Responsibilities:
    // Keeps track of the person's name and a list of their jobs.
    // Behaviors:
    // Displays the resume, which shows the name first, followed by displaying each one of the jobs.

    public string _name = "";
    public List<Job> jobs = new List<Job>();
    public Resume()
    {

    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console .WriteLine ("Jobs:");

        foreach(Job job in jobs)
        {
            job.display();
        }
    }

}