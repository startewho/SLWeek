using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
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
            this.VM = author;
        }

    }

}

