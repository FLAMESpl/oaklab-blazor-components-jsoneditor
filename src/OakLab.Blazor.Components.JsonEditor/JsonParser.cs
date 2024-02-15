using OakLab.Blazor.Components.JsonEditor.Structure;

namespace OakLab.Blazor.Components.JsonEditor;

internal static class JsonParser
{
    public static JsonEditorDocument Parse(string jsonText)
    {
        var characters = jsonText.GetEnumerator();
        var tokens = new List<IJsonEditorToken>();
        var bufferIndex = 0;

        Span<char> buffer = stackalloc char[1000];

        while (characters.MoveNext())
        {
            if (characters.Current is '{' or '}')
            {
                if (bufferIndex > 0)
                {
                    tokens.Add(new JsonEditorText(new string(buffer[..bufferIndex])));
                    buffer.Clear();
                    bufferIndex = 0;
                }

                tokens.Add(new JsonEditorBrace(characters.Current.ToString()));
            }
            else
            {
                buffer[bufferIndex] = characters.Current;
                bufferIndex++;
            }
        }

        if (bufferIndex > 0)
            tokens.Add(new JsonEditorText(new string(buffer[..bufferIndex])));

        return new JsonEditorDocument(tokens);
    }
}
