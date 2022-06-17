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
    class ListCounterparty : ObservableCollection<Контрагент>
    {
        public ListCounterparty()
        {
            PriemkaPage.DataEntitiesPriemka = new SkladEntities();            
            var query = from contr in PriemkaPage.DataEntitiesPriemka.Контрагент select contr;
            foreach (Контрагент kon in query)
            {
                this.Add(kon);
            }
            
        }
    }
}
