using System.Windows.Controls;
using Oliinyk_Lab4.Tools.Navigation;
using Oliinyk_Lab4.ViewModels;

namespace Oliinyk_Lab4.Views
{
    /// <summary>
    /// Логика взаимодействия для EnterData.xaml
    /// </summary>
    public partial class EnterDataView : UserControl, INavigatable
    {
        public EnterDataView()
        {
            InitializeComponent();
            DataContext = new EnterDataViewModel();
        }
    }
}