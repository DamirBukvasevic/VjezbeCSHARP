namespace UcenjeCS.ZavrsniRadDamirB.Model
{
    internal class Dobavljac: Entitet , IComparable<Dobavljac>
    {
        public int? Sifra { get; set; }

        public string? Naziv { get; set; }

        public string? Grad { get; set; }

        public string? Adresa { get; set; }

        public string? OIB { get; set; }

        public override string ToString()
        {
            return "ŠIFRA DOBAVLJAČA: " + Sifra + " , " + Naziv + " , " + Grad +
                " , " + Adresa + " , " + "OIB: " + OIB;
        }

        public int CompareTo(Dobavljac? other)
        {
            return Naziv.CompareTo(other.Naziv);
        }
    }
}
