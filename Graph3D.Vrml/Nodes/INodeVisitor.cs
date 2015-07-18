using Graph3D.Vrml.Nodes.Appearance;
using Graph3D.Vrml.Nodes.Appearance.Texture;
using Graph3D.Vrml.Nodes.Bindable;
using Graph3D.Vrml.Nodes.Geometry;
using Graph3D.Vrml.Nodes.Grouping;
using Graph3D.Vrml.Nodes.Interpolation;
using Graph3D.Vrml.Nodes.LightSources;
using Graph3D.Vrml.Nodes.Sensors;

namespace Graph3D.Vrml.Nodes {
    public interface INodeVisitor {

        void Visit(AnchorNode node);

        void Visit(AppearanceNode node);

        void Visit(BackgroundNode node);

        void Visit(BoxNode node);

        void Visit(ColorNode node);

        void Visit(CoordinateInterpolatorNode node);

        void Visit(CoordinateNode node);

        void Visit(CylinderNode node);

        void Visit(ProtoNode node);

        void Visit(DirectionalLightNode node);

        void Visit(ExtrusionNode node);

        void Visit(GroupNode node);

        void Visit(IndexedFaceSetNode node);

        void Visit(MaterialNode node);

        void Visit(NavigationInfoNode node);

        void Visit(NormalNode node);

        void Visit(OrientationInterpolatorNode node);

        void Visit(PixelTextureNode node);

        void Visit(PointLightNode node);

        void Visit(PositionInterpolatorNode node);

        void Visit(ScalarInterpolationNode node);

        void Visit(SceneGraphNode node);

        void Visit(ScriptNode node);

        void Visit(ShapeNode node);

        void Visit(SphereNode node);

        void Visit(TextureCoordinateNode node);

        void Visit(TimeSensorNode node);

        void Visit(TransformNode node);

        void Visit(ViewpointNode node);

    }
}
