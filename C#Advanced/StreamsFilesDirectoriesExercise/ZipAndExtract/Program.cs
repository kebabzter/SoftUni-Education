using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"..\..\..\CopyMe", @"..\CopyMeZip.zip");
            ZipFile.ExtractToDirectory(@"..\CopyMeZip.zip", @"..\");
        }
    }
}
