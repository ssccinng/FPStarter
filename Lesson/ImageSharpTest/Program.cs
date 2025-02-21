// See https://aka.ms/new-console-template for more information

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

Console.WriteLine("Hello, World!");

Image image = Image.Load(@"C:\Users\scixing\Pictures\@O@Y$G({G$86NJRP0](0%SP.png");

image.Mutate(x => x.Grayscale());
image.Save("test.jpg");