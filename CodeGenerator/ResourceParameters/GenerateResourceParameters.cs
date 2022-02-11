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
        /// <summary>
        /// Barcode type (eg. CODE_128, QR_CODE)
        /// </summary>
        [Required]
        public BarcodeFormat? Code { get; set; } = null;
        /// <summary>
        /// Text from which code will be generated
        /// </summary>
        [Required]
        public string Content { get; set; } = "";
        /// <summary>
        /// Width of code (Default: 300px)
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Width must be greater then 0.")]
        public int? Width { get; set; }
        /// <summary>
        /// Height of code (Default: 300px for square, 100px for rect)
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Height must be greater then 0.")]
        public int? Height { get; set; }
        /// <summary>
        /// Margin from left and right side of code (Default: 2px)
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Margin must be greater then 0.")]
        public int Margin { get; set; } = GeneratorConstants.Margin;
        /// <summary>
        /// Set to true for do not generate string below barcodes
        /// </summary>
        public bool SkipStringContent { get; set; } = GeneratorConstants.SkipStringContent;
        /// <summary>
        /// Foreground color in hex format (Acceptable: ffffff or %23ffffff)
        /// </summary>
        [RegularExpression(@"^#?[0-9A-Fa-f]{6}$", ErrorMessage = "Not valid hex color.")]
        public string ForegroundColor { get; set; } = Color.Black.ToHexString();
        /// <summary>
        /// Background color in hex format (Acceptable: ffffff or %23ffffff)
        /// </summary>
        [RegularExpression(@"^#?[0-9A-Fa-f]{6}$", ErrorMessage = "Not valid hex color.")]
        public string BackgroundColor { get; set; } = Color.White.ToHexString();
    }
}
