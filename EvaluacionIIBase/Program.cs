using LibreriaEvaluacion.DAL;
using LibreriaEvaluacion.DTO;

const string nombreAlumno = "Luis Sáez";

while (Menu(nombreAlumno))
{
    Console.ReadKey(); // pausa, solicitar la entrada de una tecla
}


static bool Menu(string nombreAlumno)
{ 
    bool continuar = true;

    Console.Clear(); // Limpia la pantalla
    Console.Title = $"Evaluación II: {nombreAlumno}";

    Console.WriteLine("Menú de opciones");
    Console.WriteLine("================");
    Console.WriteLine("1) Listar préstamos");
    Console.WriteLine("2) Agregar préstamo");
    Console.WriteLine("3) Actualizar préstamo");
    Console.WriteLine("4) Eliminar préstamo");
    Console.WriteLine("");
    Console.WriteLine("0) Salir");

    string opcion = Console.ReadLine().Trim(); // " 1 " => "1"

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Listado de préstamos registrados");    
            OpcionListar();
            break;
        case "2":
            Console.WriteLine("Insertar un nuevo préstamo");
            OpcionAgregar();
            break;
        case "3":
            Console.WriteLine("Actualizar un préstamo existente");
            OpcionActualizar();
            break;
        case "4":
            Console.WriteLine("Eliminar un préstamo existente");
            OpcionEliminar();
            break;
        case "0":
            Console.WriteLine("Saliendo del programa ...");
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

    return continuar;
}

static void OpcionListar()
{
    PrestamoDAL dal = new PrestamoDAL();
    List<PrestamoDTO> lista = dal.Listar();
    
    Console.WriteLine("Listar...");
    foreach (PrestamoDTO prestamo in lista)
    {
        Console.WriteLine(prestamo.ToString());
    }
}

static void OpcionAgregar()
{
    PrestamoDAL dal = new PrestamoDAL();
    try
    {
        Console.Write("Ingrese el ID del prestamo: ");
        int id = int.Parse(Console.ReadLine().Trim());
        Console.Write("Ingrese el monto del prestamo: ");
        int monto = int.Parse(Console.ReadLine().Trim());

        if (monto < 50000)
        {
            Console.Write("Se debe ingresar un monto no inferior a los CLP$50.000 ");
            return;
        }

        bool resultado = dal.Insertar(new PrestamoDTO(id, monto));

        if (resultado) Console.WriteLine($"Se ha ingresado correctamente el prestamo con ID: {id}");
        else Console.WriteLine($"El id: {id} ya existe.");
    }
    catch (Exception e)
    {
        Console.WriteLine("Error al ingresar los datos solicitados");
    }
}

static void OpcionEliminar()
{
    PrestamoDAL dal = new PrestamoDAL();
    try
    {
        Console.Write("Ingrese el ID del prestamo a eliminar: ");
        int id = int.Parse(Console.ReadLine().Trim());
        bool resultado = dal.Eliminar(dal.BuscarPorId(id));
        if (resultado) Console.WriteLine($"Se eliminó correctamente el prestado con id {id}");
        else Console.WriteLine($"El ID {id} no existe");
    }
    catch (Exception e)
    {
        Console.WriteLine("Error al ingresar los datos solicitados");
    }
}

static void OpcionActualizar()
{
    PrestamoDAL dal = new PrestamoDAL();
    try
    {
        Console.Write("Ingrese el ID del prestamo a actualizar: ");
        int id = int.Parse(Console.ReadLine().Trim());
        PrestamoDTO busquedaPrestamo = dal.BuscarPorId(id);
        if (busquedaPrestamo != null)
        {
            Console.WriteLine($"Va a proceder a editar los datos del prestamo {busquedaPrestamo.ToString()}");
            Console.WriteLine("Desea actualizar el id? s/n");
            string inputUser = (Console.ReadLine().Trim());
            int nuevaID = 0;
            int nuevoMonto = 0;
            
            if (inputUser.ToUpperInvariant() == "S")
            {
                Console.WriteLine("Ingrese la nueva id");
                 nuevaID= int.Parse(Console.ReadLine().Trim());
            }
            else
            {
                nuevaID = busquedaPrestamo.Id;
            }
            Console.WriteLine("Desea actualizar el monto? s/n");
            inputUser = (Console.ReadLine().Trim());
            if (inputUser.ToUpperInvariant() == "S")
            {
                Console.WriteLine("Ingrese el nuevo monto");
                nuevoMonto = int.Parse(Console.ReadLine().Trim());
            }
            else
            {
                nuevoMonto = busquedaPrestamo.Monto;
            }

            PrestamoDTO prestamoActualizado = new PrestamoDTO(id : nuevaID, monto: nuevoMonto);

            bool resultado = dal.Actualizar(prestamoActualizado, dal.BuscarPorIdSimple(id));
            if (resultado) Console.WriteLine("Se ha actualizado correctamente");
            else Console.WriteLine("Error al actualizar");
        }
        else
        {
            Console.WriteLine($"El ID {id} ingresado no existe.");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error al ingresar los datos solicitados");
    }
}