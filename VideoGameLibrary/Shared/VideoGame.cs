using Microsoft.JSInterop;

namespace VideoGameLibrary.Shared;

public class VideoGame
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public string Author { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }
}


public static class ConfirmExtensions
{
	public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
	{
		return jsRuntime.InvokeAsync<bool>("confirm", message);
	}
}