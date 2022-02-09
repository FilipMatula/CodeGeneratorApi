
using ZXing;
using Tyrrrz.Extensions;

namespace CodeGenerator.Extensions
{
    static class BarcodeFormatExtensions
    {
        public static bool IsSquare(this BarcodeFormat format)
        {
            return format.IsEither(BarcodeFormat.AZTEC, BarcodeFormat.DATA_MATRIX, BarcodeFormat.QR_CODE);
        }
    }
}
