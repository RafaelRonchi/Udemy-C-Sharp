using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin
{
    static class CadastroUsuarios
    {
        private static Usuario[] usuarios = 
        { 
            new Usuario(){ Nome = "Rafael", Senha="123"},
            new Usuario(){ Nome = "admin", Senha= "admin"}
        };

        private static Usuario _userLogado = null;

        public static Usuario UsuarioLogado
        {
            get { return _userLogado; } 
            private set { _userLogado = value; }
        }

        public static bool Login(string nome, string senha)
        {
            foreach (Usuario u in usuarios)
            {
                if(u.Nome == nome && u.Senha == senha)
                {
                    UsuarioLogado = u;
                    return true;
                }
            }
            return false;
        }
    }
}
