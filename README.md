# Tren İstasyonları Projesi

Bu proje, tren istasyonları hakkında bilgi toplama ve yönetme işlevlerini içermektedir.

## Gereksinimler

- .NET Core 7
- Entity Framework Core
- MVC Mimarisine uygun yapı

## Proje Açıklaması

Proje, kullanıcıların tren istasyonlarını sisteme ekleyebileceği, güncelleyebileceği ve silebileceği bir yönetim paneli sunar. Aynı şekilde, tren istasyonlarına ait tren seferlerini de kaydedebilir, güncelleyebilir ve silebilirler. Kullanıcılar, tren seferlerine ait kalkış ve varış saatlerini de kaydedebilirler. Ayrıca, sisteme kaydolup giriş yaptıktan sonra kullanıcılar, kayıtlı tren istasyonlarını ve tren seferlerini görüntüleyebilirler.

## Veritabanı Tasarımı

### Kullanıcılar Tablosu | Identity Server

- Kullanıcı ID (int): Birincil anahtar ve otomatik artan özellik
- Kullanıcı Adı (nvarchar(100)): Kullanıcının adı
- Şifre (nvarchar(200)): Kullanıcının şifresi

### Tren İstasyonları Tablosu

- Station ID (int): Birincil anahtar ve otomatik artan özellik
- Station Adı (nvarchar(100)): Tren istasyonunun adı
- Station Adresi (nvarchar(200)): Tren istasyonunun adresi
- Station Konumu (nvarchar(200)): Tren istasyonunun konumu

### Tren Seferleri Tablosu

- Journey ID (int): Birincil anahtar ve otomatik artan özellik
- Departure Station ID (int): İlişkisel bir sütun, tren seferinin kalkış yapacağı istasyonun ID'sini tutar
- Arrival Station ID (int): İlişkisel bir sütun, tren seferinin varış yapacağı istasyonun ID'sini tutar
- Departure DateTime (datetime2): Tren seferinin kalkış saati
- Arrival DateTime (datetime2): Tren seferinin varış saati

## Kurulum ve Kullanım

1. Projeyi bilgisayarınıza klonlayın.
2. `appsettings.json` dosyasında veritabanı bağlantı ayarlarınızı düzenleyin.
3. Terminal veya Package Manager Console kullanarak migration oluşturun ve veritabanını oluşturun:
