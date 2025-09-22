using System.Runtime.InteropServices.JavaScript;

namespace RiwiMusic;

public class ticket
{
    public int Id {get; set;}
    public int IdCliente {get; set;}
    public int CantidadTickets  {get; set;}
    public DateTime FechaCompra {get; set;}
    public double CostoTotal {get; set;}
}