public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        SetName("Listing");
        SetDescription("This is the listing activity");
    }

    public void Run()
    {

    }

    public string GetRandomPrompt()
    {
        return null;
    }

    public List<string> GetListFromUser()
    {
        return _prompts;
    }
}