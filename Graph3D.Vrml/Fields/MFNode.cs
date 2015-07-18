using Graph3D.Vrml.Nodes;

namespace Graph3D.Vrml.Fields {
    public class MFNode : MField<BaseNode> {

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            var clone = new MFNode();
            foreach (var child in this.values) {
                clone.appendValue(child.clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFNode;
        }


    }
}
