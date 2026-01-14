📦 Stok Takip ve Satış Yönetim Sistemi
<p align="center"> <img src="https://img.icons8.com/fluent/100/000000/inventory-flow.png" alt="Logo"/> </p>

Bu proje, işletmelerin ürün stoklarını dinamik olarak yönetebilmesi, müşteri kayıtlarını adres bilgileriyle birlikte tutabilmesi ve anlık satış raporları alabilmesi için geliştirilmiş N-Tier Architecture (Katmanlı Mimari) tabanlı bir masaüstü uygulamasıdır.

🛠 Kullanılan Teknolojiler
Programlama Dili: C# (.NET Framework)

Veritabanı: MySQL (phpMyAdmin)

Mimari: N-Tier (UI, BLL, DAL, DOMAIN)

Veri Tabanı Yönetimi: SQL Sorguları üzerinden dinamik tablo yönetimi

✨ Özellikler
Dashboard Paneli: Toplam satış, kritik stoktaki ürün sayısı ve genel ciro takibi.

Gelişmiş Müşteri Yönetimi: Müşteri türü (Bireysel/Kurumsal) ve detaylı adres kaydı.

Akıllı Stok Takibi: Kritik eşiğin altına düşen ürünlerin otomatik olarak "Kritik Stok" listesine düşmesi.

Satış Geçmişi: Yapılan tüm işlemlerin tarihsel raporlanması.

📊 Veritabanı Şeması
Proje 26_132430062 veritabanı altında şu tabloları kullanmaktadır:

Customers: Müşteri bilgileri ve adres sütunu.

Products: Ürün adı, stok adedi, fiyat ve CreatedDate bilgisi.

Sales: Satış detayları ve toplam tutar bilgisi.

🚀 Kurulum ve Çalıştırma
Repo'yu Clone'layın:

Bash

git clone https://github.com/kullaniciadin/projeadin.git
Veritabanını Hazırlayın: phpMyAdmin üzerinden aşağıdaki sorgu ile gerekli sütunları ekleyin:

SQL

ALTER TABLE Products ADD COLUMN CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP;
ALTER TABLE Customers ADD COLUMN Address VARCHAR(250);
Bağlantı Ayarları: DAL/DbConnection.cs dosyasındaki Connection String'i kendi sunucu bilgilerinizle güncelleyin.
Çalıştırın: Visual Studio üzerinden F5 ile projeyi başlatın

### Proje Önizlemesi
![Login Ekranı](https://github.com/omerfarukergen/StokTakipSistemi/blob/master/StokTakipSistemi/Screenshots/login.png?raw=true)
| Müşteri Yönetimi | Raporlama |
| :---: | :---: |
| <img src="https://github.com/omerfarukergen/StokTakipSistemi/blob/master/StokTakipSistemi/Screenshots/m%C3%BC%C5%9Fteri.png?raw=true" width="400"> | <img src="https://github.com/omerfarukergen/StokTakipSistemi/blob/master/StokTakipSistemi/Screenshots/rapor.png?raw=true" width="400"> |
| **Satış Ekranı** | **Ürün Yönetimi** |
| <img src="https://github.com/omerfarukergen/StokTakipSistemi/blob/master/StokTakipSistemi/Screenshots/sat%C4%B1%C5%9F.png?raw=true" width="400"> | <img src="https://github.com/omerfarukergen/StokTakipSistemi/blob/master/StokTakipSistemi/Screenshots/%C3%BCr%C3%BCny%C3%B6netimi.png?raw=true" width="400"> |
