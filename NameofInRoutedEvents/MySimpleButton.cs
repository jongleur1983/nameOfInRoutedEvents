using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

/// <summary>
/// this file is directly taken from the example at https://msdn.microsoft.com/de-de/library/ms752288(v=vs.110).aspx
/// </summary>
namespace NameofInRoutedEvents
{
    public class MyButtonSimple : Button
    {
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent(
            nameof(Tap),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(MyButtonSimple));

        public event RoutedEventHandler Tap
        {
            add
            {
                this.AddHandler(TapEvent, value);
            }
            remove
            {
                this.RemoveHandler(TapEvent, value);
            }
        }

        void RaiseTapEvent()
        {
            var newEventArgs = new RoutedEventArgs(MyButtonSimple.TapEvent);
            this.RaiseEvent(newEventArgs);
        }

        protected override void OnClick()
        {
            this.RaiseTapEvent();
        }
    }
}
