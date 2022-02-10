using CodeGenerator.Constants;
using CodeGenerator.Extensions;
using CodeGenerator.ResourceParameters;
using System.Drawing;
using System.Runtime.Versioning;
using ZXing;
using ZXing.Windows.Compatibility;

namespace CodeGenerator.Services
{
    public class GeneratorService : IGeneratorService
    {
        [SupportedOSPlatform("windows")]
        public Bitmap Generate(GenerateResourceParameters parameters)
        {
            var writer = new BarcodeWriter<Bitmap>
            {
                Format = parameters.Code.GetValueOrDefault(),
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = parameters.Height.GetValueOrDefault(parameters.Code.GetValueOrDefault().IsSquare() ? GeneratorConstants.SquareHeight : GeneratorConstants.RectHeight),
                    Width = parameters.Width.GetValueOrDefault(parameters.Code.GetValueOrDefault().IsSquare() ? GeneratorConstants.SquareWidth : GeneratorConstants.RectWidth),
                    Margin = parameters.Margin,
                    PureBarcode = parameters.SkipStringContent
                },
                Renderer = new BitmapRenderer
                {
                    Foreground = ColorTranslator.FromHtml(parameters.ForegroundColor.ToHtmlText()),
                    Background = ColorTranslator.FromHtml(parameters.BackgroundColor.ToHtmlText()),
                }
            };

            return writer.Write(parameters.Content);
        }
    }
}
