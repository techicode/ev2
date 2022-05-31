using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEvaluacion.DTO
{
    public class PrestamoDTO
    {
        private int id;
        private int monto;

        private static List<PrestamoDTO> prestamos = new List<PrestamoDTO>()
        {
            new PrestamoDTO() { id = 1, monto = 150000 },
            new PrestamoDTO() { id = 2, monto = 540000 },
            new PrestamoDTO() { id = 3, monto = 380000 },
        };

        public PrestamoDTO()
        {
        }

        public PrestamoDTO(int id, int monto)
        {
            this.id = id;
            this.monto = monto;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Monto
        {
            get => monto;
            set => monto = value;
        }

        public int MontoMasInteres
        {
            get => Convert.ToInt32((monto * 1.1));
        }

        public int MontoAtraso
        {
            get => Convert.ToInt32((MontoMasInteres * 1.15));
        }

        public static bool Add(PrestamoDTO datos)
        {
            if (Find(datos) != null)
            {
                return false;
            }
            {
                
            }
            try
            {
                prestamos.Add(datos);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public static List<PrestamoDTO> List => prestamos;
        
        public static int Find (int id) {
            for (int i = 0; i < prestamos.Count; i++)
            {
                if (prestamos[i].id == id) return i;
            }

            return -1;
        }

        public static PrestamoDTO Find(PrestamoDTO datos)
        {
            for (int i = 0; i < prestamos.Count; i++)
            {
                if (prestamos[i].id == datos.id) return prestamos[i];
            }

            return null;
        }

        public static bool Edit(PrestamoDTO datos, int index)
        {
            try
            {
                prestamos[index] = datos;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }   
        }

        public static bool RemoveAtIndex(int index)
        {
            try
            {
                prestamos.RemoveAt(index);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool RemoveById(PrestamoDTO datos)
        {
            try
            {
                int index = Find(datos.id);
                prestamos.RemoveAt(index);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"ID: {id} -- Monto {monto} || Monto más interés: {MontoMasInteres} || Monto con atraso: {MontoAtraso}";
        }
    }
}
