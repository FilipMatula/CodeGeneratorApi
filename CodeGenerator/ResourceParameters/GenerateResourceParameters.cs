using CodeGenerator.Constants;
using CodeGenerator.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using ZXing;

namespace CodeGenerator.ResourceParameters
{
    public class GenerateResourceParameters
    {
        [Required]
        public BarcodeFormat? Code { get; set; } = null;
        [Required]
        public string Content { get; set; } = "";
        [Range(0, int.MaxValue, ErrorMessage = "Width must be greater then 0.")]
        public int? Width { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Height must be greater then 0.")]
        public int? Height { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Margin must be greater then 0.")]
        public int Margin { get; set; } = GeneratorConstants.Margin;
        public bool SkipStringContent { get; set; } = GeneratorConstants.SkipStringContent;
        [RegularExpression(@"^#?[0-9A-Fa-f]{6}$", ErrorMessage = "Not valid hex color.")]
        public string ForegroundColor { get; set; } = Color.Black.ToHexString();
        [RegularExpression(@"^#?[0-9A-Fa-f]{6}$", ErrorMessage = "Not valid hex color.")]
        public string BackgroundColor { get; set; } = Color.White.ToHexString();
    }
}
