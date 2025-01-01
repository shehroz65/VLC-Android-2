using Android.App;
using Android.OS;
using LibVLCSharp.Shared;
using LibVLCSharp.Platforms.Android;

namespace VLC_Android_2
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private LibVLCSharp.Platforms.Android.VideoView videoView;
        private LibVLC libVLC;
        private MediaPlayer mediaPlayer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Initialize the LibVLC library
            Core.Initialize();

            SetContentView(Resource.Layout.activity_main);

            // Get the VideoView from the layout
            videoView = FindViewById<LibVLCSharp.Platforms.Android.VideoView>(Resource.Id.videoView);

            // Create a new LibVLC instance with the application context
            libVLC = new LibVLC();


            // Create a new MediaPlayer instance
            mediaPlayer = new MediaPlayer(libVLC);

            // Assign the MediaPlayer to the VideoView
            videoView.MediaPlayer = mediaPlayer;

            // Set up the media (replace with your online video URL)
            var media = new Media(libVLC, "", FromType.FromLocation);

            // Assign the media to the MediaPlayer
            mediaPlayer.Media = media;

            // Start playback
            mediaPlayer.Play();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            // Stop and dispose of the media player and libVLC instances
            mediaPlayer?.Stop();
            mediaPlayer?.Dispose();
            libVLC?.Dispose();
        }
    }
}
