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

        public bool eliminarMenu(int id) 
        {
            try
            {
                var me = db.MENU.SingleOrDefault(x=> x.ID_MENU == id);
                db.MENU.Remove(me);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool guardarMenu() 
        {
            try
            {
                db.SP_CREATE_MENU(this.nombre_menu, this.descripcion_menu);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool ModificarMenu()
        {
            try
            {
                db.SP_UPDATE_MENU(this.id_menu,this.nombre_menu, this.descripcion_menu);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
