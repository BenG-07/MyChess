namespace MyChess.Model
{
    public class King : ChessPiece
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}