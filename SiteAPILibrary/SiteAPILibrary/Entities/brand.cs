using System;
using System.Collections.Generic;
using System.Text;

namespace SiteAPILibrary.Entities
{
    public class brand:Entities.EntityBase
    {
        public brand() : base()
        {

        }
        public brand(Dictionary<string, object> fields) : base(fields)
        {

        }
        [Entities.Attributes.Id]
        public string id// id марки
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
        public string name// Марка
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
