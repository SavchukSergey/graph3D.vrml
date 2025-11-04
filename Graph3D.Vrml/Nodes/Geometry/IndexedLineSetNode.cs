using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    /// <summary>
    /// IndexedFaceSet { 
    ///   eventIn MFInt32 set_colorIndex
    ///   eventIn MFInt32 set_coordIndex
    ///   exposedField SFNode  color NULL
    ///   exposedField SFNode  coord NULL
    ///   field MFInt32 colorIndex[]     # [-1,infinity)
    ///   field SFBool colorPerVertex    TRUE
    ///   field MFInt32 coordIndex[]     # [-1,infinity)
    /// }
    /// </summary>
    public class IndexedLineSetNode : GeometryNode {

        public IndexedLineSetNode() {
            AddExposedField("color", new SFNode());
            AddExposedField("coord", new SFNode());

            AddField("colorIndex", new MFInt32());
            AddField("colorPerVertex", new SFBool(true));
            AddField("coordIndex", new MFInt32());
        }

        public SFNode Color {
            get { return GetExposedField<SFNode>("color"); }
        }

        public SFNode Coord {
            get { return GetExposedField<SFNode>("coord"); }
        }

        public MFInt32 ColorIndex {
            get { return GetExposedField<MFInt32>("colorIndex"); }
        }

        public SFBool ColorPerVertex {
            get { return GetExposedField<SFBool>("colorPerVertex"); }
        }

        public MFInt32 CoordIndex {
            get { return GetExposedField<MFInt32>("coordIndex"); }
        }

        protected override BaseNode CreateInstance() {
            return new IndexedLineSetNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
