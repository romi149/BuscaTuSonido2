using BE;
using MPP;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorUsuario
    {
        public static Usuario ObtenerUsuario(string user, string pass)
        {
            var respuesta = MapperUsuario.ValidarUsuario(user, pass);
            return respuesta;
        }

        public static bool Agregar(Usuario user)
        {
            return MapperUsuario.InsertarUsuario(user);
        }

        public static bool ModificarUsuario(Usuario user)
        {
            return MapperUsuario.ActualizarUsuario(user);
        }

        public static bool ModificarPass(Usuario user)
        {
            return MapperUsuario.ActualizarPass(user);
        }

        public static bool Eliminar(int IdUser)
        {
            return MapperUsuario.EliminarUsuario(IdUser);
        }

        public static DataSet Listar()
        {
            return MapperUsuario.ListarUsuarios();
        }

        public static List<Usuario> ListarUsuarios()
        {
            return MapperUsuario.ListaDeUsuarios();
        }

        public static DataSet ListarUsuariosConFiltro(string username, string dni, string status)
        {
            return MapperUsuario.ListarUsuariosFiltrados(username, dni, status);
        }

        public static DataSet ListarUsuariosFiltroTotal(string username, string dni)
        {
            return MapperUsuario.ListarUsuariosFiltroTotal(username, dni);
        }

        public static bool ConfirmacionUsuario(string user, string hashRecibido)
        {
            return MapperUsuario.ConfirmacionUsuario(user, hashRecibido);

        }

        public static string RecuperarHashUsuario(string user)
        {
            return MapperUsuario.RecuperarHashUsuario(user);

        }

        public static bool ObtenerHash(string user)
        {
            return MapperUsuario.CrearHashCliente(user);

        }

        public static bool ConfirmacionCambioPassword(string user, string hashRecibido, string pass)
        {
            return MapperUsuario.ConfirmacionCambioPass(user, hashRecibido, pass);

        }

        public static DataSet ListarUsuarioRol()
        {
            return MapperUsuario.ListarUsuariosRol();
        }

        public static bool EliminarUsuarioRol(int IdUser, int IdRol)
        {
            return MapperUsuario.EliminarUsuarioRol(IdUser, IdRol);
        }

        public static bool AgregarUsuarioRol(int IdUsuario, int IdRol)
        {
            return MapperUsuario.InsertarUsuarioRol(IdUsuario, IdRol);
        }

        public static int ObtenerRolUsuario(string Usuario)
        {
            return MapperUsuario.ObtenerRolUsuario(Usuario);
        }

        public static List<Permiso> VerificarAcceso(int IdRol, string pagina)
        {
            return MapperUsuario.VerificarAccesoUser(IdRol, pagina);
        }

    }
}
