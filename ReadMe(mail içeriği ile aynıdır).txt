  

Proje Genel Bilgi 

Kullanıcı(çalışan),3 ayrı şekilde sipariş girebilir.  
Boyunu belirlediği bir içecek siparisi (Venti boy Mocha) 
   Kullanıcı içecek siparişi girmek için BeveragesController'daki GetPrice(int beverageId, int sizeId)'ı çağırır.   
Kaç adet olduğunu belirlediği ekstra malzeme (x2 Milk) 
   Kullanıcı ekstra malzeme siparişi girmek için FlavorsController'daki GetPrice(int flavorId, int numberOfFlavor)'ı çağırır.   
Adet belirtmeden (1 adet anlamına gelir) ekstra malzeme 
   Kullanıcı ekstra malzeme siparişi girmek için FlavorsController'daki GetPrice(int flavorId)'ı çağırır  
Flavorsiparişini ikiye ayırmamın nedeni, siparişlerin %90'ında ekstra malzeme sayısıolmuyor. Sürekli 1 paremetresi girdirmemek için.  


Uygun değerler 

beverageId için uygun değerler -> 0, 1, 2, 3
sizeId için uygun değerler -> 0, 1, 2, 3
numberOfFlavor için uygun değerler -> 1, 2, 3, … (1 adet istendiğinde, bu parametreninolmadığı GetPrice(int flavorId) gağırılmalı, bu paremetreye 1 girmekanlamsız ama kullanıcıyı kısıtlamadım)


Kontroller (yazılan testler) - 22 adet test vardır ve hepsi geçilmiştir. Visual Studio'da Test>Run All Tests demek yeterlidir.  

BeveragesControllerTests           
GetPrice(int beverageId,int sizeId)  
GetPrice(1, 3) -> OK GetPrice(-1, 1) -> BadRequest - İçecek id veya boy id 0'dan küçük olamaz! 
GetPrice(1, -1) ->  BadRequest  - İçecek id veya boy id 0'dan küçük olamaz! 
GetPrice(5, 1) -> BadRequest  - Numarası 5 olan bir içecek bulunmamaktadır 
GetPrice(1, 3) -> BadRequest  - "Numarası 3 olan bir içecek boyu bulunmamaktadır.   

FlavorsControllerTests
GetPrice(int flavorId, int numberOfFlavor)  
GetPrice(1, 3) -> OK   
GetPrice(-1, 1) -> BadRequest - Çeşni id 0'dan küçük olamaz! 
GetPrice(3, 1) -> BadRequest  - Numarası 3 olan bir çeşni bulunmamaktadır! 
GetPrice(1, 0) ->  BadRequest - Çeşni sayısı 1'den küçük olamaz! 
GetPrice(int flavorId)  
GetPrice(1) -> OK GetPrice(-1) -> BadRequest - Çeşni id 0'dan küçük olamaz! 
GetPrice(3)  -> BadRequest - Numarası 3 olan bir çeşni bulunmamaktadır!   

BeverageManagerTestsGetPrice(int beverageId)  
GetPrice(1) -> true - AreEqual(10, price) 
GetPrice(5) -> true - AreEqual(-1, price) - Not: price'ın -1 olma durumu veri gelmeme anlamına gelir, controller'da bu durum yakalanır 
GetAll() -> true - AreEqual(4, beverages.Count) - Not: Toplamda 4 adet içecek var.  

SizeManagerTests 
GetPercentageOfPrice(sizeId)
GetPercentageOfPrice(1) -> true - AreEqual(20, price) 
GetPercentageOfPrice(4) -> true - AreEqual(-1, price) -  Not: price'ın -1 olma durumu veri gelmeme anlamına gelir, controller'da bu durum yakalanır. 
GetAll() -> true - AreEqual(4, sizes.Count) - Not: Toplamda 4 adet boy var.   

FlavorManagerTests 
GetPrice(flavorId)
GetPrice(0) -> true - AreEqual(10, price) 
GetPrice(3) -> true- AreEqual(-1, price) - Not: price'ın -1 olma durumu veri gelmeme anlamına gelir, controller'da bu durum yakalanır 
GetAll() -> true - AreEqual(3, flavors.Count)  - Not: Toplamda 3 adet çeşni var.