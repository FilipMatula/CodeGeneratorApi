using CodeGenerator.ResourceParameters;

namespace CodeGenerator.Services
{
    public interface IGeneratorService
    {
        System.Drawing.Bitmap Generate(GenerateResourceParameters parameters);
    }
}
