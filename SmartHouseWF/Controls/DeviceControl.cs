using CoolHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHouseWF.Controls
{
    public class DeviceControl:Panel
    {
        private int id;        
        private IDictionary<int, Device> devicesDictionary; // Коллекция фигур
        private Label infoLabel; // Ярлык для отображения информации
        private Button onButton; // Кнопка для включения
        private Button offButton; // Кнопка для выключения
        private Button openButton; // Кнопка для открытия
        private Button closeButton; // Кнопка для закрытия
        private Button nextButton; // Кнопка для следующего канала
        private Button prevButton; // Кнопка для предыдущего канала
        private DropDownList sourceList;  //Вып список для подключаемых устройст
        private Label tvLabel; // доп ярлык для телека
        private Button connectButton;  //Подключение доп устройства к телеку
        private Button disconnectButton; //Отключение устройства от телека
        private TextBox temperBox; // Поле ввода для отображения/установки значения температуры      
        private Button uptempButton; // Кнопка увеличить температуру
        private Button downtempButton; // Кнопка уменьшить температуру        
        private Button deleteButton;  // Кнопка удаления устройства           

        public DeviceControl(int id, IDictionary<int, Device> devicesDictionary)
        {
            this.id = id;
            this.devicesDictionary = devicesDictionary;
            Initializer();
        }

        // Инициализатор графики устройства
        protected void Initializer()
        {
            CssClass = "mac";
            //Controls.Add(Span("Устройство: " + devicesDictionary[id].name + "<br />"+ id)); 
            Controls.Add(Span("<br />"));
            infoLabel = new Label();
            infoLabel.ID = "Info" + id.ToString();
            infoLabel.Text = devicesDictionary[id].ToString();
            Controls.Add(infoLabel);
            Controls.Add(Span("<br />"));
            
            onButton = new Button();
            onButton.ID = "ON" + id.ToString();
            onButton.Text = "Вкл";
            onButton.CssClass = "mac";
            onButton.Click += onButton_Click;
            Controls.Add(onButton);
            
            offButton = new Button();
            offButton.Text = "Выкл";
            offButton.CssClass = "mac";
            offButton.ID = "OFF" + id.ToString();
            offButton.Click += offButton_Click;
            Controls.Add(offButton);
            Controls.Add(Span("<br />"));

            if(devicesDictionary[id] is TVSet)
            {
                nextButton = new Button();
                nextButton.Text = "След.канал";
                nextButton.CssClass = "mac";
                nextButton.ID = "next" + id.ToString();
                nextButton.Click += nextButton_Click;
                Controls.Add(nextButton);

                prevButton = new Button();
                prevButton.Text = "Пред.канал";
                prevButton.CssClass = "mac";
                prevButton.ID = "prev" + id.ToString();
                prevButton.Click += prevButton_Click;
                Controls.Add(prevButton);
                Controls.Add(Span("<br />"));
                tvLabel = new Label();
                tvLabel.Text = "Выберите устройство для подключения:";
                Controls.Add(tvLabel);
                sourceList = new DropDownList();
                sourceList.CssClass = "mac";
                var res =
                       from t in devicesDictionary
                       where t.Value is ITVsourced
                       select t.Value.name;
                foreach (var source in res)
                {
                    sourceList.Items.Add(source);
                }
                Controls.Add(sourceList);
                connectButton = new Button();
                connectButton.Text = "Подключить";
                connectButton.CssClass = "mac";
                connectButton.Click += connectButton_Click;
                connectButton.ID = "Conn" + id;
                Controls.Add(connectButton);
                Controls.Add(Span("<br />"));

                disconnectButton = new Button();
                disconnectButton.Text = "Отключить";
                disconnectButton.CssClass = "mac";
                disconnectButton.Click += disconnectButton_Click;
                disconnectButton.ID = "disonn" + id;
                Controls.Add(disconnectButton);
                Controls.Add(Span("<br />"));
                
            }

            if (devicesDictionary[id] is TempereaturedDevice)
            {
                openButton = new Button();
                openButton.ID = "open" + id.ToString();
                openButton.CssClass = "mac";
                openButton.Text = "Открыть дверь";
                openButton.Click += openButton_Click;
                Controls.Add(openButton);

                closeButton = new Button();
                closeButton.Text = "Закрыть дверь";
                closeButton.CssClass = "mac";
                closeButton.ID = "close" + id.ToString();
                closeButton.Click += closeButton_Click;
                Controls.Add(closeButton);
                Controls.Add(Span("<br />"));

                temperBox = new TextBox();
                temperBox.ID = "tbox" + id.ToString();
                temperBox.CssClass = "mac";               
                Controls.Add(temperBox);

                uptempButton = new Button();
                uptempButton.Text = "Увеличить температуру";
                uptempButton.CssClass = "mac";
                uptempButton.ID = "uptemp" + id.ToString();
                uptempButton.Click += uptempButton_Click;
                Controls.Add(uptempButton);

                downtempButton = new Button();
                downtempButton.Text = "Уменьшить температуру";
                downtempButton.CssClass = "mac";
                downtempButton.ID = "downtemp" + id.ToString();
                downtempButton.Click += downtempButton_Click;
                Controls.Add(downtempButton);

                Controls.Add(Span("<br />"));
                                              
            }
 
            deleteButton = new Button();
            deleteButton.ID = "d" + id.ToString();
            deleteButton.Text = "Удалить";
            deleteButton.CssClass = "mac";
            deleteButton.Click += DeleteButtonClick;
            Controls.Add(deleteButton);
        }

        void downtempButton_Click(object sender, EventArgs e)
        {
            int offset;
            if (Int32.TryParse(temperBox.Text, out offset))
            {
                ((TempereaturedDevice)devicesDictionary[id]).lowTemperature(offset);
                infoLabel.Text = devicesDictionary[id].ToString(); 
            }
        }

        void uptempButton_Click(object sender, EventArgs e)
        {
            int offset;
            if (Int32.TryParse(temperBox.Text, out offset))
            {
                ((TempereaturedDevice)devicesDictionary[id]).highTemperature(offset);
                infoLabel.Text = devicesDictionary[id].ToString(); 
            }
        }


        void closeButton_Click(object sender, EventArgs e)
        {
            ((TempereaturedDevice)devicesDictionary[id]).CloseDoor();
            infoLabel.Text = devicesDictionary[id].ToString(); 
        }

        void openButton_Click(object sender, EventArgs e)
        {
            ((TempereaturedDevice)devicesDictionary[id]).OpenDoor();
            infoLabel.Text = devicesDictionary[id].ToString(); 
        }

        void disconnectButton_Click(object sender, EventArgs e)
        {
            ((TVSet)devicesDictionary[id]).SignalSource = null;
            infoLabel.Text = devicesDictionary[id].ToString(); 
        }

        void connectButton_Click(object sender, EventArgs e)
        {
            var res =
                      from t in devicesDictionary
                      where t.Value.name == sourceList.SelectedItem.ToString()
                      select t.Value;
            foreach (var source in res)
            {
                ((TVSet)devicesDictionary[id]).SignalSource = (ITVsourced)source;
            }
            infoLabel.Text = devicesDictionary[id].ToString(); 

        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            ((TVSet)devicesDictionary[id]).prevChannel();
            infoLabel.Text = devicesDictionary[id].ToString();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            ((TVSet)devicesDictionary[id]).nextChannel();
            infoLabel.Text = devicesDictionary[id].ToString();
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            devicesDictionary[id].Off();
            infoLabel.Text = devicesDictionary[id].ToString();
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            devicesDictionary[id].On();
            infoLabel.Text = devicesDictionary[id].ToString();
        }

        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }

        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            devicesDictionary.Remove(id);           
            Parent.Controls.Remove(this); // Удаление графики для фигуры
        }
    }
}