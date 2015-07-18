using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes.Grouping;

namespace Graph3D.Vrml.Nodes {
    public class ProtoNode : GroupingNode {
        
        public new void AddField(string fieldName, Field field) {
            base.addField(fieldName, field);
        }

        public new void addEventIn(string eventInName, Field field) {
            base.addEventIn(eventInName, field);
        }
        
        public new void addEventOut(string eventOutName, Field field) {
            base.addEventOut(eventOutName, field);
        }

        public new void AddExposedField(string exposedFieldName, Field field) {
            base.addExposedField(exposedFieldName, field);
        }

        protected override BaseNode createInstance() {
            return new ProtoNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
