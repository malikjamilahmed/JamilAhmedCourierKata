using CourierKata.Enums;

namespace CourierKata.Contracts
{
    public interface IParcel
    {
        int Length { get; set; }

        int Width { get; set; }

        int Height { get; set; }

        int Weight { get; set; }

        int Cost { get; set; }

        ParcelSizeEnum Size { get; set; }
    }
}
