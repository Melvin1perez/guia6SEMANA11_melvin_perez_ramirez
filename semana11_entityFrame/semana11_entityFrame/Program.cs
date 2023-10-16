// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//------MELVIN ALEXANDER PEREZ RAMIREZ------
//ejercicio 1
//using (var contextdb = new ContextoDB())
//{
//    foreach (var item in contextdb.Estudiante)
//    {
//        Console.WriteLine(item.Id+" "+item.Nombres+" "+item.Apellidos+" "+item.Edad+" "+item.Sexo);
//    }
//}
//ejercicio2
//using (var contextdb = new ContextoDB())
//{
//    contextdb.Database.EnsureCreated();

//    var estudiante1 = new EstudianteUnab() { Nombres = "Pepita", Apellidos = "Perez" };

//    contextdb.Add(estudiante1);
//    contextdb.SaveChanges();

//    foreach (var item in contextdb.Estudiante)
//    {
//        Console.WriteLine(item.Nombres+" "+item.Apellidos);
//    }
//}
//ejercicio3

bool agregarMasRegistros = true;

using (var contextdb = new ContextoDB())
{
    contextdb.Database.EnsureCreated();

    while (agregarMasRegistros)
    {
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el apellido: ");
        string apellido = Console.ReadLine();

        Console.Write("Ingrese el sexo: ");
        string sexo = Console.ReadLine();

        Console.Write("Ingrese la edad: ");
        int edad;
        if (int.TryParse(Console.ReadLine(), out edad))
        {
            var estudiante = new EstudianteUnab() { Nombres = nombre, Apellidos = apellido, Sexo = sexo, Edad = edad };
            contextdb.Add(estudiante);
            contextdb.SaveChanges();

            Console.WriteLine("Estudiante sera agregado ala base de datos.");

            Console.Write("¿Desea agregar más registros? (SI/NO): ");
            string respuesta = Console.ReadLine();
            agregarMasRegistros = respuesta.Trim().ToUpper() == "SI";
        }
    }

    Console.WriteLine("Registros en la base de datos:");
    foreach (var estudiante in contextdb.Estudiante)
    {
        Console.WriteLine($"Nombre: {estudiante.Nombres}, Apellido: {estudiante.Apellidos}, Sexo: {estudiante.Sexo}, Edad: {estudiante.Edad}");
    }
}