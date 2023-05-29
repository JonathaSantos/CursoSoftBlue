using FFMpegCore;
using FFMpegCore.Pipes;
using FFMpegCore.Extensions.System.Drawing.Common;

using FFMpegCore.Enums;
using System.Drawing;
using FFMediaToolkit.Encoding;
using FFMediaToolkit.Graphics;
using FFMediaToolkit;
using System.Drawing.Imaging;

namespace FFMPEGAppTeste
{
    internal class TesteFFMPEG
    {
        public void TesteVideo()
        {



            List<string> video = new List<string>();
            video.Add(@"C:\Users\jonat\Downloads\Drive\1 - Dízimos YouTube Abril.jpg");
            //video.Add(@"C:\Users\jonat\Downloads\Drive\8anos.jpeg");
            //video.Add(@"C:\Users\jonat\Downloads\Drive\8anos.jpeg");
            var s = string.Join(",", video.ToArray());
            ////
            ///

            FFmpegLoader.FFmpegPath = @"C:\Desenvolvimento\com versionamento\CursoC#\CursoSoftBlue\FFMPEGAppTeste\bin\";

            var settings = new VideoEncoderSettings(width: 960, height: 544, framerate: 30, codec: FFMediaToolkit.Encoding.VideoCodec.H264);
            settings.EncoderPreset = EncoderPreset.Fast;
            settings.CRF = 17;
            var file = MediaBuilder.CreateContainer(@"C:\Users\jonat\Downloads\out.mp4").WithVideo(settings).Create();
            var files = Directory.GetFiles(@"C:\Users\jonat\Downloads\Drive\");
            foreach (var inputFile in files)
            {
                var binInputFile = File.ReadAllBytes(inputFile);
                var memInput = new MemoryStream(binInputFile);
                var bitmap = Bitmap.FromStream(memInput) as Bitmap;
                var rect = new System.Drawing.Rectangle(System.Drawing.Point.Empty, bitmap.Size);
                var bitLock = bitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                var bitmapData = ImageData.FromPointer(bitLock.Scan0, ImagePixelFormat.Bgr24, bitmap.Size);
                file.Video.AddFrame(bitmapData); // Encode the frame
                bitmap.UnlockBits(bitLock);


            }

            file.Dispose();

            ///

        }
    }
}
