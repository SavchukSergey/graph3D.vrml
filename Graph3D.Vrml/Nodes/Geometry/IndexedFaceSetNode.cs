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
            AddExposedField("color", new SFNode());
            AddExposedField("coord", new SFNode());
            AddExposedField("normal", new SFNode());
            AddExposedField("texCoord", new SFNode());
            
            AddField("ccw", new SFBool(true));
            AddField("colorIndex", new MFInt32());
            AddField("colorPerVertex", new SFBool(true));
            AddField("convex", new SFBool(true));
            AddField("coordIndex", new MFInt32());
            AddField("creaseAngle", new SFFloat(0));
            AddField("normalIndex", new MFInt32());
            AddField("normalPerVertex", new SFBool(true));
            AddField("solid", new SFBool(true));
            AddField("texCoordIndex", new MFInt32());
        }

        public SFNode Color {
            get { return GetExposedField<SFNode>("color"); }
        }

        public SFNode Coord {
            get { return GetExposedField<SFNode>("coord"); }
        }

        public SFNode Normal {
            get { return GetExposedField<SFNode>("normal"); }
        }

        public SFNode TexCoord {
            get { return GetExposedField<SFNode>("texCoord"); }
        }

        public SFBool Ccw {
            get { return GetExposedField<SFBool>("ccw"); }
        }

        public MFInt32 ColorIndex {
            get { return GetExposedField<MFInt32>("colorIndex"); }
        }

        public SFBool ColorPerVertex {
            get { return GetExposedField<SFBool>("colorPerVertex"); }
        }

        public SFBool Convex {
            get { return GetExposedField<SFBool>("convex"); }
        }

        public MFInt32 CoordIndex {
            get { return GetExposedField<MFInt32>("coordIndex"); }
        }

        public SFFloat CreaseAngle {
            get { return GetExposedField<SFFloat>("creaseAngle"); }
        }

        public MFInt32 NormalIndex {
            get { return GetExposedField<MFInt32>("normalIndex"); }
        }

        public SFBool NormalPerVertex {
            get { return GetExposedField<SFBool>("normalPerVertex"); }
        }

        public SFBool Solid {
            get { return GetExposedField<SFBool>("solid"); }
        }

        public MFInt32 TexCoordIndex {
            get { return GetExposedField<MFInt32>("texCoordIndex"); }
        }

        protected override BaseNode CreateInstance() {
            return new IndexedFaceSetNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
