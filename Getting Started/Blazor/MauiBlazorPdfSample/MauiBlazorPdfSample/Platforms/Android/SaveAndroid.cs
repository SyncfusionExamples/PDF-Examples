using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Environment = Android.OS.Environment;

namespace MauiBlazorPdfSample.Services
{
    public partial class SaveService
    {
        public partial void SaveAndView(string filename, string contentType, MemoryStream stream)
        {
            var fileUri = saveToGallery(stream);

            var intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(fileUri,"application/pdf");
            intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            intent.AddFlags(ActivityFlags.NoHistory);
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
        public Android.Net.Uri saveToGallery(MemoryStream root)
        {
            Android.Net.Uri contentCollection = null;


            ContentResolver resolver = Android.App.Application.Context.ContentResolver;

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
            {
                contentCollection = MediaStore.Downloads.GetContentUri(MediaStore.VolumeExternalPrimary);
            }
            else
            {
                 contentCollection = MediaStore.Downloads.ExternalContentUri;
            }

            ContentValues valuesmedia = new ContentValues();
            valuesmedia.Put(MediaStore.MediaColumns.DisplayName, "Output.pdf");
            valuesmedia.Put(MediaStore.MediaColumns.MimeType, "application/pdf");
            valuesmedia.Put(MediaStore.MediaColumns.RelativePath, Environment.DirectoryDownloads);

            Android.Net.Uri savedPdfUri = resolver.Insert(contentCollection, valuesmedia);
            try
            {
                Stream outdata = resolver.OpenOutputStream(savedPdfUri);
                outdata.Write(root.ToArray());

                valuesmedia.Clear();
                Toast.MakeText(Android.App.Application.Context, "Pdf saved to Downloads", ToastLength.Short).Show();
            }
            catch (Exception exception)
            {
                Toast.MakeText(Android.App.Application.Context, "Pdf not saved to Downloads", ToastLength.Short).Show();
            }
            return savedPdfUri;
        }
    }
}