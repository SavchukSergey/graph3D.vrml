namespace Graph3D.Vrml.Nodes.Grouping {
    /// <summary>
    /// Group { 
    ///   eventIn      MFNode  addChildren
    ///   eventIn      MFNode  removeChildren
    ///   exposedField MFNode  children      []
    ///   field        SFVec3f bboxCenter    0 0 0     # (-,)
    ///   field        SFVec3f bboxSize      -1 -1 -1  # (0,) or -1,-1,-1
    /// }
    /// </summary>
    public class GroupNode : GroupingNode, IChildNode {

        public GroupNode() {
        }

        protected override BaseNode createInstance() {
            return new GroupNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }
}
