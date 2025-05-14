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

Sve uloge imaju pristup mobilnoj aplikaciji dok uloge Administrator i Serviser imaju pristup desktop aplikaciji.

Implementiran je State Machine za uređaje na sljedeći način:

Tekstualno:
  -Prilikom dodavanja uređaja u bazu podataka njegovo stanje će biti "idle" - Neaktivan i u stanju se mogu uređivati podaci o uređaju, uređaj se može označiti za rezervne dijelove.
  -"parts" - Rezervni dijelovi - uređaj se može aktivirati
  -"active" - Aktivan - uređaj se može servisirati, dodati u radni zadatak i deaktivirati
  -"task" - Radni zadatak - uređaj je dio nekog radnog zadatka i imat će to stanje do prvog servisa
  -"fix" - Servisiran - uređaj se može servisirati ponovno i može se spremiti za pošiljku
  -"ready" - Spreman - uređaj je spreman za pošiljku i ponovno se može servisirati 
  -"out" - Poslan - uređaj je poslan i može se vratiti i njegovo stanje će biti "active"
 
Slikovno:
![image](https://github.com/user-attachments/assets/74c44653-411f-4fcb-a7a7-2c88a70f9f30)
