--Kullanici Ekleme
Create Proc sp_KullaniciEkleme
( 
  @KullaniciTipiId int
 ,@KullaniciAd nvarchar(150)
 ,@KullaniciParola nvarchar(50)
 ,@KullaniciEposta nvarchar(250)
 ,@KullaniciEpostaOnayKod nvarchar(250)
 ,@KullaniciEpostaOnay bit
 ,@KullaniciKayýtTarihi datetime
 ,@KullaniciSonGirisTarihi datetime
 ,@DilId int
 ,@ResimId int
)
AS
BEGIN
  if exists (select * From tbl_Kullanici Where KullaniciEposta=@KullaniciEposta)
  Begin
   Print 'Bu e-posta ile daha önce kayýt yapýlmýþtýr'
  End
  Else
  Begin
   Insert into tbl_Kullanici ([KullaniciId], [KullaniciTipiId], [KullaniciAd], [KullaniciParola], [KullaniciEposta], [KullaniciEpostaOnayKod], [KullaniciEpostaOnay], [KullaniciKayýtTarihi], [KullaniciSonGirisTarihi], [DilId], [ResimId]) 
   Values ( @KullaniciTipiId, @KullaniciAd, @KullaniciParola, @KullaniciEposta, @KullaniciEpostaOnayKod, @KullaniciEpostaOnay, @KullaniciKayýtTarihi,@KullaniciSonGirisTarihi, @DilId, @ResimId)
 @@IDENTITY

  End
END

Go

--Kullanici Pasife Çekme

  Create Trigger tgr_KullaniciSilme
  on tbl_Kullanici Instead of Delete
  As
  Begin 
  declare @KullaniciEposta nvarchar(250)
   Update tbl_Kullanici set KullaniciAktifMi=0 Where KullaniciEposta=(select @KullaniciEposta from deleted)
  End
 
Go

--Kullanýcý Bilgi Güncelleme

Create Proc sp_KullaniciBilgiGüncelleme
(
  @KullaniciTipiId int
 ,@KullaniciAd nvarchar(150)
 ,@KullaniciParola nvarchar(50)
 ,@KullaniciEposta nvarchar(250)
 ,@KullaniciEpostaOnayKod nvarchar(250)
 ,@KullaniciEpostaOnay bit
 ,@KullaniciKayýtTarihi datetime
 ,@KullaniciSonGirisTarihi datetime
 ,@DilId int
 ,@ResimId int
)
AS
BEGIN
  Update tbl_Kullanici Set 
  KullaniciTipiId=@KullaniciTipiId, KullaniciAd=@KullaniciAd, KullaniciParola=@KullaniciParola, KullaniciEposta=@KullaniciEposta, 
  KullaniciEpostaOnayKod=@KullaniciEpostaOnayKod, KullaniciEpostaOnay=@KullaniciEpostaOnay, 
  KullaniciKayýtTarihi=@KullaniciKayýtTarihi, KullaniciSonGirisTarihi=@KullaniciSonGirisTarihi, DilId=@DilId, ResimId=@ResimId 
  Where KullaniciEposta=@KullaniciEposta
END

Go
--UlkelereGoreMusteriGetirenSorgu

Create Proc sp_UlkelereGoreMusteriBilgi
( 
 @ulkeAd nvarchar(75)
)
AS
BEGIN
Select m.MusteriAd, m.MusteriSoyad, m.MusteriTelefon, u.UlkeAd from tbl_Musteriler as m
Join tbl_Ulke as u on m.UlkeID=u.UlkeId
Where u.UlkeAd=@ulkeAd
END

Go


Create Proc sp_AdaGorePersonelListesi
(
 @personelAd
)
AS
Begin
End

Go

Create Proc sp_IDyeGorePersonelListesi
(
)
AS
Begin
End

Go


Create Proc sp_GorevlerineGorePersonelListesi
(
)
AS
Begin
End

Go

Create Proc sp_VardiyaSaatlerineGorePersonelListesi
(
)
AS
Begin
End

Go

Create Proc sp_MaasaGorePersonelListesi
(
)
AS
Begin
End

Go

Create Proc sp_RezervasyonTanýmýnaGore
(
 
)
AS
Begin
End





