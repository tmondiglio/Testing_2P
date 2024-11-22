class Program
{
    static void Main(string[] args)
    {
        ColaPrioridad colaDePrioridad = new ColaPrioridad();

        // Insertar elementos con diferentes prioridades
        colaDePrioridad.Encolar("Tarea 1", 2); // Prioridad 2
        colaDePrioridad.Encolar("Tarea 2", 1); // Prioridad 1 (más alta)

        // Extraer elementos según su prioridad
        Console.WriteLine($"Procesado: {colaDePrioridad.Desencolar()}"); // Tarea 2

    }
}
