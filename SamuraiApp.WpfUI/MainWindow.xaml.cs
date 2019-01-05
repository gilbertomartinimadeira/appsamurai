using Autofac;
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

namespace SamuraiApp.WpfUI
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            var builder = new ContainerBuilder();          
            builder.RegisterType<SamuraiRepository>().As<ISamuraiRepository>();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource samuraiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("samuraiViewSource")));
            // Carregar dados ao definir a propriedade CollectionViewSource.Source:
            // samuraiViewSource.Source = [fonte de dados genérica]
        }
    }
}
