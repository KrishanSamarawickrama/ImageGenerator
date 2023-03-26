# ImageGenerator
Image generation API using StableDiffusionPipeline

This implementation initializes the StableDiffusionPipeline with the specified model ID and sets the pipeline to use CPU .to("cpu") method. 
The GenerateImage method takes an ImageModel with a text prompt and generates an image using the pipeline.

If you do not have an NVIDIA GPU or have not installed the GPU-enabled version of PyTorch, change the line _pipe = _pipe.to("cpu"); to _pipe = _pipe.to("cuda");.
