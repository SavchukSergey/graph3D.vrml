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
            get { return GetExposedField<MFNode>("children"); }
        }

        public void AppendChild(BaseNode node) {
            Children.AppendValue(node);
            node.Parent = this;
        }

        public SFVec3f BboxCenter {
            get { return GetExposedField<SFVec3f>("bboxCenter"); }
        }

        public SFVec3f BboxSize {
            get { return GetExposedField<SFVec3f>("bboxSize"); }
        }

    }
}
