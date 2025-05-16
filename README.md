# eWorkshop
Seminarski projekat iz predmeta Razvoj softvera 2</br></br>

Kredencijali</br></br>

Administrator</br>
username: user.admin</br>
password: Test123!</br>
</br>
Serviser</br>
username: user.serviser</br>
password: Test123!</br></br>

Pretplatnik</br>
username: user.pretplatnik</br>
password: Test123!</br></br>

Sve uloge imaju pristup mobilnoj aplikaciji dok uloge Administrator i Serviser imaju pristup desktop aplikaciji.</br></br>

Implementiran je State Machine za uređaje na sljedeći način:</br></br>

Tekstualno:</br>
  -Prilikom dodavanja uređaja u bazu podataka njegovo stanje će biti "idle" - Neaktivan i u stanju se mogu uređivati podaci o uređaju, uređaj se može označiti za rezervne dijelove.</br>
  -"parts" - Rezervni dijelovi - uređaj se može aktivirati</br>
  -"active" - Aktivan - uređaj se može servisirati, dodati u radni zadatak i deaktivirati</br>
  -"task" - Radni zadatak - uređaj je dio nekog radnog zadatka i imat će to stanje do prvog servisa</br>
  -"fix" - Servisiran - uređaj se može servisirati ponovno i može se spremiti za pošiljku</br>
  -"ready" - Spreman - uređaj je spreman za pošiljku i ponovno se može servisirati </br>
  -"out" - Poslan - uređaj je poslan i može se vratiti i njegovo stanje će biti "active"</br></br>
 
Slikovno:</br>
![image](https://github.com/user-attachments/assets/29feff40-ad1c-4259-a92a-35eed9f0075f)

