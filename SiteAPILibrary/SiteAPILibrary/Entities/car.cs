using System.Collections.Generic;

namespace SiteAPILibrary.Entities
{
    public class car:Entities.EntityBase //Предмет договора
    {
        public car() : base()
        {

        }
        public car(Dictionary<string, object> fields) : base(fields)
        {

        }
        [Entities.Attributes.Id]
        public brand brand//Модель
        {
            get
            {
                return (brand)this.GetValue(nameof(brand));
            }
            set
            {
                this.SetValue("brand", value);
            }
        }
        public Cmodel model//Модель
        {
            get
            {
                return (Cmodel)this.GetValue(nameof(model));
            }
            set
            {
                this.SetValue("model", value);
            }
        }
        public string? reg_number//Гос-номер
        {
            get
            {
                return (string)this.GetValue(nameof(reg_number));
            }
            set
            {
                this.SetValue("reg_number", value);
            }
        }
        public string vin_number//VIN номер
        {
            get
            {
                return (string)this.GetValue(nameof(vin_number));
            }
            set
            {
                this.SetValue("vin_number", value);
            }
        }
    }
}
