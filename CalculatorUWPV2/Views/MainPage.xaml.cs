using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CalculatorUWPV2.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {

        dynamic arthimaticResult = 0;
        dynamic arthimaticProduct = 1;
        double divition_number1;

        dynamic knowingTheOperation;


        public MainPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

            // Hide default title bar.
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            UpdateTitleBarLayout(coreTitleBar);

            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(AppTitleBar);

            // Register a handler for when the size of the overlaid caption control changes.
            // For example, when the app moves to a screen with a different DPI.
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;

            // Register a handler for when the title bar visibility changes.
            // For example, when the title bar is invoked in full screen mode.
            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;

            //Register a handler for when the window changes focus
           // Window.Current.Activated += Current_Activated;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private void OnLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var result = ApplicationView.GetForCurrentView().TryResizeView(new Size(330, 500));
            Debug.WriteLine("OnLoaded TryResizeView: " + result);
        }


        enum Operation
        {
            Addition, Multiplication, Subtraction, Division
        }

        void calcutiong(dynamic choice)
        {


            switch (choice)
            {
                case Operation.Addition:

                    this.arthimaticResult = this.arthimaticResult + double.Parse(this.screencontent.Text);

                   

                    break;

                case Operation.Subtraction:

                    this.arthimaticResult = (this.arthimaticResult * -1) - double.Parse(this.screencontent.Text);

                    /*String info = this.arthimaticResult;
                    MessageBox.Show(info);*/

                    break;

                case Operation.Division:

                    this.arthimaticResult = this.divition_number1 / double.Parse(this.screencontent.Text);
                    
                    break;

                case Operation.Multiplication:


                    this.arthimaticProduct = this.arthimaticProduct * double.Parse(this.screencontent.Text);
                    this.arthimaticResult = this.arthimaticProduct;

                    break;

                default:
                    break;

            }

            this.screencontent.Text = "";


        }

        void displayTheResult(dynamic operationname)
        {

            calcutiong(operationname);


            this.screencontent.Text = this.arthimaticResult.ToString();
        }


        private void _0_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "0";
        }

        private void _1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "1";
        }

        private void _2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "2";
        }

        private void _3_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "3";
        }

        private void _4_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "4";
        }

        private void _5_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "5";
        }

        private void _6_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "6";
        }

        private void point_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + ".";
        }

      
        private void CLS_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = "";
            this.arthimaticResult = 0;

            this.arthimaticProduct = 1;
        }

        private void _7_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "7";
        }

        private void _8_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "8";
        }

        private void _9_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.screencontent.Text = this.screencontent.Text + "9";
        }

        private void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void add_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calcutiong(Operation.Addition);

            knowingTheOperation = Operation.Addition;
        }

        private void sub_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calcutiong(Operation.Subtraction);

            knowingTheOperation = Operation.Subtraction;
        }

        private void devision_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.divition_number1 = double.Parse(this.screencontent.Text);

            knowingTheOperation = Operation.Division;

            this.screencontent.Text = "";
        }

        private void multipy_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            calcutiong(Operation.Multiplication);
            knowingTheOperation = Operation.Multiplication;
        }

        private void equalsResult_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (this.screencontent.Text != "")
            {
                displayTheResult(knowingTheOperation);

            }
        }




        ////////////////////////////////for title bar
        ///
        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            UpdateTitleBarLayout(sender);
        }

        private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
        {
            // Update title bar control size as needed to account for system size changes.
            AppTitleBar.Height = coreTitleBar.Height;

            // Ensure the custom title bar does not overlap window caption controls
            Thickness currMargin = AppTitleBar.Margin;
            AppTitleBar.Margin = new Thickness(currMargin.Left, currMargin.Top, coreTitleBar.SystemOverlayRightInset, currMargin.Bottom);
        }

        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (sender.IsVisible)
            {
                AppTitleBar.Visibility = Visibility.Visible;
            }
            else
            {
                AppTitleBar.Visibility = Visibility.Collapsed;
            }
        }

        // Update the TitleBar based on the inactive/active state of the app
       /* private void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            SolidColorBrush defaultForegroundBrush = (SolidColorBrush)Application.Current.Resources["TextFillColorPrimaryBrush"];
            SolidColorBrush inactiveForegroundBrush = (SolidColorBrush)Application.Current.Resources["TextFillColorDisabledBrush"];

            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                AppTitle.Foreground = inactiveForegroundBrush;
            }
            else
            {
                AppTitle.Foreground = defaultForegroundBrush;
            }
        }*/

        // Update the TitleBar content layout depending on NavigationView DisplayMode
        private void NavigationViewControl_DisplayModeChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewDisplayModeChangedEventArgs args)
        {
            const int topIndent = 16;
            const int expandedIndent = 48;
            int minimalIndent = 104;

            // If the back button is not visible, reduce the TitleBar content indent.
           /* if (NavigationViewControl.IsBackButtonVisible.Equals(Microsoft.UI.Xaml.Controls.NavigationViewBackButtonVisible.Collapsed))
            {
                minimalIndent = 48;
            }*/

            Thickness currMargin = AppTitleBar.Margin;

            // Set the TitleBar margin dependent on NavigationView display mode
            if (sender.PaneDisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewPaneDisplayMode.Top)
            {
                AppTitleBar.Margin = new Thickness(topIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
            else if (sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Minimal)
            {
                AppTitleBar.Margin = new Thickness(minimalIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
            else
            {
                AppTitleBar.Margin = new Thickness(expandedIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
        }
    }


}
