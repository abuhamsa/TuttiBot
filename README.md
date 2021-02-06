# TuttiBot
Das ist eine C# Applikation die es ermöglichen soll tutti.ch automatisch zu überwachen und Pushnotifications zu versenden.
Das ganze ist noch total im Aufbau.

## Funktionsweise
1. TuttiBot erhält einen Suchstring.
2. Liest den Quellcode der Seite
3. Liest den JSON-Part raus mit den Angeboten
4. Erstellt eine Offer
5. Überprüft mit JSON-File ob die Offer schon jemals gesendet wurde
6. Wenn nicht wird die Offer über den gewählten Provider versendet.

## Usage
1. git clone
2. App.config.example in App.config umbennen
3. In VisualStudio starten
4. Key für Provider setzen. 
4a. Für Pushover bitte den Userkey setzen.
4b. Bei Telegramm muss der Bot "tuttibotti" in deine Gruppe hinzugefügt werden (als Admin) danach die Chat-ID auslesen (https://t.me/RawDataBot) und entsprechend im GUI setzen. 
5. Suchbegriff eingeben (mehrere Begriffe können gesucht werden und werden mit ; getrennt)
