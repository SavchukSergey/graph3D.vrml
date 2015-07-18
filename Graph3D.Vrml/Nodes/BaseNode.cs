using System;
using System.Collections.Generic;
using System.Diagnostics;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;

namespace Graph3D.Vrml.Nodes {
    public abstract class BaseNode : ICloneable {

        [DebuggerStepThrough]
        protected BaseNode() {
        }

        public string name { get; set; }

        private BaseNode _parent;
        public BaseNode parent {
            get { return _parent; }
            set { _parent = value; }
        }

        private readonly Dictionary<string, Field> exposedFields = new Dictionary<string, Field>();
        private readonly Dictionary<string, Field> eventIns = new Dictionary<string, Field>();
        private readonly Dictionary<string, Field> eventOuts = new Dictionary<string, Field>();

        protected void addField(string fieldName, Field field) {
            //TODO: another dictionary.
            exposedFields[fieldName] = field;
        }

        protected void addExposedField(string exposedFieldName, Field field) {
            exposedFields[exposedFieldName] = field;
        }

        protected void addEventIn(string eventInName, Field field) {
            eventIns[eventInName] = field;
        }

        protected void addEventOut(string eventOutName, Field field) {
            eventOuts[eventOutName] = field;
        }

        public Field getExposedField(string exposedFieldName) {
            if (exposedFields.ContainsKey(exposedFieldName)) {
                return exposedFields[exposedFieldName];
            } else {
                throw new InvalidExposedFieldException(string.Format("'{0}' exposed field doesn't exist in node of {1} type", exposedFieldName, this.GetType().Name));
            }
        }

        public Field getField(string fieldName) {
            Field res;
            if (exposedFields.TryGetValue(fieldName, out res)) {
                return res;
            }
            throw new InvalidExposedFieldException(string.Format("'{0}' field doesn't exist in node of {1} type", fieldName, GetType().Name));
        }

        public Field getEventIn(string eventInName) {
            Field res;
            if (eventIns.TryGetValue(eventInName, out res)) {
                return res;
            }
            throw new InvalidEventInException(string.Format("'{0}' event in field doesn't exist in node of {1} type", eventInName, GetType().Name));
        }

        public Field getEventOut(string eventOutName) {
            Field res;
            if (eventOuts.TryGetValue(eventOutName, out res)) return res;
            throw new InvalidEventOutException(string.Format("'{0}' event out field doesn't exist in node of {1} type", eventOutName, GetType().Name));
        }

        protected abstract BaseNode createInstance();

        public abstract void AcceptVisitor(INodeVisitor visitor);

        public BaseNode clone() {
            var clone = createInstance();
            foreach (var key in exposedFields.Keys) {
                Field field = exposedFields[key];
                clone.exposedFields[key] = field.clone();
            }
            foreach (var key in eventIns.Keys) {
                Field field = eventIns[key];
                clone.eventIns[key] = field.clone();
            }
            foreach (var key in eventOuts.Keys) {
                Field field = eventOuts[key];
                clone.eventOuts[key] = field.clone();
            }
            clone.name = name;
            return clone;
        }

        #region ICloneable Members

        object ICloneable.Clone() {
            return this.clone();
        }

        #endregion

        public override string ToString() {
            string fieldsStr = "";
            foreach (string key in eventIns.Keys) {
                if (!string.IsNullOrEmpty(fieldsStr)) fieldsStr += ", \r\n";
                fieldsStr += key + ": " + eventIns[key].ToString();
            }
            foreach (string key in eventOuts.Keys) {
                if (!string.IsNullOrEmpty(fieldsStr)) fieldsStr += ", \r\n";
                fieldsStr += key + ": " + eventOuts[key].ToString();
            }
            foreach (string key in exposedFields.Keys) {
                if (!string.IsNullOrEmpty(fieldsStr)) fieldsStr += ", \r\n";
                fieldsStr += key + ": " + exposedFields[key].ToString();
            }
            if (!string.IsNullOrEmpty(fieldsStr)) fieldsStr += "\r\n";
            return string.Format("{0}: {{\r\n{1}}}", this.GetType().Name, fieldsStr);
        }
    }
}
