namespace UcenjeCS.ZavrsniRadDamirB.Model
{
    internal class Stavka : Entitet
    {
        public Nabava? SifraNabave { get; set; }

        public Artikl? SifraArtikla { get; set; }

        public int? KolicinaArtikla { get; set; }

        public float? CijenaArtikla { get; set; }
        public override string ToString()
        {
            return "\n" + "   " + "KOLIČINA: " + KolicinaArtikla + " kom" + " , " + "CIJENA: " + CijenaArtikla;
        }
    }
}
