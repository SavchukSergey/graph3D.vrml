using System.Collections.Generic;
using System.Diagnostics;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;

namespace Graph3D.Vrml.Nodes {
    public abstract class BaseNode {

        [DebuggerStepThrough]
        protected BaseNode() {
        }

        public string? Name { get; set; }

        public BaseNode Parent { get; set; }

        private readonly Dictionary<string, Field> _exposedFields = [];
        private readonly Dictionary<string, Field> _eventIns = [];
        private readonly Dictionary<string, Field> _eventOuts = [];

        protected void AddField(string fieldName, Field field) {
            //TODO: another dictionary.
            _exposedFields[fieldName] = field;
        }

        protected void AddExposedField(string exposedFieldName, Field field) {
            _exposedFields[exposedFieldName] = field;
        }

        protected void AddEventIn(string eventInName, Field field) {
            _eventIns[eventInName] = field;
        }

        protected void AddEventOut(string eventOutName, Field field) {
            _eventOuts[eventOutName] = field;
        }

        public TField GetExposedField<TField>(string exposedFieldName) where TField : Field {
            if (_exposedFields.TryGetValue(exposedFieldName, out var field)) {
                return (TField)field;
            }
            throw new InvalidExposedFieldException($"'{exposedFieldName}' exposed field doesn't exist in node of {GetType().Name} type");
        }

        public TField GetField<TField>(string fieldName) where TField : Field {
            if (_exposedFields.TryGetValue(fieldName, out var res)) {
                return (TField)res;
            }
            throw new InvalidExposedFieldException($"'{fieldName}' field doesn't exist in node of {GetType().Name} type");
        }

        public Field GetEventIn(string eventInName) {
            if (_eventIns.TryGetValue(eventInName, out var res)) {
                return res;
            }
            throw new InvalidEventInException($"'{eventInName}' event in field doesn't exist in node of {GetType().Name} type");
        }

        public Field GetEventOut(string eventOutName) {
            if (_eventOuts.TryGetValue(eventOutName, out var res)) return res;
            throw new InvalidEventOutException($"'{eventOutName}' event out field doesn't exist in node of {GetType().Name} type");
        }

        protected abstract BaseNode CreateInstance();

        public abstract void AcceptVisitor(INodeVisitor visitor);

        public virtual BaseNode Clone() {
            var clone = CreateInstance();
            foreach (var key in _exposedFields.Keys) {
                var field = _exposedFields[key];
                clone._exposedFields[key] = field.Clone();
            }
            foreach (var key in _eventIns.Keys) {
                var field = _eventIns[key];
                clone._eventIns[key] = field.Clone();
            }
            foreach (var key in _eventOuts.Keys) {
                var field = _eventOuts[key];
                clone._eventOuts[key] = field.Clone();
            }
            clone.Name = Name;
            return clone;
        }

        public override string ToString() {
            string fieldsStr = "";
            foreach (var key in _eventIns.Keys) {
                if (!string.IsNullOrEmpty(fieldsStr)) fieldsStr += ", \r\n";
                fieldsStr += key + ": " + _eventIns[key].ToString();
            }
            foreach (var key in _eventOuts.Keys) {
                if (!string.IsNullOrEmpty(fieldsStr)) fieldsStr += ", \r\n";
                fieldsStr += key + ": " + _eventOuts[key].ToString();
            }
            foreach (var key in _exposedFields.Keys) {
                if (!string.IsNullOrEmpty(fieldsStr)) fieldsStr += ", \r\n";
                fieldsStr += key + ": " + _exposedFields[key].ToString();
            }
            if (!string.IsNullOrEmpty(fieldsStr)) fieldsStr += "\r\n";
            return string.Format("{0}: {{\r\n{1}}}", GetType().Name, fieldsStr);
        }
    }
}
