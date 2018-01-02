using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAPP
{


    class Program
    {
        interface IPhoneBuilder
        {
            void BuildScreen();
            void BuildBattery();
            MobilePhone Phone { get; }
        }

        class Manufacturer
        {
            public void Construct(IPhoneBuilder phoneBuilder)
            {
                phoneBuilder.BuildBattery();
                phoneBuilder.BuildScreen();
            }
        }

        class WindowsPhoneBuilder : IPhoneBuilder
        {
            MobilePhone phone;

            public WindowsPhoneBuilder()
            {
                phone = new MobilePhone("Windows");
            }
            public MobilePhone Phone
            {
                get
                {
                    return phone;
                }
            }

            public void BuildBattery()
            {
                phone.PhoneBaterry = BatteryType.BatteryType_2;
            }

            public void BuildScreen()
            {
                phone.PhoneScreen = ScreenType.ScreenType_2;
            }
        }

        class AndroidPhoneBuilder : IPhoneBuilder
        {
            MobilePhone phone;
            public AndroidPhoneBuilder()
            {
                phone = new MobilePhone("Android");
            }
            public MobilePhone Phone
            {
                get
                {
                    return phone;
                }
            }

            public void BuildBattery()
            {
                phone.batteryType = BatteryType.BatteryType_1;
            }

            public void BuildScreen()
            {
                phone.PhoneScreen = ScreenType.ScreenType_1;
            }
        }
        static void Main(string[] args)
        {
            Manufacturer newManufacturer = new Manufacturer();
            IPhoneBuilder phoneBuilder, phoneBuilder2 = null;
            phoneBuilder = new AndroidPhoneBuilder();
            phoneBuilder2 = new WindowsPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            newManufacturer.Construct(phoneBuilder2);
            Console.WriteLine("A new Phone built:\n\n{0}", phoneBuilder.Phone.ToString());
            Console.WriteLine("A new Phone built:\n\n{0}", phoneBuilder2.Phone.ToString());

        }
    }

    public enum ScreenType
    {
        ScreenType_1,
        ScreenType_2,
        ScreenType_3
    }
    public enum BatteryType
    {
        BatteryType_1,
        BatteryType_2,
        BatteryType_3
    }
    class MobilePhone
    {
        string phoneName;
        public ScreenType product;
        public BatteryType batteryType;
        public MobilePhone(string name)
        {
            phoneName = name;
        }

        public string GetPhoneName
        {
            get { return phoneName; }
        }


        public ScreenType PhoneScreen { get; set; }

        public BatteryType PhoneBaterry { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", GetPhoneName, PhoneScreen, PhoneBaterry);
        }

    }


}
