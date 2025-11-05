using System;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Appearance;
using Graph3D.Vrml.Nodes.Appearance.Texture;
using Graph3D.Vrml.Nodes.Geometry;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    public static partial class AssertExt {

        public static void AreEqual(BaseNode? expected, BaseNode? actual, string? path = null) {
            path ??= "$";
            if (actual != null && expected != null) {
                if (expected is AppearanceNode expectedAppearanceNode && actual is AppearanceNode actualAppearanceNode) {
                    AreEqual(expectedAppearanceNode, actualAppearanceNode, path);
                } else if (expected is BoxNode expectedBoxNode && actual is BoxNode actualBoxNode) {
                    AreEqual(expectedBoxNode, actualBoxNode, path);
                } else if (expected is CylinderNode expectedCylinderNode && actual is CylinderNode actualCylinderNode) {
                    AreEqual(expectedCylinderNode, actualCylinderNode, path);
                } else if (expected is MaterialNode expectedMaterialNode && actual is MaterialNode actualMaterialNode) {
                    AreEqual(expectedMaterialNode, actualMaterialNode, path);
                } else if (expected is ShapeNode expectedShapeNode && actual is ShapeNode actualShapeMode) {
                    AreEqual(expectedShapeNode, actualShapeMode, path);
                } else if (expected is TextureNode expectedTextureNode && actual is TextureNode actualTextureNode) {
                    AreEqual(expectedTextureNode, actualTextureNode, path);
                } else if (expected is TextureTransformNode expectedTextureTransformNode && actual is TextureTransformNode actualTextureTransformNode) {
                    AreEqual(expectedTextureTransformNode, actualTextureTransformNode, path);
                } else {
                    throw new Exception($"Do not know how to compare {expected.GetType().Name} and {actual.GetType().Name}");
                }
            } else {
                Assert.That(expected == null, Is.EqualTo(actual == null));
            }
        }

        public static void AreEqual(AppearanceNode? expected, AppearanceNode? actual, string? path = null) {
            path ??= "$";
            if (actual != null && expected != null) {
                AreEqual(expected.Material, actual.Material, $"{path}.Material");
                AreEqual(expected.Texture, actual.Texture, $"{path}.Texture");
                AreEqual(expected.TextureTransform, actual.TextureTransform, $"{path}.TextureTransform");
            } else {
                Assert.That(expected == null, Is.EqualTo(actual == null));
            }
        }

        public static void AreEqual(BoxNode? expected, BoxNode? actual, string? path = null) {
            path ??= "$";
            if (actual != null && expected != null) {
                AreEqual(expected.Size, actual.Size, $"{path}.Size");
            } else {
                Assert.That(expected == null, Is.EqualTo(actual == null));
            }
        }

        public static void AreEqual(CylinderNode? expected, CylinderNode? actual, string? path = null) {
            path ??= "$";
            if (actual != null && expected != null) {
                AreEqual(expected.Bottom, actual.Bottom, $"{path}.Bottom");
                AreEqual(expected.Height, actual.Height, $"{path}.Height");
                AreEqual(expected.Radius, actual.Radius, $"{path}.Radius");
                AreEqual(expected.Side, actual.Side, $"{path}.Side");
                AreEqual(expected.Top, actual.Top, $"{path}.Top");
            } else {
                Assert.That(expected == null, Is.EqualTo(actual == null));
            }
        }

        public static void AreEqual(MaterialNode? expected, MaterialNode? actual, string? path) {
            path ??= "$";
            if (actual != null && expected != null) {
                AreEqual(expected.AmbientIntensity, actual.AmbientIntensity, $"{path}.AmbientIntensity");
                AreEqual(expected.DiffuseColor, actual.DiffuseColor, $"{path}.DiffuseColor");
                AreEqual(expected.EmissiveColor, actual.EmissiveColor, $"{path}.EmissiveColor");
                AreEqual(expected.Shininess, actual.Shininess, $"{path}.Shininess");
                AreEqual(expected.SpecularColor, actual.SpecularColor, $"{path}.SpecularColor");
                AreEqual(expected.Transparency, actual.Transparency, $"{path}.Transparency");
            } else {
                Assert.That(expected == null, Is.EqualTo(actual == null));
            }
        }

        public static void AreEqual(ShapeNode? expected, ShapeNode? actual, string? path) {
            path ??= "$";
            if (actual != null && expected != null) {
                AreEqual(expected.Appearance, actual.Appearance, $"{path}.Appearance");
                AreEqual(expected.Geometry, actual.Geometry, $"{path}.Geometry");
            } else {
                Assert.That(expected == null, Is.EqualTo(actual == null));
            }
        }

        public static void AreEqual(TextureNode? expected, TextureNode? actual, string? path) {
            Assert.That(actual == null ? "NULL" : "NOT_NULL", Is.EqualTo(expected == null ? "NULL" : "NOT_NULL"), path);
            //todo:
        }

        public static void AreEqual(TextureTransformNode? expected, TextureTransformNode? actual, string? path) {
            Assert.That(actual == null ? "NULL" : "NOT_NULL", Is.EqualTo(expected == null ? "NULL" : "NOT_NULL"), path);
            //todo:
        }

        public static void AreEqual(float expected, float actual, string path) {
            Assert.That(actual, Is.EqualTo(expected), path);
        }

    }
}