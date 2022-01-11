using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB4_Normfallstudie
{
    internal class Object
    {
        public int Id { get; set; }
        public string? ObjectName { get; set; }
        public Hazard? Hazard { get; set; }
        

        public static List<Object> GetObjectsAtRisk(List<Object> objects)
        {
            List<Object> objectsAtRisk = (from obj in objects
                                         where obj.Hazard.Severity >= 7
                                         select obj).ToList();  
            return objectsAtRisk;        
            
        }


        public static void WriteHazardorders(List<Object> objects)
        {
            foreach(var obj in objects)
            {
                Console.WriteLine($"Verfügung für {obj.ObjectName} wurde gesendet...");
            }
        }
    }
}
