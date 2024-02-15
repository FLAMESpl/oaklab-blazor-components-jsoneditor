using System.Text.Json.Serialization;

namespace OakLab.Blazor.Components.JsonEditor;

public class OnInputEventArgs
{
    [JsonPropertyName("fullText")]
    public string? FullText { get; set; }
}
