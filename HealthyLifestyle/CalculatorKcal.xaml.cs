namespace HealthyLifestyle;

public partial class CalculatorKcal : ContentPage
{
    int Greutate;
    double Traseu;
    int Durata;
    List<string> ListaViteza;
    List<string> ListaUnitateTimp;

    public CalculatorKcal()
	{
		InitializeComponent();

        this.ListaViteza = new List<string>() {"Usoara (<8 km/h)", "Moderata (8 - 12 km/h)", "Intensa (> 12 km/h)"};
        this.ListaUnitateTimp = new List<string>() { "ora", "min"};


        pickerViteza.ItemsSource = ListaViteza;
        pickerViteza.SelectedIndex = 0;
        pickerUnitateTimp.ItemsSource = ListaUnitateTimp;
        pickerUnitateTimp.SelectedIndex = 0;
    }

    public void ButtonCalculeaza_Clicked(object sender, EventArgs e)
    {
        CalculeazaRezultat1();
    }

    void CalculeazaRezultat1()
    {
        double durataInOre = Durata / 60.0;
        double viteza = Traseu / durataInOre;
        double METs = GetMETsValue(viteza);
        entryRezultat.Text = (Greutate * METs * durataInOre).ToString();
    }

    private void entryGreutate_TextChanged(object sender, TextChangedEventArgs e)
    {
        Greutate = ConvertTextToInt(e.NewTextValue);
    }

    private void entryTraseu_TextChanged(object sender, TextChangedEventArgs e)
    {
        Traseu = ConvertTextToDouble(e.NewTextValue);
    }

    private void entryDurata_TextChanged(object sender, TextChangedEventArgs e)
    {
        Durata = ConvertTextToInt(e.NewTextValue);
    }

    int ConvertTextToInt(string stringVal)
    {
        int intVal = 0;
        int.TryParse(stringVal, out intVal);

        return intVal;
    }

    double ConvertTextToDouble (string stringVal)
    {
        double doubleVal = 0;
        double.TryParse(stringVal, out doubleVal);

        return doubleVal;
    }
    double GetMETsValue(double viteza)
    {
        if (viteza < 8)
        {
            return 7.0;
        }
        else if (viteza >= 8 && viteza < 12)
        {
            return 8.3;
        }
        else
        {
            return 11.8;
        }
    }

    private void entryNrKm_TextChanged(object sender, TextChangedEventArgs e)
    {
        CalculeazaRezultat2(e.NewTextValue);
    }

    void CalculeazaRezultat2(string entryNrKm)
    {
        double nrKm = ConvertTextToDouble(entryNrKm);
        string unitateTimp = pickerUnitateTimp.SelectedItem as string;
        double vitezaKmH = GetVitezaKmH(pickerViteza.SelectedItem as string);
        double timpInOre = nrKm / vitezaKmH;
        double METs = GetMETsValue(vitezaKmH);

        double greutateMedie = 70;
        double rezultat = greutateMedie * METs * timpInOre;

        if(unitateTimp == "ora") 
        {
            entryRezultat2.Text = rezultat.ToString();
        }
        else
        {
            entryRezultat2.Text = (rezultat / 60.0).ToString();
        }
    }

    private void pickerUnitateTimp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedItem = pickerUnitateTimp.SelectedItem as string;
        ConvertRezultat2MinOra(selectedItem);
    }

    void ConvertRezultat2MinOra(string selectedItem)
    {
        double rezultat = ConvertTextToDouble(entryRezultat2.Text);
        if (selectedItem == "ora")
        {
            entryRezultat2.Text = (rezultat * 60.0).ToString();
        }
        else
        {
            entryRezultat2.Text = (rezultat / 60.0).ToString();
        }
    }

    double GetVitezaKmH(string viteza)
    {
        if (viteza == "Usoara (<8 km/h)")
        {
            return 7.0;
        }
        else if (viteza == "Moderata (8 - 12 km/h)")
        {
            return 10.0;
        }
        else
        {
            return 12.0;
        }
    }

    private void pickerViteza_SelectedIndexChanged(object sender, EventArgs e)
    {
        string nrKm = entryNrKm.Text;
        CalculeazaRezultat2(nrKm);
    }
}