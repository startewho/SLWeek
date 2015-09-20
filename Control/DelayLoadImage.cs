using System;
using System.IO;
using System.IO.IsolatedStorage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Q42.WinRT;
using Q42.WinRT.Data;

namespace SLWeek.Control
{

        [TemplatePart(Name = PART_DEFAULTIMAGE_NAME, Type = typeof(Image))]
        [TemplatePart(Name = PART_ACTUALIMAGE_NAME, Type = typeof(Image))]
        [TemplateVisualState(Name = STATE_DEFAULT_NAME, GroupName = GROUP_COMMONSTATES_NAME)]
        [TemplateVisualState(Name = STATE_ACTUAL_NAME, GroupName = GROUP_COMMONSTATES_NAME)]
        public class DelayLoadImage : Windows.UI.Xaml.Controls.Control
        {
            private const string PART_DEFAULTIMAGE_NAME = "PART_DefaultImage";
            private const string PART_ACTUALIMAGE_NAME = "PART_ActualImage";

            private const string STATE_DEFAULT_NAME = "STATE_Default";
            private const string STATE_ACTUAL_NAME = "STATE_Actual";

            private const string GROUP_COMMONSTATES_NAME = "CommonStates";

            private BitmapImage _image;

            static DelayLoadImage()
            {
                StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(DelayLoadImage), new PropertyMetadata(default(Stretch),StretchChanged));
                DefaultImageSourceProperty = DependencyProperty.Register("DefaultImageSource", typeof(ImageSource), typeof(DelayLoadImage), new PropertyMetadata(default(ImageSource),DefaultImageSourceChanged));
                ActualImageSourceProperty = DependencyProperty.Register("ActualImageSource", typeof(string), typeof(DelayLoadImage), new PropertyMetadata(default(string),ActualImageSourceChanged));
            }

            public DelayLoadImage()
            {
                DefaultStyleKey = typeof(DelayLoadImage);

                _image = new BitmapImage {CreateOptions = BitmapCreateOptions.None};
                _image.ImageOpened += image_ImageOpened;
            }

            private bool imageLoaded = false;

            public void image_ImageOpened(object sender, RoutedEventArgs e)
            {
                imageLoaded = true;

                if (actualImage != null)
                {
                    actualImage.Source = _image;
                    VisualStateManager.GoToState(this, STATE_ACTUAL_NAME, false);
                }
            }

            public static readonly DependencyProperty StretchProperty;

            public Stretch Stretch
            {
                get { return (Stretch)GetValue(StretchProperty); }
                set { SetValue(StretchProperty, value); }
            }

            private static void StretchChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                DelayLoadImage instance = o as DelayLoadImage;
                if (instance != null)
                {
                    if (instance.defaultImage != null)
                        instance.defaultImage.Stretch = (Stretch)e.NewValue;
                    if (instance.actualImage != null)
                        instance.actualImage.Stretch = (Stretch)e.NewValue;
                }
            }

            public static readonly DependencyProperty DefaultImageSourceProperty;

            public ImageSource DefaultImageSource
            {
                get { return (ImageSource)GetValue(DefaultImageSourceProperty); }
                set { SetValue(DefaultImageSourceProperty, value); }
            }

            //private static ImageSourceConverter converter = new ImageSourceConverter();

            private static void DefaultImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                DelayLoadImage instance = o as DelayLoadImage;
                if (instance?.defaultImage != null)
                {
                    instance.defaultImage.Source = (ImageSource)e.NewValue;
                }
            }

            public static readonly DependencyProperty ActualImageSourceProperty;

            public string ActualImageSource
            {
                get { return (string)GetValue(ActualImageSourceProperty); }
                set { SetValue(ActualImageSourceProperty, value); }
            }

            private async static void ActualImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                DelayLoadImage instance = o as DelayLoadImage;
                if (instance != null)
                {
                    instance.imageLoaded = false;
                    var newCacheUri = new Uri(e.NewValue.ToString(), UriKind.RelativeOrAbsolute);
                    var cacheUri = await WebDataCache.GetLocalUriAsync(newCacheUri);
                    if (newCacheUri != cacheUri) return;
                    //这里需要更改
             
                              

              
                instance._image.UriSource = new Uri(e.NewValue.ToString(), UriKind.RelativeOrAbsolute);
                    VisualStateManager.GoToState(instance, STATE_DEFAULT_NAME, false);
                }
            }

            internal Image actualImage;
            internal Image defaultImage;

            protected override void OnApplyTemplate()
            {
                actualImage = (Image)GetTemplateChild(PART_ACTUALIMAGE_NAME);
                defaultImage = (Image)GetTemplateChild(PART_DEFAULTIMAGE_NAME);

                defaultImage.Source = DefaultImageSource;
                defaultImage.Stretch = Stretch;

                actualImage.Source = _image;
                actualImage.Stretch = Stretch;

                if (imageLoaded)
                {
                    VisualStateManager.GoToState(this, STATE_ACTUAL_NAME, false);
                }

                base.OnApplyTemplate();
            }
        }
    


}
