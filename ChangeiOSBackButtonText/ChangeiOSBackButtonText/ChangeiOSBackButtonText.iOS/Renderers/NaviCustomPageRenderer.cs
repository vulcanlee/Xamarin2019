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
                IDynamicChangeBackText dynamicChangeBackText = (IDynamicChangeBackText)page;
                SetImageTitleBackButton("Left2", dynamicChangeBackText.BackButtonText, 0);
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
            var backButtonImage = new UIBarButtonItem(
                    UIImage.FromBundle(imageBundleName),
                    UIBarButtonItemStyle.Plain,
                    (sender, args) =>
                    {
                        topVC.NavigationController.PopViewController(true);
                    });

            // Create the Text Back Button
            //var backLeftButtonText = new UIBarButtonItem(
            //    "<",
            //    UIBarButtonItemStyle.Plain,
            //    (sender, args) =>
            //    {
            //        topVC.NavigationController.PopViewController(true);
            //    });

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
            buttons[0] = backButtonImage;
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
            string backTitle = "";
            if (App.Current.MainPage is MasterDetailPage)
            {
                MasterDetailPage masterDetailPage = App.Current.MainPage as MasterDetailPage;
                if (masterDetailPage.Detail is NaviCustomPage)
                {
                    NaviCustomPage naviCustomPage = masterDetailPage.Detail as NaviCustomPage;
                    if (naviCustomPage.CurrentPage is IDynamicChangeBackText)
                    {
                        IDynamicChangeBackText dynamicChangeBackText = naviCustomPage.CurrentPage as IDynamicChangeBackText;
                        backTitle = dynamicChangeBackText.BackButtonText;
                    }

                    //backTitle = naviCustomPage.DynamicBackButtonText;
                    //backTitle = NaviCustomPage.GetNeedGoBackButtonChanged(naviCustomPage.CurrentPage);
                }
            }
            else if (App.Current.MainPage is NaviCustomPage)
            {
                NaviCustomPage naviCustomPage = App.Current.MainPage as NaviCustomPage;
                if (naviCustomPage.CurrentPage is IDynamicChangeBackText)
                {
                    IDynamicChangeBackText dynamicChangeBackText = naviCustomPage.CurrentPage as IDynamicChangeBackText;
                    backTitle = dynamicChangeBackText.BackButtonText;
                }
                //backTitle = NaviCustomPage.GetNeedGoBackButtonChanged(naviCustomPage.CurrentPage);
            }

            if (this.NavigationBar.Items.Count() > 1)
            {
                this.TopViewController.NavigationItem.LeftBarButtonItems[1].Title = backTitle;
            }
        }
    }
}