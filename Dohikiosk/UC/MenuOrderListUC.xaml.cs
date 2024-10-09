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
using Dohikiosk.Entity; // MenuOrder 클래스가 있는 네임스페이스 추가

namespace Dohikiosk.UC
{
    /// <summary>
    /// MenuOrderListUC.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuOrderListUC : UserControl
    {


        public static readonly DependencyProperty MenuOrderProperty =
            DependencyProperty.Register("MenuOrder", typeof(MenuOrder), typeof(MenuOrderListUC), new PropertyMetadata(null));

        public MenuOrder MenuOrder
        {
            get => (MenuOrder)GetValue(MenuOrderProperty);
            set => SetValue(MenuOrderProperty, value);
        }

        private static void OnMenuOrderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (MenuOrderListUC)d;
            control.DataContext = e.NewValue; // MenuOrder로 DataContext 설정
            // XAML에서의 바인딩은 기본적으로 이 DataContext에 설정된 속성에 접근 =>즉슨 바인딩을 e(MenuOrder)객체가 가져감
        }
        public MenuOrderListUC()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuOrder.Order--;
        }
    }
}
