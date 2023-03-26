using Microsoft.AspNetCore.Mvc;
using WordArtist.Models;
using WordArtist.Services;

namespace WordArtist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly ImageGenerationService _imageGenerationService;

    public ImageController()
    {
        _imageGenerationService = new ImageGenerationService();
    }

    [HttpPost]
    public IActionResult GenerateImage([FromBody] ImageModel imageModel)
    {
        if (imageModel == null || string.IsNullOrEmpty(imageModel.Prompt))
        {
            return BadRequest("Invalid input");
        }

        try
        {
            Stream imageStream = _imageGenerationService.GenerateImage(imageModel);
            return File(imageStream, "image/jpeg");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}