using RiwiMusic;

public class Program
{
    // Listas en memoria
    private static List<conciertos> listaConciertos = new List<conciertos>();
    private static List<cliente> listaClientes = new List<cliente>();
    private static List<ticket> listaTickets = new List<ticket>();
    private static int idConcierto = 1;
    private static int idCliente = 1;
    private static int idTicket = 1;

    public static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a Riwi Music.");
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== Menú principal ===");
            Console.WriteLine("1. Gestión de Conciertos");
            Console.WriteLine("2. Gestión de Clientes");
            Console.WriteLine("3. Gestión de Tiquetes");
            Console.WriteLine("4. Historial de Compras");
            Console.WriteLine("5. Consultas Avanzadas (LINQ)");
            Console.WriteLine("6. Salir del programa");
            Console.Write("Seleccione una opción: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: GestionConciertos(); break;
                case 2: GestionClientes(); break;
                case 3: GestionTiquetes(); break;
                case 4: MostrarHistorial(); break;
                case 5: ConsultasLinq(); break;
                case 6: 
                    Console.WriteLine("Saliendo del programa...");
                    salir = true; 
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }

    // --- GESTIÓN DE CONCIERTOS ---
    private static void GestionConciertos()
    {
        Console.Clear();
        Console.WriteLine("=== Gestión de Conciertos ===");
        Console.WriteLine("1. Registrar concierto");
        Console.WriteLine("2. Listar conciertos");
        Console.WriteLine("3. Editar concierto");
        Console.WriteLine("4. Eliminar concierto");
        Console.Write("Seleccione una opción: ");
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                conciertos c = new conciertos();
                c.Id = idConcierto++;
                Console.Write("Nombre: "); c.Nombre = Console.ReadLine();
                Console.Write("Fecha (yyyy-mm-dd): "); c.Fecha = DateTime.Parse(Console.ReadLine());
                Console.Write("Ciudad: "); c.Ciudad = Console.ReadLine();
                Console.Write("Capacidad Máxima: "); c.CapacidadMaxima = double.Parse(Console.ReadLine());
                Console.Write("Costo Tiquete: "); c.CostoTiquete = double.Parse(Console.ReadLine());
                listaConciertos.Add(c);
                Console.WriteLine("Concierto registrado correctamente.");
                break;

            case 2:
                Console.WriteLine("\nLista de conciertos:");
                foreach (var concierto in listaConciertos)
                    Console.WriteLine($"{concierto.Id} - {concierto.Nombre} - {concierto.Ciudad} - {concierto.Fecha.ToShortDateString()} - ${concierto.CostoTiquete}");
                break;

            case 3:
                Console.Write("Ingrese el Id del concierto a editar: ");
                int idEditar = int.Parse(Console.ReadLine());
                var conciertoEditar = listaConciertos.FirstOrDefault(c => c.Id == idEditar);
                if (conciertoEditar != null)
                {
                    Console.Write("Nuevo nombre: "); conciertoEditar.Nombre = Console.ReadLine();
                    Console.Write("Nueva fecha (yyyy-mm-dd): "); conciertoEditar.Fecha = DateTime.Parse(Console.ReadLine());
                    Console.Write("Nueva ciudad: "); conciertoEditar.Ciudad = Console.ReadLine();
                    Console.Write("Nueva capacidad: "); conciertoEditar.CapacidadMaxima = double.Parse(Console.ReadLine());
                    Console.Write("Nuevo costo tiquete: "); conciertoEditar.CostoTiquete = double.Parse(Console.ReadLine());
                    Console.WriteLine("Concierto editado correctamente.");
                }
                else Console.WriteLine("Concierto no encontrado.");
                break;

            case 4:
                Console.Write("Ingrese el Id del concierto a eliminar: ");
                int idEliminar = int.Parse(Console.ReadLine());
                var conciertoEliminar = listaConciertos.FirstOrDefault(c => c.Id == idEliminar);
                if (conciertoEliminar != null)
                {
                    listaConciertos.Remove(conciertoEliminar);
                    Console.WriteLine("Concierto eliminado correctamente.");
                }
                else Console.WriteLine("Concierto no encontrado.");
                break;
        }
    }

    // --- GESTIÓN DE CLIENTES ---
    private static void GestionClientes()
    {
        Console.Clear();
        Console.WriteLine("=== Gestión de Clientes ===");
        Console.WriteLine("1. Registrar cliente");
        Console.WriteLine("2. Listar clientes");
        Console.WriteLine("3. Editar cliente");
        Console.WriteLine("4. Eliminar cliente");
        Console.Write("Seleccione una opción: ");
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                cliente cl = new cliente();
                cl.Id = idCliente++;
                Console.Write("Nombre: "); cl.Nombre = Console.ReadLine();
                Console.Write("Email: "); cl.Email = Console.ReadLine();
                listaClientes.Add(cl);
                Console.WriteLine("Cliente registrado correctamente.");
                break;

            case 2:
                Console.WriteLine("\nLista de clientes:");
                foreach (var c in listaClientes)
                    Console.WriteLine($"{c.Id} - {c.Nombre} - {c.Email}");
                break;

            case 3:
                Console.Write("Ingrese el Id del cliente a editar: ");
                int idEditar = int.Parse(Console.ReadLine());
                var clienteEditar = listaClientes.FirstOrDefault(c => c.Id == idEditar);
                if (clienteEditar != null)
                {
                    Console.Write("Nuevo nombre: "); clienteEditar.Nombre = Console.ReadLine();
                    Console.Write("Nuevo email: "); clienteEditar.Email = Console.ReadLine();
                    Console.WriteLine("Cliente editado correctamente.");
                }
                else Console.WriteLine("Cliente no encontrado.");
                break;

            case 4:
                Console.Write("Ingrese el Id del cliente a eliminar: ");
                int idEliminar = int.Parse(Console.ReadLine());
                var clienteEliminar = listaClientes.FirstOrDefault(c => c.Id == idEliminar);
                if (clienteEliminar != null)
                {
                    listaClientes.Remove(clienteEliminar);
                    Console.WriteLine("Cliente eliminado correctamente.");
                }
                else Console.WriteLine("Cliente no encontrado.");
                break;
        }
    }

    // --- GESTIÓN DE TIQUETES ---
    private static void GestionTiquetes()
    {
        Console.Clear();
        Console.WriteLine("=== Gestión de Tiquetes ===");
        Console.WriteLine("1. Registrar compra");
        Console.WriteLine("2. Listar tiquetes");
        Console.WriteLine("3. Editar compra");
        Console.WriteLine("4. Eliminar compra");
        Console.Write("Seleccione una opción: ");
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                ticket t = new ticket();
                t.Id = idTicket++;
                Console.Write("Id Cliente: "); t.IdCliente = int.Parse(Console.ReadLine());
                Console.Write("Cantidad de tickets: "); t.CantidadTickets = int.Parse(Console.ReadLine());
                t.FechaCompra = DateTime.Now;
                listaTickets.Add(t);
                Console.WriteLine("Compra registrada correctamente.");
                break;

            case 2:
                Console.WriteLine("\nLista de tiquetes:");
                foreach (var tiq in listaTickets)
                    Console.WriteLine($"ID: {tiq.Id}, Cliente: {tiq.IdCliente}, Cantidad: {tiq.CantidadTickets}, Fecha: {tiq.FechaCompra}");
                break;

            case 3:
                Console.Write("Ingrese el Id del tiquete a editar: ");
                int idEditar = int.Parse(Console.ReadLine());
                var ticketEditar = listaTickets.FirstOrDefault(t => t.Id == idEditar);
                if (ticketEditar != null)
                {
                    Console.Write("Nueva cantidad: "); ticketEditar.CantidadTickets = int.Parse(Console.ReadLine());
                    Console.WriteLine("Compra editada correctamente.");
                }
                else Console.WriteLine("Tiquete no encontrado.");
                break;

            case 4:
                Console.Write("Ingrese el Id del tiquete a eliminar: ");
                int idEliminar = int.Parse(Console.ReadLine());
                var ticketEliminar = listaTickets.FirstOrDefault(t => t.Id == idEliminar);
                if (ticketEliminar != null)
                {
                    listaTickets.Remove(ticketEliminar);
                    Console.WriteLine("Tiquete eliminado correctamente.");
                }
                else Console.WriteLine("Tiquete no encontrado.");
                break;
        }
    }

    // --- HISTORIAL DE COMPRAS ---
    private static void MostrarHistorial()
    {
        Console.Clear();
        Console.WriteLine("=== Historial de Compras ===");
        if (listaTickets.Count == 0)
        {
            Console.WriteLine("No hay compras registradas.");
            return;
        }

        foreach (var t in listaTickets)
        {
            var cliente = listaClientes.FirstOrDefault(c => c.Id == t.IdCliente);
            string nombreCliente = cliente != null ? cliente.Nombre : "Desconocido";
            Console.WriteLine($"Compra #{t.Id}: Cliente: {nombreCliente}, Cantidad: {t.CantidadTickets}, Fecha: {t.FechaCompra}");
        }
    }

    // --- CONSULTAS AVANZADAS (LINQ) ---
    private static void ConsultasLinq()
    {
        Console.Clear();
        Console.WriteLine("=== Consultas Avanzadas (LINQ) ===");
        // Ejemplo: mostrar clientes con más de 1 compra
        var clientesConMultiplesCompras = listaTickets
            .GroupBy(t => t.IdCliente)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);

        Console.WriteLine("Clientes con más de 1 compra:");
        foreach (var id in clientesConMultiplesCompras)
        {
            var cliente = listaClientes.FirstOrDefault(c => c.Id == id);
            Console.WriteLine(cliente != null ? cliente.Nombre : $"Cliente {id}");
        }
    }
}
