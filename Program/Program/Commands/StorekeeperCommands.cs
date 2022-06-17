using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Курсовой_проект.Commands
{
    class StorekeeperCommands
    {
        public static RoutedCommand Priemka { get; set; }
        public static RoutedCommand Shipment { get; set; }
        static StorekeeperCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.P, ModifierKeys.Control, "Ctrl+E"));
            Priemka = new RoutedCommand("Priemka", typeof(StorekeeperCommands), inputs);
            inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.O, ModifierKeys.Control, "Ctrl+D"));
            Shipment = new RoutedCommand("Shipment", typeof(StorekeeperCommands), inputs);
        }
    }
}
