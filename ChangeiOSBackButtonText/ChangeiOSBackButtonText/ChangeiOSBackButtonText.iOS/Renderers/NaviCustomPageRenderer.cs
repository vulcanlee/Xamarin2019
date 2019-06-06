using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeiOSBackButtonText.Interfaces;
using ChangeiOSBackButtonText.iOS.Renderers;
using ChangeiOSBackButtonText.Views;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NaviCustomPage), typeof(NaviCustomPageRenderer))]
namespace ChangeiOSBackButtonText.iOS.Renderers
{
    public class NaviCustomPageRenderer : NavigationRenderer
    {
        UIBarButtonItem barButtonItem;
        NaviCustomPage oldMyNaviPage;
        NaviCustomPage newMyNaviPage;

        protected override Task<bool> OnPushAsync(Page page, bool animated)
        {
            var retVal = base.OnPushAsync(page, animated);

            if (page is IDynamicChangeBackText)
            {
                SetBackButtonOnPage(page);
            }

            return retVal;
        }
        protected override Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            var retVal = base.OnPopViewAsync(page, animated);

            if (page is IDynamicChangeBackText)
            {
                var stack = page.Navigation.NavigationStack;

                var returnPage = stack[stack.Count - 2];

                if (returnPage != null)
                {
                    SetBackButtonOnPage(returnPage);
                }
            }
            else
            {
                //SetDefaultBackButton();
            }

            return retVal;
        }

        void SetBackButtonOnPage(Page page)
        {
            //var stack = page.Navigation.NavigationStack;

            //if(stack.Count == 1)
            //{
            //    //SetDefaultBackButton();
            //}

            if (page is IDynamicChangeBackText)
            {
                IDynamicChangeBackText dynamicChangeBackText =(IDynamicChangeBackText) page;
                SetImageTitleBackButton("Left", dynamicChangeBackText.BackButtonText, 0);
            }
            else
            {
                //SetDefaultBackButton();
            }

        }

        void SetImageTitleBackButton(string imageBundleName, string buttonTitle, int horizontalOffset)
        {
            var topVC = this.TopViewController;

            // Create the image back button
            //var backButtonImage = new UIBarButtonItem(
            //        UIImage.FromBundle(imageBundleName),
            //        UIBarButtonItemStyle.Plain,
            //        (sender, args) =>
            //        {
            //            topVC.NavigationController.PopViewController(true);
            //        });

            // Create the Text Back Button
            var backLeftButtonText = new UIBarButtonItem(
                "<",
                UIBarButtonItemStyle.Plain,
                (sender, args) =>
                {
                    topVC.NavigationController.PopViewController(true);
                });
            // Create the Text Back Button
            var backButtonText = new UIBarButtonItem(
                buttonTitle,
                UIBarButtonItemStyle.Plain,
                (sender, args) =>
                {
                    topVC.NavigationController.PopViewController(true);
                });

            backButtonText.SetTitlePositionAdjustment(new UIOffset(horizontalOffset, 0), UIBarMetrics.Default);

            // Add buttons to the Top Bar
            UIBarButtonItem[] buttons = new UIBarButtonItem[2];
            buttons[0] = backLeftButtonText;
            buttons[1] = backButtonText;

            topVC.NavigationItem.LeftBarButtonItems = buttons;
        }

        void SetDefaultBackButton()
        {
            this.TopViewController.NavigationItem.LeftBarButtonItems = null;
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            oldMyNaviPage = (NaviCustomPage)e.OldElement;
            newMyNaviPage = (NaviCustomPage)e.NewElement;
            if (oldMyNaviPage != null)
            {
                oldMyNaviPage.PropertyChanged -= OnElementPropertyChanged;
            }
            if (newMyNaviPage != null)
            {
                newMyNaviPage.PropertyChanged += OnElementPropertyChanged;
            }
            //// Create the material drop shadow
            //NavigationBar.TintColor = UIColor.Red;
            //NavigationBar.Layer.ShadowOffset = new CGSize(0, 0);
            //NavigationBar.Layer.ShadowRadius = 3;
            //NavigationBar.Layer.ShadowOpacity =0;

            //// Create the back arrow icon image
            //var arrowImage = UIImage.FromBundle("Icons/ic_arrow_back_white.png");
            //NavigationBar.BackIndicatorImage = arrowImage;
            //NavigationBar.BackIndicatorTransitionMaskImage = arrowImage;

            //// Set the back button title to empty since Material Design doesn't use it.
            //if (NavigationItem?.BackBarButtonItem != null)
            //    NavigationItem.BackBarButtonItem.Title = " ";
            //if (NavigationBar.BackItem != null)
            //{
            //    NavigationBar.BackItem.Title = " ";
            //    //NavigationBar.BackItem.BackBarButtonItem.Image = arrowImage;
            //}

            //NavigationItem.BackBarButtonItem = new UIBarButtonItem { Title = "111", Style = UIBarButtonItemStyle.Plain };
            //this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("text", UIBarButtonItemStyle.Plain, (sender, args) => { }), true);


            //NavigationItem.BackBarButtonItem = new UIBarButtonItem { Title = "", Style = UIBarButtonItemStyle.Plain };


            //barButtonItem = new UIBarButtonItem("text", UIBarButtonItemStyle.Plain, (sender, args) => { });
            //this.NavigationItem.SetLeftBarButtonItem(barButtonItem, true);
        }

        private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DynamicBackButtonText")
            {
                UpdateBackButtonTitleText();
            }
        }

        private void UpdateBackButtonTitleText()
        {
            //if (NavigationItem?.BackBarButtonItem != null)
            {
                string backTitle = "";
                if (App.Current.MainPage is MasterDetailPage)
                {
                    MasterDetailPage masterDetailPage = App.Current.MainPage as MasterDetailPage;
                    if (masterDetailPage.Detail is NaviCustomPage)
                    {
                        NaviCustomPage naviCustomPage = masterDetailPage.Detail as NaviCustomPage;
                        backTitle = naviCustomPage.DynamicBackButtonText;
                    }
                }
                else if (App.Current.MainPage is NaviCustomPage)
                {
                    NaviCustomPage naviCustomPage = App.Current.MainPage as NaviCustomPage;
                    backTitle = naviCustomPage.DynamicBackButtonText;
                }


                //string backTitle = ((NaviCustomPage)(App.Current.MainPage)).DynamicBackButtonText;
                //string backTitle = NaviCustomPage.GetDynamicBackButtonText(newMyNaviPage);
                if (this.NavigationBar.Items.Count() > 1)
                {
                    this.TopViewController.NavigationItem.LeftBarButtonItems[1].Title = backTitle;


                    //NavigationItem.BackBarButtonItem = new UIBarButtonItem { Title = backTitle };
                    //barButtonItem.Title = backTitle;
                    //NavigationItem.BackBarButtonItem.Title =  backTitle;


                    //this.NavigationBar.Items[0].Title = backTitle;
                    //UINavigationItem uINavigationItem = this.NavigationBar.Items[1];




                    //this.NavigationBar
                    //this.NavigationController.NavigationItem. = true;
                }
                //NavigationItem.BackBarButtonItem.Title = backTitle;
                //NavigationItem.BackBarButtonItem = new UIBarButtonItem { Title = backTitle };
                //NavigationItem.Title = backTitle;
            }
        }
    }
}