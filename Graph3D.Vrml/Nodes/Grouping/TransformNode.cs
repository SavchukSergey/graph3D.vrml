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
            addExposedField("center", new SFVec3f(0, 0, 0));
            addExposedField("rotation", new SFRotation(0, 0, 1, 0));
            addExposedField("scale", new SFVec3f(1, 1, 1));
            addExposedField("scaleOrientation", new SFRotation(0, 0, 1, 0));
            addExposedField("translation", new SFVec3f(0, 0, 0));
        }

        public SFVec3f center {
            get { return getExposedField("center") as SFVec3f; }
        }

        public SFRotation rotation {
            get { return getExposedField("rotation") as SFRotation; }
        }

        public SFVec3f scale {
            get { return getExposedField("scale") as SFVec3f; }
        }

        public SFRotation scaleOrientation {
            get { return getExposedField("scaleOrientation") as SFRotation; }
        }

        public SFVec3f translation {
            get { return getExposedField("translation") as SFVec3f; }
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
            temp[0, 3] = -center.x;
            temp[1, 3] = -center.y;
            temp[2, 3] = -center.z;
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GenerateRotationMatrix(scaleOrientation.x, scaleOrientation.y, scaleOrientation.z, -scaleOrientation.angle);
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GetUnitMatrix();
            temp[0, 0] = 1 / scale.x;
            temp[1, 1] = 1 / scale.y;
            temp[2, 2] = 1 / scale.z;
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GenerateRotationMatrix(scaleOrientation.x, scaleOrientation.y, scaleOrientation.z, scaleOrientation.angle);
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GenerateRotationMatrix(rotation.x, rotation.y, rotation.z, rotation.angle);
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GetUnitMatrix();
            temp[0, 3] = center.x;
            temp[1, 3] = center.y;
            temp[2, 3] = center.z;
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            temp = VrmlMath.GetUnitMatrix();
            temp[0, 3] = translation.x;
            temp[1, 3] = translation.y;
            temp[2, 3] = translation.z;
            VrmlMath.ConcatenateMatrixes(temp, matrix, matrix);

            return matrix;
        }

        protected override BaseNode createInstance() {
            return new TransformNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
