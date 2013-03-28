using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class CyclomaticComplexityCalculator : CodeTraverser
    {
        public int Result { get; private set; }

        public CyclomaticComplexityCalculator()
        {
            Result = 1;
        }

        public override void TraverseChildren(IConditional conditional)
        {
            Result++;
            base.TraverseChildren(conditional);
        }

        public override void TraverseChildren(IConditionalStatement conditionalStatement)
        {
            Result++;
            base.TraverseChildren(conditionalStatement);
        }

        public override void TraverseChildren(IWhileDoStatement whileDoStatement)
        {
            Result++;
            base.TraverseChildren(whileDoStatement);
        }

        public override void TraverseChildren(IForStatement forStatement)
        {
            Result++;
            base.TraverseChildren(forStatement);
        }

        public override void TraverseChildren(IForEachStatement forEachStatement)
        {
            Result++;
            base.TraverseChildren(forEachStatement);
        }

        public override void TraverseChildren(ICatchClause catchClause)
        {
            Result++;
            base.TraverseChildren(catchClause);
        }

        public override void TraverseChildren(ISwitchCase switchCase)
        {
            if (!switchCase.IsDefault)
                Result++;
            base.TraverseChildren(switchCase);
        }
    }
}
