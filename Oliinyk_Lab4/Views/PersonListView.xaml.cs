using Oliinyk_Lab4.Tools.Navigation;
using Oliinyk_Lab4.ViewModel;
using System.Windows.Controls;

namespace Oliinyk_Lab4.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonListView.xaml
    /// </summary>
    public partial class PersonListView : UserControl, INavigatable
    {
        public PersonListView()
        {
            InitializeComponent();
            DataContext = new PersonListViewModel();
 
        }
    }
}
