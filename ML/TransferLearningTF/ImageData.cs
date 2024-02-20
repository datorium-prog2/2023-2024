using Microsoft.ML.Data;

namespace TransferLearningTF
{
    public class ImageData
    {
        [LoadColumn(0)]
        public string? ImagePath; // Path uz broccoli.jpg bildi

        [LoadColumn(1)]
        public string? Label; // Food
    }
}
