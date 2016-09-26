using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Photme_PortableLibrary.Model;
using Photme_PortableLibrary.ViewModel;

namespace Photme_Android
{
    [Activity(Label = "Photme_Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeActivity : Activity
    {
        IList<PhotoItem> photos;
        PhotoItemListAdapter _photoList;
        Button addPhotoButton;
        ListView photoListView;
        MainViewModel _mainViewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Home);

            _mainViewModel = new MainViewModel();

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

            photos = _mainViewModel.ItemsList;

            // create our adapter
            _photoList = new PhotoItemListAdapter(this, photos);

            //Hook up our adapter to our ListView
            photoListView.Adapter = _photoList;
        }

    }
}

