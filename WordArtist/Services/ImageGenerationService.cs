using Python.Runtime;
using WordArtist.Models;

namespace WordArtist.Services;

public class ImageGenerationService
{
    private readonly dynamic _pipe;

    public ImageGenerationService()
    {
        PythonEngine.Initialize();

        using (Py.GIL())
        {
            dynamic torch = Py.Import("torch");
            dynamic diffusers = Py.Import("diffusers");
            var pipeline = diffusers.StableDiffusionPipeline;

            var modelId = "runwayml/stable-diffusion-v1-5";
            _pipe = pipeline.from_pretrained(modelId);
            _pipe = _pipe.to("cpu");
        }
    }

    public Stream GenerateImage(ImageModel imageModel)
    {
        using (Py.GIL())
        {
            var image = _pipe(imageModel.Prompt).images[0];

            var outputStream = new MemoryStream();
            image.save(outputStream, "PNG");
            outputStream.Position = 0;
            return outputStream;
        }
    }
}