using System.Collections.Generic;
using System.Diagnostics;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Appearance;
using Graph3D.Vrml.Nodes.Appearance.Texture;
using Graph3D.Vrml.Nodes.Bindable;
using Graph3D.Vrml.Nodes.Geometry;
using Graph3D.Vrml.Nodes.Grouping;
using Graph3D.Vrml.Nodes.Interpolation;
using Graph3D.Vrml.Nodes.LightSources;
using Graph3D.Vrml.Nodes.Sensors;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Parser {
    public class NodeFactory {

        [DebuggerStepThrough]
        public NodeFactory() {
            builtin["Anchor"] = new AnchorNode();
            builtin["Appearance"] = new AppearanceNode();
            builtin["Background"] = new BackgroundNode();
            builtin["Box"] = new BoxNode();
            builtin["Color"] = new ColorNode();
            builtin["Cone"] = new ConeNode();
            builtin["Coordinate"] = new CoordinateNode();
            builtin["CoordinateInterpolator"] = new CoordinateInterpolatorNode();
            builtin["Cylinder"] = new CylinderNode();
            builtin["DirectionalLight"] = new DirectionalLightNode();
            builtin["Extrusion"] = new ExtrusionNode();
            builtin["Group"] = new GroupNode();
            builtin["Collision"] = new CollisionNode();
            builtin["Switch"] = new SwitchNode();
            builtin["ImageTexture"] = new ImageTextureNode();
            builtin["IndexedFaceSet"] = new IndexedFaceSetNode();
            builtin["IndexedLineSet"] = new IndexedLineSetNode();
            builtin["Material"] = new MaterialNode();
            builtin["NavigationInfo"] = new NavigationInfoNode();
            builtin["OrientationInterpolator"] = new OrientationInterpolatorNode();
            builtin["Normal"] = new NormalNode();
            builtin["PixelTexture"] = new PixelTextureNode();
            builtin["PointLight"] = new PointLightNode();
            builtin["PositionInterpolator"] = new PositionInterpolatorNode();
            builtin["ScalarInterpolator"] = new ScalarInterpolationNode();
            builtin["Shape"] = new ShapeNode();
            builtin["Sphere"] = new SphereNode();
            builtin["TextureCoordinate"] = new TextureCoordinateNode();
            builtin["TextureTransform"] = new TextureTransformNode();
            builtin["TimeSensor"] = new TimeSensorNode();
            builtin["Transform"] = new TransformNode();
            builtin["Viewpoint"] = new ViewpointNode();
            builtin["WorldInfo"] = new WorldInfoNode();
        }

        private readonly Dictionary<string, BaseNode> builtin = [];
        private readonly Dictionary<string, BaseNode> userdefined = [];

        public virtual BaseNode CreateNode(string nodeTypeName, string? nodeName, TokenizerPosition position) {
            if (builtin.TryGetValue(nodeTypeName, out BaseNode? builtinValue)) {
                var node = builtinValue.Clone();
                node.Name = nodeName;
                return node;
            }
            if (userdefined.TryGetValue(nodeTypeName, out BaseNode? userdefinedValue)) {
                BaseNode node = userdefinedValue.Clone();
                node.Name = nodeName;
                return node;
            }
            throw new InvalidVRMLSyntaxException($"Couldn't create node: {nodeTypeName}", position);
        }

        public void AddPrototype(BaseNode proto) {
            if (proto.Name != null) {
                userdefined[proto.Name] = proto;
            }
        }

    }
}
