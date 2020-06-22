using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;



// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
  
    [OperationContract]
    List<AvtoVAvtosalonu> IzpisAdmin();
    [OperationContract]
    Avtosalon najstarejsiAvtosalon();
    [OperationContract]
    Avtosalon najvecAvtomobilov();
    [OperationContract]
    double PovprecnavrednostAvtov();
    [OperationContract]
    bool Uporabnik(string Ime, string geslo);
    [OperationContract]
    List<Avto> VrniAvte();
    [OperationContract]
    List<Avtosalon> VrniAvtoSalone();
    [OperationContract]
    List<AvtoVAvtosalonu> VrniAvteVSalonu();
    [OperationContract]
    void DodajAvto(string znamka,string model, int cena);
    [OperationContract]
    void DodajAvtoSalon(string naziv, string kraj, int LetoUstanovitve);
    [OperationContract]
    void DodajAvtoVSalon(int idAvtosalona, int idavta);
    [OperationContract]
    void poosodobiAvto(int a, string znamka, string model, int cena);
    [OperationContract]
    void poosodobiAvtoSalon(int a, string naziv, string kraj, int leto);
    [OperationContract]
    void posodobiUporabniskiRacun(int id, string Ime, string geslo);
    [OperationContract]
    void poosodobiAvtoVSalonu(int id,int idavta, int idavtosalona);
    [OperationContract]
    void IzbrisiAvto(int avtoid);
    [OperationContract]
    void IzbrisiAvtoSalon(int avtoSalonid);
    [OperationContract]
    void DodajAvtoVavtoSalon(int avto, int avtosalon);
    [OperationContract]
    void DodajAvtosalonAvtu(int avtoid, int savtolonid);
    [OperationContract]
    void OdstraniAvtoVavtosalonu(int ID);
    [OperationContract]
    void DodajUporabnika(string Ime, string geslo, string admin);
    [OperationContract]
    void OdstraniUporabnika(int id);
    [OperationContract]
    List<UporabniskiRacun> VrniVseUporabnike();
    [OperationContract]
    void IzbrisiVseAvte();
    [OperationContract]
    void OdstraniAvtomobilIzsalona(int avtoid, int avtosalonid);
    [OperationContract]
    void Odstranilastnistvoavtosalonanadavtom(int avtoid, int avtosalonid);
    [OperationContract]
    void VrniSaloneAvtov();








    // TODO: Add your service operations here
}

[DataContract]
public class Avto
{
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public string znamka { get; set; }
    [DataMember]
    public string model { get; set; }
    [DataMember]
    public int cena { get; set; }
    public virtual ICollection<Avtosalon> avtosaloni { get; set; }

    public Avto() { }
    public Avto(int id, string znamka, string model, int cena)
    {
        this.id = id;
        this.znamka = znamka;
        this.model = model;
        this.cena = cena;
    }
}


[DataContract]
public class Avtosalon
{
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public string naziv { get; set; }
    [DataMember]
    public string kraj { get; set; }
    [DataMember]
    public int letoUstanovitve { get; set; }

    public virtual ICollection<Avto> avti { get; set; }
    public Avtosalon() { }
    public Avtosalon(int idAvtosalona, string naziv, string kraj, int letoUstanovitve)
    {
        this.id = idAvtosalona;
        this.naziv = naziv;
        this.kraj = kraj;
        this.letoUstanovitve = letoUstanovitve;
    }
}
[DataContract]
public class AvtoVAvtosalonu
{
    [DataMember]
    public int id { get; set; }

    [DataMember]
    public int avto { get; set; }
    [DataMember]
    public int avtosaloni {get;set;}

    public AvtoVAvtosalonu() { }

    public AvtoVAvtosalonu(int id, int avto, int avtosaloni)
    {
        this.id = id;
        this.avto = avto;
        this.avtosaloni = avtosaloni;
    }
}

[DataContract]
public class UporabniskiRacun
{
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public string uporabniskoIme { get; set; }
    [DataMember]
    public string geslo { get; set; }
    public enum Admin { da, ne };
    [DataMember]
    public Admin admin { get; set; }
    public UporabniskiRacun() { }
    public UporabniskiRacun(string uporabniskoIme, string geslo, Admin admin)
    {
        this.uporabniskoIme = uporabniskoIme;
        this.geslo = geslo;
        this.admin = admin;
    }
}
[DataContract]
public class AvtosalonContext: DbContext
{
    [DataMember]
    public DbSet<Avto> avti { get; set; }
    [DataMember]
    public DbSet<Avtosalon> avtosaloni { get; set; }
    [DataMember]
    public DbSet<UporabniskiRacun> uporabniskiRacuni { get; set; }
    [DataMember]
    public DbSet<AvtoVAvtosalonu> avtoVAvtosaloni { get; set; }
}


