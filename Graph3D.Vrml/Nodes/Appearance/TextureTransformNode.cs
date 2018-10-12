using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Appearance {
    /// <summary>
    /// TextureTransform {
    ///   exposedField SFVec2f center      0 0
    ///   exposedField SFFloat rotation    0
    ///   exposedField SFVec2f scale       1 1
    ///   exposedField SFVec2f translation 0 0
    /// }
    /// </summary>
    public class TextureTransformNode : Node {

        public TextureTransformNode() {
        }

        protected override BaseNode CreateInstance() {
            return new TextureTransformNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
