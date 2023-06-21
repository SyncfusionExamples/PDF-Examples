using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Java.IO;
using Open_and_save_PDF_document_Xamarin.Droid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndroid))]
namespace Open_and_save_PDF_document_Xamarin.Droid
{
    class SaveAndroid : ISave
    {
        //Method to save document as a file in Android and view the saved document
        public async Task SaveAndView(string fileName, String contentType, MemoryStream stream)
        {
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
            {
                var fileUri = saveToDownloads(stream);

                var intent = new Intent();
                intent.SetFlags(ActivityFlags.ClearTop);
                intent.SetFlags(ActivityFlags.NewTask);
                intent.SetAction(Intent.ActionSend);
                intent.SetType("*/*");
                intent.PutExtra(Intent.ExtraStream, fileUri);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);

                var chooserIntent = Intent.CreateChooser(intent, "Send File");
                chooserIntent.SetFlags(ActivityFlags.ClearTop);
                chooserIntent.SetFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(chooserIntent);
            }
            else
            {
                string exception = string.Empty;
                string root = null;

                if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
                {
                    ActivityCompat.RequestPermissions((Android.App.Activity)Forms.Context, new String[] { Manifest.Permission.WriteExternalStorage }, 1);
                }

                if (Android.OS.Environment.IsExternalStorageEmulated)
                {
                    root = Android.OS.Environment.ExternalStorageDirectory.ToString();
                }
                else
                    root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

                Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
                try
                {
                    myDir.Mkdir();
                }
                catch (Exception e)
                {

                }
                Java.IO.File file = new Java.IO.File(myDir, fileName);

                if (file.Exists()) file.Delete();

                try
                {
                    FileOutputStream outs = new FileOutputStream(file);
                    outs.Write(stream.ToArray());

                    outs.Flush();
                    outs.Close();
                }
                catch (Exception e)
                {
                    exception = e.ToString();
                }
                if (file.Exists() && contentType != "application/html")
                {
                    string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                    string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                    try
                    {
                        Android.Net.Uri path = FileProvider.GetUriForFile(Forms.Context, Android.App.Application.Context.PackageName + ".provider", file);
                        intent.SetDataAndType(path, mimeType);
                    }
                    catch (Exception e)
                    {
                        exception = e.ToString();
                    }
                    intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                    Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
                }
            }
        }

        public Android.Net.Uri saveToDownloads(MemoryStream root)
        {
            Android.Net.Uri contentCollection = null;


            ContentResolver resolver = Android.App.Application.Context.ContentResolver;


            contentCollection = MediaStore.Downloads.GetContentUri(MediaStore.VolumeExternalPrimary);

            ContentValues valuesmedia = new ContentValues();
            valuesmedia.Put(MediaStore.MediaColumns.DisplayName, "Output.pdf");
            valuesmedia.Put(MediaStore.MediaColumns.MimeType, "application/pdf");
            valuesmedia.Put(MediaStore.MediaColumns.RelativePath, Android.OS.Environment.DirectoryDownloads);

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