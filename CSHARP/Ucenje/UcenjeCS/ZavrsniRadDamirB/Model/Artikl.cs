namespace UcenjeCS.ZavrsniRadDamirB.Model
{
    internal class Artikl: Entitet
    {
        public int? Sifra { get; set; }

        public string? Naziv { get; set; }

        public override string ToString()
        {
            return "ŠIFRA ARTIKLA: " + Sifra + "   " + "ARTIKL: " + Naziv;
        }
    }
}
