using System.Runtime.Serialization;
using MVVMSidekick.ViewModels;
using SLWeek.Models;

namespace SLWeek.ViewModels
{

    [DataContract]
    public class AuthorPage_Model : ViewModelBase<AuthorPage_Model>
    {
        public AuthorPage_Model()
        {
                
        }
        public Author VM { get; set; }
        public AuthorPage_Model(Author author)
        {
            VM = author;
        }

    }

}

