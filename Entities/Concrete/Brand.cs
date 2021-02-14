using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Brand Bir Veritabanı tablosu
    //IEntity Brandın Referansını Tutar
    public class Brand:IEntity
    {
        //Çıplak Class Kalmasın -> Eğerki bir class herhangi bir inheritance veya interface implementasyonu almıyorsa o bize ilerde problem yaşatır.
        
        //Böyle classları gruplarız. Gruplama -> Mesela Bu Projede  Concrete klasöründeki classlar bir veritabanı tablosuna karşılık geliyor
        
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
