using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ViajeiD_.Model;

namespace ViajeiD_.ViewModel
{
    public class FeedViewModel : INotifyPropertyChanged
    {
        private List<PostagemPub> _postagens;

        public List<PostagemPub> Postagens
        {
            get { return _postagens; }
            set
            {
                if (_postagens != value)
                {
                    _postagens = value;
                    OnPropertyChanged(nameof(Postagens));
                }
            }
        }

        public FeedViewModel()
        {
            // Inicializa a lista de postagens
            Postagens = new List<PostagemPub>();
        }

        // Método para definir as postagens no ViewModel
        public void SetPostagens(List<PostagemPub> postagens)
        {
            Postagens = postagens.OrderByDescending(p => p.Data).ToList();
        }

        // Implementação da interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyPostagensChanged()
        {
            OnPropertyChanged(nameof(Postagens));
        }

    }
}
