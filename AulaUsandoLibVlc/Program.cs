using LibVLCSharp.Shared;
using StructureMap.Pipeline;

namespace Aula.NetCore.LibVLCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arquivos = Directory.GetFiles(@"C:\tmp");
            string[] arquivos2 = Directory.GetFiles(@"C:\tmp", "*", SearchOption.AllDirectories);
            string[] arquivos3 = Directory.GetFiles(@"C:\tmp", "*.txt");
            List<Media> listaMedia = new List<Media>();

            Stream stream = File.OpenRead(@"C:\tmp\temp\Nitro_Wallpaper_5000x2813.jpg");

            var libVLC = new LibVLC(enableDebugLogs: false);
            Console.WriteLine("Running on LibVLC {0} ({1})", libVLC.Version, libVLC.Changeset);
            Console.WriteLine(" (compiled with {0})", libVLC.LibVLCCompiler);

            var media = new Media(libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));
            var media3 = new Media(libVLC, new StreamMediaInput(stream));
            //
            string[] list =
                 { @"C:\tmp\temp\Nitro_Wallpaper_5000x2813.jpg",
                @"C:\tmp\temp\planet9_Wallpaper_5000x2813.jpg"};

            var t = @"C:\tmp\temp\planet9_Wallpaper_5000x2813.jpg";

            var media2 = new Media(libVLC, t);
            var media5 = new Media(libVLC, @"C:\tmp\temp\Nitro_Wallpaper_5000x2813.jpg");

            var y = new MediaDiscoverer(libVLC, "teste");

            var mediaList = new MediaList(libVLC);
            mediaList.AddMedia(media5);
            mediaList.AddMedia(media2);
            mediaList.SetMedia(media);
            
            listaMedia.Add(media2);
            listaMedia.Add(media5);
            media5 = new Media(libVLC, new Uri("https://infonet.com.br/wp-content/uploads/2022/06/medicos_fotofreepik_020622-210x136.jpg"));
            mediaList.AddMedia(media5);
            mediaList.AddMedia(media);

            var media4 = new Media(mediaList);

            //
            var mp = new MediaPlayer(media4);
            var l1 = mediaList.Count;
            Int64 tempoMedia = mediaList[2].Duration;
            for (int i = 0; i < l1; i++)
            {
                mp.Fullscreen = true;
                tempoMedia = mediaList[i].Duration;
                mp.Play(mediaList[i]);
                Thread.Sleep(1000);
                tempoMedia = mediaList[i].Duration;
                //tempoMedia = tempoMedia < 5000 ? 5000 : tempoMedia;
                //Task.Delay((int)tempoMedia);
                Thread.Sleep((int)tempoMedia);
            }
            mp.Stop();
            Console.ReadKey();
            //mp.Play(media2);
            mp.NextChapter();
            Console.ReadKey();
            Console.Beep();
        }
    }
}
/*
 m = library.libvlc_media_new_location(inst, "path/to/your/file"); // Create a new item 
    mp = library.libvlc_media_player_new_from_media(m);               // Create a media player playing environement 
    library.libvlc_media_release(m);                                  // No need to keep the media now 
    library.libvlc_media_player_play(mp);                             // play the media_player 
    Thread.Sleep(10000);                                              // Let it play a bit 
    library.libvlc_media_player_stop(mp);                             // Stop playing 
    library.libvlc_media_player_release(mp);                          // Free the media_player 
    library.libvlc_release(inst);

    LibVLCLibrary.Free(library);
 
 */