using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Photme_PortableLibrary.Model;
using File = Java.IO.File;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace Photme_Android
{
    public static class ImageHelp
    {
        public static File File;
        public static File Dir;
        public static Bitmap Bitmap;
    }

    [Activity(Label = "PhotoItemActivity")]

    // View/edit a Photo, capture image

    public class PhotoItemActivity : Activity
    {
        PhotoItem _photo = new PhotoItem();
        ImageView imageView;
        byte[] _byteData;
        EditText notesTextEdit;
        EditText nameTextEdit;
        Button saveButton;
        Button cancelDeleteButton;
        Button captureButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // set our layout to be the home screen
            SetContentView(Resource.Layout.PhotoDetails);

            nameTextEdit = FindViewById<EditText>(Resource.Id.NameText);
            notesTextEdit = FindViewById<EditText>(Resource.Id.NotesText);

            imageView = FindViewById<ImageView>(Resource.Id.ImvImage);

            saveButton = FindViewById<Button>(Resource.Id.SaveButton);
            captureButton = FindViewById<Button>(Resource.Id.CaptureButton);

            nameTextEdit.Text = _photo.Name;
            notesTextEdit.Text = _photo.Note;


            imageView.SetImageResource(Resource.Drawable.Icon);


            // button clicks 

            saveButton.Click += (sender, e) =>
            {
                if (_byteData != null)
                {
                    Save();
                }
                else
                {
                    Toast.MakeText(this, "Please capture photo", ToastLength.Long).Show();
                }
            };

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                captureButton.Click += TakeAPicture;
            }
        }

        private void ImageConverting(ref Bitmap bitmap)
        {
            imageView.SetImageBitmap(bitmap);

            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                _byteData = stream.ToArray();
            }

            bitmap = null;
        }

        void Save()
        {
            _photo.Name = nameTextEdit.Text;
            _photo.Note = notesTextEdit.Text;
            _photo.Image = _byteData;

            //FotmiApp.Current.PhotoService.SavePhoto(_photo);

            Finish();
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void CreateDirectoryForPictures()
        {
            ImageHelp.Dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "Photme_Android");

            if (!ImageHelp.Dir.Exists())
            {
                ImageHelp.Dir.Mkdirs();
            }
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            ImageHelp.File = new File(ImageHelp.Dir, String.Format("Images_{0}.jpg", Guid.NewGuid()));

            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(ImageHelp.File));

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(ImageHelp.File);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);


            int height = Resources.DisplayMetrics.HeightPixels;
            int width = imageView.Height;

            ImageHelp.Bitmap = ImageHelp.File.Path.LoadAndResizeBitmap(width, height);

            if (ImageHelp.Bitmap != null)
            {
                ImageConverting(ref ImageHelp.Bitmap);
            }

            GC.Collect();
        }
    }
}