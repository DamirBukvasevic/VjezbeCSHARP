namespace UcenjeCS.ZavrsniRadDamirB.Model
{
    internal class Stavka : Entitet
    {
        public List<Nabava>? SifraNabave { get; set; }

        public List<Artikl>? SifraArtikla { get; set; }

        public int? KolicinaArtikla { get; set; }

        public float? CijenaArtikla { get; set; }
        public override string ToString()
        {
            return "Šifra= " + SifraNabave + ", Šifra artikla= " + SifraArtikla;
        }
    }
}
