using System;

namespace POOFinal.Models
{
    public class LoginManager
    {
        private static LoginManager _instance;

        private Utilizador _utilizador;

        private LoginManager()
        {

        }

        public static LoginManager Instance
        {
            get
            {
                if (_instance == null) {
                    _instance = new LoginManager();
                }
                return _instance;
            }
        }

        public void AdicionarUtilizador(Utilizador utilizador)
        {
            _utilizador = utilizador;
            _utilizador.Password = "";
        }

        public Utilizador getUserLogado()
        {
            return _utilizador;
        }
    }
}

