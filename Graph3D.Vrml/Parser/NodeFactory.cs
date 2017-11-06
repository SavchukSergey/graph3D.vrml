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
            builtin["TimeSensor"] = new TimeSensorNode();
            builtin["Transform"] = new TransformNode();
            builtin["Viewpoint"] = new ViewpointNode();
            builtin["WorldInfo"] = new WorldInfoNode();
        }

        private readonly Dictionary<string, BaseNode> builtin = new Dictionary<string, BaseNode>();
        private readonly Dictionary<string, BaseNode> userdefined = new Dictionary<string, BaseNode>();

        public virtual BaseNode CreateNode(string nodeTypeName, string nodeName) {
            if (builtin.ContainsKey(nodeTypeName)) {
                var node = builtin[nodeTypeName].clone();
                node.name = nodeName;
                return node;
            }
            if (userdefined.ContainsKey(nodeTypeName)) {
                BaseNode node = userdefined[nodeTypeName].clone();
                node.name = nodeName;
                return node;
            }
            throw new InvalidVRMLSyntaxException("Couldn't create node: " + nodeTypeName);
        }

        public void AddPrototype(BaseNode proto) {
            userdefined[proto.name] = proto;
        }

    }
}
