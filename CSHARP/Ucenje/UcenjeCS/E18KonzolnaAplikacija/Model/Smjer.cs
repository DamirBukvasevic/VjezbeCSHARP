namespace UcenjeCS.E18KonzolnaAplikacija.Model
{
    internal class Smjer:Entitet
    {

        public string? Naziv { get; set; }
        public int? Trajanje { get; set; }
        public float? Cijena { get; set; }
        public DateTime? IzvodiSeOd { get; set; }
        public bool? Verificiran { get; set; }

        public override string ToString()
        {
            return "Sifra=" + Sifra + " ,Naziv=" + Naziv + ", Trajanje=" + Trajanje + ", Cijena=" + Cijena +
                ", IzvodiSeOd=" + IzvodiSeOd + ", Verificiran=" + Verificiran; 
        }

    }
}
