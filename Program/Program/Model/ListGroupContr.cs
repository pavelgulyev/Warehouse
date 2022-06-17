using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой_проект.Model
{
    class ListGroupContr : ObservableCollection<Группа_контрагентов>
    {
        public ListGroupContr()
        {
            PriemkaPage.DataEntitiesPriemka = new SkladEntities();
            
            var query = from Товар in PriemkaPage.DataEntitiesPriemka.Группа_контрагентов                        
                        select Товар;
            foreach (Группа_контрагентов priemki in query)
            {                
                this.Add(priemki);
            }
        }
    }
}
