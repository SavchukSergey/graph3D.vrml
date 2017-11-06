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
            addExposedField("color", new SFNode());
            addExposedField("coord", new SFNode());

            addField("colorIndex", new MFInt32());
            addField("colorPerVertex", new SFBool(true));
            addField("coordIndex", new MFInt32());
        }

        public SFNode color {
            get { return GetExposedField("color") as SFNode; }
        }

        public SFNode coord {
            get { return GetExposedField("coord") as SFNode; }
        }

        public MFInt32 colorIndex {
            get { return getField("colorIndex") as MFInt32; }
        }

        public SFBool colorPerVertex {
            get { return getField("colorPerVertex") as SFBool; }
        }

        public MFInt32 coordIndex {
            get { return getField("coordIndex") as MFInt32; }
        }

        protected override BaseNode createInstance() {
            return new IndexedLineSetNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
