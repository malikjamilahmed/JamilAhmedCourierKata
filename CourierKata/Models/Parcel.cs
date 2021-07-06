﻿using CourierKata.Contracts;
using CourierKata.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.Models
{
    public class Parcel : IParcel
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ParcelSizeEnum Size { get; set; }

        public int Cost { get; set; }

        public Parcel(int length, int width, int height) {
            Height = height;
            Width = width;
            Length = length;            
        }
    }
}