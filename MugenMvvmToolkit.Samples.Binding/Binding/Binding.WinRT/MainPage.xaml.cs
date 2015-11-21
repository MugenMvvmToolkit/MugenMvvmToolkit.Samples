namespace Binding.WinRT
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Binding.App());
        }
    }
}