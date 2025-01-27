using SatisfactorySaveNet.Abstracts.Maths.Data;
using SatisfactorySaveNet.Abstracts.Maths.Vector;
using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace SatisfactorySaveNet.Abstracts.Maths.Matrix
{
    /// <summary>
    /// Represents a 3x3 matrix containing 3D rotation and scale with double-precision components.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3D : IEquatable<Matrix3D>, IFormattable
    {
        /// <summary>
        /// First row of the matrix.
        /// </summary>
        public Vector3D Row0;

        /// <summary>
        /// Second row of the matrix.
        /// </summary>
        public Vector3D Row1;

        /// <summary>
        /// Third row of the matrix.
        /// </summary>
        public Vector3D Row2;

        /// <summary>
        /// The identity matrix.
        /// </summary>
        public static readonly Matrix3D Identity = new(Vector3D.UnitX, Vector3D.UnitY, Vector3D.UnitZ);

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3D"/> struct.
        /// </summary>
        /// <param name="row0">Top row of the matrix.</param>
        /// <param name="row1">Second row of the matrix.</param>
        /// <param name="row2">Bottom row of the matrix.</param>
        public Matrix3D(Vector3D row0, Vector3D row1, Vector3D row2)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3D"/> struct.
        /// </summary>
        /// <param name="m00">First item of the first row of the matrix.</param>
        /// <param name="m01">Second item of the first row of the matrix.</param>
        /// <param name="m02">Third item of the first row of the matrix.</param>
        /// <param name="m10">First item of the second row of the matrix.</param>
        /// <param name="m11">Second item of the second row of the matrix.</param>
        /// <param name="m12">Third item of the second row of the matrix.</param>
        /// <param name="m20">First item of the third row of the matrix.</param>
        /// <param name="m21">Second item of the third row of the matrix.</param>
        /// <param name="m22">Third item of the third row of the matrix.</param>
        public Matrix3D
        (
            double m00, double m01, double m02,
            double m10, double m11, double m12,
            double m20, double m21, double m22
        )
        {
            Row0 = new Vector3D(m00, m01, m02);
            Row1 = new Vector3D(m10, m11, m12);
            Row2 = new Vector3D(m20, m21, m22);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3D"/> struct.
        /// </summary>
        /// <param name="matrix">A Matrix4d to take the upper-left 3x3 from.</param>
        public Matrix3D(Matrix4D matrix)
        {
            Row0 = matrix.Row0.Xyz;
            Row1 = matrix.Row1.Xyz;
            Row2 = matrix.Row2.Xyz;
        }

        /// <summary>
        /// Gets the determinant of this matrix.
        /// </summary>
        public readonly double Determinant
        {
            get
            {
                var m11 = Row0.X;
                var m12 = Row0.Y;
                var m13 = Row0.Z;
                var m21 = Row1.X;
                var m22 = Row1.Y;
                var m23 = Row1.Z;
                var m31 = Row2.X;
                var m32 = Row2.Y;
                var m33 = Row2.Z;

                return
                    (m11 * m22 * m33) + (m12 * m23 * m31) + (m13 * m21 * m32)
                    - (m13 * m22 * m31) - (m11 * m23 * m32) - (m12 * m21 * m33);
            }
        }

        /// <summary>
        /// Gets the first column of this matrix.
        /// </summary>
        public readonly Vector3D Column0 => new(Row0.X, Row1.X, Row2.X);

        /// <summary>
        /// Gets the second column of this matrix.
        /// </summary>
        public readonly Vector3D Column1 => new(Row0.Y, Row1.Y, Row2.Y);

        /// <summary>
        /// Gets the third column of this matrix.
        /// </summary>
        public readonly Vector3D Column2 => new(Row0.Z, Row1.Z, Row2.Z);

        /// <summary>
        /// Gets or sets the value at row 1, column 1 of this instance.
        /// </summary>
        public double M11
        {
            readonly get => Row0.X;
            set => Row0.X = value;
        }

        /// <summary>
        /// Gets or sets the value at row 1, column 2 of this instance.
        /// </summary>
        public double M12
        {
            readonly get => Row0.Y;
            set => Row0.Y = value;
        }

        /// <summary>
        /// Gets or sets the value at row 1, column 3 of this instance.
        /// </summary>
        public double M13
        {
            readonly get => Row0.Z;
            set => Row0.Z = value;
        }

        /// <summary>
        /// Gets or sets the value at row 2, column 1 of this instance.
        /// </summary>
        public double M21
        {
            readonly get => Row1.X;
            set => Row1.X = value;
        }

        /// <summary>
        /// Gets or sets the value at row 2, column 2 of this instance.
        /// </summary>
        public double M22
        {
            readonly get => Row1.Y;
            set => Row1.Y = value;
        }

        /// <summary>
        /// Gets or sets the value at row 2, column 3 of this instance.
        /// </summary>
        public double M23
        {
            readonly get => Row1.Z;
            set => Row1.Z = value;
        }

        /// <summary>
        /// Gets or sets the value at row 3, column 1 of this instance.
        /// </summary>
        public double M31
        {
            readonly get => Row2.X;
            set => Row2.X = value;
        }

        /// <summary>
        /// Gets or sets the value at row 3, column 2 of this instance.
        /// </summary>
        public double M32
        {
            readonly get => Row2.Y;
            set => Row2.Y = value;
        }

        /// <summary>
        /// Gets or sets the value at row 3, column 3 of this instance.
        /// </summary>
        public double M33
        {
            readonly get => Row2.Z;
            set => Row2.Z = value;
        }

        /// <summary>
        /// Gets or sets the values along the main diagonal of the matrix.
        /// </summary>
        public Vector3D Diagonal
        {
            readonly get => new(Row0.X, Row1.Y, Row2.Z);
            set
            {
                Row0.X = value.X;
                Row1.Y = value.Y;
                Row2.Z = value.Z;
            }
        }

        /// <summary>
        /// Gets the trace of the matrix, the sum of the values along the diagonal.
        /// </summary>
        public readonly double Trace => Row0.X + Row1.Y + Row2.Z;

        /// <summary>
        /// Gets or sets the value at a specified row and column.
        /// </summary>
        /// <param name="rowIndex">The index of the row.</param>
        /// <param name="columnIndex">The index of the column.</param>
        public double this[int rowIndex, int columnIndex]
        {
            readonly get
            {
                if (rowIndex == 0)
                {
                    return Row0[columnIndex];
                }

                var tmp = rowIndex == 1
                    ? Row1[columnIndex]
                    : rowIndex;
                return tmp == 2
                    ? Row2[columnIndex]
                    : throw new IndexOutOfRangeException("You tried to access this matrix at: (" + rowIndex + ", " +
                                                   columnIndex + ")");
            }

            set
            {
                if (rowIndex == 0)
                {
                    Row0[columnIndex] = value;
                }
                else if (rowIndex == 1)
                {
                    Row1[columnIndex] = value;
                }
                else
                {
                    Row2[columnIndex] = rowIndex == 2
                        ? value
                        : throw new IndexOutOfRangeException("You tried to set this matrix at: (" + rowIndex + ", " +
                                                                           columnIndex + ")");
                }
            }
        }

        /// <summary>
        /// Converts this instance into its inverse.
        /// </summary>
        public void Invert()
        {
            this = Invert(this);
        }

        /// <summary>
        /// Converts this instance into its transpose.
        /// </summary>
        public void Transpose()
        {
            this = Transpose(this);
        }

        /// <summary>
        /// Returns a normalized copy of this instance.
        /// </summary>
        /// <returns>The normalized copy.</returns>
        public readonly Matrix3D Normalized()
        {
            var m = this;
            m.Normalize();
            return m;
        }

        /// <summary>
        /// Divides each element in the Matrix by the <see cref="Determinant"/>.
        /// </summary>
        public void Normalize()
        {
            var determinant = Determinant;
            Row0 /= determinant;
            Row1 /= determinant;
            Row2 /= determinant;
        }

        /// <summary>
        /// Returns an inverted copy of this instance.
        /// </summary>
        /// <returns>The inverted copy.</returns>
        public readonly Matrix3D Inverted()
        {
            var m = this;
            if (m.Determinant != 0)
            {
                m.Invert();
            }

            return m;
        }

        /// <summary>
        /// Returns a copy of this Matrix3 without scale.
        /// </summary>
        /// <returns>The matrix without scaling.</returns>
        public readonly Matrix3D ClearScale()
        {
            var m = this;
            m.Row0 = m.Row0.Normalized();
            m.Row1 = m.Row1.Normalized();
            m.Row2 = m.Row2.Normalized();
            return m;
        }

        /// <summary>
        /// Returns a copy of this Matrix3 without rotation.
        /// </summary>
        /// <returns>The matrix without rotation.</returns>
        public readonly Matrix3D ClearRotation()
        {
            var m = this;
            m.Row0 = new Vector3D(m.Row0.Length, 0, 0);
            m.Row1 = new Vector3D(0, m.Row1.Length, 0);
            m.Row2 = new Vector3D(0, 0, m.Row2.Length);
            return m;
        }

        /// <summary>
        /// Returns the scale component of this instance.
        /// </summary>
        /// <returns>The scale components.</returns>
        public readonly Vector3D ExtractScale()
        {
            return new(Row0.Length, Row1.Length, Row2.Length);
        }

        /// <summary>
        /// Returns the rotation component of this instance. Quite slow.
        /// </summary>
        /// <param name="rowNormalize">
        /// Whether the method should row-normalize (i.e. remove scale from) the Matrix. Pass false if
        /// you know it's already normalized.
        /// </param>
        /// <returns>The rotation.</returns>
        [Pure]
        public readonly QuaternionD ExtractRotation(bool rowNormalize = true)
        {
            var row0 = Row0;
            var row1 = Row1;
            var row2 = Row2;

            if (rowNormalize)
            {
                row0 = row0.Normalized();
                row1 = row1.Normalized();
                row2 = row2.Normalized();
            }

            // code below adapted from Blender
            QuaternionD q = default;
            var trace = 0.25 * (row0[0] + row1[1] + row2[2] + 1.0);

            if (trace > 0)
            {
                var sq = Math.Sqrt(trace);

                q.W = sq;
                sq = 1.0 / (4.0 * sq);
                q.X = (row1[2] - row2[1]) * sq;
                q.Y = (row2[0] - row0[2]) * sq;
                q.Z = (row0[1] - row1[0]) * sq;
            }
            else if (row0[0] > row1[1] && row0[0] > row2[2])
            {
                var sq = 2.0 * Math.Sqrt(1.0 + row0[0] - row1[1] - row2[2]);

                q.X = 0.25 * sq;
                sq = 1.0 / sq;
                q.W = (row2[1] - row1[2]) * sq;
                q.Y = (row1[0] + row0[1]) * sq;
                q.Z = (row2[0] + row0[2]) * sq;
            }
            else if (row1[1] > row2[2])
            {
                var sq = 2.0 * Math.Sqrt(1.0 + row1[1] - row0[0] - row2[2]);

                q.Y = 0.25 * sq;
                sq = 1.0 / sq;
                q.W = (row2[0] - row0[2]) * sq;
                q.X = (row1[0] + row0[1]) * sq;
                q.Z = (row2[1] + row1[2]) * sq;
            }
            else
            {
                var sq = 2.0 * Math.Sqrt(1.0 + row2[2] - row0[0] - row1[1]);

                q.Z = 0.25 * sq;
                sq = 1.0 / sq;
                q.W = (row1[0] - row0[1]) * sq;
                q.X = (row2[0] + row0[2]) * sq;
                q.Y = (row2[1] + row1[2]) * sq;
            }

            q.Normalize();
            return q;
        }

        /// <summary>
        /// Build a rotation matrix from the specified axis/angle rotation.
        /// </summary>
        /// <param name="axis">The axis to rotate about.</param>
        /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
        /// <param name="result">A matrix instance.</param>
        public static void CreateFromAxisAngle(Vector3D axis, double angle, out Matrix3D result)
        {
            // normalize and create a local copy of the vector.
            axis.Normalize();
            double axisX = axis.X, axisY = axis.Y, axisZ = axis.Z;

            // calculate angles
            var cos = Math.Cos(-angle);
            var sin = Math.Sin(-angle);
            var t = 1.0f - cos;

            // do the conversion math once
            var tXX = t * axisX * axisX;
            var tXY = t * axisX * axisY;
            var tXZ = t * axisX * axisZ;
            var tYY = t * axisY * axisY;
            var tYZ = t * axisY * axisZ;
            var tZZ = t * axisZ * axisZ;

            var sinX = sin * axisX;
            var sinY = sin * axisY;
            var sinZ = sin * axisZ;

            result.Row0.X = tXX + cos;
            result.Row0.Y = tXY - sinZ;
            result.Row0.Z = tXZ + sinY;
            result.Row1.X = tXY + sinZ;
            result.Row1.Y = tYY + cos;
            result.Row1.Z = tYZ - sinX;
            result.Row2.X = tXZ - sinY;
            result.Row2.Y = tYZ + sinX;
            result.Row2.Z = tZZ + cos;
        }

        /// <summary>
        /// Build a rotation matrix from the specified axis/angle rotation.
        /// </summary>
        /// <param name="axis">The axis to rotate about.</param>
        /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
        /// <returns>A matrix instance.</returns>
        [Pure]
        public static Matrix3D CreateFromAxisAngle(Vector3D axis, double angle)
        {
            CreateFromAxisAngle(axis, angle, out var result);
            return result;
        }

        /// <summary>
        /// Build a rotation matrix from the specified quaternion.
        /// </summary>
        /// <param name="q">Quaternion to translate.</param>
        /// <param name="result">Matrix result.</param>
        public static void CreateFromQuaternion(in QuaternionD q, out Matrix3D result)
        {
            // Adapted from https://en.wikipedia.org/wiki/Quaternions_and_spatial_rotation#Quaternion-derived_rotation_matrix
            // with the caviat that SatisfactorySaveNet uses row-major matrices so the matrix we create is transposed
            var sqx = q.X * q.X;
            var sqy = q.Y * q.Y;
            var sqz = q.Z * q.Z;
            var sqw = q.W * q.W;

            var xy = q.X * q.Y;
            var xz = q.X * q.Z;
            var xw = q.X * q.W;

            var yz = q.Y * q.Z;
            var yw = q.Y * q.W;

            var zw = q.Z * q.W;

            var s2 = 2d / (sqx + sqy + sqz + sqw);

            result.Row0.X = 1d - (s2 * (sqy + sqz));
            result.Row1.Y = 1d - (s2 * (sqx + sqz));
            result.Row2.Z = 1d - (s2 * (sqx + sqy));

            result.Row0.Y = s2 * (xy + zw);
            result.Row1.X = s2 * (xy - zw);

            result.Row2.X = s2 * (xz + yw);
            result.Row0.Z = s2 * (xz - yw);

            result.Row2.Y = s2 * (yz - xw);
            result.Row1.Z = s2 * (yz + xw);
        }

        /// <summary>
        /// Build a rotation matrix from the specified quaternion.
        /// </summary>
        /// <param name="q">Quaternion to translate.</param>
        /// <returns>A matrix instance.</returns>
        [Pure]
        public static Matrix3D CreateFromQuaternion(QuaternionD q)
        {
            CreateFromQuaternion(in q, out var result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the x-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix3d instance.</param>
        public static void CreateRotationX(double angle, out Matrix3D result)
        {
            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            result = Identity;
            result.Row1.Y = cos;
            result.Row1.Z = sin;
            result.Row2.Y = -sin;
            result.Row2.Z = cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the x-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix3d instance.</returns>
        [Pure]
        public static Matrix3D CreateRotationX(double angle)
        {
            CreateRotationX(angle, out var result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the y-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix3d instance.</param>
        public static void CreateRotationY(double angle, out Matrix3D result)
        {
            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            result = Identity;
            result.Row0.X = cos;
            result.Row0.Z = -sin;
            result.Row2.X = sin;
            result.Row2.Z = cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the y-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix3d instance.</returns>
        [Pure]
        public static Matrix3D CreateRotationY(double angle)
        {
            CreateRotationY(angle, out var result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the z-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix3d instance.</param>
        public static void CreateRotationZ(double angle, out Matrix3D result)
        {
            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            result = Identity;
            result.Row0.X = cos;
            result.Row0.Y = sin;
            result.Row1.X = -sin;
            result.Row1.Y = cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the z-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix3d instance.</returns>
        [Pure]
        public static Matrix3D CreateRotationZ(double angle)
        {
            CreateRotationZ(angle, out var result);
            return result;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="scale">Single scale factor for the x, y, and z axes.</param>
        /// <returns>A scale matrix.</returns>
        [Pure]
        public static Matrix3D CreateScale(double scale)
        {
            CreateScale(scale, out var result);
            return result;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="scale">Scale factors for the x, y, and z axes.</param>
        /// <returns>A scale matrix.</returns>
        [Pure]
        public static Matrix3D CreateScale(Vector3D scale)
        {
            CreateScale(in scale, out var result);
            return result;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="x">Scale factor for the x axis.</param>
        /// <param name="y">Scale factor for the y axis.</param>
        /// <param name="z">Scale factor for the z axis.</param>
        /// <returns>A scale matrix.</returns>
        [Pure]
        public static Matrix3D CreateScale(double x, double y, double z)
        {
            CreateScale(x, y, z, out var result);
            return result;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="scale">Single scale factor for the x, y, and z axes.</param>
        /// <param name="result">A scale matrix.</param>
        public static void CreateScale(double scale, out Matrix3D result)
        {
            result = Identity;
            result.Row0.X = scale;
            result.Row1.Y = scale;
            result.Row2.Z = scale;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="scale">Scale factors for the x, y, and z axes.</param>
        /// <param name="result">A scale matrix.</param>
        public static void CreateScale(in Vector3D scale, out Matrix3D result)
        {
            result = Identity;
            result.Row0.X = scale.X;
            result.Row1.Y = scale.Y;
            result.Row2.Z = scale.Z;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="x">Scale factor for the x axis.</param>
        /// <param name="y">Scale factor for the y axis.</param>
        /// <param name="z">Scale factor for the z axis.</param>
        /// <param name="result">A scale matrix.</param>
        public static void CreateScale(double x, double y, double z, out Matrix3D result)
        {
            result = Identity;
            result.Row0.X = x;
            result.Row1.Y = y;
            result.Row2.Z = z;
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The left operand of the addition.</param>
        /// <param name="right">The right operand of the addition.</param>
        /// <returns>A new instance that is the result of the addition.</returns>
        [Pure]
        public static Matrix3D Add(Matrix3D left, Matrix3D right)
        {
            Add(in left, in right, out var result);
            return result;
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The left operand of the addition.</param>
        /// <param name="right">The right operand of the addition.</param>
        /// <param name="result">A new instance that is the result of the addition.</param>
        public static void Add(in Matrix3D left, in Matrix3D right, out Matrix3D result)
        {
            Vector3D.Add(in left.Row0, in right.Row0, out result.Row0);
            Vector3D.Add(in left.Row1, in right.Row1, out result.Row1);
            Vector3D.Add(in left.Row2, in right.Row2, out result.Row2);
        }

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The left operand of the multiplication.</param>
        /// <param name="right">The right operand of the multiplication.</param>
        /// <returns>A new instance that is the result of the multiplication.</returns>
        [Pure]
        public static Matrix3D Mult(Matrix3D left, Matrix3D right)
        {
            Mult(in left, in right, out var result);
            return result;
        }

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The left operand of the multiplication.</param>
        /// <param name="right">The right operand of the multiplication.</param>
        /// <param name="result">A new instance that is the result of the multiplication.</param>
        public static void Mult(in Matrix3D left, in Matrix3D right, out Matrix3D result)
        {
            var leftM11 = left.Row0.X;
            var leftM12 = left.Row0.Y;
            var leftM13 = left.Row0.Z;
            var leftM21 = left.Row1.X;
            var leftM22 = left.Row1.Y;
            var leftM23 = left.Row1.Z;
            var leftM31 = left.Row2.X;
            var leftM32 = left.Row2.Y;
            var leftM33 = left.Row2.Z;
            var rightM11 = right.Row0.X;
            var rightM12 = right.Row0.Y;
            var rightM13 = right.Row0.Z;
            var rightM21 = right.Row1.X;
            var rightM22 = right.Row1.Y;
            var rightM23 = right.Row1.Z;
            var rightM31 = right.Row2.X;
            var rightM32 = right.Row2.Y;
            var rightM33 = right.Row2.Z;

            result.Row0.X = (leftM11 * rightM11) + (leftM12 * rightM21) + (leftM13 * rightM31);
            result.Row0.Y = (leftM11 * rightM12) + (leftM12 * rightM22) + (leftM13 * rightM32);
            result.Row0.Z = (leftM11 * rightM13) + (leftM12 * rightM23) + (leftM13 * rightM33);
            result.Row1.X = (leftM21 * rightM11) + (leftM22 * rightM21) + (leftM23 * rightM31);
            result.Row1.Y = (leftM21 * rightM12) + (leftM22 * rightM22) + (leftM23 * rightM32);
            result.Row1.Z = (leftM21 * rightM13) + (leftM22 * rightM23) + (leftM23 * rightM33);
            result.Row2.X = (leftM31 * rightM11) + (leftM32 * rightM21) + (leftM33 * rightM31);
            result.Row2.Y = (leftM31 * rightM12) + (leftM32 * rightM22) + (leftM33 * rightM32);
            result.Row2.Z = (leftM31 * rightM13) + (leftM32 * rightM23) + (leftM33 * rightM33);
        }

        /// <summary>
        /// Calculate the inverse of the given matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <param name="result">The inverse of the given matrix if it has one, or the input if it is singular.</param>
        /// <exception cref="InvalidOperationException">Thrown if the Matrix3d is singular.</exception>
        public static void Invert(in Matrix3D matrix, out Matrix3D result)
        {
            // Original implementation can be found here:
            // https://github.com/niswegmann/small-matrix-inverse/blob/6eac02b84ad06870692abaf828638a391548502c/invert3x3_c.h
            double row0X = matrix.Row0.X, row0Y = matrix.Row0.Y, row0Z = matrix.Row0.Z;
            double row1X = matrix.Row1.X, row1Y = matrix.Row1.Y, row1Z = matrix.Row1.Z;
            double row2X = matrix.Row2.X, row2Y = matrix.Row2.Y, row2Z = matrix.Row2.Z;

            // Compute the elements needed to calculate the determinant
            // so that we can throw without writing anything to the out parameter.
            var invRow0X = (+row1Y * row2Z) - (row1Z * row2Y);
            var invRow1X = (-row1X * row2Z) + (row1Z * row2X);
            var invRow2X = (+row1X * row2Y) - (row1Y * row2X);

            // Compute determinant:
            var det = (row0X * invRow0X) + (row0Y * invRow1X) + (row0Z * invRow2X);

            if (det == 0f)
            {
                throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
            }

            // Compute adjoint:
            result.Row0.X = invRow0X;
            result.Row0.Y = (-row0Y * row2Z) + (row0Z * row2Y);
            result.Row0.Z = (+row0Y * row1Z) - (row0Z * row1Y);
            result.Row1.X = invRow1X;
            result.Row1.Y = (+row0X * row2Z) - (row0Z * row2X);
            result.Row1.Z = (-row0X * row1Z) + (row0Z * row1X);
            result.Row2.X = invRow2X;
            result.Row2.Y = (-row0X * row2Y) + (row0Y * row2X);
            result.Row2.Z = (+row0X * row1Y) - (row0Y * row1X);

            // Multiply adjoint with reciprocal of determinant:
            det = 1.0f / det;

            result.Row0.X *= det;
            result.Row0.Y *= det;
            result.Row0.Z *= det;
            result.Row1.X *= det;
            result.Row1.Y *= det;
            result.Row1.Z *= det;
            result.Row2.X *= det;
            result.Row2.Y *= det;
            result.Row2.Z *= det;
        }

        /// <summary>
        /// Calculate the inverse of the given matrix.
        /// </summary>
        /// <param name="mat">The matrix to invert.</param>
        /// <returns>The inverse of the given matrix.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
        [Pure]
        public static Matrix3D Invert(Matrix3D mat)
        {
            Invert(in mat, out var result);
            return result;
        }

        /// <summary>
        /// Calculate the transpose of the given matrix.
        /// </summary>
        /// <param name="mat">The matrix to transpose.</param>
        /// <returns>The transpose of the given matrix.</returns>
        [Pure]
        public static Matrix3D Transpose(Matrix3D mat)
        {
            return new(mat.Column0, mat.Column1, mat.Column2);
        }

        /// <summary>
        /// Calculate the transpose of the given matrix.
        /// </summary>
        /// <param name="mat">The matrix to transpose.</param>
        /// <param name="result">The result of the calculation.</param>
        public static void Transpose(in Matrix3D mat, out Matrix3D result)
        {
            result.Row0 = mat.Column0;
            result.Row1 = mat.Column1;
            result.Row2 = mat.Column2;
        }

        /// <summary>
        /// Matrix multiplication.
        /// </summary>
        /// <param name="left">left-hand operand.</param>
        /// <param name="right">right-hand operand.</param>
        /// <returns>A new Matrix3d which holds the result of the multiplication.</returns>
        [Pure]
        public static Matrix3D operator *(Matrix3D left, Matrix3D right)
        {
            return Mult(left, right);
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        [Pure]
        public static bool operator ==(Matrix3D left, Matrix3D right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equal right; false otherwise.</returns>
        [Pure]
        public static bool operator !=(Matrix3D left, Matrix3D right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a System.String that represents the current Matrix3d.
        /// </summary>
        /// <returns>The string representation of the matrix.</returns>
        public readonly override string ToString()
        {
            return ToString(null, null);
        }

        /// <inheritdoc cref="ToString(string, IFormatProvider)"/>
        public readonly string ToString(string format)
        {
            return ToString(format, null);
        }

        /// <inheritdoc cref="ToString(string, IFormatProvider)"/>
        public readonly string ToString(IFormatProvider formatProvider)
        {
            return ToString(null, formatProvider);
        }

        /// <inheritdoc/>
        public readonly string ToString(string? format, IFormatProvider? formatProvider)
        {
            var row0 = Row0.ToString(format, formatProvider);
            var row1 = Row1.ToString(format, formatProvider);
            var row2 = Row2.ToString(format, formatProvider);
            return $"{row0}\n{row1}\n{row2}";
        }

        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
        public readonly override int GetHashCode()
        {
            return HashCode.Combine(Row0, Row1, Row2);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        [Pure]
        public readonly override bool Equals(object? obj)
        {
            return obj is Matrix3D matrix && Equals(matrix);
        }

        /// <summary>
        /// Indicates whether the current matrix is equal to another matrix.
        /// </summary>
        /// <param name="other">A matrix to compare with this matrix.</param>
        /// <returns>true if the current matrix is equal to the matrix parameter; otherwise, false.</returns>
        [Pure]
        public readonly bool Equals(Matrix3D other)
        {
            return Row0 == other.Row0 &&
                Row1 == other.Row1 &&
                Row2 == other.Row2;
        }
    }
}
