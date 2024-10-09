using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Dohikiosk.Entity;
using Dohikiosk.UC;

namespace Dohikiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리 
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<MenuOrder> MenuOrders { get; set; }

        public ObservableCollection<MenuEntity> Menus { get; set; }
        private long _totalPrice;

        public long TotalPrice
        {
            get => _totalPrice;
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));  //해당 이벤트로 MainWindow에서 알게되서 Binding 이된다고한다.
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            MenuOrders = new ObservableCollection<MenuOrder>
            ();
            Menus = new ObservableCollection<MenuEntity>();
            SettingMenu("치킨", 21000);
            SettingMenu("피자", 15000);

            SettingMenu("감튀", 2500);
            SettingMenu("콜라", 2500);

            SettingMenu("사이다", 2500);
            SettingMenu("제로콜라", 2500);

            SettingMenu("테스트1", 2500);
            SettingMenu("제로콜라2", 2500);
            SettingMenu("제로콜라3", 2500);

            TotalPrice =0;
            DataContext = this;
        }

        private void SettingMenu(String name, long price)
        {
            //동일한 이름의 MenuOrder가 있으면 반환 없으면 null
            MenuEntity existingOrder = Menus.FirstOrDefault(order => order.Name == name);

            if (existingOrder == null)
            {
                MenuEntity newMenu = new MenuEntity
                {
                    Name = name,
                    Type = null,
                    Price = price
                };

                // 새로운 메뉴 오더를 추가
                Menus.Add(newMenu);
                //뉴오더의 경우에도 이벤트 추가 
                newMenu.PropertyChanged += Menu_PropertyChanged;
            }
            else
            {

            }
        }



        private void Delete_Order(MenuOrder menu)
        {
            Console.WriteLine(" 들어오니");
            MenuOrders.Remove(menu);
        }

        //추가하는 로직
        private void InsertOrder(String name, long price)
        {
            //동일한 이름의 MenuOrder가 있으면 반환 없으면 null
            MenuOrder existingOrder = MenuOrders.FirstOrDefault(order => order.Name == name);

            if (existingOrder != null)
            {
                // 동일한 메뉴가 존재하면 수량을 증가
                existingOrder.Order++;
            }
            else
            {
                MenuOrder newOrder = new MenuOrder
                {
                    Name = name,
                    Order = 1, // 처음 추가하므로 수량은 1
                    Price = price
                };

                // 새로운 메뉴 오더를 추가
                MenuOrders.Add(newOrder);
                //뉴오더의 경우에도 이벤트 추가 
                newOrder.PropertyChanged += MenuOrder_PropertyChanged;
                CalculateTotalPrice();//새로 추가되었으니~
            }
        }


        private void Menu_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MenuEntity.Price))
            {
                CalculateTotalPrice(); // 가격이 변경되었을경우 수정(이럴일은없겠지만..)
            }
            if (e.PropertyName == nameof(MenuEntity.Check))
            {
                var menuEntity = sender as MenuEntity;
                InsertOrder(menuEntity.Name, menuEntity.Price);
            }
        }


        private void MenuOrder_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MenuOrder.Order))
            {
                MenuOrder menu = (MenuOrders.FirstOrDefault(order => order.Order == 0));
                if (menu != null)
                {
                    Delete_Order(menu);
                }
                CalculateTotalPrice(); // 주문갯수가 변경될 때마다 총 가격 계산
            }
        }






        //총가격을 계산해주는 로직
        private void CalculateTotalPrice()
        {
            TotalPrice = MenuOrders.Sum(order => order.TotalPrice);
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
