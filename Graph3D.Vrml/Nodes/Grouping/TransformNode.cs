using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Grouping {
    /// <summary>
    /// Transform { 
    ///   eventIn      MFNode      addChildren
    ///   eventIn      MFNode      removeChildren
    ///   exposedField SFVec3f     center           0 0 0    # (-,)
    ///   exposedField MFNode      children         []
    ///   exposedField SFRotation  rotation         0 0 1 0  # [-1,1],(-,)
    ///   exposedField SFVec3f     scale            1 1 1    # (0,)
    ///   exposedField SFRotation  scaleOrientation 0 0 1 0  # [-1,1],(-,)
    ///   exposedField SFVec3f     translation      0 0 0    # (-,)
    ///   field        SFVec3f     bboxCenter       0 0 0    # (-,)
    ///   field        SFVec3f     bboxSize         -1 -1 -1 # (0,) or -1,-1,-1
    /// }
    /// </summary>
    public class TransformNode : GroupingNode, IChildNode {

        public TransformNode() {
            AddExposedField("center", new SFVec3f(0, 0, 0));
            AddExposedField("rotation", new SFRotation(0, 0, 1, 0));
            AddExposedField("scale", new SFVec3f(1, 1, 1));
            AddExposedField("scaleOrientation", new SFRotation(0, 0, 1, 0));
            AddExposedField("translation", new SFVec3f(0, 0, 0));
        }

        public SFVec3f Center {
            get { return GetExposedField("center") as SFVec3f; }
        }

        public SFRotation Rotation {
            get { return GetExposedField("rotation") as SFRotation; }
        }

        public SFVec3f Scale {
            get { return GetExposedField("scale") as SFVec3f; }
        }

        public SFRotation ScaleOrientation {
            get { return GetExposedField("scaleOrientation") as SFRotation; }
        }

        public SFVec3f Translation {
            get { return GetExposedField("translation") as SFVec3f; }
        }

        /// <summary>
        /// Generates matrix for tranformation from local coordinate system to origin one.
        /// </summary>
        /// <returns>3x4 matrix.</returns>
        public float[,] GenerateTransformMatrix() {
            //P' = T × C × R × SR × S × -SR × -C × P
            float[,] matrix = VrmlMath.GetUnitMatrix();

            float[,] temp = null;

            temp = VrmlMath.GetUnitMatrix();
            temp[0, 3] = -Center.X;
            temp[1, 3] = -Center.Y;
            temp[2, 3] = -Center.Z;
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GenerateRotationMatrix(ScaleOrientation.X, ScaleOrientation.Y, ScaleOrientation.Z, -ScaleOrientation.Angle);
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GetUnitMatrix();
            temp[0, 0] = 1 / Scale.X;
            temp[1, 1] = 1 / Scale.Y;
            temp[2, 2] = 1 / Scale.Z;
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GenerateRotationMatrix(ScaleOrientation.X, ScaleOrientation.Y, ScaleOrientation.Z, ScaleOrientation.Angle);
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GenerateRotationMatrix(Rotation.X, Rotation.Y, Rotation.Z, Rotation.Angle);
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GetUnitMatrix();
            temp[0, 3] = Center.X;
            temp[1, 3] = Center.Y;
            temp[2, 3] = Center.Z;
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GetUnitMatrix();
            temp[0, 3] = Translation.X;
            temp[1, 3] = Translation.Y;
            temp[2, 3] = Translation.Z;
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            return matrix;
        }

        protected override BaseNode CreateInstance() {
            return new TransformNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
