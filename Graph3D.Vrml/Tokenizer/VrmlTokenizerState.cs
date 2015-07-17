namespace Graph3D.Vrml.Tokenizer
{
    public abstract class VrmlTokenizerState
    {

        protected readonly Vrml97Tokenizer tokenizer;
        protected readonly TokenizerContext context;

        protected VrmlTokenizerState(TokenizerContext context)
        {
            this.context = context;
            this.tokenizer = context.Tokenizer;
        }

        public abstract VrmlTokenizerState Tick();

    }
}
