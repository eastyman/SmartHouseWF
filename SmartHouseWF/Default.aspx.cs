using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoolHouse;
using SmartHouseWF.Controls;

namespace SmartHouseWF
{
    public partial class Default : System.Web.UI.Page
    {
        // Коллекция устройств
        private IDictionary<int, Device> devicesDictionary;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            }
            else
            {
                devicesDictionary = new SortedDictionary<int, Device>();
                devicesDictionary.Add(1, new Fringe("TEST", -20, 5));

                Session["Devices"] = devicesDictionary;
                Session["NextId"] = 2;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)           
            {                
                addDeviceButton.Click += AddDeviceButtonClick;
            }
            InitialiseDevicesPanel();
        }

        // Создание элементов графики для всех фигур в коллекции
        protected void InitialiseDevicesPanel()
        {
            foreach (int key in devicesDictionary.Keys)
            {
                DevicePanel.Controls.Add(new DeviceControl(key, devicesDictionary));
            }
        }

        // Обработчик нажатия кнопки добавления Устройств
        protected void AddDeviceButtonClick(object sender, EventArgs e)
        {
            Device newDevice;
            switch (dropDownDevicesList.SelectedIndex)
            {
                default:
                    newDevice = new Fringe(DeviceName.Text, -20, 5);
                    break;
                case 1:
                    newDevice = new TVSet(DeviceName.Text, 0, 100);
                    break;
                case 2:
                    newDevice = new MicroWave(DeviceName.Text, 50, 250);
                    break;
                case 3:
                    newDevice = new Oven(DeviceName.Text, 50, 300);
                    break;
            }

            int id = (int)Session["NextId"];
            devicesDictionary.Add(id, newDevice);
            DevicePanel.Controls.Add(new DeviceControl(id, devicesDictionary));
            id++;
            Session["NextId"] = id;
        }
    }    
}