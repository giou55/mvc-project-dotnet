using Microsoft.EntityFrameworkCore;

using mvc_project_dotnet.Models;

namespace mvc_project_dotnet.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            MyDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<MyDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                        {
                            Title = "Pride and Prejudice",
                            Description = "It is a truth universally acknowledged that when most people think of " +
                                "Jane Austen they think of this charming and humorous story of love, " +
                                "difficult families and the tricky task of finding a handsome husband with a good fortune.",
                            Author = "Jane Austen",
                            Price = (float)28.50,
                            CreatedTimestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                        },
                    new Book
                        {
                            Title = "The Great Gatsby",
                            Description = "Jay Gatsby, the enigmatic millionaire who throws decadent parties " +
                                "but doesn’t attend them, is one of the great characters of American literature. " +
                                "This is F. Scott Fitzgerald at his most sparkling and devastating.",
                            Author = "F. Scott Fitzgerald",
                            Price = (float)32.50,
                            CreatedTimestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                        },
                    new Book
                        {
                            Title = "Brave New World",
                            Description = "One of the greatest and most prescient dystopian novels " +
                                "ever written, this should be on everyone’s must-read list.",
                            Author = "Aldous Huxley",
                            Price = (float)30.50,
                            CreatedTimestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                        },
                    new Book
                        {
                            Title = "Crime and Punishment",
                            Description = "This novel is a masterful and completely captivating depiction " +
                                "of a man experiencing a profound mental unravelling. No amount of ethical " +
                                "bargaining on Raskolnikov’s part can free him from the parasitic guilt nested in his soul. " +
                                "A brilliant read if you loved Breaking Bad.",
                            Author = "Fyodor Dostoevsky",
                            Price = (float)48.50,
                            CreatedTimestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                        },
                    new Book
                        {
                            Title = "Moby-Dick",
                            Description = "Every American writer since 1851 has been chasing the same " +
                                "whale: to somehow write a novel as epic and influential as Melville’s.",
                            Author = "Herman Melville",
                            Price = (float)48.50,
                            CreatedTimestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                        }
                );

                context.SaveChanges();
            }
        }
    }
}