# EvFBW_Coding_2023_F
Programmierkurs für Fortgeschrittene 2023 für Jugendliche beim Evangelischen Familienbildungswerk

## Software
Wir arbeiten auf Windows 11 Computern und installieren dort
- das Textbearbeitungs Programm __Notepad++__ von
[notepad-plus-plus.org](https://notepad-plus-plus.org/downloads/)
- das Bildbearbeitungs Programm __The Gimp__ von
[www.gimp.org](https://www.gimp.org/)
- die Audio Software __Audacity__ von
[www.audacityteam.org](https://www.audacityteam.org/download/windows/)
- die Versionskontrollsoftware __git__
  - Zuerst installieren wir die Basis-Software von [gitforwindows.org](https://gitforwindows.org/)
  - Dann installieren wir die Software von [tortoisegit.org](https://tortoisegit.org/download/) die die Benutzeroberfläche von dem Windows File Explorer um nützliche Icons und Menüs erweitert

### Für die Python Programmierer
- das __Python__ Übersetzer Programm von
[www.python.org](https://www.python.org/downloads/)
- die Community Version der Entwicklungsumgebung __PyCharm__ von
[www.jetbrains.com](https://www.jetbrains.com/pycharm/download/#section=windows)

### Für die Minecraft Mod Programmierer
Seht dazu die Beschreibung "Minecraft Mods" in dem folgenden Abschnitt weiter unten.

### Für die Unity Programmierer
Seht dazu die Beschreibung des Spiels "Solar Parcour" in dem folgenden Abschnitt weiter unten.

### Für die Unreal Programmierer
still under construction

## Solar Parcour
Das ist ein Spiel was ich für den Programmierkurs
beim Evangelischen Familienbildungswerk vorbereitet habe.
Es ist mit Absicht unfertig 
und kann von den teilnehmenden Kindern
beliebig erweitert werden.

Die teilnehmenden Kinder können das Spiel bequem 
auf ihr eigenes Android Smartphone installieren,
sodass sie es zu Hause oder unterwegs spielen 
und sogar ihren Familien und Freunden zeigen können.

Wenn ihr dieses Projekt zu Hause auf den eigenen Computer
herunterladen und bearbeiten möchtet
müsst ihr die folgenden Schritte befolgen.

1. Zuerst solltet ihr dieses Projekt als Zip Archiv herunterladen. Klickt auf den grünen Knopf mit der Aufschrift "Code" und dann auf den Menüeintrag "Download ZIP". Lasst Euch beim Öffnen dieser ZIP Datei von Euren Eltern helfen.
https://github.com/martinjanfischer/EvFBW_Coding_2023_F.git
![github01](Readme/github01.jpg)

2. Danach solltet ihr das Programm Unity Hub herunterladen und installieren.
Klickt entweder auf die Adresse
https://unity.com/download
oder direkt auf die Adresse
https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe
.
Es kann sein, dass Windows Probleme bei der Installation von Unity Hub macht,
weil das Programm nicht über den Microsoft Store installiert wird.
Prüft daher in dem Programm Einstellungen, Apps und Features 
dass ihr auch Programme installieren dürft, die nicht über den Microsoft Store angeboten werden.
![Unity01](Readme/Unity01.jpg)

3. Ihr müsst ein Konto beim Unity anlegen.
Bei diesem Schritt könnt ihr Euch von Euren Eltern helfen lassen.
![Unity02](Readme/Unity02.jpg)

4. In dem Unity Hub Fenster klickt ihr auf der linken Seite auf "Projects"
![Unity03](Readme/Unity03.jpg)

5. In dem Unity Hub Fenster klickt ihr auf der rechten Seite auf den Knopf "Open"
![Unity04](Readme/Unity04.jpg)

6. In dem Verzeichnis-Auswahl-Fenster wechselt ihr in das Verzeichnis, das ihr nach dem Öffnen des ZIP Archivs (siehe Schritt 1) angelegt habt und klickt dann auf den Knopf "Open".
![Unity05](Readme/Unity05.jpg)

7. Unity HUB empfiehlt Euch einen Unity Editor zu installieren.
Es ist super wichtig die "Missing Version 2021.3.24f1 LTS" zu installieren.
Bitte wählt keine andere Version aus.
Klickt dann auf den Knopf mit der Aufschrift "Install Version 2021.3.24f1".
![Unity06](Readme/Unity06.jpg)

8. Das nächste Unity HUB Fenster fragt Euch
welche Module installiert werden sollen.
Unbedingt solltet ihr "Microsoft Visual Studio Community 2019" auswählen.
Wenn Ihr das Spiel auch auf Eurem Android Smartphone installieren möchtet,
dann solltet Ihr auch "Android Build Support",
"OpenJDK", und "Android SDK & NDK Tools" installieren.
Klickt auf den Knopf mit der Aufschrift "Continue".
![Unity07](Readme/Unity07.jpg)
![Unity08](Readme/Unity08.jpg)

9. Ihr müsst dann noch die Lizenzvereinbahrungen
für die Benutzung von Visual Studio 2019 Community akzeptieren
bevor ihr auf den Knopf mit der Aufschrift "Continue" klickt.
![Unity09](Readme/Unity09.jpg)

10. Zuletzt müsst ihr dann noch die Lizenzvereinbahrungen
für die Benutzung vom Android SDK und NDK akzeptieren.
Ihr klickt auf den Knopf mit der Aufschrift "Install"
und die sehr lange Installation beginnt.
![Unity10](Readme/Unity10.jpg)

11. Nachdem die Installation fertig geworden ist,
könnt Ihr nun das Spielprojekt im Unity HUB Fenster öffnen,
wenn Ihr zuerst den Knopf "Projects" auf der linken Seite anklickt
und dann in der Mitte des Fensters das Spielprojekt anklickt.
Es wird ein Kreis angezeigt, dass den Ladevorgang anzeigt.
Es kommt dann ein Fortschrittsbalken 
und dann der Ladebildschirm des Unity Editor Programms.
![Unity11](Readme/Unity11.jpg)
![Unity12](Readme/Unity12.jpg)
![Unity13](Readme/Unity13.jpg)

12. Das Unity Editor Fenster sollte ungefähr so wie im Bild aussehen.
Ihr könnt das Spiel auch sofort spielen indem ihr auf den Knopf mit dem Dreieck klickt.
Ihr verlasst das Spiel auch wieder über denselben Knopft.
![Unity14](Readme/Unity14.jpg)
![Unity15](Readme/Unity15.jpg)

13. Wenn Ihr das APK Installationspaket für Euer Android Smartphone erstellen möchtet,
dann klickt auf das Menü "File, Build Settings...".
![Unity16](Readme/Unity16.jpg)

14. In dem nächsten Fenster wählt Ihr zuerst oben links eine Szene aus
die Ihr in dem Installationspaket haben wollt,
dann wählt ihr links die Plattform "Android" aus. Wenn ihr diese Einstellung zum ersten Mal durchführt, dann gibt es unten rechts einen Knopf "Switch Version" den ihr mit der Maus anklickt. Danach sollte derselbe Knopf die Aufschrift "Build" anzeigen. Zuletzt klickt ihr genau auf diesen Knopf "Build".
![Unity17](Readme/Unity17.jpg)

15. In dem nächsten Fenster wählt Ihr ein Verzeichnis aus,
in dem die Datei "SolarParcour.apk" erzeugt werden soll,
dann klickt Ihr auf den Knopf "Speichern".
Dann erscheint ein Fortschrittsbalken und Ihr müsst wieder etwas warten.
![Unity18](Readme/Unity18.jpg)
![Unity19](Readme/Unity19.jpg)

20. Zum Schluss schliesst Ihr Euer Android Smartphone 
an den Computer an, kopiert die Datei "SolarParcour.apk" auf Euer Smartphone,
und auf dem Smartphone könnt Ihr dann das Paket installieren.

## Minecraft Mods
Für das Schreiben von Mods für Minecraft brauchst Du folgendes
1.	Eltern mit einem __Microsoft Account__ mit __30€ Guthaben__ 
(XBOX Gutscheine, Kreditkarte, Lastschrift, ...)

2.	__Minecraft: Java & Bedrock Edition for PC__ kaufen auf __minecraft.net__ mit diesem Microsoft Account
- [Minecraft: Java & Bedrock Edition for PC](https://www.xbox.com/de-DE/games/store/minecraft-java-bedrock-edition-for-pc/9nxp44l49shj)

3.	Nach dem Kauf den __Minecraft Launcher__ für Windows __herunterladen__

4.	In Windows beim __Microsoft Store__ mit dem Microsoft Account __anmelden__

5.	Den __Minecraft Launcher__ auf Windows __starten__

6.	__OpenJDK__ herunterladen und installieren
damit man in der Sprache Java programmieren kann

7.	__IntelliJ__ herunterladen und installieren
damit man mit einer vernünftigen Entwicklungsumgebung in Java programmieren kann
Lade die Community Version der Entwicklungsumgebung __IntelliJ__ herunter von
[www.jetbrains.com](https://www.jetbrains.com/de-de/idea/download/?section=windows)

8.	Entweder Minecraft __Forge__ Archiv oder Minecraft __Fabric__ Archiv herunterladen
Forge ist etwas komplizierter als Fabric
Das Archiv aus Quelltextdateien ist ein __Grundgerüst__ für ein __Mod__ in Minecraft
und kann schon in Minecraft installiert und ausgeführt werden
- Software
  - [https://files.minecraftforge.net/net/minecraftforge/forge/index_1.19.html](https://files.minecraftforge.net/net/minecraftforge/forge/index_1.19.html)
  - [https://fabricmc.net/use/installer/](https://fabricmc.net/use/installer/)

9. Der youtuber „Kaupenjoe“ hat ein paar tolle Erklärvideos zu Forge und Fabric und fertige Programmierbeispiele im Internet veröffentlicht
- Forge
  - [GitHub - Tutorials-By-Kaupenjoe/Forge-Tutorial-1.19](https://github.com/Tutorials-By-Kaupenjoe/Forge-Tutorial-1.19)
  - [Minecraft 1.19 Forge Modding Tutorials - YouTube](https://www.youtube.com/playlist?list=PLKGarocXCE1HrC60yuTNTGRoZc6hf5Uvl)
- Fabric
  - [GitHub - Tutorials-By-Kaupenjoe/Fabric-Tutorial-1.19](https://github.com/Tutorials-By-Kaupenjoe/Fabric-Tutorial-1.19)
  - [Minecraft 1.19 Fabric Modding Tutorials - YouTube](https://www.youtube.com/playlist?list=PLKGarocXCE1EeLZggaXPJaARxnAbUD8Y_)

10.	Das Forge/Fabric Archiv mit Selbst Programmierten Quelltext und Bilddateien füllen