Create Proc sp_OdaEkleme
( 
  @odaNo int
 ,@odaTipID int
 ,@odaFiyat decimal(8,3)
 ,@odaBosMu bit
 ,@katID int
 ,@odaTemizMi bit 
 ,@odaKapasite int
 ,@odaAktifMi bit
 ,@odaAciklama nvarchar(300)
 ,@klimaAktifMi bit
 ,@minibarAktifMi bit
 ,@sacKurutmaAktifMi bit
 ,@wifiAktifMi bit
 ,@kasaAktifMi bit
 ,@balkonAktifMi bit
 ,@tvAktifMi bit
 ,@tekkisilikyatakadet int
 ,@ciftkisilikyatakadet int
)
AS
BEGIN
  if exists (select * From Odalar Where odaNo=@odaNo)
  Begin
   Print 'Bu oda numara daha önceden kullanýlmýþ.'
  End
  Else
  Begin
  Declare @odaOzellikID int
  Insert into OdaOzellikleri ([klimaAktifMi], [minibarAktifMi], [sacKurutmaAktifMi], [wifiAktifMi], [kasaAktifMi], [balkonAktifMi], [tvAktifMi]) VALUES (@klimaAktifMi, @minibarAktifMi,@sacKurutmaAktifMi, @wifiAktifMi, @kasaAktifMi, @balkonAktifMi)
  SET @odaOzellikID = @@IDENTITY


   Insert into Odalar ([odaNo], [odaTipID], [odaOzellikleriID], [odaFiyat], [odaBosMu], [katID], [odaTemizMi], [odaKapasite], [odaAktifMi], [odaAciklama]) 
   Values (  @odaNo, @odaTipID, @odaOzellikID, @odaFiyat, @odaBosMu, @katID, @odaTemizMi, @odaKapasite,@odaAktifMi, @odaAciklama)
 

  End
END



--MusteriEkleme
Create Proc sp_MusteriEkle
( 
 
  @musteriAd nvarchar(20)
 ,@musteriSoyad nvarchar(20)
 ,@musteriTelNo nvarchar(20)
 ,@musteriEposta nvarchar(200)
 ,@musteriAdres nvarchar(300)
 ,@ulkeID int
 ,@sehirID int
 ,@musteriFirmaAd nvarchar(300)
 ,@firmaVergiNo nvarchar(300)
 ,@musteriSirketMi bit
 ,@dilID int
 ,@cinsiyetID int
 ,@musteriTC nvarchar(11)
 ,@musteriAktifMi bit
 ,@musteriAciklama nvarchar(300)
)
AS
BEGIN
  Insert into Musteriler([musteriAd], [musteriSoyad], [musteriTelNo], [musteriEposta], [musteriAdres], [ulkeID], [sehirID], [musteriFirmaAd], [firmaVergiNo], [musteriSirketMi], [dilID], [cinsiyetID],[musteriTC], [musteriAktifMi], [musteriAciklama]) Values(@musteriAd ,@musteriSoyad,@musteriTelNo,@musteriEposta,@musteriAdres,@ulkeID,@sehirID,@musteriFirmaAd,@firmaVergiNo, @musteriSirketMi,@dilID,@cinsiyetID,@musteriTC, @musteriAktifMi, @musteriAciklama)
END


--Müþteri Güncelleme

Create Proc sp_MusteriGuncelleme
(
 
  @musteriAd nvarchar(20)
 ,@musteriSoyad nvarchar(20)
 ,@musteriTelNo nvarchar(20)
 ,@musteriEposta nvarchar(200)
 ,@musteriAdres nvarchar(300)
 ,@ulkeID int
 ,@sehirID int
 ,@musteriFirmaAd nvarchar(300)
 ,@firmaVergiNo nvarchar(300)
 ,@musteriSirketMi bit
 ,@dilID int
 ,@cinsiyetID int
 ,@musteriAktifMi bit
 ,@musteriAciklama nvarchar(300)
 ,@musteriTC nvarchar(11)
)
AS
BEGIN
  Update Musteriler Set 
   musteriAd=@musteriAd, musteriSoyad=@musteriSoyad, musteriTelNo=@musteriTelNo, musteriEposta=@musteriEposta, musteriAdres=@musteriAdres, ulkeID=@ulkeID, sehirID=@sehirID, musteriFirmaAd=@musteriFirmaAd, firmaVergiNo=@firmaVergiNo, musteriSirketMi=@musteriSirketMi, dilID=@dilID, cinsiyetID=@cinsiyetID,musteriAktifMi=@musteriAktifMi, musteriAciklama=@musteriAciklama, musteriTC=@musteriTC
  Where musteriTC=@musteriTC
