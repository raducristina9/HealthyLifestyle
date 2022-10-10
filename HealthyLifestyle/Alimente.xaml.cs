namespace HealthyLifestyle;

public partial class Alimente : ContentPage
{
    List<Aliment> listaCuAlimente= new List<Aliment>();
    bool alimentInitializat = false;
    public Alimente()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {

        DaoAliment dao = new DaoAliment();

 
        if (!alimentInitializat)
        {
            listaCuAlimente = dao.getAllAliments();
            alimentInitializat = true;
        }

        if (listaCuAlimente.Count == 0)
        {
            listaCuAlimente = await ServiceAliment.getDataAsync();

            dao.adaugaListaAliment(listaCuAlimente);
        }
        listViewAlimente.ItemsSource = listaCuAlimente;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        DaoAliment dao = new DaoAliment();
        dao.deleteAll(); 
        DisplayAlert("Informatiile au fost sterse", e.ToString(),"OK");
    }
}