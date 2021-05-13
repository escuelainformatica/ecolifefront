using ClassLibrary1.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.repo
{
    public class UsuarioRepo
    {
        public static bool Validar(Usuario usr)
        {
            using(var contexto=new Model1())
            {
                var usuarioBase=contexto.Usuario.Find(usr.Cuenta);
                if(usuarioBase!=null && usuarioBase.Clave==usr.Clave)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
