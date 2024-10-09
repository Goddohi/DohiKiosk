using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dohikiosk.Entity
{
    public class MenuOrder : INotifyPropertyChanged
    {
        private string _name;
        private long _order;
        private long _price;

        private long _totalprice;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public long Order
        {
            get => _order;
            set
            {
                if (_order != value)
                {
                    _order = value; //
                    OnPropertyChanged(nameof(Order)); // 오더의 갯수 변경 통지
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public long Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price)); // 가격 변동이 될일이 있을까
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public long TotalPrice => Price * Order; // 총 가격 계산
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) //매개변수로 변경된 속성의 이름(propertyName)을 받아, 어떤 속성이 변경암
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //PropertyChanged가 null이 아닐때 = (구독자가 있는 경우) Invoke 메서드를 사용하여 이벤트를 발생
        }
    }
}

