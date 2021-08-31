using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteAPILibrary.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            _fields = new Dictionary<string, object>();
        }
        public EntityBase(Dictionary<string, object> fields)
        {
            _fields = fields;
        }
        protected Dictionary<string, object> _fields;
        private List<string> _updatedKeys = new List<string>();
        protected void SetValue(string key, object value)
        {
            //if (!_fields.Keys.Contains(key) | (value != null | _fields[key] != value)
            {
                _fields[key] = value;
                if (!_updatedKeys.Contains(key)) _updatedKeys.Add(key);
            }
        }
        public object GetValue(string key)
        {
            if (_fields.ContainsKey(key)) return _fields[key];
            else return null;

        }
        public string[] GetUpdatedField()
        {
            if (this._updatedKeys.Count == 0) return null;
            else return this._updatedKeys.ToArray();
        }
        public string GetIdName()
        {
            return this.GetType()
                .GetProperties()
                .Where(x => x.CustomAttributes
                           .Any(ca => ca.AttributeType == typeof(Entities.Attributes.IdAttribute))).First().Name;
        }

        public int GetIdValue()
        {
            return (int)this.GetValue(GetIdName());
        }
    }
}
