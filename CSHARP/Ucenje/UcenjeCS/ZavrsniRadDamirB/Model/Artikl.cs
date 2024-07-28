namespace UcenjeCS.ZavrsniRadDamirB.Model
{
    internal class Artikl: Entitet , IComparable<Artikl>
    {
        public int? Sifra { get; set; }

        public string? Naziv { get; set; }

        public int CompareTo(Artikl? other)
        {
            return Naziv.CompareTo(other.Naziv);
        }
        public override string ToString()
        {
            return "   " + "ŠIFRA: " + Sifra + "   " + "NAZIV: " + Naziv;
        }
    }
}
