namespace MyChess.Model
{
    public class Queen : ChessPiece
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}