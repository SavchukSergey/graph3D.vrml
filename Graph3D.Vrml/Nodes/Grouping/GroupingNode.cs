using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Grouping {
    //TODO: move children field to ICompositeNode
    public abstract class GroupingNode : Node {

        protected GroupingNode() {
            addExposedField("children", new MFNode());
            addField("bboxSize", new SFVec3f(-1, -1, -1));
            addField("bboxCenter", new SFVec3f(0, 0, 0));
        }

        public MFNode children {
            get { return GetExposedField("children") as MFNode; }
        }

        public void appendChild(BaseNode node) {
            children.appendValue(node);
            node.parent = this;
        }

        public SFVec3f bboxCenter {
            get { return getField("bboxCenter") as SFVec3f; }
        }

        public SFVec3f bboxSize {
            get { return getField("bboxSize") as SFVec3f; }
        }

    }
}
