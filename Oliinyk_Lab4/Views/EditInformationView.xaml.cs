using System.Windows.Controls;
using Oliinyk_Lab4.Models;
using Oliinyk_Lab4.Tools.Navigation;
using Oliinyk_Lab4.ViewModels;

namespace Oliinyk_Lab4.Views
{
    /// <summary>
    /// Логика взаимодействия для ShowInformationView.xaml
    /// </summary>
    public partial class EditInformationView : UserControl, INavigatable
    {
        internal EditInformationView(Person person)
        {
            InitializeComponent();
            DataContext = new EditInformationViewModel(person);
        }
    }
}