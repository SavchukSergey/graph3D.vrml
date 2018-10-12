using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Grouping {
    //TODO: move children field to ICompositeNode
    public abstract class GroupingNode : Node {

        protected GroupingNode() {
            AddExposedField("children", new MFNode());
            AddField("bboxSize", new SFVec3f(-1, -1, -1));
            AddField("bboxCenter", new SFVec3f(0, 0, 0));
        }

        public MFNode Children {
            get { return GetExposedField("children") as MFNode; }
        }

        public void AppendChild(BaseNode node) {
            Children.AppendValue(node);
            node.Parent = this;
        }

        public SFVec3f BboxCenter {
            get { return GetField("bboxCenter") as SFVec3f; }
        }

        public SFVec3f BboxSize {
            get { return GetField("bboxSize") as SFVec3f; }
        }

    }
}
