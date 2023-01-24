# ASP.NET-Challenge

## Sipariş Yönetim Servisi

Sipariş yönetim servisi, 3 farklı tablodan oluşan, DB First Entity Framework ile tasarlanmış bir form aplikasyondur.

## Tablo Açıklamaları
- Firma: Id, Firma Adı, Onay Durumu, Sipariş İzin başlangıç saati, Sipariş İzin bitiş saati
- Ürünler: Id, FirmaId, Ürün Adı, Stok, Fiyatı 
- Sipariş: Id, FirmaId, UrunId, Siparişi veren kişinin adı, Sipariş Tarihi

## Aplikasyon Görseli
![This is an image](https://i.ibb.co/74TrqNJ/Ekran-G-r-nt-s-71.png)

## Aplikasyon Amaçları:
>- Firma Listele: Firmanın tablo içindeki bütün bilgilerini DataGridView a aktarır.
>- Firma Ekleme: Firma GroupBox içindeki bilgiler girilerek yeni veri oluşturur.
>- Firma Güncelleme: Girilen Firma ID bilgisine göre bilgileri günceller.

>- Ürün Ekle: Urun Groupbox içindeki bilgiler girilerek yeni veri oluşturur.

>- Sipariş Oluştur: Firma onaylı ise, 08:00-11:00 arasında sipariş oluşturur. Şartlar sağlanmadığı takdirde kayıt oluşturmaz ve uyarı penceresi belirir.
