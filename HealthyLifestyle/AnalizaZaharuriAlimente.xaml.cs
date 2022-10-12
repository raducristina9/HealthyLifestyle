using Microcharts;

namespace HealthyLifestyle;

public partial class AnalizaZaharuriAlimente : ContentPage
{
	public AnalizaZaharuriAlimente()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        List<ChartEntry> chartEntries = new List<ChartEntry>();

        List<Aliment> listaAlimente = await ServiceAliment.getDataAsync();

        Random random = new Random();

        listaAlimente.Sort();

        int i = 0;

        foreach (Aliment aliment in listaAlimente)
        {
            chartEntries.Add(new ChartEntry((float)aliment.sugar)
            {
                Label = aliment.name,
                ValueLabel = aliment.sugar.ToString(),
                Color = new SkiaSharp.SKColor(
                        (byte)random.Next(256),
                        (byte)random.Next(256),
                        (byte)random.Next(256)
                )
            }); ;

            i++;

            if (i == 9)
            {
                break;
            }
        }

        chartViewZaharuri.Chart = new BarChart() { Entries = chartEntries };
    }
}