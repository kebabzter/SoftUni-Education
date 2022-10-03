using System;
using System.Collections.Generic;
using System.Text;

namespace BoxData
{
    public class Box
    {
        //length, width and height
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Height
        {
            get { return height; }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value; 
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value; 
            }
        }

        public double Length
        {
            get { return length; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value; 
            }
        }

        //Volume = lwh
        private double Volume()
        {
            return Length * Width * Height;
        }

        //Lateral Surface Area = 2lh + 2wh
        private double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        //Surface Area = 2lw + 2lh + 2wh
        private double SurfaceArea()
        {
            return 2*Length*Width+ 2 * Length * Height + 2 * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");
            
            return sb.ToString().TrimEnd();
        }
    }
}
