using System;

namespace Graph3D.Vrml {
    public static class VrmlMath {

        /// <summary>
        /// Generates 3x4 unit matrix.
        /// </summary>
        /// <returns>3x4 matrix.</returns>
        public static float[,] GetUnitMatrix() {
            float[,] matrix = new float[3, 4];
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 0;
            matrix[0, 3] = 0;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 0;
            matrix[1, 3] = 0;
            matrix[2, 0] = 0;
            matrix[2, 1] = 0;
            matrix[2, 2] = 1;
            matrix[2, 3] = 0;
            return matrix;
        }

        /// <summary>
        /// Concatenates two 3x4 matrix into output matrix.
        /// </summary>
        /// <param name="a">Left 3x4 matrix.</param>
        /// <param name="b">Right 3x4 matrix.</param>
        /// <param name="output">Output 3x4 matrix.</param>
        public static void ConcatenateMatrixes(float[,] a, float[,] b, float[,] output) {
            float c00 = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0] + a[0, 2] * b[2, 0];
            float c01 = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1] + a[0, 2] * b[2, 1];
            float c02 = a[0, 0] * b[0, 2] + a[0, 1] * b[1, 2] + a[0, 2] * b[2, 2];
            float c03 = a[0, 0] * b[0, 3] + a[0, 1] * b[1, 3] + a[0, 2] * b[2, 3] + a[0, 3];
            float c10 = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0] + a[1, 2] * b[2, 0];
            float c11 = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1] + a[1, 2] * b[2, 1];
            float c12 = a[1, 0] * b[0, 2] + a[1, 1] * b[1, 2] + a[1, 2] * b[2, 2];
            float c13 = a[1, 0] * b[0, 3] + a[1, 1] * b[1, 3] + a[1, 2] * b[2, 3] + a[1, 3];
            float c20 = a[2, 0] * b[0, 0] + a[2, 1] * b[1, 0] + a[2, 2] * b[2, 0];
            float c21 = a[2, 0] * b[0, 1] + a[2, 1] * b[1, 1] + a[2, 2] * b[2, 1];
            float c22 = a[2, 0] * b[0, 2] + a[2, 1] * b[1, 2] + a[2, 2] * b[2, 2];
            float c23 = a[2, 0] * b[0, 3] + a[2, 1] * b[1, 3] + a[2, 2] * b[2, 3] + a[2, 3];
            output[0, 0] = c00;
            output[0, 1] = c01;
            output[0, 2] = c02;
            output[0, 3] = c03;
            output[1, 0] = c10;
            output[1, 1] = c11;
            output[1, 2] = c12;
            output[1, 3] = c13;
            output[2, 0] = c20;
            output[2, 1] = c21;
            output[2, 2] = c22;
            output[2, 3] = c23;
        }

        /// <summary>
        /// Generates rotation 3x4 matrix.
        /// </summary>
        /// <param name="x">Rotation axis's x.</param>
        /// <param name="y">Rotation axis's y.</param>
        /// <param name="z">Rotation axis's z.</param>
        /// <param name="angle">Rotation angle.</param>
        /// <returns></returns>
        public static float[,] GenerateRotationMatrix(float x, float y, float z, float angle) {
            //[ tx2+c    txy+sz    txz-sy
            //  txy-sz   ty2+c     tyz+sx
            //  txz+sy   tyz-sx    tz2+c  ]
            //where c = cos(a), s = sin(a), and t = 1-c
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);
            float t = 1 - c;
            float[,] matrix = new float[3, 4];
            matrix[0, 0] = t * x * x + c;
            matrix[0, 1] = t * x * y + s * z;
            matrix[0, 2] = t * x * z - s * y;
            matrix[0, 3] = 0;
            matrix[1, 0] = t * x * y - s * z;
            matrix[1, 1] = t * y * y + c;
            matrix[1, 2] = t * y * z + s * x;
            matrix[1, 3] = 0;
            matrix[2, 0] = t * x * z + s * y;
            matrix[2, 1] = t * y * z - s * x;
            matrix[2, 2] = t * z * z + c;
            matrix[2, 3] = 0;
            return matrix;
        }

        /// <summary>
        /// Transforms 3D vector using transformation matrix.
        /// </summary>
        /// <param name="x">Vector's x.</param>
        /// <param name="y">Vector's y.</param>
        /// <param name="z">Vector's z.</param>
        /// <param name="transformation">Transformation 3x4 matrix.</param>
        /// <returns></returns>
        public static float[] TransformVector(float x, float y, float z, float[,] transformation) {
            float[] result =
            [
                transformation[0, 0] * x + transformation[0, 1] * y + transformation[0, 2] * z + transformation[0, 3],
                transformation[1, 0] * x + transformation[1, 1] * y + transformation[1, 2] * z + transformation[1, 3],
                transformation[2, 0] * x + transformation[2, 1] * y + transformation[2, 2] * z + transformation[2, 3],
            ];
            return result;
        }


    }
}
