namespace HealthyLifestyle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new  CalculatorKcal());
        }

        private  void Button_Clicked_1(object sender, EventArgs e)
        {
             Navigation.PushAsync(new CategoriiAlimente());
        }
    }
}