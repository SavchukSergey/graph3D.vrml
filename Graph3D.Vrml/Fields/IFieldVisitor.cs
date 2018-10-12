namespace Graph3D.Vrml.Fields {
    public interface IFieldVisitor {

        void Visit(SFBool field);

        void Visit(SFImage field);


        void Visit(SFFloat field);

        void Visit(MFFloat field);


        void Visit(SFString field);

        void Visit(MFString field);
        
        
        void Visit(SFInt32 field);

        void Visit(MFInt32 field);


        void Visit(SFVec2f field);

        void Visit(MFVec2f field);
        
        
        void Visit(SFVec3f field);

        void Visit(MFVec3f field);

        
        void Visit(SFColor field);

        void Visit(MFColor field);


        void Visit(SFNode field);

        void Visit(MFNode field);


        void Visit(SFRotation field);

        void Visit(MFRotation field);

        void Visit(SFTime field);

    }
}
