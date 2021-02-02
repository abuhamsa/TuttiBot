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
