using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeiD_.ViewModel
{
    public class ExibirUsuarioViewModel : BindableObject
    {
        private string _userName;
        private string _name;
        private string _email;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public ExibirUsuarioViewModel()
        {
            UserName = App.Usuario.NomeUsuario;
            Name = App.Usuario.Nome;
            Email = App.Usuario.Email;
        }
    }
}
