using System;
using System.Collections.Generic;

namespace SiteAPILibrary.Entities
{
    public class contract:Entities.EntityBase
    {
        public contract() : base()
        {

        }
        public contract(Dictionary<string, object> fields) : base(fields)
        {

        }
        [Entities.Attributes.Id]
        public string number //Номер договора
        {
            get
            {
                return (string)this.GetValue(nameof(number));
            }
            set
            {
                this.SetValue("number", value);
            }
        }
        public DateTime date//Дата заключения
        {
            get
            {
                return (DateTime)this.GetValue(nameof(date));
            }
            set
            {
                this.SetValue("date", value);
            }
        }
        public string? url//Ссылка на электронную версию договора
        {
            get
            {
                return (string?)this.GetValue(nameof(url));
            }
            set
            {
                this.SetValue("url", value);
            }
        }
        public car car//Предмет договора
        {
            get
            {
                return (car)this.GetValue(nameof(car));
            }
            set
            {
                this.SetValue("car", value);
            }
        }
        public string status//Статус договора
        {
            get
            {
                return (string)this.GetValue(nameof(status));
            }
            set
            {
                this.SetValue("status", value);
            }
        }
        public double current_payment_amount//Сумма ближайшего платежа
        {
            get
            {
                return (double)this.GetValue(nameof(current_payment_amount));
            }
            set
            {
                this.SetValue("current_payment_amount", value);
            }
        }
        public DateTime current_payment_date//Дата ближайшего платежа
        {
            get
            {
                return (DateTime)this.GetValue(nameof(current_payment_date));
            }
            set
            {
                this.SetValue("current_payment_date", value);
            }
        }
    }
}
