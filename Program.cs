using System;
using System.Reflection;

namespace VehicleDescriptionAttributeReaderLateBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************");
            ReflectAttributesUsingLateBinding();
        }

        private static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                Assembly asm = Assembly.Load("AttributedCarLibrary");

                Type vehicleDesc =
                    asm.GetType("AttributedCarLibrary.VehicleDescriptionAtribute");

                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");

                Type[] types = asm.GetTypes();

                foreach (Type t in types)
                {
                    object[] objs = t.GetCustomAttributes(vehicleDesc, false);
                    
                    foreach(object o in objs)
                    {
                        Console.WriteLine("---> {0}: {1}", t.Name, propDesc.GetValue(0,null));

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
