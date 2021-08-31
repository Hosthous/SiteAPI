using System;
using System.Collections.Generic;
using System.Text;

namespace SiteAPILibrary.Entities
{
    public class model:Entities.EntityBase
    {
        public model() : base()
        {

        }
        public model(Dictionary<string, object> fields) : base(fields)
        {

        }
        [Entities.Attributes.Id]
        public string id//id модели
        {
            get
            {
                return (string)this.GetValue(nameof(id));
            }
            set
            {
                this.SetValue("id", value);
            }
        }
        public string name//Модель
        {
            get
            {
                return (string)this.GetValue(nameof(name));
            }
            set
            {
                this.SetValue("name", value);
            }
        }
    }
}
