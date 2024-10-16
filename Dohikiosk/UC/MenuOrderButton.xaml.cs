using Dohikiosk.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Dohikiosk.UC
{
    /// <summary>
    /// MenuOrderButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuOrderButton : UserControl
    {

        public static readonly DependencyProperty MenuProperty =
            DependencyProperty.Register("MenuEntity", typeof(MenuEntity), typeof(MenuOrderButton), new PropertyMetadata(null));


        public MenuEntity MenuEntity
        {
            get => (MenuEntity)GetValue(MenuProperty);
            set => SetValue(MenuProperty, value);
        }


        // MenuEntity가 변경될 때 호출되는 메서드
        private static void OnMenuChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (MenuOrderButton)d;
            control.DataContext = e.NewValue; // MenuEntity로 DataContext 설정
        }

        public MenuOrderButton()
        {
            InitializeComponent();
        }
   

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MenuEntity.Check = !MenuEntity.Check;
        }
    }
}
