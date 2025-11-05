using System;
using Graph3D.Vrml.Fields;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    public static partial class AssertExt {

        public static void AreEqual(Field expected, Field actual, string? path = null) {
            path ??= "$";
            if (expected is SFBool expectedSFBool && actual is SFBool actualSFBool) {
                AreEqual(expectedSFBool, actualSFBool, path);
            } else if (expected is SFInt32 expectedSFInt32 && actual is SFInt32 actualSfInt32) {
                AreEqual(expectedSFInt32, actualSfInt32, path);
            } else if (expected is SFFloat expectedSFFloat && actual is SFFloat actualSFFloat) {
                AreEqual(expectedSFFloat, actualSFFloat, path);
            } else if (expected is SFColor expectedSFColor && actual is SFColor actualSFColor) {
                AreEqual(expectedSFColor, actualSFColor, path);
            } else if (expected is SFVec3f expectedSFVec3f && actual is SFVec3f actualSFVec3f) {
                AreEqual(expectedSFVec3f, actualSFVec3f, path);
            } else {
                throw new Exception($"Do not know how to compare {expected.GetType().Name} and {actual.GetType().Name}");
            }
        }

        public static void AreEqual(SFBool expected, SFBool actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Value, Is.EqualTo(expected.Value), $"{path}.Value");
        }

        public static void AreEqual(SFInt32 expected, SFInt32 actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Value, Is.EqualTo(expected.Value), $"{path}.Value");
        }

        public static void AreEqual(SFFloat expected, SFFloat actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Value, Is.EqualTo(expected.Value), $"{path}.Value");
        }

        public static void AreEqual(SFColor expected, SFColor actual, string path) {
            Assert.That(actual.Red, Is.EqualTo(expected.Red), $"{path}.Red");
            Assert.That(actual.Green, Is.EqualTo(expected.Green), $"{path}.Green");
            Assert.That(actual.Blue, Is.EqualTo(expected.Blue), $"{path}.Blue");
        }

        public static void AreEqual(SFVec3f expected, SFVec3f actual, string path) {
            Assert.That(actual.X, Is.EqualTo(expected.X), $"{path}.X");
            Assert.That(actual.Y, Is.EqualTo(expected.Y), $"{path}.Y");
            Assert.That(actual.Z, Is.EqualTo(expected.Z), $"{path}.Z");
        }
    }
}