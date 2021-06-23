using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante_siglo_XI.DALC;

namespace Restaurante_siglo_XI
{
    public class Menu
    {
        public int id_menu { get; set; }
        public String nombre_menu { get; set; }
        public String descripcion_menu { get; set; }

        RestauranteEntities db = new RestauranteEntities();



        public List<Menu> leer_todo() 
        {
            return this.db.MENU.Select( m => new Menu() 
            {
                id_menu = (int)m.ID_MENU,
                nombre_menu = m.NOMBRE_MENU,
                descripcion_menu = m.DESCRIPCION_MENU
            }).ToList();
        }


        public Menu buscar(int id) 
        {
            return this.db.MENU.Select(m => new Menu()
            {
                id_menu = (int)m.ID_MENU,
                nombre_menu = m.NOMBRE_MENU,
                descripcion_menu = m.DESCRIPCION_MENU
            }).Where(m=> m.id_menu ==id).FirstOrDefault();
        }


        public bool guardarMenu() 
        {
            try
            {
                var menus = new MENU 
                {
                    NOMBRE_MENU = nombre_menu,
                    DESCRIPCION_MENU = descripcion_menu
                };
                db.MENU.Add(menus);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
