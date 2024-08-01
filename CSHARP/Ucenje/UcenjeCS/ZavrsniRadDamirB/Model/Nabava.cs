namespace UcenjeCS.ZavrsniRadDamirB.Model
{
    internal class Nabava:Entitet
    {
        public int? Sifra { get; set; }

        public int? BrojNabave { get; set; }

        public DateTime? DatumNabave { get; set; }

        public List<Dobavljac>? NazivDobavljaca { get; set; }

        public override string ToString()
        {
            return "Šifra: " + Sifra + " , Broj nabave: " + BrojNabave + " , Datum: "+ DatumNabave;
        }
    }
}