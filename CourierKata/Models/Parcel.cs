using CourierKata.Contracts;
using CourierKata.Enums;

namespace CourierKata.Models
{
    public class Parcel : IParcel
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public ParcelSizeEnum Size { get; set; }

        public int Cost { get; set; }

        public Parcel(int length, int width, int height, int weight = 0) {
            Height = height;
            Width = width;
            Length = length;
            Weight = weight;
        }
    }
}
