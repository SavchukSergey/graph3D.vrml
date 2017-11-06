using System.Collections.Generic;
using System.Diagnostics;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;

namespace Graph3D.Vrml.Nodes {
    public abstract class BaseNode {

        [DebuggerStepThrough]
        protected BaseNode() {
        }

        public string name { get; set; }

        public BaseNode Parent { get; set; }

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

        public Field GetExposedField(string exposedFieldName) {
            if (exposedFields.TryGetValue(exposedFieldName, out Field field)) {
                return field;
            }
            throw new InvalidExposedFieldException($"'{exposedFieldName}' exposed field doesn't exist in node of {GetType().Name} type");
        }

        public Field getField(string fieldName) {
            if (exposedFields.TryGetValue(fieldName, out Field res)) {
                return res;
            }
            throw new InvalidExposedFieldException($"'{fieldName}' field doesn't exist in node of {GetType().Name} type");
        }

        public Field getEventIn(string eventInName) {
            if (eventIns.TryGetValue(eventInName, out Field res)) {
                return res;
            }
            throw new InvalidEventInException($"'{eventInName}' event in field doesn't exist in node of {GetType().Name} type");
        }

        public Field getEventOut(string eventOutName) {
            if (eventOuts.TryGetValue(eventOutName, out Field res)) return res;
            throw new InvalidEventOutException($"'{eventOutName}' event out field doesn't exist in node of {GetType().Name} type");
        }

        protected abstract BaseNode createInstance();

        public abstract void AcceptVisitor(INodeVisitor visitor);

        public BaseNode clone() {
            var clone = createInstance();
            foreach (var key in exposedFields.Keys) {
                Field field = exposedFields[key];
                clone.exposedFields[key] = field.Clone();
            }
            foreach (var key in eventIns.Keys) {
                Field field = eventIns[key];
                clone.eventIns[key] = field.Clone();
            }
            foreach (var key in eventOuts.Keys) {
                Field field = eventOuts[key];
                clone.eventOuts[key] = field.Clone();
            }
            clone.name = name;
            return clone;
        }

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
            return string.Format("{0}: {{\r\n{1}}}", GetType().Name, fieldsStr);
        }
    }
}
