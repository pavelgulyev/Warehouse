using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой_проект.Model
{
    class ListSkladov : ObservableCollection<Склад>
    {
        public ListSkladov()
        {
            SkladEntities DataEntitiesPriemka = new SkladEntities();
            DbSet<Склад> kontr = DataEntitiesPriemka.Склад;
            var query = from Склад in kontr select Склад;
            foreach (Склад priemki in query)
            {                
                this.Add(priemki);
            }
        }
    }
}
