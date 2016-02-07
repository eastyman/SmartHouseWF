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
       // private TextBox DeviceBox;
        private Button deleteButton;
        private IDictionary<int, Device> devicesDictionary; // Коллекция фигур
        public DeviceControl(int id, IDictionary<int, Device> devicesDictionary)
        {
            this.id = id;
            this.devicesDictionary = devicesDictionary;
            Initializer();
        }

        // Инициализатор графики устройства
        protected void Initializer()
        {
          //  CssClass = "figure-div";
            Controls.Add(Span("Устройство: " + devicesDictionary[id].name + "<br />"+ id)); 
            Controls.Add(Span("<br />"));
            deleteButton = new Button();
            deleteButton.Text = "Удалить";
            deleteButton.Click += DeleteButtonClick;
            Controls.Add(deleteButton);
        }

        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }

        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            Controls.Add(Span("Curr id"+id));
            devicesDictionary.Remove(id);           
            Parent.Controls.Remove(this); // Удаление графики для фигуры
        }
    }
}