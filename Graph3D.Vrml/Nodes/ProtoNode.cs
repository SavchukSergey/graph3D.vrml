using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes.Grouping;

namespace Graph3D.Vrml.Nodes {
    //todo: rename to ProtoStatement, remove baseclass
    public class ProtoNode : GroupingNode {
        
        public new void AddField(string fieldName, Field field) {
            base.AddField(fieldName, field);
        }

        public new void AddEventIn(string eventInName, Field field) {
            base.AddEventIn(eventInName, field);
        }
        
        public new void AddEventOut(string eventOutName, Field field) {
            base.AddEventOut(eventOutName, field);
        }

        public new void AddExposedField(string exposedFieldName, Field field) {
            base.AddExposedField(exposedFieldName, field);
        }

        protected override BaseNode CreateInstance() {
            return new ProtoNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
