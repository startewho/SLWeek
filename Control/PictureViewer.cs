using System;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace SLWeek.Control
{

    [TemplatePart(Name = "Thumbnail", Type = typeof(Image))]
    [TemplatePart(Name = "Image", Type = typeof(Image))]
    [TemplatePart(Name = "Root", Type = typeof(Grid))]
    public class PictureViewer :Windows.UI.Xaml.Controls.Control
    {
        private Image ImageControl;
        private Image ThumbnailImageControl;
        private Grid Root;
        private CompositeTransform RootRenderTransform;
        private Point? lastOrigin;
        private double lastUniformScale;
        private Point ImagePosition = new Point(0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageViewer"/> class.
        /// </summary>
        public PictureViewer()
        {
            DefaultStyleKey = typeof(PictureViewer);
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application
        /// code or internal processes (such as a rebuilding layout pass)
        /// call <see cref="M:System.Windows.Controls.Control.ApplyTemplate"/>.
        /// In simplest terms, this means the method is called just before a UI
        /// element displays in an application.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            if (ThumbnailImageControl != null) //Unhook from old template
            {
                ThumbnailImageControl.ImageOpened -= ThumbImage_ImageOpened;
                ThumbnailImageControl.ImageFailed -= ThumbImage_ImageFailed;
            }
            ThumbnailImageControl = GetTemplateChild("Thumbnail") as Image;
            if (ThumbnailImageControl != null)
            {
                ThumbnailImageControl.ImageOpened += ThumbImage_ImageOpened;
                ThumbnailImageControl.ImageFailed += ThumbImage_ImageFailed;
            }

            if (ImageControl != null) //Unhook from old template
            {
                ImageControl.ImageOpened -= Image_ImageOpened;
                ImageControl.ImageFailed -= Image_ImageFailed;
            }
            ImageControl = GetTemplateChild("Image") as Image;
            if (ImageControl != null)
            {
                ImageControl.ImageOpened += Image_ImageOpened;
                ImageControl.ImageFailed += Image_ImageFailed;
            }

            if (Root != null) //Unhook from old template
            {
             
                Root.ManipulationDelta -= Root_ManipulationDelta;
                Root.ManipulationStarted -= Root_ManipulationStarted;
                RootRenderTransform = null;
            }
            Root = GetTemplateChild("Root") as Grid;
            if (Root != null)
            {
                Root.ManipulationDelta += Root_ManipulationDelta;
                Root.ManipulationStarted += Root_ManipulationStarted;
                Root.RenderTransform = RootRenderTransform = new CompositeTransform();
            }
            base.OnApplyTemplate();
        }

        /// <summary>
        /// Provides the behavior for the Measure pass of Silverlight layout.
        /// Classes can override this method to define their own Measure pass behavior.
        /// </summary>
        /// <param name="availableSize">The available size that this object can 
        /// give to child objects. Infinity (<see cref="F:System.Double.PositiveInfinity"/>) 
        /// can be specified as a value to indicate that the object will size to
        /// whatever content is available.</param>
        /// <returns>
        /// The size that this object determines it needs during layout, based on
        /// its calculations of the allocated sizes for child objects; or based 
        /// on other considerations, such as a fixed container size.
        /// </returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            //Set clip, so when scaling image, image won't go outside its bounds.
            Clip = new RectangleGeometry() { Rect = new Rect(new Point(), availableSize) };
            return base.MeasureOverride(availableSize);
        }

        /// <summary>
        /// Handles the ManipulationStarted event of the Root control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ManipulationStartedEventArgs"/>
        /// instance containing the event data.</param>
        private void Root_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            lastUniformScale = Math.Sqrt(2);
            lastOrigin = null;
        }

        /// <summary>
        /// Handles the ManipulationDelta event of the Root control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.ManipulationDeltaEventArgs"/> 
        /// instance containing the event data.</param>
        private void Root_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var transform = (CompositeTransform)Root.RenderTransform;

            if (transform != null)
            {
                var origin = e.OriginalSource as FrameworkElement;

                transform.SkewX *= e.Delta.Scale;
                transform.SkewY *= e.Delta.Scale;
            }
        }

        private void Image_ImageOpened(object sender, RoutedEventArgs e)
        {
            IsImageLoaded = true;
            if (ImageOpened != null)
                ImageOpened(this, EventArgs.Empty);
            if (ThumbnailImageControl != null)
                ThumbnailImageControl.Visibility = Visibility.Collapsed;
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            if (ImageFailed != null)
                ImageFailed(this, EventArgs.Empty);
        }

        private void ThumbImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            IsThumbnailLoaded = true;
            if (ThumbnailOpened != null)
                ThumbnailOpened(this, EventArgs.Empty);
        }

        private void ThumbImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            if (ThumbnailFailed != null)
                ThumbnailFailed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets or sets the high resolution image to display.
        /// </summary>
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Image"/> Dependency Property.
        /// </summary>
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(PictureViewer), new PropertyMetadata(default(ImageSource), OnImagePropertyChanged));

        private static void OnImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var iv = (d as PictureViewer);
            iv.IsImageLoaded = false;
        }

        /// <summary>
        /// Gets or sets the thumbnail. This should be the exact same as the 
        /// Image set on <see cref="Image"/>, but at a lower resolution.
        /// </summary>
        public ImageSource Thumbnail
        {
            get { return (ImageSource)GetValue(ThumbnailProperty); }
            set { SetValue(ThumbnailProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Thumbnail"/> Dependency Property.
        /// </summary>
        public static readonly DependencyProperty ThumbnailProperty =
            DependencyProperty.Register("Thumbnail", typeof(ImageSource), typeof(PictureViewer), new PropertyMetadata(default(ImageSource),OnThumbnailPropertyChanged));

        private static void OnThumbnailPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var iv = (d as PictureViewer);
            iv.IsThumbnailLoaded = false;
            if (iv.ThumbnailImageControl != null)
                iv.ThumbnailImageControl.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Gets a value indicating whether the high resolution image has loaded.
        /// </summary>
        public bool IsImageLoaded { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the thumbnail image has loaded.
        /// </summary>
        public bool IsThumbnailLoaded { get; private set; }

        /// <summary>
        /// Fired when the full resolution image has successfully loaded.
        /// </summary>
        public event EventHandler ImageOpened;
        /// <summary>
        /// Fired when the full resolution image failed to load.
        /// </summary>
        public event EventHandler ImageFailed;
        /// <summary>
        /// Fired when the thumbnail image has successfully loaded.
        /// </summary>
        public event EventHandler ThumbnailOpened;
        /// <summary>
        /// Fired when the thumbnail image has failed to load.
        /// </summary>
        public event EventHandler ThumbnailFailed;
    }
}
