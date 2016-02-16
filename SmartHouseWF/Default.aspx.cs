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
              //  devicesDictionary.Add(1, new Fringe("TEST", -20, 5));

                Session["Devices"] = devicesDictionary;
                Session["NextId"] = 1;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)           
            {                
                addDeviceButton.Click += AddDeviceButtonClick;
            }
            DeviceName.CssClass = "mac";
            addDeviceButton.CssClass = "mac";
            dropDownDevicesList.CssClass = "mac";
            InitialiseDevicesPanel();
        }

        // Создание элементов графики для всех устройств в коллекции
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
            int count = 0; 
            var res =
                     from t in devicesDictionary
                     where t.Value.name == DeviceName.Text
                     select t.Value;
            foreach (var source in res)
            {
                count++;
            }
            if (count == 0)
            {
                Device newDevice;
                switch (dropDownDevicesList.SelectedIndex)
                {
                    default:
                        newDevice = new Fringe(DeviceName.Text, -20, 5);
                        Device lamp = new Device("FringeLamp");
                        ((Fringe)newDevice).Lamp = lamp;
                        break;
                    case 1:
                        newDevice = new TVSet(DeviceName.Text, 0, 100);
                        break;
                    case 2:
                        newDevice = new MicroWave(DeviceName.Text, 50, 250);
                        ((MicroWave)newDevice).highTemperature(100);
                        break;
                    case 3:
                        newDevice = new Oven(DeviceName.Text, 50, 300);
                        ((Oven)newDevice).highTemperature(100);
                        break;
                    case 4:
                        newDevice = new Satellite(DeviceName.Text);                        
                        foreach (Control parent in DevicePanel.Controls)
                        {
                            foreach (Control chield in parent.Controls)
                            {
                                if (chield is DropDownList && chield.ID == "source")
                                {
                                    ((DropDownList)chield).Items.Add(DeviceName.Text);
                                }
                            }
                        }
                        break;
                    case 5:
                        newDevice = new GameBox(DeviceName.Text);
                        foreach (Control parent in DevicePanel.Controls)
                        {
                            foreach (Control chield in parent.Controls)
                            {
                                if (chield is DropDownList && chield.ID == "source")
                                {
                                    ((DropDownList)chield).Items.Add(DeviceName.Text);
                                }
                            }
                        }
                        break;
                }

                int id = (int)Session["NextId"];
                devicesDictionary.Add(id, newDevice);
                ErrText.Text = "";
                DevicePanel.Controls.Add(new DeviceControl(id, devicesDictionary));
                id++;
                Session["NextId"] = id;               
            }
            else
            {
                ErrText.Text = "Устройство с такими именем уже сущесвует";
            }
        }
    }    
}