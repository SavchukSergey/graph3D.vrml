using System;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Appearance;
using Graph3D.Vrml.Nodes.Appearance.Texture;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    public static partial class AssertExt {

        public static void AreEqual(BaseNode expected, BaseNode actual, string? path = null) {
            path ??= "$";
            Assert.That(actual == null ? "NULL" : "NOT_NULL", Is.EqualTo(expected == null ? "NULL" : "NOT_NULL"), path);
            if (expected != null && actual != null) {

                Assert.That(actual.GetType(), Is.EqualTo(expected.GetType()), $"{path}/GetType() must be the same");
                switch (expected) {
                    case AppearanceNode _:
                        AreEqual((AppearanceNode)expected, (AppearanceNode)actual, path);
                        break;
                    case MaterialNode _:
                        AreEqual((MaterialNode)expected, (MaterialNode)actual, path);
                        break;
                    case ShapeNode _:
                        AreEqual((ShapeNode)expected, (ShapeNode)actual, path);
                        break;
                    case TextureNode _:
                        AreEqual((TextureNode)expected, (TextureNode)actual, path);
                        break;
                    case TextureTransformNode _:
                        AreEqual((TextureTransformNode)expected, (TextureTransformNode)actual, path);
                        break;
                    default:
                        throw new NotSupportedException($"AreEqual for type {expected.GetType().Name} is not supported");
                }
            }
        }

        private static void AreEqual(AppearanceNode expected, AppearanceNode actual, string path) {
            Assert.That(actual == null ? "NULL" : "NOT_NULL", Is.EqualTo(expected == null ? "NULL" : "NOT_NULL"), path);
            if (expected != null && actual != null) {
                AreEqual(expected.Material, actual.Material, $"{path}/Material");
                AreEqual(expected.Texture, actual.Texture, $"{path}/Texture");
                AreEqual(expected.TextureTransform, actual.TextureTransform, $"{path}/TextureTransform");
            }
        }

        private static void AreEqual(MaterialNode expected, MaterialNode actual, string path) {
            Assert.That(actual == null ? "NULL" : "NOT_NULL", Is.EqualTo(expected == null ? "NULL" : "NOT_NULL"), path);
            if (expected != null && actual != null) {
                AreEqual(expected.AmbientIntensity, actual.AmbientIntensity, $"{path}/AmbientIntensity");
                AreEqual(expected.DiffuseColor, actual.DiffuseColor, $"{path}/DiffuseColor");
                AreEqual(expected.EmissiveColor, actual.EmissiveColor, $"{path}/EmissiveColor");
                AreEqual(expected.Shininess, actual.Shininess, $"{path}/Shininess");
                AreEqual(expected.SpecularColor, actual.SpecularColor, $"{path}/SpecularColor");
                AreEqual(expected.Transparency, actual.Transparency, $"{path}/Transparency");
            }
        }

        private static void AreEqual(ShapeNode expected, ShapeNode actual, string path) {
            Assert.That(actual == null ? "NULL" : "NOT_NULL", Is.EqualTo(expected == null ? "NULL" : "NOT_NULL"), path);
            if (expected != null && actual != null) {
                AreEqual(expected.Appearance, actual.Appearance, $"{path}/Appearance");
                AreEqual(expected.Geometry, actual.Geometry, $"{path}/Geometry");
            }
        }

        private static void AreEqual(TextureNode expected, TextureNode actual, string path) {
            Assert.That(actual == null ? "NULL" : "NOT_NULL", Is.EqualTo(expected == null ? "NULL" : "NOT_NULL"), path);
            //todo:
        }

        private static void AreEqual(TextureTransformNode expected, TextureTransformNode actual, string path) {
            Assert.That(actual == null ? "NULL" : "NOT_NULL", Is.EqualTo(expected == null ? "NULL" : "NOT_NULL"), path);
            //todo:
        }

        private static void AreEqual(float expected, float actual, string path) {
            Assert.That(actual, Is.EqualTo(expected), path);
        }

    }
}