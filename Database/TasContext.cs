using Entities.Models;
using Entities.Models.ManyToMany;

using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Entities.Models
{
    // Esta class é a nossa representação da base de dados. Tem as nossas tabelas e as nossas ligações.
    public class TasDB: DbContext
    {
        public TasDB(DbContextOptions<TasDB> options):base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        // TODO: Criar os Models iniciais para cada uma das tabelas no diagrama.
        // Aqui definimos as nossas entidades, que são as nossas tabelas.
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<SceneEffect> SceneEffects { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Type> Types { get; set; }

        // Many To Many relation tables.
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<SceneItem> SceneItems { get; set; }
        public DbSet<SceneType> SceneTypes { get; set; }


        // TODO: Definir as relações restantes no diagrama da DB
        //  Aqui estamos a usar FluentAPI para definir as relações entre as tabelas.
        //  Gosto de usar aqui porque fica mais explicito, pelo menos na minha opinião,
        // mas é possível fazer o mesmo nos Models de Entidades diretamente... São escolhas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Some of these have more than 1 relation defined.
            DefineSceneChoices(modelBuilder);     
            DefineSceneSceneEffect(modelBuilder);

            //  Many To Many, single relation defined.
            DefineItemsTypes(modelBuilder);
            DefineScenesItems(modelBuilder);
            DefineScenesTypes(modelBuilder);
        }

        private void DefineSceneChoices(ModelBuilder modelBuilder)
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
        }

        private void DefineSceneSceneEffect(ModelBuilder modelBuilder)
        {
            // One to One relationship
            modelBuilder.Entity<Scene>()
                .HasOne<SceneEffect>(s => s.SceneEffect)
                .WithOne(sf => sf.Scene)
                .HasForeignKey<SceneEffect>(sf => sf.sceneId);
                
        }

        private void DefineItemsTypes(ModelBuilder modelBuilder)
        {
            // Many to Many
            modelBuilder.Entity<Item>()
                .HasMany(i => i.Types)
                .WithMany(t => t.Items)
                .UsingEntity<ItemType>();
        }

        private void DefineScenesItems(ModelBuilder modelBuilder)
        {
            // Many to Many
            modelBuilder.Entity<Scene>()
                .HasMany(s => s.Items)
                .WithMany(i => i.Scenes)
                .UsingEntity<SceneItem>();
        }

        private void DefineScenesTypes(ModelBuilder modelBuilder)
        {
            // Many to Many
            modelBuilder.Entity<Scene>()
                .HasMany(s => s.Types)
                .WithMany(t => t.Scenes)
                .UsingEntity<SceneType>();
        }
    }
}