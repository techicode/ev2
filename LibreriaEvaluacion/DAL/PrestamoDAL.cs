using LibreriaEvaluacion.DTO;

namespace LibreriaEvaluacion.DAL
{
    public class PrestamoDAL
    {
        public bool Insertar(PrestamoDTO datos)
        {
            return PrestamoDTO.Add(datos);
        }

        public bool Actualizar(PrestamoDTO datos, int index)
        {
            return PrestamoDTO.Edit(datos, index);
        }

        public bool Eliminar(PrestamoDTO datos)
        {
            return PrestamoDTO.RemoveById(datos);
        }

        public List<PrestamoDTO> Listar()
        {
            return PrestamoDTO.List;
        }

        public int BuscarPorIdSimple(int id)
        {
            return PrestamoDTO.Find(id);
        }

        public bool EliminarPorIndice(int indice)
        {
            return PrestamoDTO.RemoveAtIndex(indice);
        }

        public PrestamoDTO? BuscarPorId(int id)
        {
            foreach (var prestamo in PrestamoDTO.List)
            {
                if (prestamo.Id == id)
                {
                    return prestamo;
                }
            }

            return null;
        }
     }
}
