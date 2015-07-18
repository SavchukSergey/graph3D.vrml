using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    /// <summary>
    /// IndexedFaceSet { 
    ///   eventIn       MFInt32 set_colorIndex
    ///   eventIn       MFInt32 set_coordIndex
    ///   eventIn       MFInt32 set_normalIndex
    ///   eventIn       MFInt32 set_texCoordIndex
    ///   exposedField  SFNode  color             NULL
    ///   exposedField  SFNode  coord             NULL
    ///   exposedField  SFNode  normal            NULL
    ///   exposedField  SFNode  texCoord          NULL
    ///   field         SFBool  ccw               TRUE
    ///   field         MFInt32 colorIndex        []        # [-1,)
    ///   field         SFBool  colorPerVertex    TRUE
    ///   field         SFBool  convex            TRUE
    ///   field         MFInt32 coordIndex        []        # [-1,)
    ///   field         SFFloat creaseAngle       0         # [0,)
    ///   field         MFInt32 normalIndex       []        # [-1,)
    ///   field         SFBool  normalPerVertex   TRUE
    ///   field         SFBool  solid             TRUE
    ///   field         MFInt32 texCoordIndex     []        # [-1,)
    /// }
    /// </summary>
    public class IndexedFaceSetNode : GeometryNode {

        public IndexedFaceSetNode() {
            addExposedField("color", new SFNode());
            addExposedField("coord", new SFNode());
            addExposedField("normal", new SFNode());
            addExposedField("texCoord", new SFNode());
            
            addField("ccw", new SFBool(true));
            addField("colorIndex", new MFInt32());
            addField("colorPerVertex", new SFBool(true));
            addField("convex", new SFBool(true));
            addField("coordIndex", new MFInt32());
            addField("creaseAngle", new SFFloat(0));
            addField("normalIndex", new MFInt32());
            addField("normalPerVertex", new SFBool(true));
            addField("solid", new SFBool(true));
            addField("texCoordIndex", new MFInt32());
        }

        public SFNode color {
            get { return getExposedField("color") as SFNode; }
        }

        public SFNode coord {
            get { return getExposedField("coord") as SFNode; }
        }

        public SFNode normal {
            get { return getExposedField("normal") as SFNode; }
        }

        public SFNode texCoord {
            get { return getExposedField("texCoord") as SFNode; }
        }

        public SFBool ccw {
            get { return getField("ccw") as SFBool; }
        }

        public MFInt32 colorIndex {
            get { return getField("colorIndex") as MFInt32; }
        }

        public SFBool colorPerVertex {
            get { return getField("colorPerVertex") as SFBool; }
        }

        public SFBool convex {
            get { return getField("convex") as SFBool; }
        }

        public MFInt32 coordIndex {
            get { return getField("coordIndex") as MFInt32; }
        }

        public SFFloat creaseAngle {
            get { return getField("creaseAngle") as SFFloat; }
        }

        public MFInt32 normalIndex {
            get { return getField("normalIndex") as MFInt32; }
        }

        public SFBool normalPerVertex {
            get { return getField("normalPerVertex") as SFBool; }
        }

        public SFBool solid {
            get { return getField("solid") as SFBool; }
        }

        public MFInt32 texCordIndex {
            get { return getField("texCordIndex") as MFInt32; }
        }

        protected override BaseNode createInstance() {
            return new IndexedFaceSetNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
