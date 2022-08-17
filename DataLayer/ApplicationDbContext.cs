using Microsoft.EntityFrameworkCore;
using SolarLabSolutionDomain.Templates;
 
 namespace SolarLabSolution.DataLayer;
 
 public class ApplicationDbContext : DbContext
 {
     public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
         : base(options)
     {
         Database.EnsureCreated();
     }
     
     public DbSet<Staff> Staff { get; set; }
  
 }