END

--Müþteri Pasife Çekme(Sil butonu)
 Create Trigger tgr_MusteriSilme
  on Musteriler Instead of Delete
  As
  Begin 
   Update Musteriler set musteriAktifMi=0 Where musteriTC=(select musteriTC from deleted)
  End

Create Proc sp_MusteriSilme
(
@musteriTC nvarchar(11)
)
AS
BEGIN
Delete from Musteriler Where musteriTC=@musteriTC
END



--Rezervasyon Kaydet
Create Proc sp_RezervasyonKaydet
( 
  @rezervasyonBaslangicTarih datetime
 ,@rezervasyonBitisTarihi datetime
 ,@rezervasyonIndirim decimal(8,3)
 ,@rezervasyonAktifMi bit
 ,@rezervasyonAciklama nvarchar(300)
 ,@calisanID int
 ,@musteriID int
 ,@odaNo int
)
AS
BEGIN
  Insert into Rezervasyonlar ([rezervasyonIslemTarih], [rezervasyonBaslangicTarih], [rezervasyonBitisTarihi], [rezervasyonIndirim], [rezervasyonAktifMi], [rezervasyonAciklama], [calisanID], [musteriID], [odaNo]) 
  Values(GETDATE(),@rezervasyonBaslangicTarih, @rezervasyonBitisTarihi, @rezervasyonIndirim, @rezervasyonAktifMi, @rezervasyonAciklama, @calisanID, @musteriID,@odaNo)
END



--KullanýcýGiris
ALTER Proc [dbo].[sp_KullaniciGiris]
( 
 @kullaniciAd nvarchar(20),
 @kullaniciSifre nvarchar(20)
)
AS
BEGIN
  if exists(select * From Kullanicilar Where kullaniciAd=@kullaniciAd and kullaniciSifre=@kullaniciSifre)
  Begin
    Select TOP(1) kullaniciTipiID,calisanID,yoneticiID FROM Kullanicilar where kullaniciAd=@kullaniciAd
  End
  Else
  Begin
    Select 0
  End
END


--Çalýþan Güncelleme
Create Proc sp_CalisanBilgiGuncelleme
(
  @calisanAd nvarchar(20)
 ,@calisanSoyad nvarchar(20)
 ,@calisanTCKimlikNo nvarchar(15)
 ,@calisanDogumTarih datetime
 ,@calisanTelefonNo nvarchar(20)
 ,@calisanEPosta nvarchar(20)
 ,@calisanAdres nvarchar(300)
 ,@ulkeID int
 ,@sehirID int
 ,@gorevID int
 ,@cinsiyetID int
 ,@calisanMaas decimal(8,3)
 ,@calisanSicilNo nvarchar(20)
 ,@calisanEngelliMi bit
 ,@acilDurumKisiAd nvarchar(20)
 ,@acilDurumKisiTel nvarchar(20)
 ,@calisanIseBaslamaTarih datetime
 ,@calisanIstenCikisTarih datetime
 ,@calisanAktifMi bit
 ,@calisanAciklama nvarchar(300)
)
AS
BEGIN
  Update Calisanlar Set calisanAd=@calisanAd, calisanSoyad=@calisanSoyad, calisanTCKimlikNo=@calisanTCKimlikNo, calisanDogumTarih=@calisanDogumTarih, calisanTelefonNo=@calisanTelefonNo, calisanEposta=@calisanEPosta, calisanAdres=@calisanAdres, ulkeId=@ulkeID, sehirId=@sehirID, gorevID=@gorevID, cinsiyetID=@cinsiyetID,
  calisanMaas=@calisanMaas, calisanSicilNo=@calisanSicilNo, calisanEngelliMi=@calisanEngelliMi, acilDurumKisiAd=@acilDurumKisiAd, acilDurumTelefonNo=@acilDurumKisiTel, calisanIseBaslamaTarih=@calisanIseBaslamaTarih, calisanIstenCikisTarih=@calisanIstenCikisTarih, calisanAktifMi=@calisanAktifMi, calisanAciklama=@calisanAciklama  
  Where calisanTCKimlikNo=@calisanTCKimlikNo
