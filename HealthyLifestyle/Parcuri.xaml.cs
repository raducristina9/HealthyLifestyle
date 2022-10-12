namespace HealthyLifestyle;

public partial class Parcuri : ContentPage
{
    List<Parc> listaCuParcuri = new List<Parc>();
    public Parcuri()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        listaCuParcuri = await ServiceParc.preiaParcuri();
        collectionViewParcuri.ItemsSource = listaCuParcuri;

    }

}