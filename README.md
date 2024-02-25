#  Creare un'app web Razor Pages con ASP.NET Core

## utilizzare Entity Framework per collegarsi ad un database locale creato tramite SQLite
## EF Core è un mapper relazionale a oggetti (O/RM) che semplifica l'accesso ai dati. 

### Passi collegamento entity:

## 0- Per prima cosa si scrivono le classi del modello e EF Core si crea il database.
## Le classi del modello sono note come classi POCO (da "Plain-O ld CLR Objects") perché non hanno una 
## dipendenza da EF Core. Definiscono le proprietà dei dati archiviati nel database.

### 1-Aggiungere i pacchetti NuGet e gli strumenti EF

### 2- Eseguire lo scaffholding del modello

### 3- Usare SQLite per lo sviluppo, SQL Server per la produzione

### 4- Creare lo schema del database iniziale usando la funzionalità di migrazione di Entity Framework