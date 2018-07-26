using System.Windows.Input;

namespace PairMatch
{
    internal class CustomCommands
    {
        public static readonly RoutedUICommand Statistics = new RoutedUICommand
        (
            "Statistics",
            "Statistics",
            typeof(CustomCommands)
        );

        public static readonly RoutedUICommand Exit = new RoutedUICommand
        (
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            }
        );
    }
}