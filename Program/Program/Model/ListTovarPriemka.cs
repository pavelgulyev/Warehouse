using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой_проект.Model
{
    class ListTovarPriemka : ObservableCollection<Товар>
    {
        public ListTovarPriemka()
        {
            PriemkaPage.DataEntitiesPriemka = new SkladEntities();
            
            var query = from Товар in PriemkaPage.DataEntitiesPriemka.Товар                        
                        select Товар;
            foreach (Товар priemki in query)
            {                
                this.Add(priemki);
            }
        }
    }
}
