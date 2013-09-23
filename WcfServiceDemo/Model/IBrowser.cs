namespace WcfServiceDemo.Model
{
    public interface IBrowser
    {
        string Engine { get; set; }

        string Name { get; set; }

        string Platform { get; set; }

        string Version { get; set; }

        string Grade { get; set; }
    }
}