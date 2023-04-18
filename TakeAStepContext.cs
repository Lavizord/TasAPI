using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Entities.Models
{
    // Esta class é a nossa representação da base de dados. Tem as nossas tabelas e as nossas ligações.
    public class TasDB: DbContext
    {
        public TasDB(DbContextOptions<TasDB> options):base(options)
        {
        }
        // Aqui definimos as nossas entidades, que são as nossas tabelas.
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<SceneEffect> SceneEffects { get; set; }
 
        //  Aqui estamos a usar FluentAPI para definir as relações entre as tabelas.
        //  Gosto de usar aqui porque fica mais explicito, pelo menos na minha opinião,
        // mas é possível fazer o mesmo nos Models de Entidades diretamente... São escolhas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DefineSceneChoide(modelBuilder);     
        }

        private void DefineSceneChoide(ModelBuilder modelBuilder)
        {
            // One-to-many relationship            
            modelBuilder.Entity<Scene>()
                .HasMany<Choice>(s => s.PrecidingChoices)
                .WithOne(c => c.NextScene)
                .HasForeignKey(c => c.NextSceneId); 
                
            // One-to-many relationship            
            modelBuilder.Entity<Scene>()
                .HasMany<Choice>(s => s.OwnChoices)
                .WithOne(c => c.OwnScene)
                .HasForeignKey(c => c.OwnSceneId);
            
            // One to One relationship
            modelBuilder.Entity<Scene>()
                .HasOne<SceneEffect>(s => s.SceneEffect)
                .WithOne(sf => sf.Scene)
                .HasForeignKey<SceneEffect>(sf => sf.sceneId);
        }
    }
}