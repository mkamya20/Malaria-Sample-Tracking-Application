using CsvHelper.Configuration;
using Prismproject_A.Models;

public sealed class ZumbaSamplesMap : ClassMap<ZumbaSamples>
{
    public ZumbaSamplesMap()
    {
        // Map each column from the CSV to the model properties
        Map(m => m.BoxNumber).Name("BoxNumber");
        Map(m => m.Barcode).Name("Barcode");
        Map(m => m.BoxRow).Name("BoxRow");
        Map(m => m.BoxColumn).Name("BoxColumn");
        Map(m => m.dateAdded).Name("dateAdded");
        Map(m => m.Round).Name("Round");


        // Ignore the Id column
        Map(m => m.Id).Ignore();

    }
}
