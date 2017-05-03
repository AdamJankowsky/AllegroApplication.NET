# AllegroApplication.NET
Simple application using Allegro WSDL API

Prosta aplikacja korzystająca z API Allegro, początkowo miał to być menedżer sprzedaży jednak z uwagi na ograniczenia w działaniu Sandboksa Allegro nie będę w stanie przetestować różnych scenariuszy.

Aplikacja łączy się z api sandboksa allegro i pobiera Wystawione, Sprzedane i Wygrane przedmioty. Powstał również model przechowywalni kluczy do automatycznego wysłania (np. do gier, oprogramowania etc.). Jednakże z racji prac Allegro nad snadboksem sama funkcjonalność wysyłania kluczy nie została jeszcze napisana.

Aplikacja do działania potrzebuje dane zapisane w pliku Global.cs (klucz api, użytkownika i hasło).