END


Create Proc sp_CalisanKaydet
 (
   @calisanAd nvarchar(20)
  ,@calisanSoyad nvarchar(20)
  ,@calisanTCKimlikNo nvarchar(15)
  ,@calisanDogumTarih datetime
  ,@calisanTelefonNo nvarchar(20)
  ,@calisanEposta nvarchar(20)
  ,@calisanAdres nvarchar(300)
  ,@ulkeId int
  ,@sehirId int 
  ,@gorevID int
  ,@cinsiyetID int
  ,@calisanMaas decimal(8,3)
  ,@calisanSicilNo nvarchar(20)
  ,@calisanEngelliMi bit
  ,@acilDurumKisiAd nvarchar(20)
  ,@acilDurumTelefonNo nvarchar(20)
  ,@calisanIseBaslamaTarih datetime
  ,@calisanIstenCikisTarih datetime
  ,@calisanAktifMi bit
  ,@calisanAciklama nvarchar(300)     
)
AS
BEGIN
INSERT INTO Calisanlar([calisanAd], [calisanSoyad], [calisanTCKimlikNo], [calisanDogumTarih], [calisanTelefonNo], [calisanEposta], [calisanAdres], [ulkeId], [sehirId], [gorevID], [cinsiyetID], [calisanMaas], [calisanSicilNo], [calisanEngelliMi], [acilDurumKisiAd],[acilDurumTelefonNo], [calisanIseBaslamaTarih], [calisanIstenCikisTarih], [calisanAktifMi], [calisanAciklama])VALUES (@calisanAd,@calisanSoyad, @calisanTCKimlikNo, @calisanDogumTarih, @calisanTelefonNo,@calisanEposta, @calisanAdres, @ulkeId,@sehirId, @gorevID, @cinsiyetID, @calisanMaas, @calisanSicilNo, @calisanEngelliMi, @acilDurumKisiAd, @acilDurumTelefonNo, @calisanIseBaslamaTarih, @calisanIstenCikisTarih ,@calisanAktifMi ,@calisanAciklama)
END



--Çalýþan Pasife Çekme(Sil butonu)

Alter Trigger tgr_CalisanSilme
  on Calisanlar Instead of Delete
  As
  Begin 
   Update Calisanlar set calisanAktifMi=0 Where calisanTCKimlikNo=(select calisanTCKimlikNo from deleted)
  End


  --Kampanya Güncelle

  Create Proc sp_KampanyaGuncelle
  (
    @kampanyaAd nvarchar(20)
   ,@kampanyaIndirim int
   ,@kampanyaBaslangicTarihi datetime
   ,@kampanyaBitisTarihi datetime
   ,@kampanyaAktifMi bit
   ,@kampanyaAciklama nvarchar(400)
  )
  AS
  BEGIN
  Update Kampanyalar SET kampanyaAd=@kampanyaAd, kampanyaIndirim=@kampanyaIndirim, kampanyaBaslangicTarihi=@kampanyaBaslangicTarihi, kampanyaBitisTarihi=@kampanyaBitisTarihi, kampanyaAktifMi=@kampanyaAktifMi, kampanyaAciklama=@kampanyaAciklama Where kampanyaAd=@kampanyaAd
  END


  --KampanyaEkle

Create Proc sp_KampanyaEkle
(
    @kampanyaAd nvarchar(20)
   ,@kampanyaIndirim int
   ,@kampanyaBaslangicTarihi datetime
   ,@kampanyaBitisTarihi datetime
   ,@kampanyaAktifMi bit
   ,@kampanyaAciklama nvarchar(400))
AS
BEGIN

END
