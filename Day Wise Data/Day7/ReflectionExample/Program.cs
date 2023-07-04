using System.Reflection;
namespace ReflectionExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assembly assembly = Assembly.GetAssembly(typeof(int));
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Assembly assembly = Assembly.GetCallingAssembly();
            //Assembly assembly = Assembly.GetEntryAssembly();
            Assembly assembly = Assembly.LoadFile("D:\\Trainings\\ActsJune23\\Day1\\BasicClassConcepts\\bin\\Debug\\net7.0\\BasicClassConcepts.dll");

            //Console.WriteLine(assembly.FullName);
            Console.WriteLine(assembly.GetName().Name);

            Type[] arrTypes = assembly.GetTypes();

            foreach (Type t in arrTypes) 
            {
                Console.WriteLine("    "+t.Name);
                MethodInfo[] arrMethods = t.GetMethods();
                foreach (MethodInfo m in arrMethods) 
                {
                    Console.WriteLine("        " + m.Name);
                }
            }

        }
    }
}