using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace garipov_glazki
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();

            var currentServices = Garipov_glazkiEntities.GetContext().Agent.ToList();

            ServiceListView.ItemsSource = currentServices;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());

        }

        private void TBSearch_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateAgents();

        }

        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void FilterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();

        }


        private void UpdateAgents()
        {
            var currentAgents = Garipov_glazkiEntities.GetContext().Agent.ToList();

            currentAgents = currentAgents.Where(p => p.Title.ToLower().Contains(TBSearch.Text.ToLower()) || p.Phone.Replace("+7", "8").Replace("(", "").Replace(") ", "").Replace(" ", "").Replace("-", "").Contains(TBSearch.Text.Replace("+7", "8").Replace("(", "").Replace(") ", "").Replace(" ", "").Replace("-", ""))
            || p.Email.ToLower().Contains(TBSearch.Text.ToLower())).ToList();



            

            if (SortCombo.SelectedIndex==0)
                currentAgents = currentAgents.OrderBy(p => p.Title).ToList();
            if (SortCombo.SelectedIndex == 1)
                currentAgents = currentAgents.OrderByDescending(p =>p.Title).ToList();
            if (SortCombo.SelectedIndex == 2)
                currentAgents = currentAgents.OrderBy(p => p.Title).ToList();
            if (SortCombo.SelectedIndex == 3)
                currentAgents = currentAgents.OrderByDescending(p => Title).ToList();
            if (SortCombo.SelectedIndex == 4)
                currentAgents = currentAgents.OrderBy(p => p.Priority).ToList();
            if (SortCombo.SelectedIndex == 5)
                currentAgents = currentAgents.OrderByDescending(p => p.Priority).ToList();


            if (FilterCombo.SelectedIndex == 0)
                currentAgents = currentAgents.Where(p => (p.AgentTypeID >= 1 && p.AgentTypeID <= 6)).ToList();
            if (FilterCombo.SelectedIndex == 1)
                currentAgents = currentAgents.Where(p => (p.AgentTypeID==1)).ToList();
            if (FilterCombo.SelectedIndex == 2)
                currentAgents = currentAgents.Where(p => (p.AgentTypeID == 2)).ToList();
            if (FilterCombo.SelectedIndex == 3)
                currentAgents = currentAgents.Where(p => (p.AgentTypeID == 3)).ToList();
            if (FilterCombo.SelectedIndex == 4)
                currentAgents = currentAgents.Where(p => (p.AgentTypeID == 4)).ToList();
            if (FilterCombo.SelectedIndex == 5)
                currentAgents = currentAgents.Where(p => (p.AgentTypeID == 5)).ToList();
            if (FilterCombo.SelectedIndex == 6)
                currentAgents = currentAgents.Where(p => (p.AgentTypeID == 6)).ToList();





            ServiceListView.ItemsSource = currentAgents;









        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();

        }

        private void ServiceListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();

        }
    }
}
