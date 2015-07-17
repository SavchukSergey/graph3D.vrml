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

        void visit(AnchorNode node);

        void visit(AppearanceNode node);

        void visit(BackgroundNode node);

        void visit(BoxNode node);

        void visit(ColorNode node);

        void visit(CoordinateInterpolatorNode node);

        void visit(CoordinateNode node);

        void visit(CylinderNode node);

        void visit(CustomNode node);

        void visit(DirectionalLightNode node);

        void visit(ExtrusionNode node);

        void visit(GroupNode node);

        void visit(IndexedFaceSetNode node);

        void visit(MaterialNode node);

        void visit(NavigationInfoNode node);

        void visit(NormalNode node);

        void visit(OrientationInterpolatorNode node);

        void visit(PixelTextureNode node);

        void visit(PointLightNode node);

        void visit(PositionInterpolatorNode node);

        void visit(ScalarInterpolationNode node);

        void visit(SceneGraphNode node);

        void visit(ScriptNode node);

        void visit(ShapeNode node);

        void visit(SphereNode node);

        void visit(TextureCoordinateNode node);

        void visit(TimeSensorNode node);

        void visit(TransformNode node);

        void visit(ViewpointNode node);

    }
}
