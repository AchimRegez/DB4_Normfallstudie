using System;
using System.Linq;

namespace DB4_Normfallstudie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new EnvironmentalDamageManagementContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            using (context)
            {
                //Creating Persons
                Console.WriteLine("Creating persons...");
                var ownerHans = new Owner()
                {
                    FirstName = "Hans",
                    LastName = "Nötig"
                };

                var ownerSabrina = new Owner()
                {
                    FirstName = "Sabrina",
                    LastName = "Betschart"
                };

                var employeeAnja = new Employee()
                {
                    FirstName = "Anja",
                    LastName = "Baer"
                };

                var employeeRene = new Employee()
                {
                    FirstName = "Rene",
                    LastName = "Durr"
                };

                var landRegistryStefanie = new LandRegistry()
                {
                    FirstName = "Stefanie",
                    LastName = "Fleischer"
                };

                var landRegistryKatja = new LandRegistry()
                {
                    FirstName = "Katja",
                    LastName = "Bleich"
                };


                Console.WriteLine("Creating hazard...");
                //Creating Hazards
                var hazardPesticide = new Hazard()
                {
                    Substance = "Pesticide",
                    Severity = 5
                };

                var hazardCadmium = new Hazard()
                {
                    Substance = "Cadmium",
                    Severity = 8
                };

                var hazardChrome = new Hazard()
                {
                    Substance = "Chrome",
                    Severity = 8
                };

                var hazardRadionuclides = new Hazard()
                {
                    Substance = "Radionuclides",
                    Severity = 9
                };


                Console.WriteLine("Creating objects...");
                //Creating Objects
                var objectToTheRose = new Object()
                {
                    ObjectName = "To The Rose",
                    Hazard = hazardPesticide
                };

                var objectMetalli = new Object()
                {
                    ObjectName = "Metalli",
                    Hazard = hazardChrome
                };



                //Adding persons to the database
                context.Employees.Add(employeeAnja);
                context.Employees.Add(employeeRene);
                context.Owners.Add(ownerHans);
                context.Owners.Add(ownerSabrina);
                context.LandRegistryOffices.Add(landRegistryStefanie);
                context.LandRegistryOffices.Add(landRegistryKatja);
                

                //Adding objects to the database
                context.Objects.Add(objectToTheRose);
                context.Objects.Add(objectMetalli);    
                context.SaveChanges();
                Console.WriteLine("Database updated...");
                


                /*Besitzer X wird von Grundbuchamt A aufgefordert einen Fragebogen auszufüllen
                 * -> Einspeisung Angaben von Objekten
                 * -> Alle Objekte erhalten die Risiko haben
                 * -> Verfügungen werden für Risikobehaftete Objekte versendet 
                 * 
                 * 
                 */

                //Checkliste
                var objectsAtRisk = Object.GetObjectsAtRisk(context.Objects.ToList());
                Object.WriteHazardorders(objectsAtRisk);

                Console.ReadLine();
            }
        }
    }
}
