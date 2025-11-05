using System;
using Graph3D.Vrml.Fields;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    public static partial class AssertExt {

        public static void AreEqual(Field expected, Field actual, string? path = null) {
            path ??= "$";
            if (expected is SFInt32 expectedSFInt32 && actual is SFInt32 actualSfInt32) {
                AreEqual(expectedSFInt32, actualSfInt32, path);
            } else if (expected is SFColor expectedSFColor && actual is SFColor actualSFColor) {
                AreEqual(expectedSFColor, actualSFColor, path);
            } else {
                throw new Exception($"Do not know how to compare {expected.GetType().Name} and {actual.GetType().Name}");
            }
        }

        public static void AreEqual(SFInt32 expected, SFInt32 actual, string? path = null) {
            path ??= "$";
            Assert.That(actual.Value, Is.EqualTo(expected.Value), $"{path}.Value");
        }

        public static void AreEqual(SFColor expected, SFColor actual, string path) {
            Assert.That(actual.Red, Is.EqualTo(expected.Red), $"{path}.Red");
            Assert.That(actual.Green, Is.EqualTo(expected.Green), $"{path}.Green");
            Assert.That(actual.Blue, Is.EqualTo(expected.Blue), $"{path}.Blue");
        }
    }
}