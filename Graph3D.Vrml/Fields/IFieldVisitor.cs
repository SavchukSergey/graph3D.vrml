namespace Graph3D.Vrml.Fields {
    public interface IFieldVisitor {

        void visit(SFBool field);

        void visit(SFImage field);


        void visit(SFFloat field);

        void visit(MFFloat field);


        void visit(SFString field);

        void visit(MFString field);
        
        
        void visit(SFInt32 field);

        void visit(MFInt32 field);


        void visit(SFVec2f field);

        void visit(MFVec2f field);
        
        
        void visit(SFVec3f field);

        void visit(MFVec3f field);

        
        void visit(SFColor field);

        void visit(MFColor field);


        void visit(SFNode field);

        void visit(MFNode field);


        void visit(SFRotation field);

        void visit(MFRotation field);

        void visit(SFTime field);

    }
}
