/* In questa esercitazione vengono aggiunte classi per la gestione dei film in un database. 
Le classi di modello dell'app usano Entity Framework Core (EF Core) per lavorare con il database. 
EF Core è un mapper relazionale a oggetti (O/RM) che semplifica l'accesso ai dati. 
Per prima cosa si scrivono le classi del modello e EF Core si crea il database.

Le classi del modello sono note come classi POCO (da "Plain-O ld CLR Objects") perché non hanno una 
dipendenza da EF Core. Definiscono le proprietà dei dati archiviati nel database. */

using System.ComponentModel.DataAnnotations;


namespace RazorPagesMovie.Models;


public class Movie

{
    public int Id { get; set; }
    public string? Title { get; set; }

/*Attributo [DataType] per specificare il tipo di dati nel ReleaseDate campo. Con questo attributo:
l'utente non deve immettere le informazioni temporali nel campo della data.
Viene visualizzata solo la data, non le informazioni temporali */
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}