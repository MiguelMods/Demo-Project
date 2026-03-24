namespace demo.project.site.Models.ViewModels;

public class SelectOption(long value, string text)
{
    public long Value { get; set; } = value;
    public string Text { get; set; } = text;
}
