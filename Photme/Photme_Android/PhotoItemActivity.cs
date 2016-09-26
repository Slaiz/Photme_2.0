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
using Photme_PortableLibrary.ViewModel;
using File = Java.IO.File;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace Photme_Android
{
    [Activity(Label = "PhotoItemActivity")]

    // View/edit a Photo, capture image

    public class PhotoItemActivity : Activity
    {
        private ImageView imageView;
        private EditText notesTextEdit;
        private EditText nameTextEdit;
        private Button saveButton;
        private Button captureButton;
        private byte[] _byteData;
        private MainViewModel _mainViewModel;
        private ImageHelper _imageHelper;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // set our layout to be the home screen
            SetContentView(Resource.Layout.PhotoDetails);

            _mainViewModel = new MainViewModel();
            _imageHelper = new ImageHelper();

            nameTextEdit = FindViewById<EditText>(Resource.Id.NameText);
            notesTextEdit = FindViewById<EditText>(Resource.Id.NotesText);

            imageView = FindViewById<ImageView>(Resource.Id.ImvImage);

            saveButton = FindViewById<Button>(Resource.Id.SaveButton);
            captureButton = FindViewById<Button>(Resource.Id.CaptureButton);

            nameTextEdit.Text = _mainViewModel.TextProperty1;
            notesTextEdit.Text = _mainViewModel.TextProperty2;


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

        public void ImageConverting(Bitmap bitmap)
        {

            imageView.SetImageBitmap(bitmap);

            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                _byteData = stream.ToArray();
            }
        }

        void Save()
        {
            _mainViewModel.TextProperty1 = nameTextEdit.Text;
            _mainViewModel.TextProperty2 = notesTextEdit.Text;
            _mainViewModel.ImageBytes = _byteData;

            _mainViewModel.AddPhoto();

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
            _imageHelper.Dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "Photme_Android");

            if (!_imageHelper.Dir.Exists())
            {
                _imageHelper.Dir.Mkdirs();
            }
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            _imageHelper.File = new File(_imageHelper.Dir, String.Format("Images_{0}.jpg", Guid.NewGuid()));

            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_imageHelper.File));

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(_imageHelper.File);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);


            int height = Resources.DisplayMetrics.HeightPixels;
            int width = imageView.Height;

            _imageHelper.Bitmap = _imageHelper.File.Path.LoadAndResizeBitmap(width, height);

            if (_imageHelper.Bitmap != null)
            {
                ImageConverting(_imageHelper.Bitmap);
            }
        }
    }
}