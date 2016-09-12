using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Photme_PortableLibrary.Model;

namespace Photme_Android
{
    [Activity(Label = "Photme_Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeActivity : Activity
    {
        PhotoItemListAdapter _photoList;
        IList<PhotoItem> _photos;
        Button addPhotoButton;
        ListView photoListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Home);

            photoListView = FindViewById<ListView>(Resource.Id.photoList);
            addPhotoButton = FindViewById<Button>(Resource.Id.AddButton);

            // 
            if (addPhotoButton != null)
            {
                addPhotoButton.Click += (sender, e) => {
                    StartActivity(typeof(PhotoItemActivity));
                };
            }

            // 
            if (photoListView != null)
            {
                photoListView.ItemClick += (sender, e) => {
                    StartActivity(typeof(PhotoItemActivity));
                };
            }
        }
     
        protected override void OnResume()
        {
            base.OnResume();

            //_photos = FotmiApp.Current.PhotoService.GetPhotos();

            // create our adapter
            _photoList = new PhotoItemListAdapter(this, _photos);

            //Hook up our adapter to our ListView
            photoListView.Adapter = _photoList;
        }

    }
}

