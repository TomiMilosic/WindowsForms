using System.Collections.Generic;
using System.Linq;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    List<UporabniskiRacun> uporabniki = new List<UporabniskiRacun>();
    List<Avto> Avti = new List<Avto>();
    List<Avtosalon> Avtosaloni = new List<Avtosalon>();
    List<AvtoVAvtosalonu> AVS = new List<AvtoVAvtosalonu>();

    Service()
    {
        /*
                uporabniki.Add(new UporabniskiRacun("tomi", "milosic", UporabniskiRacun.Admin.da));
                uporabniki.Add(new UporabniskiRacun("alen", "rajsp", UporabniskiRacun.Admin.ne));


                Avto avto1 = new Avto(1, "wv", "golf", 20000);
                Avto avto2 = new Avto(2, "mazda", "mazda3", 25000);
                Avto avto3 = new Avto(3, "kia", "stingerGT", 50000);
                Avto avto4 = new Avto(4, "bmw", "M4", 80000);
                Avto avto5 = new Avto(5, "toyota", "supra", 45000);


                Avti.Add(avto1);
                Avti.Add(avto2);
                Avti.Add(avto3);
                Avti.Add(avto4);
                Avti.Add(avto5);




                Avtosalon avtosalon1 = new Avtosalon(1, "Porsche", "Maribor", 1984);
                Avtosalon avtosalon2 = new Avtosalon(2, "Autobroker", "Ljubljana", 1999);
                Avtosalon avtosalon3 = new Avtosalon(3, "Selmar", "Maribor", 2005);

                Avtosaloni.Add(avtosalon1);
                Avtosaloni.Add(avtosalon2);
                Avtosaloni.Add(avtosalon3);

                AVS.Add(new AvtoVAvtosalonu(1,avto1,avtosalon1));
                AVS.Add(new AvtoVAvtosalonu(2,avto2,avtosalon1));
                AVS.Add(new AvtoVAvtosalonu(3,avto3,avtosalon1));
                AVS.Add(new AvtoVAvtosalonu(4,avto4,avtosalon2));
                AVS.Add(new AvtoVAvtosalonu(5,avto5,avtosalon3));

        */
    }

    public List<AvtoVAvtosalonu> IzpisAdmin()
    {
        using (var db= new AvtosalonContext())
        {
            return db.avtoVAvtosaloni.ToList();
        }
        
    }

    public Avtosalon najstarejsiAvtosalon()
    {
        using (var db=new AvtosalonContext())
        {
            Avtosalon najstarejsi = db.avtosaloni.OrderBy(x => x.letoUstanovitve).First();

            return najstarejsi;
        }
        
    }

    public Avtosalon najvecAvtomobilov()
    {
        using (var fb= new AvtosalonContext())
        {
          //  int najvecavtomobilov = AVS.OrderBy(x => x.avto.id).Count();

            //AvtoVAvtosalonu najvecAvtomobilov = AVS.First(x => x.avto.id == 3);


            return new Avtosalon(1, "Porsche", "Maribor", 1984);
        }
        
    }

    public double PovprecnavrednostAvtov()
    {
        using (var db= new AvtosalonContext())
        {
            double povprecna = db.avti.Average(x => x.cena);

            return povprecna;
        }
        
    }

    public bool Uporabnik(string Ime, string geslo)
    {

        using (var db= new AvtosalonContext())
        {
            foreach (var item in db.uporabniskiRacuni.ToList())
            {
                if (item.uporabniskoIme==Ime && item.geslo==geslo)
                {
                    return true;
                }
            }
        }

        return false;

    }


    //naloga 4l elelellelelellelelelelleleleleleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
    public List<Avto> VrniAvte()
    {
        using (var db = new AvtosalonContext())
        {
            db.Configuration.ProxyCreationEnabled= false;
            var test = db.avti.ToList();
            return db.avti.ToList();
        }
    }

    public List<AvtoVAvtosalonu> VrniAvteVSalonu()
    {
        using (var db= new AvtosalonContext())
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.avtoVAvtosaloni.ToList();
        }
    }

    //prikaz vseh avtov
    public List<Avtosalon> VrniAvtoSalone()
    {
        using (var db = new AvtosalonContext())
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.avtosaloni.ToList();
        }
    }





    public void DodajAvto(string znamka, string model, int cena)
    {

        Avto avto = new Avto { znamka = znamka, model = model, cena = cena };
        using (var db = new AvtosalonContext())
        {
            db.avti.Add(avto);
            db.SaveChanges();
        }
    }

    public void DodajAvtoSalon(string naziv,string kraj, int LetoUstanovitve)
    {
        using (var db= new AvtosalonContext())
        {
            Avtosalon avtoSalon = new Avtosalon { naziv = naziv, kraj = kraj, letoUstanovitve = LetoUstanovitve };
            db.avtosaloni.Add(avtoSalon);
            db.SaveChanges();
        }
        
        
    }

    public void DodajAvtoVSalon(int idAvtosalona, int idavta)
    {

        using (var db = new AvtosalonContext())
        {

            var EnAvtoSalon = db.avtosaloni.Find(idAvtosalona);
            var avto = db.avti.Find(idavta);
            EnAvtoSalon.avti.Add(avto);
            db.avtosaloni.Add(EnAvtoSalon);
            db.SaveChanges(); 
        }
    }


    public void poosodobiAvto(int a,string znamka,string model,int cena)
    {
        using (var db = new AvtosalonContext())
        {
            foreach (var item in db.avti.ToList())
            {
                if (item.id==a)
                {
                    item.znamka = znamka;
                    item.model = model;
                    item.cena = cena;

                }
            }

            

            db.SaveChanges();
        }
    }




    public void poosodobiAvtoSalon(int a, string naziv, string kraj, int leto)
    {
        using (var db = new AvtosalonContext())
        {
            foreach (var item in db.avtosaloni.ToList())
            {
                if (item.id == a)
                {
                    item.naziv = naziv;
                    item.kraj = kraj;
                    item.letoUstanovitve = leto;

                }
            }



            db.SaveChanges();
        }
    }



    public void poosodobiAvtoVSalonu(int ID,int NoviAvto,int NoviAvtoSalon)
    {
        using (var db = new AvtosalonContext())
        {

            foreach (var item in db.avtoVAvtosaloni.ToList())
            {
                if (item.id==ID)
                {
                    item.avto = NoviAvto;
                    item.avtosaloni = NoviAvtoSalon;
                }
            }
             db.SaveChanges();
        }
    }


    public void IzbrisiAvto(int id)
    {
        using (var db = new AvtosalonContext())
        {
            //Avto neke = db.avti.Find(id);
            foreach (var item in db.avti.ToList())
            {
                if (item.id==id)
                {
                    db.avti.Remove(item);
                    db.SaveChanges();
                }
            }
         
        }

    }



    public void IzbrisiAvtoSalon(int id)
    {
        using (var db = new AvtosalonContext())
        {
            foreach (var item in db.avtosaloni.ToList())
            {
                if (item.id==id)
                {
                    db.avtosaloni.Remove(item);
                    db.SaveChanges();
                }
            }
        }

    }


    public void DodajAvtoVavtoSalon(int avtoid, int savtolonid)
    {
        using (var db = new AvtosalonContext())
        {
            db.avtoVAvtosaloni.Add(new AvtoVAvtosalonu { avto = avtoid, avtosaloni= savtolonid });
            db.SaveChanges();
        }
    }

    public void DodajAvtosalonAvtu(int avtoid, int savtolonid)
    {
        using (var db = new AvtosalonContext())
        {
            Avto avto = db.avti.Find(avtoid);
            Avtosalon avtosalon = db.avtosaloni.Find(savtolonid);
            avto.avtosaloni.Add(avtosalon);
            db.avti.Add(avto);
            db.SaveChanges();
        }
    }

    public void OdstraniAvtoVavtosalonu(int ID)
    {
        using (var db = new AvtosalonContext())
        {
            foreach (var item in db.avtoVAvtosaloni)
            {
                if (item.id==ID)
                {
                    db.avtoVAvtosaloni.Remove(item);
                }
            }
            db.SaveChanges();
        }
    }

    public void DodajUporabnika(string Ime, string geslo, string admin)
    {
        using (var db= new AvtosalonContext())
        {
            if (admin == "Da" || admin == "DA" || admin == "Ja" || admin == "JA")
            {
                UporabniskiRacun racun = new UporabniskiRacun(Ime,geslo,UporabniskiRacun.Admin.da);
                db.uporabniskiRacuni.Add(racun);
                db.SaveChanges();
            }
            else
            {
                UporabniskiRacun racun = new UporabniskiRacun(Ime, geslo, UporabniskiRacun.Admin.ne);
                db.uporabniskiRacuni.Add(racun);
                db.SaveChanges();
            }
        }
    }

    public void OdstraniUporabnika(int id)
    {
        using (var db= new AvtosalonContext())
        {
            UporabniskiRacun neke = new UporabniskiRacun();
            foreach (var item in db.uporabniskiRacuni.ToList())
            {
                if (item.id==id)
                {
                    neke = item;
                }
            }
            db.uporabniskiRacuni.Remove(neke);
            db.SaveChanges();
        }
    }

    public List<UporabniskiRacun> VrniVseUporabnike()
    {
        using (var db= new AvtosalonContext())
        {
            return db.uporabniskiRacuni.ToList<UporabniskiRacun>();
        }
    }

    public void IzbrisiVseAvte()
    {
        using (var db= new AvtosalonContext())
        {
            foreach (var item in db.avti)
            {
                db.avti.Remove(item);
            }
            db.SaveChanges();
        }
    }

    public void OdstraniAvtomobilIzsalona(int avtoid, int avtosalonid)
    {
        using (var db = new AvtosalonContext())
        {
            Avto avto = new Avto();
            Avtosalon avtosalon = new Avtosalon();

            foreach (var item in db.avti.ToList())
            {
                if (item.id == avtoid)
                {
                    avto = item;
                }
            }

            foreach (var item in db.avtosaloni.ToList())
            {
                if (item.id == avtosalonid)
                {
                    avtosalon = item;
                }
            }

           //db.avtoVAvtosaloni.Remove(new AvtoVAvtosalonu { avto = avto, avtosalon = avtosalon });

            db.SaveChanges();
        }
    }

    public void Odstranilastnistvoavtosalonanadavtom(int avtoid, int avtosalonid)
    {
        using (var db = new AvtosalonContext())
        {
            Avto avto = new Avto();
            Avtosalon avtosalon = new Avtosalon();

            foreach (var item in db.avti.ToList())
            {
                if (item.id == avtoid)
                {
                    avto = item;
                }
            }

            foreach (var item in db.avtosaloni.ToList())
            {
                if (item.id == avtosalonid)
                {
                    avtosalon = item;
                }
            }

           // db.avtoVAvtosaloni.Remove(new AvtoVAvtosalonu { avto = avto, avtosalon = avtosalon });

            db.SaveChanges();
        }
    }

    public void posodobiUporabniskiRacun(int id, string Ime, string geslo)
    {
        using (var db = new AvtosalonContext())
        {
            foreach (var item in db.uporabniskiRacuni.ToList())
            {
                if (item.id == id)
                {
                    item.uporabniskoIme = Ime;
                    item.geslo = geslo;
                    

                }
            }



            db.SaveChanges();
        }
    }

    public void VrniSaloneAvtov()
    {
        throw new System.NotImplementedException();
    }
}

