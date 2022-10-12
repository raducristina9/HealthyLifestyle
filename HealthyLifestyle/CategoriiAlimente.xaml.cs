using Microcharts;

namespace HealthyLifestyle;

public partial class CategoriiAlimente : ContentPage
{
	public CategoriiAlimente()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        List<ChartEntry> chartEntries = new List<ChartEntry>();

        List<Aliment> listaAlimente = await ServiceAliment.getDataAsync();

        Random random = new Random();

        foreach (Aliment aliment in listaAlimente)
        {
            chartEntries.Add(new ChartEntry((float)aliment.calories)
            {
                Label = aliment.name,
                ValueLabel = aliment.calories.ToString(),
                Color = new SkiaSharp.SKColor(
                        (byte)random.Next(256),
                        (byte)random.Next(256),
                        (byte)random.Next(256)
                )
            }); ;
        }

        chartViewAlimente.Chart = new LineChart() { Entries = chartEntries };
    }
}