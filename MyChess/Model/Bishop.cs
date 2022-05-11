namespace MyChess.Model
{
    public class Bishop : ChessPiece
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}