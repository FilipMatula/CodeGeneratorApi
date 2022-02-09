using CodeGenerator.Constants;
using CodeGenerator.Extensions;
using CodeGenerator.ResourceParameters;
using System.Drawing;
using ZXing;
using ZXing.Rendering;

namespace CodeGenerator.Services
{
    public class GeneratorService : IGeneratorService
    {
        public Bitmap Generate(GenerateResourceParameters parameters)
        {
            var writer = new BarcodeWriter
            {
                Format = parameters.Code,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = parameters.Height.GetValueOrDefault(parameters.Code.IsSquare() ? GeneratorConstants.SquareHeight : GeneratorConstants.RectHeight),
                    Width = parameters.Width.GetValueOrDefault(parameters.Code.IsSquare() ? GeneratorConstants.SquareWidth : GeneratorConstants.RectWidth),
                    Margin = parameters.Margin,
                    PureBarcode = parameters.SkipStringContent
                },
                Renderer = new BitmapRenderer
                {
                    Foreground = ColorTranslator.FromHtml(parameters.ForegroundColor),
                    Background = ColorTranslator.FromHtml(parameters.BackgroundColor),
                }
            };

            return writer.Write(parameters.Content);
        }
    }
}
