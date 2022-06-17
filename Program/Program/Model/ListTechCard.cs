using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой_проект.Model
{
    class ListTechCard : ObservableCollection<Техкарта>
    {
        public ListTechCard()
        {
            PriemkaPage.DataEntitiesPriemka = new SkladEntities();            
            var query = from contr in PriemkaPage.DataEntitiesPriemka.Техкарта select contr;
            foreach (Техкарта kon in query)
            {
                this.Add(kon);
            }
            
        }
    }
}
