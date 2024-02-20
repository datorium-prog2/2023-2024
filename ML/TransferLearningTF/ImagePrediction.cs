using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLearningTF
{
    public class ImagePrediction : ImageData
    {
        public float[]? Score; //0.80 -> 80% ka tas ir konkrētais label

        public string? PredictedLabelValue; // prognozētais label
    }
}
