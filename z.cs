using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
internal class z
{
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}