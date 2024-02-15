namespace OakLab.Blazor.Components.JsonEditor;

public record JsonEditorColorScheme
{
    public static JsonEditorColorScheme Default { get; } = new();

    public string Neutral { get; init; } = "black";
    public string Brace { get; init; } = "brown";

    internal string GetVariables() => string.Concat(ComposeVariables());

    private string[] ComposeVariables() => new[]
    {
        $"{JsonEditorCssVariables.ColorNeutral}: {Neutral};",
        $"{JsonEditorCssVariables.ColorBrace}: {Brace};"
    };
}