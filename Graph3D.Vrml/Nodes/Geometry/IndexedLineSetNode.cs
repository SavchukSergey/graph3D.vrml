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
            get { return GetExposedField("color") as SFNode; }
        }

        public SFNode Coord {
            get { return GetExposedField("coord") as SFNode; }
        }

        public MFInt32 ColorIndex {
            get { return GetField("colorIndex") as MFInt32; }
        }

        public SFBool ColorPerVertex {
            get { return GetField("colorPerVertex") as SFBool; }
        }

        public MFInt32 CoordIndex {
            get { return GetField("coordIndex") as MFInt32; }
        }

        protected override BaseNode CreateInstance() {
            return new IndexedLineSetNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
