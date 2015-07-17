using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes.Grouping;

namespace Graph3D.Vrml.Nodes {
    public class CustomNode : GroupingNode {
        
        public new void addField(string fieldName, Field field) {
            base.addField(fieldName, field);
        }

        public new void addEventIn(string eventInName, Field field) {
            base.addEventIn(eventInName, field);
        }
        
        public new void addEventOut(string eventOutName, Field field) {
            base.addEventOut(eventOutName, field);
        }

        public new void addExposedField(string exposedFieldName, Field field) {
            base.addExposedField(exposedFieldName, field);
        }

        protected override BaseNode createInstance() {
            return new CustomNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }
}
