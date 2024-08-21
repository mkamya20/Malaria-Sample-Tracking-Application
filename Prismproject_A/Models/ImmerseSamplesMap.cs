using CsvHelper.Configuration;
using Prismproject_A.Models;

public sealed class ImmerseSamplesMap : ClassMap<ImmerseSamples>
{
    public ImmerseSamplesMap()
    {
        // Map each column from the CSV to the model properties
        Map(m => m.BoxNumber).Name("BoxNumber");
        Map(m => m.Barcode).Name("Barcode");
        Map(m => m.BoxRow).Name("BoxRow");
        Map(m => m.BoxColumn).Name("BoxColumn");
        Map(m => m.TbldateAdded).Name("TbldateAdded");
        //Map(m => m.PlateNumber).Name("PlateNumber");
        //Map(m => m.PcrplateLayout).Name("PcrplateLayout");
        //Map(m => m.AliquotePlateNumber).Name("AliquotePlateNumber");
        //Map(m => m.AliquotePlatePosition).Name("AliquotePlatePosition");

        // Ignore the Id column
        Map(m => m.Id).Ignore();
        Map(m => m.PlateNumber).Ignore();
        Map(m => m.PcrplateLayout).Ignore();
        Map(m => m.AliquotePlateNumber).Ignore();
        Map(m => m.AliquotePlatePosition).Ignore();
    }
}
