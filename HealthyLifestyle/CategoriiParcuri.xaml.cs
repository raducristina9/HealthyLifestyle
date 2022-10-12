using Microcharts;

namespace HealthyLifestyle;

public partial class CategoriiParcuri : ContentPage
{
	public CategoriiParcuri()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        List<ChartEntry> chartEntries = new List<ChartEntry>();

        List<Parc> listaParcuri = await ServiceParc.preiaParcuri();

        Random random = new Random();

        foreach (Parc parc in listaParcuri)
        {
            chartEntries.Add(new ChartEntry((float)parc.hectare)
            {
                Label = parc.denumire,
                ValueLabel = parc.hectare.ToString(),
                Color = new SkiaSharp.SKColor(
                        (byte)random.Next(256),
                        (byte)random.Next(256),
                        (byte)random.Next(256)
                )
            }); ;
        }

        chartViewParcuri.Chart = new PieChart() { Entries = chartEntries };
    }
}