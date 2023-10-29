using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary.Server.Data;
using VideoGameLibrary.Shared;

namespace VideoGameLibrary.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VideoGameController : ControllerBase
{
	private readonly DataContext dataContext;

	public VideoGameController(DataContext dataContext)
	{
		this.dataContext = dataContext;
	}

	[HttpGet("GetAllVideoGames")]
	public async Task<ActionResult<List<VideoGame>>> GetAllVideoGames() => Ok(await dataContext.VideoGames.ToListAsync());

	[HttpGet("GetOneVideoGame/{id}")]
	public async Task<ActionResult<VideoGame>> GetOneVideoGame(int id)
	{
		var result = await dataContext.VideoGames.FindAsync(id);

		if (result is null)
			return NotFound();

		return Ok(result);
	}


	[HttpPost("CreateNewVideoGame")]
	public async Task<ActionResult<List<VideoGame>>> CreateNewVideoGame(VideoGame videoGame)
	{

		dataContext.VideoGames.Add(videoGame);
		await dataContext.SaveChangesAsync();

		return await GetAllVideoGames();

	}

	[HttpPut("UpdateVideoGame/{id}")]
	public async Task<ActionResult<List<VideoGame>>> UpdateVideoGame(VideoGame videoGame, int id)
	{
		var result = await dataContext.VideoGames.FindAsync(id);

		if (result is null)
			return NotFound();

		result.Title = videoGame.Title;
		result.Author = videoGame.Author;
		result.ReleaseYear = videoGame.ReleaseYear;

		await dataContext.SaveChangesAsync();

		return await GetAllVideoGames();

	}

	[HttpDelete("DeleteVideoGame/{id}")]
	public async Task<ActionResult<List<VideoGame>>> DeleteVideoGame(int id)
	{
		var result = await dataContext.VideoGames.FindAsync(id);

		if (result is null)
			return NotFound();

		dataContext.VideoGames.Remove(result);
		await dataContext.SaveChangesAsync();

		return Ok();

	}

}
